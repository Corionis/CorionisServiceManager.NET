using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;

namespace CorionisServiceManager.NET
{
    public partial class TheForm : Form
    {
        private Config cfg;
        private CsmContext ctxt;
        private bool UpdateTimerStarted = false;
        private Timer monitorUpdateTimer;
        private int[] selectedMonitorRows;
        public Services Services;
        private DataGridViewCellStyle rowStyleRunning;
        private DataGridViewCellStyle rowStyleStopped;
        private DataGridViewCellStyle rowStyleUnknown;

        public TheForm(Config theCfg, CsmContext theContext)
        {
            this.cfg = theCfg;
            this.ctxt = theContext;

            InitializeComponent();

            IntPtr hwnd = this.Handle; // required for positioning to work
            this.Left = cfg.Left;
            this.Top = cfg.Top;
            this.Width = cfg.Width;
            this.Height = cfg.Height;

            this.Text = cfg.GetProgramTitle();

            // Styles
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = SystemColors.ControlDarkDark;
            columnHeaderStyle.Font = new Font("Microsoft Sans Serif, 8.25pt, style=Bold", 8.25F);
            columnHeaderStyle.ForeColor = Color.White;
            columnHeaderStyle.SelectionBackColor = SystemColors.ControlDark;
            columnHeaderStyle.SelectionForeColor = Color.White;

            rowStyleRunning = new DataGridViewCellStyle();
            rowStyleRunning.BackColor = Color.LawnGreen;

            rowStyleStopped = new DataGridViewCellStyle();
            rowStyleStopped.BackColor = Color.Red;

            rowStyleUnknown = new DataGridViewCellStyle();
            rowStyleUnknown.BackColor = Color.Yellow;

            // System
            Load += EventFormLoad;
            FormClosing += EventFormClosing;
            Resize += EventFormResized;


            // Menu
            restartToolStripMenuItem.Click += EventMenuFileRestart;
            exitToolStripMenuItem.Click += EventMenuFileExit;

            // Monitor tab
            toolStripMonitorAuto.Click += EventMonitorButtonAuto;
            toolStripMonitorDisable.Click += EventMonitorButtonDisable;
            toolStripMonitorManual.Click += EventMonitorButtonManual;
            toolStripMonitorStart.Click += EventMonitorButtonStart;
            toolStripMonitorStop.Click += EventMonitorButtonStop;
            dataGridViewMonitor.MouseMove += dataGridViewMonitorMouseMove;
            dataGridViewMonitor.MouseDown += dataGridViewMonitorMouseDown;
            dataGridViewMonitor.DragOver += dataGridViewMonitorDragOver;
            dataGridViewMonitor.DragDrop += dataGridViewMonitorDragDrop;
            dataGridViewMonitor.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Select tab
            dataGridViewSelect.DataBindingComplete += EventSelectDataComplete;
            toolStripSelectRefresh.Click += EventSelectButtonRefresh;
            toolStripSelectSave.Click += EventSelectButtonSave;
            toolStripSelectCancel.Click += EventSelectButtonCancel;
            dataGridViewSelect.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Config tab

            // Log tab

            // Populate the data on all the tabs
            Services = new Services(ref cfg);
            PopulateSelect(); // initialize Select to populate services first
            PopulateMonitor();

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
                // Cancel the event so TheForm is not disposed
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
            if (!UpdateTimerStarted)
            {
                dataGridViewMonitor.ClearSelection();

                // Update then start the Monitor tab update timer
                EventMonitorUpdateTick(sender, e);
                monitorUpdateTimer.Start();
                UpdateTimerStarted = true;
            }
        }

        public void EventFormResized(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                SaveMonitorSelections();

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

                // Set cell-level tool-tips
                foreach (DataGridViewRow row in dataGridViewMonitor.Rows)
                {
                    var cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Name");
                    cell.ToolTipText = "Click or F2 to edit";
                    cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Identifier");
                    cell.ToolTipText = "Ctrl/Shift-Click to select, Drag 'n Drop to move row";
                    cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Start Type");
                    cell.ToolTipText = "Ctrl/Shift-Click to select, Drag 'n Drop to move row";
                    cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Status");
                    cell.ToolTipText = "Ctrl/Shift-Click to select, Drag 'n Drop to move row";
                }

                RestoreMonitorSelections();
            }
        }

        private void EventMenuFileRestart(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void EventMenuFileExit(object sender, EventArgs e)
        {
            ctxt.Exit(sender, e);
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

        private void EventMonitorButtonStart(object sender, EventArgs e)
        {
            ManageServices("start");
        }

        private void EventMonitorButtonStop(object sender, EventArgs e)
        {
            ManageServices("stop");
        }

        void EventMonitorUpdateTick(object sender, EventArgs e)
        {
            foreach (var service in Services.selectedServices)
            {
                var row = GetRowByIdentifier(dataGridViewMonitor, service.ServiceName);
                if (row != null)
                {
                    service.Refresh();
                    var status = service.Status.ToString();

                    MonitoredService mon = Services.monitoredServices.First(id => id.Identifier == service.ServiceName);
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

            dataGridViewMonitor.Refresh();
        }

        private void EventSelectButtonCancel(object sender, EventArgs e)
        {
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

        private string GetColumnValue(DataGridViewCellCollection cells, string headerName)
        {
            var v = cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == headerName).Value.ToString();
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
            Int32 selectedRowCount = dataGridViewMonitor.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; ++i)
                {
                    string id = GetColumnValue(dataGridViewMonitor.SelectedRows[i].Cells, "Identifier");
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
                int status = -1;
                if (!process.Start())
                {
                    throw new Exception("cannot run sc command");
                }

                process.WaitForExit();
                status = process.ExitCode;
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

        private void PopulateSelect()
        {
            Services.GetAllServices();
            dataGridViewSelect.DataSource = Services.allServices;
        }

        private void RestoreMonitorSelections()
        {
            dataGridViewMonitor.ClearSelection();
            if (selectedMonitorRows != null)
            {
                for (int i = 0; i < selectedMonitorRows.Length; ++i)
                {
                    dataGridViewMonitor.Rows[selectedMonitorRows[i]].Selected = true;
                }
            }
        }

        public void SaveMonitorSelections()
        {
            Int32 selectedRowCount = dataGridViewMonitor.Rows.GetRowCount(DataGridViewElementStates.Selected);
            selectedMonitorRows = new int[selectedRowCount];
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; ++i)
                {
                    selectedMonitorRows[i] = dataGridViewMonitor.SelectedRows[i].Index;
                }
            }
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
            // foreach (MonitoredService mon in Services.monitoredServices)
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
        }

        public void ShowForm()
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
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
                    DragDropEffects dropEffect = dataGridViewMonitor.DoDragDrop(dataGridViewMonitor.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
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
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
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
                dataGridViewMonitor.Refresh();
                EventMonitorUpdateTick(sender, e);
            }
        }

        #endregion

        // -----------------------------------------------------------------------------------------------------------------------
    }
}