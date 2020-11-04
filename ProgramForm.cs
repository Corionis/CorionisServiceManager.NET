using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.ServiceProcess;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace CorionisServiceManager.NET
{
    public partial class ProgramForm : Form
    {
        private bool adminChecked = false;
        private bool asAdmin = false;
        private Config cfg;
        private CsmContext ctxt;
        private int monitorSortColumnIndex = -1;
        private SortOrder monitorSortMode = SortOrder.None;
        private Timer monitorUpdateTimer;
        private DataGridViewCellStyle rowStyleRunning;
        private DataGridViewCellStyle rowStyleStopped;
        private DataGridViewCellStyle rowStyleUnknown;
        private int selectSortColumnIndex = -1;
        private SortOrder selectSortMode = SortOrder.None;
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
            rowStyleStopped = new DataGridViewCellStyle();
            rowStyleUnknown = new DataGridViewCellStyle();
            SetMonitorColors();

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
            dataGridViewMonitor.CellClick += EventMonitorCellClicked;
            dataGridViewMonitor.MouseMove += dataGridViewMonitorMouseMove;
            dataGridViewMonitor.MouseDown += dataGridViewMonitorMouseDown;
            dataGridViewMonitor.DragOver += dataGridViewMonitorDragOver;
            dataGridViewMonitor.DragDrop += dataGridViewMonitorDragDrop;

            // Select tab
            dataGridViewSelect.DataBindingComplete += EventSelectDataComplete;
            toolStripSelectRefresh.Click += EventSelectButtonRefresh;
            toolStripSelectSave.Click += EventSelectButtonSave;
            toolStripSelectCancel.Click += EventSelectButtonCancel;
            dataGridViewSelect.CellClick += EventSelectCellClicked;

            // Options tab
            toolStripOptionsDefault.Click += EventOptionsButtonDefault;
            toolStripOptionsSave.Click += EventOptionsButtonSave;
            toolStripOptionsCancel.Click += EventOptionsButtonCancel;
            optionsRunningFore.Click += EventOptionsRunningFore;
            optionsRunningForeLabel.Click += EventOptionsRunningFore;
            optionsRunningBack.Click += EventOptionsRunningBack;
            optionsRunningBackLabel.Click += EventOptionsRunningBack;
            optionsStoppedFore.Click += EventOptionsStoppedFore;
            optionsStoppedForeLabel.Click += EventOptionsStoppedFore;
            optionsStoppedBack.Click += EventOptionsStoppedBack;
            optionsStoppedBackLabel.Click += EventOptionsStoppedBack;
            optionsUnknownFore.Click += EventOptionsUnknownFore;
            optionsUnknownForeLabel.Click += EventOptionsUnknownFore;
            optionsUnknownBack.Click += EventOptionsUnknownBack;
            optionsUnknownBackLabel.Click += EventOptionsUnknownBack;
            optionsSelectFore.Click += EventOptionsSelectFore;
            optionsSelectForeLabel.Click += EventOptionsSelectFore;
            optionsSelectBack.Click += EventOptionsSelectBack;
            optionsSelectBackLabel.Click += EventOptionsSelectBack;

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
                                " has no services selected.\r\n\r\nPlease select one or more services to monitor & manage. Check the" +
                                " \"Sel\" for each desired service on the Select tab, Save your choices, then goto the Monitor tab",
                    "No Services Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            // Running "As Administrator"?
            if (!adminChecked)
            {
                if (!RunningAsAdministrator())
                {
                    // disable the action buttons
                    toolStripMonitorAll.Enabled = false;
                    toolStripMonitorAll.BackColor = Color.Wheat;
                    toolStripMonitorAll.ToolTipText = toolStripMonitorAll.ToolTipText + " (Disabled)";
                    toolStripMonitorNone.Enabled = false;
                    toolStripMonitorNone.BackColor = Color.Wheat;
                    toolStripMonitorNone.ToolTipText = toolStripMonitorNone.ToolTipText + " (Disabled)";
                    //
                    toolStripMonitorStart.Enabled = false;
                    toolStripMonitorStart.BackColor = Color.Wheat;
                    toolStripMonitorStart.ToolTipText = toolStripMonitorStart.ToolTipText + " (Disabled)";
                    toolStripMonitorStop.Enabled = false;
                    toolStripMonitorStop.BackColor = Color.Wheat;
                    toolStripMonitorStop.ToolTipText = toolStripMonitorStop.ToolTipText + " (Disabled)";
                    //
                    toolStripMonitorAuto.Enabled = false;
                    toolStripMonitorAuto.BackColor = Color.Wheat;
                    toolStripMonitorAuto.ToolTipText = toolStripMonitorAuto.ToolTipText + " (Disabled)";
                    toolStripMonitorDisable.Enabled = false;
                    toolStripMonitorDisable.BackColor = Color.Wheat;
                    toolStripMonitorDisable.ToolTipText = toolStripMonitorDisable.ToolTipText + " (Disabled)";
                    toolStripMonitorManual.Enabled = false;
                    toolStripMonitorManual.BackColor = Color.Wheat;
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

                adminChecked = true;
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

        private void EventMonitorCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var type = dataGridViewMonitor.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType();
                if (type == typeof(DataGridViewCheckBoxCell))
                {
                    DataGridView dgv = (DataGridView) sender;
                    if (asAdmin)
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
            else
            {
                if (monitorSortColumnIndex != e.ColumnIndex)
                {
                    for (int i = 0; i < dataGridViewMonitor.Columns.Count; ++i)
                    {
                        dataGridViewMonitor.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }

                    monitorSortMode = SortOrder.None;
                    dataGridViewMonitor.Refresh();
                    monitorSortColumnIndex = e.ColumnIndex;
                }

                monitorSortMode = (monitorSortMode == SortOrder.None) ? SortOrder.Ascending :
                    (monitorSortMode == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.None;

                dataGridViewMonitor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = monitorSortMode;

                if (monitorSortMode != SortOrder.None)
                {
                    var name = dataGridViewMonitor.Columns[e.ColumnIndex].HeaderText;
                    if (monitorSortMode == SortOrder.Ascending)
                    {
                        if (name.Equals("Name"))
                        {
                            Services.monitoredServices.Sort((x, y) =>
                                String.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
                        }
                        else if (name.Equals("Identifier"))
                        {
                            Services.monitoredServices.Sort((x, y) =>
                                String.Compare(x.Identifier, y.Identifier, StringComparison.Ordinal));
                        }
                        else if (name.Equals("Start Type"))
                        {
                            Services.monitoredServices.Sort((x, y) =>
                                String.Compare(x.Startup, y.Startup, StringComparison.Ordinal));
                        }
                        else if (name.Equals("Status"))
                        {
                            Services.monitoredServices.Sort((x, y) =>
                                String.Compare(x.Status, y.Status, StringComparison.Ordinal));
                        }
                    }
                    else
                    {
                        if (name.Equals("Name"))
                        {
                            Services.monitoredServices.Sort((x, y) =>
                                String.Compare(y.Name, x.Name, StringComparison.Ordinal));
                        }
                        else if (name.Equals("Identifier"))
                        {
                            Services.monitoredServices.Sort((x, y) =>
                                String.Compare(y.Identifier, x.Identifier, StringComparison.Ordinal));
                        }
                        else if (name.Equals("Start Type"))
                        {
                            Services.monitoredServices.Sort((x, y) =>
                                String.Compare(y.Startup, x.Startup, StringComparison.Ordinal));
                        }
                        else if (name.Equals("Status"))
                        {
                            Services.monitoredServices.Sort((x, y) =>
                                String.Compare(y.Status, x.Status, StringComparison.Ordinal));
                        }
                    }
                }
                else
                {
                    // Reset context of Monitor tab data
                    cfg.Load();
                    PopulateMonitor();
                    monitorSortMode = SortOrder.None;
                    monitorSortColumnIndex = -1;
                }

                EventMonitorUpdateTick(sender, e);
                dataGridViewMonitor.Refresh();
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
            EventSelectDataComplete(sender, e);
            SetMonitorColors();
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

        private void EventOptionsSelectFore(object sender, EventArgs e)
        {
            var color = ShowColorDialog(sender, e, cfg.SelectFore);
            optionsSelectFore.BackColor = color;
            cfg.SelectFore = cfg.ColorToHex(color);
        }

        private void EventOptionsSelectBack(object sender, EventArgs e)
        {
            var color = ShowColorDialog(sender, e, cfg.SelectBack);
            optionsSelectBack.BackColor = color;
            cfg.SelectBack = cfg.ColorToHex(color);
        }

        private void EventSelectButtonCancel(object sender, EventArgs e)
        {
            // reset the selections
            foreach (DataGridViewRow row in dataGridViewSelect.Rows)
            {
                var c = row.Cells.Cast<DataGridViewCell>().First(o => o.OwningColumn.HeaderText == "Sel");
                if (c != null)
                {
                    c.Value = "False";
                    row.DefaultCellStyle.ForeColor = dataGridViewSelect.DefaultCellStyle.ForeColor;
                    row.DefaultCellStyle.BackColor = dataGridViewSelect.DefaultCellStyle.BackColor;
                }
            }

            EventSelectDataComplete(sender, e);
        }

        private void EventSelectButtonRefresh(object sender, EventArgs e)
        {
            PopulateSelect();
            EventSelectDataComplete(sender, e);
        }

        private void EventSelectButtonSave(object sender, EventArgs e)
        {
            // Count the Picked items to size the new Config.ServiceIdNamePair array below
            int count = 0;
            for (int i = 0; i < dataGridViewSelect.Rows.Count; ++i)
            {
                DataGridViewRow row = dataGridViewSelect.Rows[i];
                var c = row.Cells.Cast<DataGridViewCell>().First(o => o.OwningColumn.HeaderText == "Sel");
                if (c != null && c.Value != null &&
                    c.Value.ToString().Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    ++count;
                }
            }

            cfg.SelectedServiceIds = new Config.ServiceIdNamePair[count];
            if (count > 0)
            {
                for (int i = 0, n = 0; i < dataGridViewSelect.Rows.Count; ++i)
                {
                    DataGridViewRow row = dataGridViewSelect.Rows[i];
                    var c = row.Cells.Cast<DataGridViewCell>().First(o => o.OwningColumn.HeaderText == "Sel");
                    if (c != null && c.Value != null &&
                        c.Value.ToString().Equals("true", StringComparison.OrdinalIgnoreCase))
                    {
                        cfg.SelectedServiceIds[n] = new Config.ServiceIdNamePair();

                        string name = GetColumnValue(row.Cells, "Name");
                        cfg.SelectedServiceIds[n].Name = name;

                        string id = GetColumnValue(row.Cells, "Identifier");
                        cfg.SelectedServiceIds[n].Identifier = id;

                        ++n;
                    }
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
                        var c = row.Cells.Cast<DataGridViewCell>().First(o => o.OwningColumn.HeaderText == "Sel");
                        if (c != null)
                        {
                            c.Value = "True";
                            row.DefaultCellStyle.ForeColor = cfg.ColorFromHex(cfg.SelectFore);
                            row.DefaultCellStyle.BackColor = cfg.ColorFromHex(cfg.SelectBack);
                        }
                    }
                }
            }
        }

        private void EventSelectCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                var type = dataGridViewSelect.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType();
                if (type == typeof(DataGridViewCheckBoxCell))
                {
                    DataGridView dgv = (DataGridView) sender;

                    // flip the sense true/false
                    bool sense = true;
                    object obj = dataGridViewSelect.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (obj != null)
                    {
                        sense = !obj.ToString().Equals("true", StringComparison.OrdinalIgnoreCase);
                    }

                    // update the data immediately
                    dataGridViewSelect.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (sense) ? "True" : "False";
                    if (sense)
                    {
                        dataGridViewSelect.Rows[e.RowIndex].DefaultCellStyle.ForeColor = cfg.ColorFromHex(cfg.SelectFore);
                        dataGridViewSelect.Rows[e.RowIndex].DefaultCellStyle.BackColor = cfg.ColorFromHex(cfg.SelectBack);
                    }
                    else
                    {
                        dataGridViewSelect.Rows[e.RowIndex].DefaultCellStyle.ForeColor =
                            dataGridViewSelect.DefaultCellStyle.ForeColor;
                        dataGridViewSelect.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                            dataGridViewSelect.DefaultCellStyle.BackColor;
                    }

                    dgv.EndEdit();
                }
            }
            else
            {
                if (selectSortColumnIndex > 0 && selectSortColumnIndex != e.ColumnIndex)
                {
                    for (int i = 0; i < dataGridViewSelect.Columns.Count; ++i)
                    {
                        dataGridViewSelect.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }

                    selectSortMode = SortOrder.None;
                    dataGridViewSelect.Refresh();
                }
                selectSortColumnIndex = e.ColumnIndex;

                selectSortMode = (selectSortMode == SortOrder.None) ? SortOrder.Ascending :
                    (selectSortMode == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.None;

                dataGridViewSelect.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = selectSortMode;

                if (selectSortMode != SortOrder.None)
                {
                    var name = dataGridViewSelect.Columns[e.ColumnIndex].HeaderText;
                    if (selectSortMode == SortOrder.Ascending)
                    {
                        // if (name.Equals("Name"))
                        // {
                        //     Services.selectedServices.Sort((x, y) =>
                        //         String.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
                        // }
                        // else if (name.Equals("Identifier"))
                        // {
                        //     Services.selectedServices.Sort((x, y) =>
                        //         String.Compare(x.Identifier, y.Identifier, StringComparison.Ordinal));
                        // }
                        // else if (name.Equals("Start Type"))
                        // {
                        //     Services.selectedServices.Sort((x, y) =>
                        //         String.Compare(x.Startup, y.Startup, StringComparison.Ordinal));
                        // }
                        // else if (name.Equals("Status"))
                        // {
                        //     Services.selectedServices.Sort((x, y) =>
                        //         String.Compare(x.Status, y.Status, StringComparison.Ordinal));
                        // }
                    }
                    else
                    {
                        // if (name.Equals("Name"))
                        // {
                        //     Services.selectedServices.Sort((x, y) =>
                        //         String.Compare(y.Name, x.Name, StringComparison.Ordinal));
                        // }
                        // else if (name.Equals("Identifier"))
                        // {
                        //     Services.selectedServices.Sort((x, y) =>
                        //         String.Compare(y.Identifier, x.Identifier, StringComparison.Ordinal));
                        // }
                        // else if (name.Equals("Start Type"))
                        // {
                        //     Services.selectedServices.Sort((x, y) =>
                        //         String.Compare(y.Startup, x.Startup, StringComparison.Ordinal));
                        // }
                        // else if (name.Equals("Status"))
                        // {
                        //     Services.selectedServices.Sort((x, y) =>
                        //         String.Compare(y.Status, x.Status, StringComparison.Ordinal));
                        }
                }
                else
                {
                    // Reset context of Select tab data
                    cfg.Load();
                    PopulateSelect();
                    selectSortMode = SortOrder.None;
                    selectSortColumnIndex = -1;
                }

                 // EventSelectUpdateTick(sender, e);
                dataGridViewSelect.Refresh();
                
            }
        }

        #endregion

        // -----------------------------------------------------------------------------------------------------------------------

        private void AugmentMonitorCells()
        {
            if (!asAdmin)
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
                if (!asAdmin)
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

        private void MoveMonitorRow(int from, int to)
        {
            MonitoredService moveRow = Services.monitoredServices[from];
            Services.monitoredServices.RemoveAt(from);
            if (to >= 0)
            {
                Services.monitoredServices.Insert(to, moveRow);
            }
            else
            {
                // If dragged/sorted out-of-bounds add it to the bottom
                Services.monitoredServices.Add(moveRow);
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
            optionsSelectFore.BackColor = cfg.ColorFromHex(cfg.SelectFore);
            optionsSelectBack.BackColor = cfg.ColorFromHex(cfg.SelectBack);

            if (!RunningAsAdministrator())
            {
                optionsCheckBoxStartAtLogin.Enabled = false;
            }

            tabOptions.Refresh();
            AugmentMonitorCells(); // done here for Options Cancel
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
            asAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            return asAdmin;
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

        private void SetMonitorColors()
        {
            rowStyleRunning.BackColor = cfg.ColorFromHex(cfg.RunningBack);
            rowStyleRunning.ForeColor = cfg.ColorFromHex(cfg.RunningFore);

            rowStyleStopped.BackColor = cfg.ColorFromHex(cfg.StoppedBack);
            rowStyleStopped.ForeColor = cfg.ColorFromHex(cfg.StoppedFore);

            rowStyleUnknown.BackColor = cfg.ColorFromHex(cfg.UnknownBack);
            rowStyleUnknown.ForeColor = cfg.ColorFromHex(cfg.UnknownFore);
        }

        public Color ShowColorDialog(object sender, EventArgs e, String hexColor)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.ShowHelp = false;
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
                cell.Selected = sense;
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
                MoveMonitorRow(rowIndexFromMouseDown, rowIndexOfItemUnderMouseToDrop);
                dataGridViewMonitor.ClearSelection();

                // Clear any sort
                for (int i = 0; i < dataGridViewMonitor.Columns.Count; ++i)
                {
                    dataGridViewMonitor.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                }

                monitorSortMode = SortOrder.None;
                monitorSortColumnIndex = -1;
                dataGridViewMonitor.Refresh();
                EventMonitorUpdateTick(sender, e);
            }
        }

        #endregion

        // -----------------------------------------------------------------------------------------------------------------------
    }
}