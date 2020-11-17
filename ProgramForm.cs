﻿using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.ServiceProcess;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;

namespace CorionisServiceManager.NET
{
    /// <summary>
    /// ProgramForm class.
    /// The application logic of the main Windows Form.
    /// </summary>
    public partial class ProgramForm : Form
    {
        private bool adminChecked = false;
        private bool asAdmin = false;
        private Config cfg;
        private CsmContext ctxt;
        public Log logger { get; }
        private Panel miniPanel;
        private int monitorSortColumnIndex = -1;
        private SortOrder monitorSortMode = SortOrder.None;
        private Timer monitorUpdateTimer;
        private int originalFormHeight = -1;
        private DataGridViewCellStyle rowStyleRunning;
        private DataGridViewCellStyle rowStyleStopped;
        private DataGridViewCellStyle rowStyleUnknown;
        private int selectSortColumnIndex = -1;
        private SortOrder selectSortMode = SortOrder.None;
        public Services services;
        private bool updateTickActive = false;
        private bool updateTimerStarted = false;

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
            checkForUpdatesToolStripMenuItem.Click += EventMenuCheckForUpdates;
            exitToolStripMenuItem.Click += EventMenuFileExit;
            minifyToolStripMenuItem.Click += EventMenuViewMinify;
            onlineDocumentationToolStripMenuItem.Click += EventMenuHelpOnlineDocumentation;
            restartToolStripMenuItem.Click += EventMenuFileRestart;

            // Tab control
            tabControl.Click += EventTabFocused;

            // Monitor tab
            toolStripMonitorAll.Click += EventMonitorButtonAll;
            toolStripMonitorAuto.Click += EventMonitorButtonAuto;
            toolStripMonitorDisable.Click += EventMonitorButtonDisable;
            toolStripMonitorManual.Click += EventMonitorButtonManual;
            toolStripMonitorNone.Click += EventMonitorButtonNone;
            toolStripMonitorStart.Click += EventMonitorButtonStart;
            toolStripMonitorStop.Click += EventMonitorButtonStop;
            toolStripMonitorToggleMinify.Click += EventMonitorButtonToggleMinify;
            dataGridViewMonitor.CellClick += EventMonitorCellClicked;
            dataGridViewMonitor.CellValueChanged += EventMonitorCellEndEdit;
            dataGridViewMonitor.KeyDown += EventMonitorKeyDown;
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
            dataGridViewSelect.KeyDown += EventSelectKeyDown;

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
            logger = new Log(cfg, logTextBox);
            logBindingSource.DataSource = logger;
            toolStripLogButtonBottom.Click += EventLogButtonBottom;
            toolStripLogButtonClear.Click += EventLogButtonClear;
            toolStripLogButtonSave.Click += EventLogButtonSave;
            toolStripLogButtonView.Click += EventLogButtonView;

            // Populate the data on all the tabs
            services = new Services(ref cfg);
            PopulateSelect(); // initialize Select to populate services first
            PopulateMonitor();
            PopulateOptions();

            logger.Write("-----------------------------------------------");
            logger.Write(cfg.Program + " Version " + cfg.Version + " started");
            services.LogMonitoredServices(logger);

            // Setup the Monitor tab update timer
            monitorUpdateTimer = new Timer();
            monitorUpdateTimer.Interval = 1000; // 1 second
            monitorUpdateTimer.Tick += EventMonitorUpdateTick;

            // Write the JSON configuration file and create/update the Task Scheduler task
            SaveUserPreferences();
        }
        // -----------------------------------------------------------------------------------------------------------------------

        #region Event Handlers

