namespace CorionisServiceManager.NET
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheForm));
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
            this.tabLog = new System.Windows.Forms.TabPage();
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
            this.dataGridViewMonitor.TabIndex = 1;
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
            this.monitorPickedCheckBox.IndeterminateValue = "notused";
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
            this.toolStripMonitor.TabIndex = 0;
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
            this.dataGridViewSelect.TabIndex = 2;
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
    }
}