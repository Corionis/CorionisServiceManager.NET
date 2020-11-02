using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace CorionisServiceManager.NET
{
    public partial class ProgramForm : Form
    {
        private bool AdminChecked = false;
        private bool AsAdmin = false;
        private Config cfg;
        private CsmContext ctxt;
        private Timer monitorUpdateTimer;
        private DataGridViewCellStyle rowStyleRunning;
        private DataGridViewCellStyle rowStyleStopped;
        private DataGridViewCellStyle rowStyleUnknown;
        public Services Services;
        private bool updateTimerStarted = false;
        private bool updateTickActive = false;

        public ProgramForm(Config theCfg, CsmContext theContext)
        {
            this.cfg = theCfg;
            this.ctxt = theContext;

            InitializeComponent();

            IntPtr hwnd = this.Handle; // required for positioning to work
            this.Top = cfg.Top;
            this.Left = cfg.Left;
            this.Width = cfg.Width;
            this.Height = cfg.Height;

            this.Text = cfg.GetProgramTitle();

            // Styles
            rowStyleRunning = new DataGridViewCellStyle();
            rowStyleRunning.BackColor = cfg.ColorFromHex(cfg.RunningBack);
            rowStyleRunning.ForeColor = cfg.ColorFromHex(cfg.RunningFore);

            rowStyleStopped = new DataGridViewCellStyle();
            rowStyleStopped.BackColor = cfg.ColorFromHex(cfg.StoppedBack);
            rowStyleStopped.ForeColor = cfg.ColorFromHex(cfg.StoppedFore);

            rowStyleUnknown = new DataGridViewCellStyle();
            rowStyleUnknown.BackColor = cfg.ColorFromHex(cfg.UnknownBack);
            ;
            rowStyleUnknown.ForeColor = cfg.ColorFromHex(cfg.UnknownFore);
            ;

            // System
            Load += EventFormLoad;
            FormClosing += EventFormClosing;
            Shown += EventFormShown;
            Resize += EventFormResized;

            // Menu
            aboutToolStripMenuItem.Click += EventMenuHelpAbout;
            onlineDocumentationToolStripMenuItem.Click += EventMenuHelpOnlineDocumentation;
            restartToolStripMenuItem.Click += EventMenuFileRestart;
            exitToolStripMenuItem.Click += EventMenuFileExit;

            // Monitor tab
            toolStripMonitorAll.Click += EventMonitorButtonAll;
            toolStripMonitorAuto.Click += EventMonitorButtonAuto;
            toolStripMonitorDisable.Click += EventMonitorButtonDisable;
            toolStripMonitorManual.Click += EventMonitorButtonManual;
            toolStripMonitorNone.Click += EventMonitorButtonNone;
            toolStripMonitorStart.Click += EventMonitorButtonStart;
            toolStripMonitorStop.Click += EventMonitorButtonStop;
            dataGridViewMonitor.CellClick += EventMonitorPickedClicked;
            dataGridViewMonitor.MouseMove += dataGridViewMonitorMouseMove;
            dataGridViewMonitor.MouseDown += dataGridViewMonitorMouseDown;
            dataGridViewMonitor.DragOver += dataGridViewMonitorDragOver;
            dataGridViewMonitor.DragDrop += dataGridViewMonitorDragDrop;

            // Select tab
            dataGridViewSelect.DataBindingComplete += EventSelectDataComplete;
            toolStripSelectRefresh.Click += EventSelectButtonRefresh;
            toolStripSelectSave.Click += EventSelectButtonSave;
            toolStripSelectCancel.Click += EventSelectButtonCancel;

            // Options tab
            toolStripOptionsDefault.Click += EventOptionsButtonDefault;
            toolStripOptionsSave.Click += EventOptionsButtonSave;
            toolStripOptionsCancel.Click += EventOptionsButtonCancel;

            optionsRunningFore.Click += EventOptionsRunningFore;
            optionsRunningBack.Click += EventOptionsRunningBack;
            optionsStoppedFore.Click += EventOptionsStoppedFore;
            optionsStoppedBack.Click += EventOptionsStoppedBack;
            optionsUnknownFore.Click += EventOptionsUnknownFore;
            optionsUnknownBack.Click += EventOptionsUnknownBack;

            // Log tab

            // Populate the data on all the tabs
            Services = new Services(ref cfg);
            PopulateSelect(); // initialize Select to populate services first
            PopulateMonitor();
            PopulateOptions();

            // Setup the Monitor tab update timer
            monitorUpdateTimer = new Timer();
            monitorUpdateTimer.Interval = 1000; // 1 second
            monitorUpdateTimer.Tick += EventMonitorUpdateTick;
        }
        // -----------------------------------------------------------------------------------------------------------------------

        #region Event Handlers

        private void EventFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Cancel the event so ProgramForm is not disposed
                e.Cancel = true;

                // Do not actually close. Hide in the system tray.
                if (cfg.MinimizeOnClose == true)
                {
                    WindowState = FormWindowState.Minimized;
                }
                else
                {
                    // Gracefully exit
                    ctxt.Exit(sender, e);
                }
            }
        }

        private void EventFormLoad(object sender, EventArgs e)
        {
            // Only do this when the program and data are loaded
            if (!updateTimerStarted)
            {
                dataGridViewMonitor.ClearSelection();

                // Update then start the Monitor tab update timer
                EventMonitorUpdateTick(sender, e);
                AugmentMonitorCells();

                monitorUpdateTimer.Start();
                updateTimerStarted = true;
            }
        }

        public void EventFormResized(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (cfg.HideWhenMinimized == false)
                {
                    ShowInTaskbar = true;
                }
                else
                {
                    if (Visible)
                    {
                        MiniminzedNotification();
                    }

                    ShowInTaskbar = false;
                    Visible = false;
                }
            }
            else if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                ShowInTaskbar = true;
                Visible = true;

                EventMonitorUpdateTick(sender, e);
                AugmentMonitorCells();
            }
        }

        private void EventFormShown(object sender, EventArgs e)
        {
            // Any services selected to monitor?
            if (Services.monitoredServices.Count < 1)
            {
                // switch to the Select tab
                tabControl.SelectedIndex = 1;

                MessageBox.Show(cfg.Program +
                                " has no services selected.\r\n\r\nPlease select one or more services to monitor & manage using your mouse. " +
                                " Use Ctrl-Click to select individual services or Shift-Click to select a range.",
                    "No Services Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            // Running "As Administrator"?
            if (!AdminChecked)
            {
                if (!RunningAsAdministrator())
                {
                    // disable the action buttons
                    toolStripMonitorAll.Enabled = false;
                    toolStripMonitorAll.BackColor = System.Drawing.Color.Wheat;
                    toolStripMonitorAll.ToolTipText = toolStripMonitorAll.ToolTipText + " (Disabled)";
                    toolStripMonitorNone.Enabled = false;
                    toolStripMonitorNone.BackColor = System.Drawing.Color.Wheat;
                    toolStripMonitorNone.ToolTipText = toolStripMonitorNone.ToolTipText + " (Disabled)";
                    //
                    toolStripMonitorStart.Enabled = false;
                    toolStripMonitorStart.BackColor = System.Drawing.Color.Wheat;
                    toolStripMonitorStart.ToolTipText = toolStripMonitorStart.ToolTipText + " (Disabled)";
                    toolStripMonitorStop.Enabled = false;
                    toolStripMonitorStop.BackColor = System.Drawing.Color.Wheat;
                    toolStripMonitorStop.ToolTipText = toolStripMonitorStop.ToolTipText + " (Disabled)";
                    //
                    toolStripMonitorAuto.Enabled = false;
                    toolStripMonitorAuto.BackColor = System.Drawing.Color.Wheat;
                    toolStripMonitorAuto.ToolTipText = toolStripMonitorAuto.ToolTipText + " (Disabled)";
                    toolStripMonitorDisable.Enabled = false;
                    toolStripMonitorDisable.BackColor = System.Drawing.Color.Wheat;
                    toolStripMonitorDisable.ToolTipText = toolStripMonitorDisable.ToolTipText + " (Disabled)";
                    toolStripMonitorManual.Enabled = false;
                    toolStripMonitorManual.BackColor = System.Drawing.Color.Wheat;
                    toolStripMonitorManual.ToolTipText = toolStripMonitorManual.ToolTipText + " (Disabled)";

                    var result = MessageBox.Show(
                        cfg.Program +
                        " is not running with the Administrator privileges needed to manage services.\r\n\r\n" +
                        "Windows services may only be monitored. The \"Start at login\" option cannot be changed.\r\n\r\n" +
                        "To avoid this warning right-click the program icon then select \"Run as administrator\".\r\n\r\n" +
                        "Click OK to continue, or Cancel to exit.",
                        "Administrator Privileges",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1
                    );
                    if (result == DialogResult.Cancel)
                    {
                        ctxt.Exit(null, null);
                    }
                }

                AdminChecked = true;
            }
        }

        private void EventMenuHelpAbout(object sender, EventArgs e)
        {
            var about = new AboutForm(this, cfg);
            about = null;
        }

        private void EventMenuHelpOnlineDocumentation(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Corionis/CorionisServiceManager.NET/wiki");
        }

        private void EventMenuFileRestart(object sender, EventArgs e)
        {
            SaveUserPreferences();

            // Hide tray icon, otherwise it will remain until mouse over
            ctxt.trayIcon.Visible = false;

            Application.Restart();
            Environment.Exit(0);
        }

        private void EventMenuFileExit(object sender, EventArgs e)
        {
            ctxt.Exit(sender, e);
        }

        private void EventMonitorButtonAll(object sender, EventArgs e)
        {
            TogglePicked(true);
        }

        private void EventMonitorButtonAuto(object sender, EventArgs e)
        {
            ManageServices("auto");
        }

        private void EventMonitorButtonDisable(object sender, EventArgs e)
        {
            ManageServices("disable");
        }

        private void EventMonitorButtonManual(object sender, EventArgs e)
        {
            ManageServices("manual");
        }

        private void EventMonitorButtonNone(object sender, EventArgs e)
        {
            TogglePicked(false);
        }

        private void EventMonitorButtonStart(object sender, EventArgs e)
        {
            ManageServices("start");
        }

        private void EventMonitorButtonStop(object sender, EventArgs e)
        {
            ManageServices("stop");
        }

        private void EventMonitorPickedClicked(object sender, DataGridViewCellEventArgs e)
        {
            var type = dataGridViewMonitor.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType();
            if (type == typeof(DataGridViewCheckBoxCell))
            {
                DataGridView dgv = (DataGridView) sender;
                if (AsAdmin)
                {
                    // flip the sense true/false
                    bool sense = true;
                    object obj = dataGridViewMonitor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null)
                    {
                        sense = !obj.ToString().Equals("true", StringComparison.OrdinalIgnoreCase);
                    }

                    // update the data immediately
                    Services.monitoredServices[e.RowIndex].Picked = sense;
                    dataGridViewMonitor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (sense) ? "True" : "False";
                    dgv.EndEdit();
                }
            }
        }

        private void EventMonitorUpdateTick(object sender, EventArgs e)
        {
            if (!updateTickActive)
            {
                updateTickActive = true;
                dataGridViewMonitor.ClearSelection();

                foreach (var service in Services.selectedServices)
                {
                    var row = GetRowByIdentifier(dataGridViewMonitor, service.ServiceName);
                    if (row != null)
                    {
                        service.Refresh();
                        var status = service.Status.ToString();

                        MonitoredService mon =
                            Services.monitoredServices.First(id => id.Identifier == service.ServiceName);
                        mon.Startup = service.StartType.ToString();
                        mon.Status = status;
                        switch (status.ToLower())
                        {
                            case "running":
                                row.DefaultCellStyle = rowStyleRunning;
                                break;
                            case "stopped":
                                row.DefaultCellStyle = rowStyleStopped;
                                break;
                            default:
                                row.DefaultCellStyle = rowStyleUnknown;
                                break;
                        }
                    }
                }

                updateTickActive = false;
                dataGridViewMonitor.Refresh();
            }
        }

        private void EventOptionsButtonCancel(object sender, EventArgs e)
        {
            cfg.Load();
            PopulateOptions();
        }

        private void EventOptionsButtonDefault(object sender, EventArgs e)
        {
            cfg.SetConfigDefaults();
            PopulateOptions();
        }

        private void EventOptionsButtonSave(object sender, EventArgs e)
        {
            SaveUserPreferences(); // Save all changes including on the Monitor tab
            PopulateOptions();
        }

        private void EventOptionsRunningFore(object sender, EventArgs e)
        {
            var color = ShowColorDialog(sender, e, cfg.RunningFore);
            optionsRunningFore.BackColor = color;
            cfg.RunningFore = cfg.ColorToHex(color);
            rowStyleRunning.ForeColor = color;
        }

        private void EventOptionsRunningBack(object sender, EventArgs e)
        {
            var color = ShowColorDialog(sender, e, cfg.RunningBack);
            optionsRunningBack.BackColor = color;
            cfg.RunningBack = cfg.ColorToHex(color);
            rowStyleRunning.BackColor = color;
        }

        private void EventOptionsStoppedFore(object sender, EventArgs e)
        {
            var color = ShowColorDialog(sender, e, cfg.StoppedFore);
            optionsStoppedFore.BackColor = color;
            cfg.StoppedFore = cfg.ColorToHex(color);
            rowStyleStopped.ForeColor = color;
        }

        private void EventOptionsStoppedBack(object sender, EventArgs e)
        {
            var color = ShowColorDialog(sender, e, cfg.StoppedBack);
            optionsStoppedBack.BackColor = color;
            cfg.StoppedBack = cfg.ColorToHex(color);
            rowStyleStopped.BackColor = color;
        }

        private void EventOptionsUnknownFore(object sender, EventArgs e)
        {
            var color = ShowColorDialog(sender, e, cfg.UnknownFore);
            optionsUnknownFore.BackColor = color;
            cfg.UnknownFore = cfg.ColorToHex(color);
            rowStyleUnknown.ForeColor = color;
        }

        private void EventOptionsUnknownBack(object sender, EventArgs e)
        {
            var color = ShowColorDialog(sender, e, cfg.UnknownBack);
            optionsUnknownBack.BackColor = color;
            cfg.UnknownBack = cfg.ColorToHex(color);
            rowStyleUnknown.BackColor = color;
        }

        private void EventSelectButtonCancel(object sender, EventArgs e)
        {
            // reset the selections
            EventSelectDataComplete(sender, e);
        }

        private void EventSelectButtonRefresh(object sender, EventArgs e)
        {
            PopulateSelect();
            EventSelectDataComplete(sender, e);
        }

        private void EventSelectButtonSave(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridViewSelect.Rows.GetRowCount(DataGridViewElementStates.Selected);
            cfg.SelectedServiceIds = new Config.ServiceIdNamePair[selectedRowCount];
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; ++i)
                {
                    cfg.SelectedServiceIds[i] = new Config.ServiceIdNamePair();

                    string name = GetColumnValue(dataGridViewSelect.SelectedRows[i].Cells, "Name");
                    cfg.SelectedServiceIds[i].Name = name;

                    string id = GetColumnValue(dataGridViewSelect.SelectedRows[i].Cells, "Identifier");
                    cfg.SelectedServiceIds[i].Identifier = id;
                }
            }

            cfg.Save();

            // Update the Monitor tab with new selections
            Services.GetSelectedServices();
            dataGridViewMonitor.DataSource = Services.monitoredServices; // required to get new instance
            AugmentMonitorCells();
            dataGridViewMonitor.Refresh();
        }

        private void EventSelectDataComplete(object sender, EventArgs e)
        {
            dataGridViewSelect.ClearSelection();
            dataGridViewSelect.Refresh();

            // Highlight (select) previously selected services
            if (cfg.SelectedServiceIds.Length > 0)
            {
                foreach (Config.ServiceIdNamePair pair in cfg.SelectedServiceIds)
                {
                    var row = GetRowByIdentifier(dataGridViewSelect, pair.Identifier);
                    if (row != null)
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        #endregion

        // -----------------------------------------------------------------------------------------------------------------------

        private void AugmentMonitorCells()
        {
            if (!AsAdmin)
            {
                // Disable Picked checkbox controls
                foreach (DataGridViewRow row in dataGridViewMonitor.Rows)
                {
                    var cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Sel");
                    cell.ReadOnly = true;
                }
            }

            // Set cell-level tool-tips
            foreach (DataGridViewRow row in dataGridViewMonitor.Rows)
            {
                var cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Sel");
                if (!AsAdmin)
                {
                    cell.ToolTipText = cfg.ShowGridTooltips ? "Click to select (Disabled)" : "";
                }
                else
                    cell.ToolTipText = cfg.ShowGridTooltips ? "Click to select" : "";

                cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Name");
                cell.ToolTipText = cfg.ShowGridTooltips ? "Click or F2 to edit" : "";

                cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Identifier");
                string ttt = cfg.ShowGridTooltips ? "Drag 'n Drop to move row" : "";

                cell.ToolTipText = ttt;
                cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Start Type");
                cell.ToolTipText = ttt;
                cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Status");
                cell.ToolTipText = ttt;
            }
        }

        private string GetColumnValue(DataGridViewCellCollection cells, string headerName)
        {
            var c = cells.Cast<DataGridViewCell>().First(o => o.OwningColumn.HeaderText == headerName);
            var v = c.FormattedValue.ToString();
            return v;
        }

        public DataGridView GetMonitorDataGridView()
        {
            return dataGridViewMonitor;
        }

        public DataGridView GetSelectDataGridView()
        {
            return dataGridViewSelect;
        }

        private DataGridViewRow GetRowByIdentifier(DataGridView view, String id)
        {
            foreach (DataGridViewRow row in view.Rows)
            {
                if (GetColumnValue(row.Cells, "Identifier").Equals(id))
                {
                    return row;
                }
            }

            return null;
        }

        private void ManageServices(String command)
        {
            for (int i = 0; i < dataGridViewMonitor.Rows.Count; ++i)
            {
                string picked = GetColumnValue(dataGridViewMonitor.Rows[i].Cells, "Sel");
                if (picked.Equals("True"))
                {
                    string id = GetColumnValue(dataGridViewMonitor.Rows[i].Cells, "Identifier");
                    var service = Services.selectedServices.First(s => s.ServiceName == id);
                    service.Refresh();

                    switch (command.ToLower())
                    {
                        case "auto":
                            ManageStartupType(service.ServiceName, "auto");
                            break;
                        case "disable":
                            ManageStartupType(service.ServiceName, "disabled");
                            break;
                        case "manual":
                            ManageStartupType(service.ServiceName, "demand");
                            break;
                        case "start":
                            if (service.Status != ServiceControllerStatus.Running)
                                service.Start();
                            break;
                        case "stop":
                            if (service.Status != ServiceControllerStatus.Stopped)
                                service.Stop();
                            break;
                        default:
                            throw new Exception("unknown ManageServices command");
                    }
                }
            }
        }

        private int ManageStartupType(String id, String type)
        {
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "CMD.EXE",
                Arguments = $"/c sc config {id} start= {type}"
            };

            using (var process = new Process {StartInfo = startInfo})
            {
                if (!process.Start())
                {
                    throw new Exception("cannot run sc command: " + startInfo.ToString());
                }

                process.WaitForExit();
                int status = process.ExitCode;
                return status;
            }
        }

        private void MiniminzedNotification()
        {
            if (cfg.DisplayMinimizedNotifications)
            {
                ctxt.Popup(cfg.GetProgramTitle(), "CSM is running in the system tray");
            }
        }

        private void PopulateMonitor()
        {
            Services.GetSelectedServices();
            dataGridViewMonitor.DataSource = Services.monitoredServices;
        }

        private void PopulateOptions()
        {
            configBindingSource.DataSource = cfg;
            this.Text = cfg.GetProgramTitle();
            ctxt.trayIcon.Text = cfg.GetProgramTitle();

            configBindingSource.ResetBindings(false);
            optionsRunningFore.BackColor = cfg.ColorFromHex(cfg.RunningFore);
            optionsRunningBack.BackColor = cfg.ColorFromHex(cfg.RunningBack);
            optionsStoppedFore.BackColor = cfg.ColorFromHex(cfg.StoppedFore);
            optionsStoppedBack.BackColor = cfg.ColorFromHex(cfg.StoppedBack);
            optionsUnknownFore.BackColor = cfg.ColorFromHex(cfg.UnknownFore);
            optionsUnknownBack.BackColor = cfg.ColorFromHex(cfg.UnknownBack);

            if (!RunningAsAdministrator())
            {
                optionsCheckBoxStartAtLogin.Enabled = false;
            }

            tabOptions.Refresh();
            AugmentMonitorCells(); // done here for Options refresh
            tabMonitor.Refresh();
            Refresh();
        }

        private void PopulateSelect()
        {
            Services.GetAllServices();
            dataGridViewSelect.DataSource = Services.allServices;
        }

        public bool RunningAsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            AsAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            return AsAdmin;
        }

        public void SaveUserPreferences()
        {
            // Must be visible for coordinates to be valid
            if (Visible == false || WindowState == FormWindowState.Minimized)
            {
                ShowForm();
            }

            cfg.Left = Left;
            cfg.Top = Top;
            cfg.Width = Width;
            cfg.Height = Height;

            // Copy monitored service names, that are editable, to the saved configuration
            cfg.SelectedServiceIds = new Config.ServiceIdNamePair[Services.monitoredServices.Count];
            for (int i = 0; i < Services.monitoredServices.Count; ++i)
            {
                var mon = Services.monitoredServices[i];
                Config.ServiceIdNamePair pair = new Config.ServiceIdNamePair();
                pair.Identifier = mon.Identifier;
                pair.Name = mon.Name;
                cfg.SelectedServiceIds[i] = pair;
            }

            cfg.Save();
            StartAtLogin();
        }

        public Color ShowColorDialog(object sender, EventArgs e, String hexColor)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.ShowHelp = true;
            cd.AnyColor = true;
            Color color = cfg.ColorFromHex(hexColor);
            cd.Color = color;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                return cd.Color;
            }

            return color;
        }

        public void ShowForm()
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
        }

        public void StartAtLogin()
        {
            if (RunningAsAdministrator())
            {
                using (TaskService ts = new TaskService())
                {
                    var task = ts.GetTask(Assembly.GetEntryAssembly().Location);
                    if (task == null && cfg.StartAtLogin)
                    {
                        // Create a new task definition and assign properties
                        TaskDefinition td = ts.NewTask();
                        td.RegistrationInfo.Description = cfg.Program;
                        td.RegistrationInfo.Author = "Corionis, LLC";
                        td.RegistrationInfo.Date = DateTime.Now;

                        // Set "Run with highest privileges" to avoid UAC when managing services
                        td.Principal.RunLevel = TaskRunLevel.Highest;

                        // Create a trigger that will fire the task at this time every other day
                        td.Triggers.Add(new LogonTrigger());

                        // Create an action that will launch Notepad whenever the trigger fires
                        td.Actions.Add(new ExecAction(Assembly.GetEntryAssembly().Location, "", null));

                        // Register the task in the root folder.
                        ts.RootFolder.RegisterTaskDefinition(cfg.Program, td);
                    }
                    else if (task != null && !cfg.StartAtLogin)
                    {
                        ts.RootFolder.DeleteTask(cfg.Program, false);
                    }
                }
            }
        }

        public void TogglePicked(bool sense)
        {
            for (int i = 0; i < dataGridViewMonitor.Rows.Count; ++i)
            {
                var cell = dataGridViewMonitor.Rows[i].Cells.Cast<DataGridViewCell>()
                    .First(o => o.OwningColumn.HeaderText == "Sel");

                // update the data immediately
                Services.monitoredServices[i].Picked = sense;
                cell.Value = sense;
                dataGridViewMonitor.Refresh();
            }
        }

        // -----------------------------------------------------------------------------------------------------------------------

        #region Monitor Tab Drag 'n Drop Handling

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        private void dataGridViewMonitorMouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.
                    DragDropEffects dropEffect =
                        dataGridViewMonitor.DoDragDrop(dataGridViewMonitor.Rows[rowIndexFromMouseDown],
                            DragDropEffects.Move);
                }
            }
        }

        private void dataGridViewMonitorMouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataGridViewMonitor.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred.
                // The DragSize indicates the size that the mouse can move
                // before a drag event should be started.
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)),
                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridViewMonitorDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridViewMonitorDragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be converted to client coordinates
            Point clientPoint = dataGridViewMonitor.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below.
            rowIndexOfItemUnderMouseToDrop = dataGridViewMonitor.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                MonitoredService moveRow = Services.monitoredServices[rowIndexFromMouseDown];
                Services.monitoredServices.RemoveAt(rowIndexFromMouseDown);
                if (rowIndexOfItemUnderMouseToDrop >= 0)
                {
                    Services.monitoredServices.Insert(rowIndexOfItemUnderMouseToDrop, moveRow);
                }
                else
                {
                    // If dragged out-of-bounds add it to the bottom
                    Services.monitoredServices.Add(moveRow);
                }

                dataGridViewMonitor.ClearSelection();
                EventMonitorUpdateTick(sender, e);
            }
        }

        #endregion

        // -----------------------------------------------------------------------------------------------------------------------
    }
}