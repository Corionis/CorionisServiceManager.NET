namespace CSM
{
    partial class TheForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monitoredServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.servicesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripMonitor = new System.Windows.Forms.ToolStrip();
            this.toolStripMonitorStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripMonitorStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripMonitorDisable = new System.Windows.Forms.ToolStripButton();
            this.toolStripMonitorManual = new System.Windows.Forms.ToolStripButton();
            this.toolStripMonitorAuto = new System.Windows.Forms.ToolStripButton();
            this.tabSelect = new System.Windows.Forms.TabPage();
            this.toolStripSelect = new System.Windows.Forms.ToolStrip();
            this.toolStripSelectRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSelectCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSelectSave = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewSelect = new System.Windows.Forms.DataGridView();
            this.displayNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.monitoredServicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.servicesBindingSource1)).BeginInit();
            this.toolStripMonitor.SuspendLayout();
            this.tabSelect.SuspendLayout();
            this.toolStripSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.servicesBindingSource)).BeginInit();
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
            this.fileToolStripMenuItem.Text = "File";
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
            this.helpToolStripMenuItem.Text = "Help";
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
            this.tabControl.TabIndex = 2;
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
            this.tabMonitor.TabIndex = 0;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dataGridViewMonitor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.nameDataGridViewTextBoxColumn, this.identifierDataGridViewTextBoxColumn, this.startupDataGridViewTextBoxColumn, this.statusDataGridViewTextBoxColumn1});
            this.dataGridViewMonitor.DataSource = this.monitoredServicesBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMonitor.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMonitor.EnableHeadersVisualStyles = false;
            this.dataGridViewMonitor.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewMonitor.Name = "dataGridViewMonitor";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMonitor.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewMonitor.RowHeadersVisible = false;
            this.dataGridViewMonitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMonitor.Size = new System.Drawing.Size(785, 359);
            this.dataGridViewMonitor.TabIndex = 1;
            //
            // nameDataGridViewTextBoxColumn
            //
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ToolTipText = "Name of service - Editable";
            //
            // identifierDataGridViewTextBoxColumn
            //
            this.identifierDataGridViewTextBoxColumn.DataPropertyName = "Identifier";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.identifierDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.identifierDataGridViewTextBoxColumn.FillWeight = 90F;
            this.identifierDataGridViewTextBoxColumn.HeaderText = "Identifier";
            this.identifierDataGridViewTextBoxColumn.Name = "identifierDataGridViewTextBoxColumn";
            this.identifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.identifierDataGridViewTextBoxColumn.ToolTipText = "Internal service id";
            //
            // startupDataGridViewTextBoxColumn
            //
            this.startupDataGridViewTextBoxColumn.DataPropertyName = "Startup";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.startupDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.startupDataGridViewTextBoxColumn.FillWeight = 90F;
            this.startupDataGridViewTextBoxColumn.HeaderText = "Start Type";
            this.startupDataGridViewTextBoxColumn.Name = "startupDataGridViewTextBoxColumn";
            this.startupDataGridViewTextBoxColumn.ReadOnly = true;
            this.startupDataGridViewTextBoxColumn.ToolTipText = "Service startup type";
            //
            // statusDataGridViewTextBoxColumn1
            //
            this.statusDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusDataGridViewTextBoxColumn1.DataPropertyName = "Status";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.statusDataGridViewTextBoxColumn1.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn1.Name = "statusDataGridViewTextBoxColumn1";
            this.statusDataGridViewTextBoxColumn1.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn1.ToolTipText = "Current service status";
            this.statusDataGridViewTextBoxColumn1.Width = 62;
            //
            // monitoredServicesBindingSource
            //
            this.monitoredServicesBindingSource.DataMember = "monitoredServices";
            this.monitoredServicesBindingSource.DataSource = this.servicesBindingSource1;
            //
            // servicesBindingSource1
            //
            this.servicesBindingSource1.DataSource = typeof(CSM.Services);
            //
            // toolStripMonitor
            //
            this.toolStripMonitor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripMonitor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripMonitorStart, this.toolStripMonitorStop, this.toolStripMonitorDisable, this.toolStripMonitorManual, this.toolStripMonitorAuto});
            this.toolStripMonitor.Location = new System.Drawing.Point(3, 362);
            this.toolStripMonitor.MinimumSize = new System.Drawing.Size(0, 29);
            this.toolStripMonitor.Name = "toolStripMonitor";
            this.toolStripMonitor.Padding = new System.Windows.Forms.Padding(0, 3, 4, 2);
            this.toolStripMonitor.Size = new System.Drawing.Size(785, 29);
            this.toolStripMonitor.TabIndex = 0;
            this.toolStripMonitor.Text = "toolStripMonitor";
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
            // toolStripMonitorDisable
            //
            this.toolStripMonitorDisable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMonitorDisable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMonitorDisable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMonitorDisable.Image = ((System.Drawing.Image) (resources.GetObject("toolStripMonitorDisable.Image")));
            this.toolStripMonitorDisable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMonitorDisable.Name = "toolStripMonitorDisable";
            this.toolStripMonitorDisable.Size = new System.Drawing.Size(49, 21);
            this.toolStripMonitorDisable.Text = "&Disable";
            //
            // toolStripMonitorManual
            //
            this.toolStripMonitorManual.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMonitorManual.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMonitorManual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMonitorManual.Image = ((System.Drawing.Image) (resources.GetObject("toolStripMonitorManual.Image")));
            this.toolStripMonitorManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMonitorManual.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.toolStripMonitorManual.Name = "toolStripMonitorManual";
            this.toolStripMonitorManual.Size = new System.Drawing.Size(51, 21);
            this.toolStripMonitorManual.Text = "&Manual";
            //
            // toolStripMonitorAuto
            //
            this.toolStripMonitorAuto.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMonitorAuto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMonitorAuto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMonitorAuto.Image = ((System.Drawing.Image) (resources.GetObject("toolStripMonitorAuto.Image")));
            this.toolStripMonitorAuto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMonitorAuto.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.toolStripMonitorAuto.Name = "toolStripMonitorAuto";
            this.toolStripMonitorAuto.Size = new System.Drawing.Size(37, 21);
            this.toolStripMonitorAuto.Text = "&Auto";
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
            this.tabSelect.TabIndex = 1;
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
            this.toolStripSelect.TabIndex = 2;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.displayNameDataGridViewTextBoxColumn, this.serviceNameDataGridViewTextBoxColumn, this.startTypeDataGridViewTextBoxColumn, this.statusDataGridViewTextBoxColumn});
            this.dataGridViewSelect.DataSource = this.servicesBindingSource;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSelect.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelect.EnableHeadersVisualStyles = false;
            this.dataGridViewSelect.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSelect.Name = "dataGridViewSelect";
            this.dataGridViewSelect.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelect.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewSelect.RowHeadersVisible = false;
            this.dataGridViewSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelect.Size = new System.Drawing.Size(785, 388);
            this.dataGridViewSelect.TabIndex = 2;
            //
            // displayNameDataGridViewTextBoxColumn
            //
            this.displayNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.displayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName";
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.displayNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.displayNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.displayNameDataGridViewTextBoxColumn.Name = "displayNameDataGridViewTextBoxColumn";
            this.displayNameDataGridViewTextBoxColumn.ReadOnly = true;
            //
            // serviceNameDataGridViewTextBoxColumn
            //
            this.serviceNameDataGridViewTextBoxColumn.DataPropertyName = "ServiceName";
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.serviceNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.serviceNameDataGridViewTextBoxColumn.FillWeight = 90F;
            this.serviceNameDataGridViewTextBoxColumn.HeaderText = "Identifier";
            this.serviceNameDataGridViewTextBoxColumn.Name = "serviceNameDataGridViewTextBoxColumn";
            this.serviceNameDataGridViewTextBoxColumn.ReadOnly = true;
            //
            // startTypeDataGridViewTextBoxColumn
            //
            this.startTypeDataGridViewTextBoxColumn.DataPropertyName = "StartType";
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.startTypeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.startTypeDataGridViewTextBoxColumn.FillWeight = 90F;
            this.startTypeDataGridViewTextBoxColumn.HeaderText = "Start Type";
            this.startTypeDataGridViewTextBoxColumn.Name = "startTypeDataGridViewTextBoxColumn";
            this.startTypeDataGridViewTextBoxColumn.ReadOnly = true;
            //
            // statusDataGridViewTextBoxColumn
            //
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 62;
            //
            // servicesBindingSource
            //
            this.servicesBindingSource.DataMember = "allServices";
            this.servicesBindingSource.DataSource = typeof(CSM.Services);
            //
            // tabOptions
            //
            this.tabOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabOptions.Location = new System.Drawing.Point(4, 24);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(795, 398);
            this.tabOptions.TabIndex = 2;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            //
            // tabLog
            //
            this.tabLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabLog.Location = new System.Drawing.Point(4, 24);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(795, 398);
            this.tabLog.TabIndex = 3;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // TheForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TheForm";
            this.Text = "Corionis Service Manager";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabMonitor.ResumeLayout(false);
            this.tabMonitor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.monitoredServicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.servicesBindingSource1)).EndInit();
            this.toolStripMonitor.ResumeLayout(false);
            this.toolStripMonitor.PerformLayout();
            this.tabSelect.ResumeLayout(false);
            this.tabSelect.PerformLayout();
            this.toolStripSelect.ResumeLayout(false);
            this.toolStripSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.servicesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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
        private System.Windows.Forms.BindingSource monitoredServicesBindingSource;
        private System.Windows.Forms.BindingSource servicesBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}