        private static int WM_QUERYENDSESSION = 0x11;
        private static bool systemShutdown = false;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg==WM_QUERYENDSESSION)
            {
                logger.Write("System shutdown event");
                systemShutdown = true;
            }

            // If this is WM_QUERYENDSESSION, the closing event should be
            // raised in the base WndProc.
            base.WndProc(ref m);

        } //WndProc

        private void EventFormClosing(object sender, FormClosingEventArgs e)
        {
            if (systemShutdown)
            {
                // Gracefully exit
                logger.Write("System shutdown, exiting gracefully");
                ctxt.Exit(sender, e);
            }

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

                // Reorder and resize the Monitor and Select tab columns
                OrderSizeColumns();

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
            if (services.monitoredServices.Count < 1)
            {
                // switch to the Select tab
                tabControl.SelectedIndex = 1;

                MessageBox.Show(cfg.Program +
                                " has no services selected.\r\n\r\nPlease select one or more services to monitor & manage. Check the" +
                                " \"Sel\" for each desired service on the Select tab, Save your choices, then goto the Monitor tab",
                    "No services Selected",
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

        private void EventLogButtonBottom(object sender, EventArgs e)
        {
            logTextBox.Focus();
            logTextBox.SelectionStart = logger.logBuffer.Length - 1;
            logTextBox.ScrollToCaret();
        }

        private void EventLogButtonClear(object sender, EventArgs e)
        {
            logger.Clear();
        }

        private void EventLogButtonSave(object sender, EventArgs e)
        {
            logger.Save();
        }

        private void EventLogButtonView(object sender, EventArgs e)
        {
            logger.Save();
            Process.Start(logger.GetLogFilename());
        }

        private void EventMenuCheckForUpdates(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path, "Updater.exe");
            Process.Start(path);
        }

        private void EventMenuHelpAbout(object sender, EventArgs e)
        {
            new AboutForm(this, cfg);
        }

        private void EventMenuHelpOnlineDocumentation(object sender, EventArgs e)
        {
            var url = "https://corionis.github.io/CorionisServiceManager.NET/";
            Process.Start("explorer.exe", "\"" + @"" + url + "\"");
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

        private void EventMenuViewMinify(object sender, EventArgs e)
        {
            menuStrip.Visible = false;
            tabControl.Visible = false;

            if (miniPanel == null)
            {
                miniPanel = new Panel();
                miniPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                miniPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
                miniPanel.Location = new System.Drawing.Point(0, 6);
                miniPanel.Margin = new System.Windows.Forms.Padding(4);
                miniPanel.Name = "tabControl";
                miniPanel.Size = new System.Drawing.Size(803, 450);
                miniPanel.TabIndex = 1;
                Controls.Add(miniPanel);
            }

            miniPanel.SuspendLayout();
            miniPanel.Controls.Add(dataGridViewMonitor);
            miniPanel.Controls.Add(toolStripMonitor);
            toolStripMonitorToggleMinify.Image = Properties.Resources.arrow_down;
            toolStripMonitorToggleMinify.ToolTipText = "Expand";
            miniPanel.Visible = false;

            originalFormHeight = this.Height;
            Height = CalculateMinifyHeight();

            miniPanel.ResumeLayout();
            miniPanel.Visible = true;
            cfg.IsMinified = true;

            AugmentMonitorCells();
            EventMonitorUpdateTick(sender, e);
            tabMonitor.Refresh();
            Refresh();
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

        private void EventMonitorButtonToggleMinify(object sender, EventArgs e)
        {
            if (miniPanel != null && miniPanel.Visible == true)
            {
                cfg.IsMinified = false;
                miniPanel.Visible = false;
                tabMonitor.Controls.Add(this.dataGridViewMonitor);
                tabMonitor.Controls.Add(toolStripMonitor);
                toolStripMonitorToggleMinify.Image = Properties.Resources.arrow_up;
                toolStripMonitorToggleMinify.ToolTipText = "Minify";
                menuStrip.Visible = true;
                tabControl.Visible = true;
                this.Height = originalFormHeight;
                Refresh();
            }
            else
            {
                EventMenuViewMinify(sender, e);
            }
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
                        services.monitoredServices[e.RowIndex].Picked = sense;
                        dataGridViewMonitor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (sense) ? "True" : "False";
                        dgv.EndEdit();
                    }
                }
            }
            else // It is a column header, perform sort
            {
                var name = dataGridViewMonitor.Columns[e.ColumnIndex].HeaderText;
                if (!name.Equals("Sel"))
                {
                    // reset mode & glyph in all column headers
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

                    // progress the mode through the 3 states
                    monitorSortMode = (monitorSortMode == SortOrder.None) ? SortOrder.Ascending :
                        (monitorSortMode == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.None;

                    // set this column header glyph
                    dataGridViewMonitor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = monitorSortMode;

                    if (monitorSortMode != SortOrder.None)
                    {
                        if (monitorSortMode == SortOrder.Ascending)
                        {
                            if (name.Equals("Name"))
                            {
                                services.monitoredServices.Sort((x, y) =>
                                    String.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
                            }
                            else if (name.Equals("Identifier"))
                            {
                                services.monitoredServices.Sort((x, y) =>
                                    String.Compare(x.Identifier, y.Identifier, StringComparison.Ordinal));
                            }
                            else if (name.Equals("Start"))
                            {
                                services.monitoredServices.Sort((x, y) =>
                                    String.Compare(x.Startup, y.Startup, StringComparison.Ordinal));
                            }
                            else if (name.Equals("Status"))
                            {
                                services.monitoredServices.Sort((x, y) =>
                                    String.Compare(x.Status, y.Status, StringComparison.Ordinal));
                            }
                            else
                            {
                                throw new Exception("unknown column name");
                            }
                        }
                        else
                        {
                            if (name.Equals("Name"))
                            {
                                services.monitoredServices.Sort((x, y) =>
                                    String.Compare(y.Name, x.Name, StringComparison.Ordinal));
                            }
                            else if (name.Equals("Identifier"))
                            {
                                services.monitoredServices.Sort((x, y) =>
                                    String.Compare(y.Identifier, x.Identifier, StringComparison.Ordinal));
                            }
                            else if (name.Equals("Start"))
                            {
                                services.monitoredServices.Sort((x, y) =>
                                    String.Compare(y.Startup, x.Startup, StringComparison.Ordinal));
                            }
                            else if (name.Equals("Status"))
                            {
                                services.monitoredServices.Sort((x, y) =>
                                    String.Compare(y.Status, x.Status, StringComparison.Ordinal));
                            }
                            else
                            {
                                throw new Exception("unknown column name");
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
        }

        private void EventMonitorCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var name = dataGridViewSelect.Columns[e.ColumnIndex].HeaderText;

            // Save changes if a Name has been edited
            if (name.Equals("Name"))
            {
                SaveUserPreferences();
            }
        }

        public void EventMonitorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                // ignore F3 Sort, direct sorting does not support it
                e.Handled = true;
            }
        }

        private void EventMonitorUpdateTick(object sender, EventArgs e)
        {
            if (!updateTickActive && services != null && services.selectedServices != null && services.selectedServices.Length > 0)
            {
                updateTickActive = true;
                dataGridViewMonitor.ClearSelection();

                foreach (var service in services.selectedServices)
                {
                    var row = GetRowByIdentifier(dataGridViewMonitor, service.ServiceName);
                    if (row != null)
                    {
                        service.Refresh();
                        var status = service.Status.ToString();

                        MonitoredService mon = services.monitoredServices.First(id => id.Identifier == service.ServiceName);
                        var current = mon.Status;
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

                        if (!status.Equals(current))
                        {
                            ctxt.Popup(cfg.GetProgramTitle(), $"Service {mon.Name} is {status}");
                            logger.Write("Service " + mon.Name + " is " + status);
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
            services.GetSelectedServices();
            dataGridViewMonitor.DataSource = services.monitoredServices; // required to get new instance
            AugmentMonitorCells();
            dataGridViewMonitor.Refresh();
            services.LogMonitoredServices(logger);
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
            if (e.RowIndex > -1)
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
            else // It is a column header, perform sort
            {
                var name = dataGridViewSelect.Columns[e.ColumnIndex].HeaderText;
                if (!name.Equals("Sel"))
                {
                    // reset mode & glyph in all column headers
                    if (selectSortColumnIndex != e.ColumnIndex)
                    {
                        for (int i = 0; i < dataGridViewSelect.Columns.Count; ++i)
                        {
                            dataGridViewSelect.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                        }

                        selectSortMode = SortOrder.None;
                        dataGridViewSelect.Refresh();
                        selectSortColumnIndex = e.ColumnIndex;
                    }

                    // progress the mode through the 3 states
                    selectSortMode = (selectSortMode == SortOrder.None) ? SortOrder.Ascending :
                        (selectSortMode == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.None;

                    // set this column header glyph
                    dataGridViewSelect.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = selectSortMode;

                    if (selectSortMode != SortOrder.None)
                    {
                        var sorter = new ServiceSorter(name, selectSortMode == SortOrder.Ascending);
                        Array.Sort(services.allServices, sorter);
                    }
                    else
                    {
                        // Reset context of Select tab data
                        cfg.Load();
                        PopulateSelect();
                        selectSortMode = SortOrder.None;
                        selectSortColumnIndex = -1;
                    }

                    dataGridViewSelect.Refresh();
                }
            }
        }

        public void EventSelectKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                // ignore F3 Sort
                e.Handled = true;
            }
        }

        private void EventTabFocused(object sender, EventArgs e)
        {
            if (((TabControl) sender).SelectedTab.Name.Equals("tabLog"))
            {
                logTextBox.Focus();
                logTextBox.SelectionStart = logger.logBuffer.Length - 1;
                logTextBox.ScrollToCaret();
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
                /* The tooltip obscures the control and clicks are missed
                if (!asAdmin)
                {
                    cell.ToolTipText = cfg.ShowGridTooltips ? "Click to select (Disabled)" : "";
                }
                else
                    cell.ToolTipText = cfg.ShowGridTooltips ? "Click to select" : "";
                */

                cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Name");
                cell.ToolTipText = cfg.ShowGridTooltips ? "Click or F2 to edit" : "";

                cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Identifier");
                string ttt = cfg.ShowGridTooltips ? "Drag 'n Drop to move row" : "";

                cell.ToolTipText = ttt;
                cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Start");
                cell.ToolTipText = ttt;
                cell = row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == "Status");
                cell.ToolTipText = ttt;
            }
        }

        private int CalculateMinifyHeight()
        {
            int height = Size.Height - ClientSize.Height + toolStripMonitor.Height;
            if (dataGridViewMonitor != null && dataGridViewMonitor.Rows != null)
            {
                height += dataGridViewMonitor.ColumnHeadersHeight;
                height += dataGridViewMonitor.Rows[0].Height * dataGridViewMonitor.Rows.Count;
            }

            return height;
        }

        private string GetColumnValue(DataGridViewCellCollection cells, string headerName)
        {
            var c = cells.Cast<DataGridViewCell>().First(o => o.OwningColumn.HeaderText == headerName);
            var v = c.FormattedValue.ToString();
            return v;
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
                    var service = services.selectedServices.First(s => s.ServiceName == id);
                    service.Refresh();

                    switch (command.ToLower())
                    {
                        case "auto":
                            if (service.StartType != ServiceStartMode.Automatic)
                            {
                                ManageStartupType(service.ServiceName, service.DisplayName, "auto");
                            }

                            break;
                        case "disable":
                            if (service.StartType != ServiceStartMode.Disabled)
                            {
                                ManageStartupType(service.ServiceName, service.DisplayName, "disabled");
                            }

                            break;
                        case "manual":
                            if (service.StartType != ServiceStartMode.Manual)
                            {
                                ManageStartupType(service.ServiceName, service.DisplayName, "demand");
                            }

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

        private int ManageStartupType(String id, String name, String type)
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
                logger.Write("Service " + name + " set to " + type.ToUpper());
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
            MonitoredService moveRow = services.monitoredServices[from];
            services.monitoredServices.RemoveAt(from);
            if (to >= 0)
            {
                services.monitoredServices.Insert(to, moveRow);
            }
            else
            {
                // If dragged/sorted out-of-bounds add it to the bottom
                services.monitoredServices.Add(moveRow);
            }
        }

        public void OrderSizeColumns()
        {
            if (cfg.MonitorColumns != null && cfg.MonitorColumns.Length > 0)
            {
                for (int i = 0; i < dataGridViewMonitor.Columns.Count; ++i)
                {
                    for (int j = 0; j < cfg.MonitorColumns.Length; ++j)
                    {
                        if (cfg.MonitorColumns[j].Header.Equals(dataGridViewMonitor.Columns[i].HeaderText))
                        {
                            dataGridViewMonitor.Columns[i].Width = cfg.MonitorColumns[j].Width;
                            dataGridViewMonitor.Columns[i].DisplayIndex = cfg.MonitorColumns[j].Index;
                            break;
                        }
                    }
                }
            }
        }

        private void PopulateMonitor()
        {
            services.GetSelectedServices();
            dataGridViewMonitor.DataSource = services.monitoredServices;
        }

        private void PopulateOptions()
        {
            configBindingSource.DataSource = cfg;
            this.Text = cfg.GetProgramTitle();
            ctxt.trayIcon.Text = cfg.GetProgramTitle();
            ctxt.trayIcon.ContextMenu.MenuItems[0].Text = cfg.GetProgramTitle();

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
            services.GetAllServices();
            dataGridViewSelect.DataSource = services.allServices;
        }

        public bool RunningAsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            asAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            return asAdmin;
        }

        public void SaveSelectedServices()
        {
            // Copy monitored service names, that are editable, to the saved configuration
            cfg.SelectedServiceIds = new Config.ServiceIdNamePair[services.monitoredServices.Count];
            for (int i = 0; i < services.monitoredServices.Count; ++i)
            {
                var mon = services.monitoredServices[i];
                Config.ServiceIdNamePair pair = new Config.ServiceIdNamePair();
                pair.Identifier = mon.Identifier;
                pair.Name = mon.Name;
                cfg.SelectedServiceIds[i] = pair;
            }

            cfg.Save();
        }

        public void SaveUserPreferences()
        {
            bool WasMinified = cfg.IsMinified;

            // Un-Minify if necessary
            if (miniPanel != null && miniPanel.Visible == true)
            {
                WasMinified = true;
                EventMonitorButtonToggleMinify(null, null);
            }

            // Must be visible for coordinates to be valid
            if (Visible == false || WindowState == FormWindowState.Minimized)
            {
                ShowForm();
            }

            cfg.Left = Left;
            cfg.Top = Top;
            cfg.Width = Width;
            cfg.Height = Height;

            cfg.MonitorColumns = new Config.ColumnOrderSize[dataGridViewMonitor.Columns.Count];
            for (int i = 0; i < dataGridViewMonitor.Columns.Count; ++i)
            {
                cfg.MonitorColumns[i] = new Config.ColumnOrderSize();
                cfg.MonitorColumns[i].Header = dataGridViewMonitor.Columns[i].HeaderText;
                cfg.MonitorColumns[i].Width = dataGridViewMonitor.Columns[i].Width;
                cfg.MonitorColumns[i].Index = dataGridViewMonitor.Columns[i].DisplayIndex;
            }

            cfg.SelectColumns = new Config.ColumnOrderSize[dataGridViewSelect.Columns.Count];
            for (int i = 0; i < dataGridViewSelect.Columns.Count; ++i)
            {
                cfg.SelectColumns[i] = new Config.ColumnOrderSize();
                cfg.SelectColumns[i].Header = dataGridViewSelect.Columns[i].HeaderText;
                cfg.SelectColumns[i].Width = dataGridViewSelect.Columns[i].Width;
                cfg.SelectColumns[i].Index = dataGridViewSelect.Columns[i].DisplayIndex;
            }

            // Add the selected service & write the JSON configuration
            cfg.IsMinified = WasMinified;
            SaveSelectedServices();

            StartAtLogin();

            // Minify as necessary
            if (WasMinified == true)
            {
                EventMonitorButtonToggleMinify(null, null);
            }
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
            cd.AnyColor = true;
            cd.ShowHelp = false;
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
                    var task = ts.GetTask(cfg.Program);
                    if (task == null)
                    {
                        // Create a new task definition and assign properties
                        TaskDefinition td = ts.NewTask();
                        td.RegistrationInfo.Description = cfg.Program;
                        td.RegistrationInfo.Author = "Corionis, LLC";
                        td.RegistrationInfo.Date = DateTime.Now;

                        // Set "Run with highest privileges" to avoid UAC when managing services
                        td.Principal.RunLevel = TaskRunLevel.Highest;

                        // Create a trigger that will fire the task when the user logs-in
                        var trigger = new LogonTrigger();
                        trigger.Enabled = cfg.StartAtLogin;
                        td.Triggers.Add(trigger);

                        // Create an action that will launch this app whenever the trigger fires
                        td.Actions.Add(new ExecAction(Assembly.GetEntryAssembly().Location, "", null));

                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(cfg.Program, td);
                    }
                    else if (task != null)
                    {
                        task.Definition.Triggers[0].Enabled = cfg.StartAtLogin;
                        task.RegisterChanges();
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
                services.monitoredServices[i].Picked = sense;
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
        public class ServiceSorter : IComparer
        {
            public string ColumnName { get; set; }
            public bool IsAscending { get; set; }

            public ServiceSorter(string col, bool asc)
            {
                ColumnName = col;
                IsAscending = asc;
            }

            public int Compare(object x, object y)
            {
                string left = "";
                string right = "";
                if (ColumnName.Equals("Name"))
                {
                    left = ((ServiceController) x).DisplayName;
                    right = ((ServiceController) y).DisplayName;
                }
                else if (ColumnName.Equals("Identifier"))
                {
                    left = ((ServiceController) x).ServiceName;
                    right = ((ServiceController) y).ServiceName;
                }
                else if (ColumnName.Equals("Start"))
                {
                    left = ((ServiceController) x).StartType.ToString();
                    right = ((ServiceController) y).StartType.ToString();
                }
                else if (ColumnName.Equals("Status"))
                {
                    left = ((ServiceController) x).Status.ToString();
                    right = ((ServiceController) y).Status.ToString();
                }
                else
                {
                    throw new Exception("unknown column name");
                }

                if (IsAscending)
                {
                    return (new CaseInsensitiveComparer()).Compare(left, right);
                }
                else
                {
                    return (new CaseInsensitiveComparer()).Compare(right, left);
                }
            }
        }
    }
}