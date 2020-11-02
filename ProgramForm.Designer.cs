namespace CorionisServiceManager.NET
{
    partial class ProgramForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMonitor = new System.Windows.Forms.TabPage();
            this.dataGridViewMonitor = new System.Windows.Forms.DataGridView();
            this.monitorPickedCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.monitorNameTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monitorIdentifierTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monitorStartupTypeTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monitorStatusTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monitoredServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripMonitor = new System.Windows.Forms.ToolStrip();
            this.toolStripMonitorAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripMonitorNone = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMonitorStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripMonitorStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMonitorAuto = new System.Windows.Forms.ToolStripButton();
            this.toolStripMonitorManual = new System.Windows.Forms.ToolStripButton();
            this.toolStripMonitorDisable = new System.Windows.Forms.ToolStripButton();
            this.tabSelect = new System.Windows.Forms.TabPage();
            this.toolStripSelect = new System.Windows.Forms.ToolStrip();
            this.toolStripSelectRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSelectCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSelectSave = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewSelect = new System.Windows.Forms.DataGridView();
            this.selectNameTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectIdentifierTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectStartupTypeTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectStatusTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxBehavior = new System.Windows.Forms.GroupBox();
            this.optionsCheckBoxLogToFile = new System.Windows.Forms.CheckBox();
            this.configBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxMonitorColors = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.optionsRunningFore = new System.Windows.Forms.Label();
            this.optionsUnknownBack = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.optionsStoppedFore = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.optionsStoppedBack = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.optionsRunningBack = new System.Windows.Forms.Label();
            this.optionsUnknownFore = new System.Windows.Forms.Label();
            this.optionsCheckBoxDisplayNotifications = new System.Windows.Forms.CheckBox();
            this.optionsTextBoxFriendlyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optionsCheckBoxDisplayMinimizedNotifications = new System.Windows.Forms.CheckBox();
            this.optionsCheckBoxStartAtLogin = new System.Windows.Forms.CheckBox();
            this.optionsCheckBoxStartMinimized = new System.Windows.Forms.CheckBox();
            this.optionsCheckBoxMinimizeOnClose = new System.Windows.Forms.CheckBox();
            this.optionsCheckBoxHideWhenMinimized = new System.Windows.Forms.CheckBox();
            this.optionsCheckBoxShowGridTooltips = new System.Windows.Forms.CheckBox();
            this.toolStripOptions = new System.Windows.Forms.ToolStrip();
            this.toolStripOptionsCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripOptionsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripOptionsDefault = new System.Windows.Forms.ToolStripButton();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.monitoredServicesBindingSource)).BeginInit();
            this.toolStripMonitor.SuspendLayout();
            this.tabSelect.SuspendLayout();
            this.toolStripSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.servicesBindingSource)).BeginInit();
            this.tabOptions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxBehavior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.configBindingSource)).BeginInit();
            this.groupBoxMonitorColors.SuspendLayout();
            this.toolStripOptions.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip
            //
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileToolStripMenuItem, this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(803, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            //
            // fileToolStripMenuItem
            //
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.restartToolStripMenuItem, this.toolStripSeparator1, this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            //
            // restartToolStripMenuItem
            //
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(107, 6);
            //
            // exitToolStripMenuItem
            //
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            //
            // helpToolStripMenuItem
            //
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.onlineDocumentationToolStripMenuItem, this.toolStripSeparator3, this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            //
            // onlineDocumentationToolStripMenuItem
            //
            this.onlineDocumentationToolStripMenuItem.Name = "onlineDocumentationToolStripMenuItem";
            this.onlineDocumentationToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.onlineDocumentationToolStripMenuItem.Text = "Online &documentation";
            //
            // toolStripSeparator3
            //
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(191, 6);
            //
            // aboutToolStripMenuItem
            //
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            //
            // tabControl
            //
            this.tabControl.AllowDrop = true;
            this.tabControl.Controls.Add(this.tabMonitor);
            this.tabControl.Controls.Add(this.tabSelect);
            this.tabControl.Controls.Add(this.tabOptions);
            this.tabControl.Controls.Add(this.tabLog);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(4, 4);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(803, 426);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            //
            // tabMonitor
            //
            this.tabMonitor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabMonitor.Controls.Add(this.dataGridViewMonitor);
            this.tabMonitor.Controls.Add(this.toolStripMonitor);
            this.tabMonitor.Location = new System.Drawing.Point(4, 24);
            this.tabMonitor.Name = "tabMonitor";
            this.tabMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonitor.Size = new System.Drawing.Size(795, 398);
            this.tabMonitor.TabIndex = 2;
            this.tabMonitor.Text = "Monitor";
            this.tabMonitor.UseVisualStyleBackColor = true;
            //
            // dataGridViewMonitor
            //
            this.dataGridViewMonitor.AllowDrop = true;
            this.dataGridViewMonitor.AllowUserToAddRows = false;
            this.dataGridViewMonitor.AllowUserToDeleteRows = false;
            this.dataGridViewMonitor.AllowUserToOrderColumns = true;
            this.dataGridViewMonitor.AllowUserToResizeRows = false;
            this.dataGridViewMonitor.AutoGenerateColumns = false;
            this.dataGridViewMonitor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMonitor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            this.dataGridViewMonitor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.monitorPickedCheckBox, this.monitorNameTextBox, this.monitorIdentifierTextBox, this.monitorStartupTypeTextBox, this.monitorStatusTextBox});
            this.dataGridViewMonitor.DataSource = this.monitoredServicesBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMonitor.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMonitor.EnableHeadersVisualStyles = false;
            this.dataGridViewMonitor.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMonitor.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewMonitor.Name = "dataGridViewMonitor";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMonitor.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewMonitor.RowHeadersVisible = false;
            this.dataGridViewMonitor.Size = new System.Drawing.Size(785, 359);
            this.dataGridViewMonitor.TabIndex = 0;
            //
            // monitorPickedCheckBox
            //
            this.monitorPickedCheckBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.monitorPickedCheckBox.DataPropertyName = "Picked";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.monitorPickedCheckBox.DefaultCellStyle = dataGridViewCellStyle2;
            this.monitorPickedCheckBox.FalseValue = "False";
            this.monitorPickedCheckBox.HeaderText = "Sel";
            this.monitorPickedCheckBox.IndeterminateValue = "False";
            this.monitorPickedCheckBox.MinimumWidth = 32;
            this.monitorPickedCheckBox.Name = "monitorPickedCheckBox";
            this.monitorPickedCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.monitorPickedCheckBox.ToolTipText = "Select";
            this.monitorPickedCheckBox.TrueValue = "True";
            this.monitorPickedCheckBox.Width = 32;
            //
            // monitorNameTextBox
            //
            this.monitorNameTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.monitorNameTextBox.DataPropertyName = "Name";
            this.monitorNameTextBox.HeaderText = "Name";
            this.monitorNameTextBox.Name = "monitorNameTextBox";
            this.monitorNameTextBox.ToolTipText = "Name of service - Editable";
            //
            // monitorIdentifierTextBox
            //
            this.monitorIdentifierTextBox.DataPropertyName = "Identifier";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.monitorIdentifierTextBox.DefaultCellStyle = dataGridViewCellStyle3;
            this.monitorIdentifierTextBox.FillWeight = 90F;
            this.monitorIdentifierTextBox.HeaderText = "Identifier";
            this.monitorIdentifierTextBox.Name = "monitorIdentifierTextBox";
            this.monitorIdentifierTextBox.ReadOnly = true;
            this.monitorIdentifierTextBox.ToolTipText = "Internal service id";
            //
            // monitorStartupTypeTextBox
            //
            this.monitorStartupTypeTextBox.DataPropertyName = "Startup";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.monitorStartupTypeTextBox.DefaultCellStyle = dataGridViewCellStyle4;
            this.monitorStartupTypeTextBox.FillWeight = 90F;
            this.monitorStartupTypeTextBox.HeaderText = "Start Type";
            this.monitorStartupTypeTextBox.Name = "monitorStartupTypeTextBox";
            this.monitorStartupTypeTextBox.ReadOnly = true;
            this.monitorStartupTypeTextBox.ToolTipText = "Service startup type";
            //
            // monitorStatusTextBox
            //
            this.monitorStatusTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.monitorStatusTextBox.DataPropertyName = "Status";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.monitorStatusTextBox.DefaultCellStyle = dataGridViewCellStyle5;
            this.monitorStatusTextBox.HeaderText = "Status";
            this.monitorStatusTextBox.Name = "monitorStatusTextBox";
            this.monitorStatusTextBox.ReadOnly = true;
            this.monitorStatusTextBox.ToolTipText = "Current service status";
            this.monitorStatusTextBox.Width = 62;
            //
            // monitoredServicesBindingSource
            //
            this.monitoredServicesBindingSource.DataMember = "monitoredServices";
            this.monitoredServicesBindingSource.DataSource = typeof(CorionisServiceManager.NET.Services);
            //
            // toolStripMonitor
            //
            this.toolStripMonitor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripMonitor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripMonitorAll, this.toolStripMonitorNone, this.toolStripSeparator4, this.toolStripMonitorStart, this.toolStripMonitorStop, this.toolStripSeparator2, this.toolStripMonitorAuto, this.toolStripMonitorManual, this.toolStripMonitorDisable});
            this.toolStripMonitor.Location = new System.Drawing.Point(3, 362);
            this.toolStripMonitor.MinimumSize = new System.Drawing.Size(0, 29);
            this.toolStripMonitor.Name = "toolStripMonitor";
            this.toolStripMonitor.Padding = new System.Windows.Forms.Padding(0, 3, 4, 2);
            this.toolStripMonitor.Size = new System.Drawing.Size(785, 29);
            this.toolStripMonitor.TabIndex = 1;
            this.toolStripMonitor.Text = "toolStripMonitor";
            //
            // toolStripMonitorAll
            //
            this.toolStripMonitorAll.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMonitorAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMonitorAll.Image = ((System.Drawing.Image) (resources.GetObject("toolStripMonitorAll.Image")));
            this.toolStripMonitorAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMonitorAll.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.toolStripMonitorAll.Name = "toolStripMonitorAll";
            this.toolStripMonitorAll.Size = new System.Drawing.Size(25, 21);
            this.toolStripMonitorAll.Text = "All";
            //
            // toolStripMonitorNone
            //
            this.toolStripMonitorNone.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMonitorNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMonitorNone.Image = ((System.Drawing.Image) (resources.GetObject("toolStripMonitorNone.Image")));
            this.toolStripMonitorNone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMonitorNone.Name = "toolStripMonitorNone";
            this.toolStripMonitorNone.Size = new System.Drawing.Size(40, 21);
            this.toolStripMonitorNone.Text = "None";
            //
            // toolStripSeparator4
            //
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 24);
            //
            // toolStripMonitorStart
            //
            this.toolStripMonitorStart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMonitorStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMonitorStart.Image = ((System.Drawing.Image) (resources.GetObject("toolStripMonitorStart.Image")));
            this.toolStripMonitorStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMonitorStart.Name = "toolStripMonitorStart";
            this.toolStripMonitorStart.Size = new System.Drawing.Size(35, 21);
            this.toolStripMonitorStart.Text = "&Start";
            //
            // toolStripMonitorStop
            //
            this.toolStripMonitorStop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMonitorStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMonitorStop.Image = ((System.Drawing.Image) (resources.GetObject("toolStripMonitorStop.Image")));
            this.toolStripMonitorStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMonitorStop.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.toolStripMonitorStop.Name = "toolStripMonitorStop";
            this.toolStripMonitorStop.Size = new System.Drawing.Size(35, 21);
            this.toolStripMonitorStop.Text = "St&op";
            //
            // toolStripSeparator2
            //
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 24);
            //
            // toolStripMonitorAuto
            //
            this.toolStripMonitorAuto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMonitorAuto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMonitorAuto.Image = ((System.Drawing.Image) (resources.GetObject("toolStripMonitorAuto.Image")));
            this.toolStripMonitorAuto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMonitorAuto.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.toolStripMonitorAuto.Name = "toolStripMonitorAuto";
            this.toolStripMonitorAuto.Size = new System.Drawing.Size(37, 21);
            this.toolStripMonitorAuto.Text = "&Auto";
            //
            // toolStripMonitorManual
            //
            this.toolStripMonitorManual.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMonitorManual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMonitorManual.Image = ((System.Drawing.Image) (resources.GetObject("toolStripMonitorManual.Image")));
            this.toolStripMonitorManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMonitorManual.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.toolStripMonitorManual.Name = "toolStripMonitorManual";
            this.toolStripMonitorManual.Size = new System.Drawing.Size(51, 21);
            this.toolStripMonitorManual.Text = "&Manual";
            //
            // toolStripMonitorDisable
            //
            this.toolStripMonitorDisable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMonitorDisable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMonitorDisable.Image = ((System.Drawing.Image) (resources.GetObject("toolStripMonitorDisable.Image")));
            this.toolStripMonitorDisable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMonitorDisable.Name = "toolStripMonitorDisable";
            this.toolStripMonitorDisable.Size = new System.Drawing.Size(49, 21);
            this.toolStripMonitorDisable.Text = "&Disable";
            //
            // tabSelect
            //
            this.tabSelect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabSelect.Controls.Add(this.toolStripSelect);
            this.tabSelect.Controls.Add(this.dataGridViewSelect);
            this.tabSelect.Location = new System.Drawing.Point(4, 24);
            this.tabSelect.Name = "tabSelect";
            this.tabSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelect.Size = new System.Drawing.Size(795, 398);
            this.tabSelect.TabIndex = 2;
            this.tabSelect.Text = "Select";
            this.tabSelect.UseVisualStyleBackColor = true;
            //
            // toolStripSelect
            //
            this.toolStripSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripSelectRefresh, this.toolStripSelectCancel, this.toolStripSelectSave});
            this.toolStripSelect.Location = new System.Drawing.Point(3, 362);
            this.toolStripSelect.MinimumSize = new System.Drawing.Size(0, 29);
            this.toolStripSelect.Name = "toolStripSelect";
            this.toolStripSelect.Padding = new System.Windows.Forms.Padding(0, 3, 4, 2);
            this.toolStripSelect.Size = new System.Drawing.Size(785, 29);
            this.toolStripSelect.TabIndex = 1;
            this.toolStripSelect.TabStop = true;
            this.toolStripSelect.Text = "toolStripSelect";
            //
            // toolStripSelectRefresh
            //
            this.toolStripSelectRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripSelectRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSelectRefresh.Image = ((System.Drawing.Image) (resources.GetObject("toolStripSelectRefresh.Image")));
            this.toolStripSelectRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSelectRefresh.Name = "toolStripSelectRefresh";
            this.toolStripSelectRefresh.Size = new System.Drawing.Size(50, 21);
            this.toolStripSelectRefresh.Text = "&Refresh";
            //
            // toolStripSelectCancel
            //
            this.toolStripSelectCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSelectCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripSelectCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSelectCancel.Image = ((System.Drawing.Image) (resources.GetObject("toolStripSelectCancel.Image")));
            this.toolStripSelectCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSelectCancel.Name = "toolStripSelectCancel";
            this.toolStripSelectCancel.Size = new System.Drawing.Size(47, 21);
            this.toolStripSelectCancel.Text = "&Cancel";
            //
            // toolStripSelectSave
            //
            this.toolStripSelectSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSelectSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripSelectSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSelectSave.Image = ((System.Drawing.Image) (resources.GetObject("toolStripSelectSave.Image")));
            this.toolStripSelectSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSelectSave.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.toolStripSelectSave.Name = "toolStripSelectSave";
            this.toolStripSelectSave.Size = new System.Drawing.Size(35, 21);
            this.toolStripSelectSave.Text = "&Save";
            //
            // dataGridViewSelect
            //
            this.dataGridViewSelect.AllowUserToAddRows = false;
            this.dataGridViewSelect.AllowUserToDeleteRows = false;
            this.dataGridViewSelect.AllowUserToOrderColumns = true;
            this.dataGridViewSelect.AllowUserToResizeRows = false;
            this.dataGridViewSelect.AutoGenerateColumns = false;
            this.dataGridViewSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSelect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.selectNameTextBox, this.selectIdentifierTextBox, this.selectStartupTypeTextBox, this.selectStatusTextBox});
            this.dataGridViewSelect.DataSource = this.servicesBindingSource;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSelect.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelect.EnableHeadersVisualStyles = false;
            this.dataGridViewSelect.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSelect.Name = "dataGridViewSelect";
            this.dataGridViewSelect.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelect.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewSelect.RowHeadersVisible = false;
            this.dataGridViewSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelect.Size = new System.Drawing.Size(785, 388);
            this.dataGridViewSelect.TabIndex = 0;
            //
            // selectNameTextBox
            //
            this.selectNameTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.selectNameTextBox.DataPropertyName = "DisplayName";
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.selectNameTextBox.DefaultCellStyle = dataGridViewCellStyle9;
            this.selectNameTextBox.HeaderText = "Name";
            this.selectNameTextBox.Name = "selectNameTextBox";
            this.selectNameTextBox.ReadOnly = true;
            //
            // selectIdentifierTextBox
            //
            this.selectIdentifierTextBox.DataPropertyName = "ServiceName";
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.selectIdentifierTextBox.DefaultCellStyle = dataGridViewCellStyle10;
            this.selectIdentifierTextBox.FillWeight = 90F;
            this.selectIdentifierTextBox.HeaderText = "Identifier";
            this.selectIdentifierTextBox.Name = "selectIdentifierTextBox";
            this.selectIdentifierTextBox.ReadOnly = true;
            //
            // selectStartupTypeTextBox
            //
            this.selectStartupTypeTextBox.DataPropertyName = "StartType";
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.selectStartupTypeTextBox.DefaultCellStyle = dataGridViewCellStyle11;
            this.selectStartupTypeTextBox.FillWeight = 90F;
            this.selectStartupTypeTextBox.HeaderText = "Start Type";
            this.selectStartupTypeTextBox.Name = "selectStartupTypeTextBox";
            this.selectStartupTypeTextBox.ReadOnly = true;
            //
            // selectStatusTextBox
            //
            this.selectStatusTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.selectStatusTextBox.DataPropertyName = "Status";
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.selectStatusTextBox.DefaultCellStyle = dataGridViewCellStyle12;
            this.selectStatusTextBox.HeaderText = "Status";
            this.selectStatusTextBox.Name = "selectStatusTextBox";
            this.selectStatusTextBox.ReadOnly = true;
            this.selectStatusTextBox.Width = 62;
            //
            // servicesBindingSource
            //
            this.servicesBindingSource.DataMember = "allServices";
            this.servicesBindingSource.DataSource = typeof(CorionisServiceManager.NET.Services);
            //
            // tabOptions
            //
            this.tabOptions.BackColor = System.Drawing.Color.Transparent;
            this.tabOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabOptions.Controls.Add(this.panel1);
            this.tabOptions.Controls.Add(this.toolStripOptions);
            this.tabOptions.Location = new System.Drawing.Point(4, 24);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(795, 398);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            //
            // panel1
            //
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.groupBoxBehavior);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 359);
            this.panel1.TabIndex = 1;
            //
            // groupBoxBehavior
            //
            this.groupBoxBehavior.AutoSize = true;
            this.groupBoxBehavior.BackColor = System.Drawing.SystemColors.Window;
            this.groupBoxBehavior.Controls.Add(this.optionsCheckBoxLogToFile);
            this.groupBoxBehavior.Controls.Add(this.groupBoxMonitorColors);
            this.groupBoxBehavior.Controls.Add(this.optionsCheckBoxDisplayNotifications);
            this.groupBoxBehavior.Controls.Add(this.optionsTextBoxFriendlyName);
            this.groupBoxBehavior.Controls.Add(this.label1);
            this.groupBoxBehavior.Controls.Add(this.optionsCheckBoxDisplayMinimizedNotifications);
            this.groupBoxBehavior.Controls.Add(this.optionsCheckBoxStartAtLogin);
            this.groupBoxBehavior.Controls.Add(this.optionsCheckBoxStartMinimized);
            this.groupBoxBehavior.Controls.Add(this.optionsCheckBoxMinimizeOnClose);
            this.groupBoxBehavior.Controls.Add(this.optionsCheckBoxHideWhenMinimized);
            this.groupBoxBehavior.Controls.Add(this.optionsCheckBoxShowGridTooltips);
            this.groupBoxBehavior.Location = new System.Drawing.Point(3, 3);
            this.groupBoxBehavior.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxBehavior.Name = "groupBoxBehavior";
            this.groupBoxBehavior.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxBehavior.Size = new System.Drawing.Size(357, 264);
            this.groupBoxBehavior.TabIndex = 0;
            this.groupBoxBehavior.TabStop = false;
            this.groupBoxBehavior.Text = "Behavior";
            //
            // optionsCheckBoxLogToFile
            //
            this.optionsCheckBoxLogToFile.AutoSize = true;
            this.optionsCheckBoxLogToFile.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "LogToFile", true));
            this.optionsCheckBoxLogToFile.Location = new System.Drawing.Point(12, 117);
            this.optionsCheckBoxLogToFile.Name = "optionsCheckBoxLogToFile";
            this.optionsCheckBoxLogToFile.Size = new System.Drawing.Size(72, 17);
            this.optionsCheckBoxLogToFile.TabIndex = 8;
            this.optionsCheckBoxLogToFile.Text = "Log to file";
            this.optionsCheckBoxLogToFile.UseVisualStyleBackColor = true;
            //
            // configBindingSource
            //
            this.configBindingSource.DataSource = typeof(CorionisServiceManager.NET.Config);
            //
            // groupBoxMonitorColors
            //
            this.groupBoxMonitorColors.AutoSize = true;
            this.groupBoxMonitorColors.BackColor = System.Drawing.SystemColors.Window;
            this.groupBoxMonitorColors.Controls.Add(this.label3);
            this.groupBoxMonitorColors.Controls.Add(this.optionsRunningFore);
            this.groupBoxMonitorColors.Controls.Add(this.optionsUnknownBack);
            this.groupBoxMonitorColors.Controls.Add(this.label4);
            this.groupBoxMonitorColors.Controls.Add(this.optionsStoppedFore);
            this.groupBoxMonitorColors.Controls.Add(this.label12);
            this.groupBoxMonitorColors.Controls.Add(this.label8);
            this.groupBoxMonitorColors.Controls.Add(this.label10);
            this.groupBoxMonitorColors.Controls.Add(this.optionsStoppedBack);
            this.groupBoxMonitorColors.Controls.Add(this.label6);
            this.groupBoxMonitorColors.Controls.Add(this.optionsRunningBack);
            this.groupBoxMonitorColors.Controls.Add(this.optionsUnknownFore);
            this.groupBoxMonitorColors.Location = new System.Drawing.Point(-3, 149);
            this.groupBoxMonitorColors.Name = "groupBoxMonitorColors";
            this.groupBoxMonitorColors.Size = new System.Drawing.Size(351, 99);
            this.groupBoxMonitorColors.TabIndex = 0;
            this.groupBoxMonitorColors.TabStop = false;
            this.groupBoxMonitorColors.Text = "Monitor Colors";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Running text:";
            //
            // optionsRunningFore
            //
            this.optionsRunningFore.BackColor = System.Drawing.Color.Black;
            this.optionsRunningFore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsRunningFore.CausesValidation = false;
            this.optionsRunningFore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsRunningFore.Location = new System.Drawing.Point(109, 18);
            this.optionsRunningFore.MaximumSize = new System.Drawing.Size(15, 15);
            this.optionsRunningFore.MinimumSize = new System.Drawing.Size(15, 15);
            this.optionsRunningFore.Name = "optionsRunningFore";
            this.optionsRunningFore.Size = new System.Drawing.Size(15, 15);
            this.optionsRunningFore.TabIndex = 30;
            //
            // optionsUnknownBack
            //
            this.optionsUnknownBack.AutoSize = true;
            this.optionsUnknownBack.BackColor = System.Drawing.Color.Yellow;
            this.optionsUnknownBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsUnknownBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsUnknownBack.Location = new System.Drawing.Point(316, 68);
            this.optionsUnknownBack.MinimumSize = new System.Drawing.Size(15, 15);
            this.optionsUnknownBack.Name = "optionsUnknownBack";
            this.optionsUnknownBack.Size = new System.Drawing.Size(15, 15);
            this.optionsUnknownBack.TabIndex = 5;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Stopped text:";
            //
            // optionsStoppedFore
            //
            this.optionsStoppedFore.AutoSize = true;
            this.optionsStoppedFore.BackColor = System.Drawing.Color.Black;
            this.optionsStoppedFore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsStoppedFore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsStoppedFore.Location = new System.Drawing.Point(109, 42);
            this.optionsStoppedFore.MinimumSize = new System.Drawing.Size(15, 15);
            this.optionsStoppedFore.Name = "optionsStoppedFore";
            this.optionsStoppedFore.Size = new System.Drawing.Size(15, 15);
            this.optionsStoppedFore.TabIndex = 2;
            //
            // label12
            //
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(185, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Unknown background:";
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(185, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Running background:";
            //
            // label10
            //
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(185, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Stopped background:";
            //
            // optionsStoppedBack
            //
            this.optionsStoppedBack.AutoSize = true;
            this.optionsStoppedBack.BackColor = System.Drawing.Color.Red;
            this.optionsStoppedBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsStoppedBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsStoppedBack.Location = new System.Drawing.Point(316, 42);
            this.optionsStoppedBack.MinimumSize = new System.Drawing.Size(15, 15);
            this.optionsStoppedBack.Name = "optionsStoppedBack";
            this.optionsStoppedBack.Size = new System.Drawing.Size(15, 15);
            this.optionsStoppedBack.TabIndex = 3;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Unknown text:";
            //
            // optionsRunningBack
            //
            this.optionsRunningBack.AutoSize = true;
            this.optionsRunningBack.BackColor = System.Drawing.Color.LawnGreen;
            this.optionsRunningBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsRunningBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsRunningBack.Location = new System.Drawing.Point(316, 18);
            this.optionsRunningBack.MinimumSize = new System.Drawing.Size(15, 15);
            this.optionsRunningBack.Name = "optionsRunningBack";
            this.optionsRunningBack.Size = new System.Drawing.Size(15, 15);
            this.optionsRunningBack.TabIndex = 1;
            //
            // optionsUnknownFore
            //
            this.optionsUnknownFore.AutoSize = true;
            this.optionsUnknownFore.BackColor = System.Drawing.Color.Black;
            this.optionsUnknownFore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsUnknownFore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsUnknownFore.Location = new System.Drawing.Point(109, 66);
            this.optionsUnknownFore.MinimumSize = new System.Drawing.Size(15, 15);
            this.optionsUnknownFore.Name = "optionsUnknownFore";
            this.optionsUnknownFore.Size = new System.Drawing.Size(15, 15);
            this.optionsUnknownFore.TabIndex = 4;
            //
            // optionsCheckBoxDisplayNotifications
            //
            this.optionsCheckBoxDisplayNotifications.AutoSize = true;
            this.optionsCheckBoxDisplayNotifications.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "DisplayNotifications", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optionsCheckBoxDisplayNotifications.Location = new System.Drawing.Point(12, 46);
            this.optionsCheckBoxDisplayNotifications.Name = "optionsCheckBoxDisplayNotifications";
            this.optionsCheckBoxDisplayNotifications.Size = new System.Drawing.Size(119, 17);
            this.optionsCheckBoxDisplayNotifications.TabIndex = 1;
            this.optionsCheckBoxDisplayNotifications.Text = "Display notifications";
            this.optionsCheckBoxDisplayNotifications.UseVisualStyleBackColor = true;
            //
            // optionsTextBoxFriendlyName
            //
            this.optionsTextBoxFriendlyName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configBindingSource, "FriendlyName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optionsTextBoxFriendlyName.Location = new System.Drawing.Point(188, 16);
            this.optionsTextBoxFriendlyName.Name = "optionsTextBoxFriendlyName";
            this.optionsTextBoxFriendlyName.Size = new System.Drawing.Size(143, 20);
            this.optionsTextBoxFriendlyName.TabIndex = 0;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Friendly name for title:";
            //
            // optionsCheckBoxDisplayMinimizedNotifications
            //
            this.optionsCheckBoxDisplayMinimizedNotifications.AutoSize = true;
            this.optionsCheckBoxDisplayMinimizedNotifications.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "DisplayMinimizedNotifications", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optionsCheckBoxDisplayMinimizedNotifications.Location = new System.Drawing.Point(12, 70);
            this.optionsCheckBoxDisplayMinimizedNotifications.Name = "optionsCheckBoxDisplayMinimizedNotifications";
            this.optionsCheckBoxDisplayMinimizedNotifications.Size = new System.Drawing.Size(167, 17);
            this.optionsCheckBoxDisplayMinimizedNotifications.TabIndex = 3;
            this.optionsCheckBoxDisplayMinimizedNotifications.Text = "Display minimized notifications";
            this.optionsCheckBoxDisplayMinimizedNotifications.UseVisualStyleBackColor = true;
            //
            // optionsCheckBoxStartAtLogin
            //
            this.optionsCheckBoxStartAtLogin.AutoSize = true;
            this.optionsCheckBoxStartAtLogin.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "StartAtLogin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optionsCheckBoxStartAtLogin.Location = new System.Drawing.Point(185, 46);
            this.optionsCheckBoxStartAtLogin.Name = "optionsCheckBoxStartAtLogin";
            this.optionsCheckBoxStartAtLogin.Size = new System.Drawing.Size(85, 17);
            this.optionsCheckBoxStartAtLogin.TabIndex = 2;
            this.optionsCheckBoxStartAtLogin.Text = "Start at login";
            this.optionsCheckBoxStartAtLogin.UseVisualStyleBackColor = true;
            //
            // optionsCheckBoxStartMinimized
            //
            this.optionsCheckBoxStartMinimized.AutoSize = true;
            this.optionsCheckBoxStartMinimized.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "StartMinimized", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optionsCheckBoxStartMinimized.Location = new System.Drawing.Point(185, 70);
            this.optionsCheckBoxStartMinimized.Name = "optionsCheckBoxStartMinimized";
            this.optionsCheckBoxStartMinimized.Size = new System.Drawing.Size(96, 17);
            this.optionsCheckBoxStartMinimized.TabIndex = 4;
            this.optionsCheckBoxStartMinimized.Text = "Start minimized";
            this.optionsCheckBoxStartMinimized.UseVisualStyleBackColor = true;
            //
            // optionsCheckBoxMinimizeOnClose
            //
            this.optionsCheckBoxMinimizeOnClose.AutoSize = true;
            this.optionsCheckBoxMinimizeOnClose.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "MinimizeOnClose", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optionsCheckBoxMinimizeOnClose.Location = new System.Drawing.Point(185, 94);
            this.optionsCheckBoxMinimizeOnClose.Name = "optionsCheckBoxMinimizeOnClose";
            this.optionsCheckBoxMinimizeOnClose.Size = new System.Drawing.Size(109, 17);
            this.optionsCheckBoxMinimizeOnClose.TabIndex = 6;
            this.optionsCheckBoxMinimizeOnClose.Text = "Minimize on close";
            this.optionsCheckBoxMinimizeOnClose.UseVisualStyleBackColor = true;
            //
            // optionsCheckBoxHideWhenMinimized
            //
            this.optionsCheckBoxHideWhenMinimized.AutoSize = true;
            this.optionsCheckBoxHideWhenMinimized.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "HideWhenMinimized", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optionsCheckBoxHideWhenMinimized.Location = new System.Drawing.Point(185, 117);
            this.optionsCheckBoxHideWhenMinimized.Name = "optionsCheckBoxHideWhenMinimized";
            this.optionsCheckBoxHideWhenMinimized.Size = new System.Drawing.Size(125, 17);
            this.optionsCheckBoxHideWhenMinimized.TabIndex = 7;
            this.optionsCheckBoxHideWhenMinimized.Text = "Hide when minimized";
            this.optionsCheckBoxHideWhenMinimized.UseVisualStyleBackColor = true;
            //
            // optionsCheckBoxShowGridTooltips
            //
            this.optionsCheckBoxShowGridTooltips.AutoSize = true;
            this.optionsCheckBoxShowGridTooltips.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.configBindingSource, "ShowGridTooltips", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optionsCheckBoxShowGridTooltips.Location = new System.Drawing.Point(12, 94);
            this.optionsCheckBoxShowGridTooltips.Name = "optionsCheckBoxShowGridTooltips";
            this.optionsCheckBoxShowGridTooltips.Size = new System.Drawing.Size(109, 17);
            this.optionsCheckBoxShowGridTooltips.TabIndex = 5;
            this.optionsCheckBoxShowGridTooltips.Text = "Show grid tooltips";
            this.optionsCheckBoxShowGridTooltips.UseVisualStyleBackColor = true;
            //
            // toolStripOptions
            //
            this.toolStripOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripOptionsCancel, this.toolStripOptionsSave, this.toolStripOptionsDefault});
            this.toolStripOptions.Location = new System.Drawing.Point(3, 362);
            this.toolStripOptions.MinimumSize = new System.Drawing.Size(0, 29);
            this.toolStripOptions.Name = "toolStripOptions";
            this.toolStripOptions.Padding = new System.Windows.Forms.Padding(0, 3, 4, 2);
            this.toolStripOptions.Size = new System.Drawing.Size(785, 29);
            this.toolStripOptions.TabIndex = 0;
            this.toolStripOptions.TabStop = true;
            this.toolStripOptions.Text = "toolStripOptions";
            //
            // toolStripOptionsCancel
            //
            this.toolStripOptionsCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripOptionsCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripOptionsCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripOptionsCancel.Image = ((System.Drawing.Image) (resources.GetObject("toolStripOptionsCancel.Image")));
            this.toolStripOptionsCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOptionsCancel.Name = "toolStripOptionsCancel";
            this.toolStripOptionsCancel.Size = new System.Drawing.Size(47, 21);
            this.toolStripOptionsCancel.Text = "&Cancel";
            //
            // toolStripOptionsSave
            //
            this.toolStripOptionsSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripOptionsSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripOptionsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripOptionsSave.Image = ((System.Drawing.Image) (resources.GetObject("toolStripOptionsSave.Image")));
            this.toolStripOptionsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOptionsSave.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.toolStripOptionsSave.Name = "toolStripOptionsSave";
            this.toolStripOptionsSave.Size = new System.Drawing.Size(35, 21);
            this.toolStripOptionsSave.Text = "&Save";
            //
            // toolStripOptionsDefault
            //
            this.toolStripOptionsDefault.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripOptionsDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripOptionsDefault.Image = ((System.Drawing.Image) (resources.GetObject("toolStripOptionsDefault.Image")));
            this.toolStripOptionsDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOptionsDefault.Name = "toolStripOptionsDefault";
            this.toolStripOptionsDefault.Size = new System.Drawing.Size(54, 21);
            this.toolStripOptionsDefault.Text = "&Defaults";
            //
            // tabLog
            //
            this.tabLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabLog.Location = new System.Drawing.Point(4, 24);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(795, 398);
            this.tabLog.TabIndex = 4;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            //
            // ProgramForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(412, 92);
            this.Name = "ProgramForm";
            this.Text = "Corionis Service Manager";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabMonitor.ResumeLayout(false);
            this.tabMonitor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.monitoredServicesBindingSource)).EndInit();
            this.toolStripMonitor.ResumeLayout(false);
            this.toolStripMonitor.PerformLayout();
            this.tabSelect.ResumeLayout(false);
            this.tabSelect.PerformLayout();
            this.toolStripSelect.ResumeLayout(false);
            this.toolStripSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.servicesBindingSource)).EndInit();
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxBehavior.ResumeLayout(false);
            this.groupBoxBehavior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.configBindingSource)).EndInit();
            this.groupBoxMonitorColors.ResumeLayout(false);
            this.groupBoxMonitorColors.PerformLayout();
            this.toolStripOptions.ResumeLayout(false);
            this.toolStripOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripButton toolStripMonitorAll;
        private System.Windows.Forms.ToolStripButton toolStripMonitorNone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

        private System.Windows.Forms.DataGridView dataGridViewSelect;

        private System.Windows.Forms.TabControl tabControl;

        private System.Windows.Forms.MenuStrip menuStrip;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TabPage tabMonitor;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.TabPage tabSelect;

        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineDocumentationToolStripMenuItem;

        #endregion

        private System.Windows.Forms.BindingSource monitoredServicesBindingSource;
        private System.Windows.Forms.BindingSource servicesBindingSource;
        private System.Windows.Forms.ToolStrip toolStripSelect;
        private System.Windows.Forms.ToolStripButton toolStripSelectRefresh;
        private System.Windows.Forms.ToolStripButton toolStripSelectCancel;
        private System.Windows.Forms.ToolStripButton toolStripSelectSave;
        private System.Windows.Forms.ToolStrip toolStripMonitor;
        private System.Windows.Forms.ToolStripButton toolStripMonitorStart;
        private System.Windows.Forms.ToolStripButton toolStripMonitorStop;
        private System.Windows.Forms.ToolStripButton toolStripMonitorAuto;
        private System.Windows.Forms.ToolStripButton toolStripMonitorManual;
        private System.Windows.Forms.ToolStripButton toolStripMonitorDisable;
        private System.Windows.Forms.DataGridView dataGridViewMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectNameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectIdentifierTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectStartupTypeTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectStatusTextBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn monitorPickedCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn monitorNameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn monitorIdentifierTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn monitorStartupTypeTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn monitorStatusTextBox;
        private System.Windows.Forms.ToolStrip toolStripOptions;
        private System.Windows.Forms.ToolStripButton toolStripOptionsCancel;
        private System.Windows.Forms.ToolStripButton toolStripOptionsSave;
        private System.Windows.Forms.CheckBox optionsCheckBoxDisplayMinimizedNotifications;
        private System.Windows.Forms.BindingSource configBindingSource;
        private System.Windows.Forms.CheckBox optionsCheckBoxDisplayNotifications;
        private System.Windows.Forms.TextBox optionsTextBoxFriendlyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox optionsCheckBoxStartAtLogin;
        private System.Windows.Forms.CheckBox optionsCheckBoxShowGridTooltips;
        private System.Windows.Forms.CheckBox optionsCheckBoxHideWhenMinimized;
        private System.Windows.Forms.CheckBox optionsCheckBoxMinimizeOnClose;
        private System.Windows.Forms.CheckBox optionsCheckBoxStartMinimized;
        private System.Windows.Forms.Label optionsUnknownBack;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label optionsStoppedBack;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label optionsRunningBack;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label optionsUnknownFore;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label optionsStoppedFore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label optionsRunningFore;
        private System.Windows.Forms.GroupBox groupBoxMonitorColors;
        private System.Windows.Forms.GroupBox groupBoxBehavior;
        private System.Windows.Forms.ToolStripButton toolStripOptionsDefault;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox optionsCheckBoxLogToFile;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}