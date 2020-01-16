namespace S7Connection
{
    partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtOrderCode = new System.Windows.Forms.TextBox();
            this.buttonReadCPUInfo = new System.Windows.Forms.Button();
            this.txtModuleName = new System.Windows.Forms.TextBox();
            this.txtAsName = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtModuleTypeName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LogData_textbox = new System.Windows.Forms.TextBox();
            this.LogData_button = new System.Windows.Forms.Button();
            this.LogData_label = new System.Windows.Forms.Label();
            this.LogData_checkbox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CPUStatus_label = new System.Windows.Forms.Label();
            this.CPUStatus_labelconst = new System.Windows.Forms.Label();
            this.textBoxSlot = new System.Windows.Forms.TextBox();
            this.textBoxRack = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.tabView = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.Miliseconds_checkBox = new System.Windows.Forms.CheckBox();
            this.Seconds_checkbox = new System.Windows.Forms.CheckBox();
            this.Minute_checkbox = new System.Windows.Forms.CheckBox();
            this.Hour_checkbox = new System.Windows.Forms.CheckBox();
            this.Day_checkbox = new System.Windows.Forms.CheckBox();
            this.Month_checkBox = new System.Windows.Forms.CheckBox();
            this.Year_checkbox = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.X_Interval_text = new System.Windows.Forms.TextBox();
            this.Xgrid_checkBox = new System.Windows.Forms.CheckBox();
            this.X_MinorGrid_checkbox = new System.Windows.Forms.CheckBox();
            this.X_Interval_label = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.Y_Interval_text = new System.Windows.Forms.TextBox();
            this.Maxscale_text = new System.Windows.Forms.TextBox();
            this.MinScale_text = new System.Windows.Forms.TextBox();
            this.Y_Interval_label = new System.Windows.Forms.Label();
            this.Ygrid_checkbox = new System.Windows.Forms.CheckBox();
            this.Y_MinorGrid_checkbox = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Maxscale_label = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Refresh_text = new System.Windows.Forms.TextBox();
            this.maxtime_textbox = new System.Windows.Forms.TextBox();
            this.Minimize_checkbox = new System.Windows.Forms.CheckBox();
            this.Legend_checkbox = new System.Windows.Forms.CheckBox();
            this.Refresh_label = new System.Windows.Forms.Label();
            this.maxtime_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ms_text = new System.Windows.Forms.Label();
            this.tabVariables = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Pause_checkBox = new System.Windows.Forms.CheckBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LoadVars_button = new System.Windows.Forms.Button();
            this.SaveVars_button = new System.Windows.Forms.Button();
            this.Variables_list = new System.Windows.Forms.ListBox();
            this.AddToChart_button = new System.Windows.Forms.Button();
            this.Remove_button = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dbPicker_button = new System.Windows.Forms.Button();
            this.DisplayFormat_comboBox = new System.Windows.Forms.ComboBox();
            this.Comment_textBox = new System.Windows.Forms.TextBox();
            this.PLCMax_textbox = new System.Windows.Forms.TextBox();
            this.PLCMin_textbox = new System.Windows.Forms.TextBox();
            this.MaxVal_textbox = new System.Windows.Forms.TextBox();
            this.MinVal_textbox = new System.Windows.Forms.TextBox();
            this.SymbolicName_text = new System.Windows.Forms.TextBox();
            this.Variable_text = new System.Windows.Forms.TextBox();
            this.Multiply_text = new System.Windows.Forms.TextBox();
            this.Add_text = new System.Windows.Forms.TextBox();
            this.DisplayFormat_label = new System.Windows.Forms.Label();
            this.Comment_label = new System.Windows.Forms.Label();
            this.calculate_checkbox = new System.Windows.Forms.CheckBox();
            this.PLCMax_label = new System.Windows.Forms.Label();
            this.PLCMin_label = new System.Windows.Forms.Label();
            this.MaxVal_label = new System.Windows.Forms.Label();
            this.MinVal_label = new System.Windows.Forms.Label();
            this.Modify_button = new System.Windows.Forms.Button();
            this.Multiply_label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.More_button = new System.Windows.Forms.Button();
            this.SymbolicName_label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Color_button = new System.Windows.Forms.Button();
            this.tabActual = new System.Windows.Forms.TabPage();
            this.Variables_dataGridView = new System.Windows.Forms.DataGridView();
            this.Adres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SymbolicName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Format = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabHelp = new System.Windows.Forms.TabPage();
            this.tabDown = new System.Windows.Forms.TabControl();
            this.ChartPage = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Chart1_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabDir = new System.Windows.Forms.TabPage();
            this.buttonGetDB = new System.Windows.Forms.Button();
            this.txtDBGet = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.buttonBlockInfo = new System.Windows.Forms.Button();
            this.txtBI = new System.Windows.Forms.TextBox();
            this.txtBlockNum = new System.Windows.Forms.TextBox();
            this.CBBlock = new System.Windows.Forms.ComboBox();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.CommunicationTimer = new System.Windows.Forms.Timer(this.components);
            this.InterfaceRefreshtimer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.CPU_STATUS = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabView.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabVariables.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabActual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Variables_dataGridView)).BeginInit();
            this.tabDown.SuspendLayout();
            this.ChartPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.Chart1_contextMenuStrip.SuspendLayout();
            this.tabTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabDir.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tabDown, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.textBoxError, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1080, 857);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabView);
            this.tabControl.Controls.Add(this.tabVariables);
            this.tabControl.Controls.Add(this.tabActual);
            this.tabControl.Controls.Add(this.tabHelp);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1080, 220);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.groupBox4);
            this.tabMain.Controls.Add(this.groupBox3);
            this.tabMain.Controls.Add(this.groupBox1);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1072, 194);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.txtVersion);
            this.groupBox4.Controls.Add(this.label39);
            this.groupBox4.Controls.Add(this.txtOrderCode);
            this.groupBox4.Controls.Add(this.buttonReadCPUInfo);
            this.groupBox4.Controls.Add(this.txtModuleName);
            this.groupBox4.Controls.Add(this.txtAsName);
            this.groupBox4.Controls.Add(this.txtSerialNumber);
            this.groupBox4.Controls.Add(this.txtModuleTypeName);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(512, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 188);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Unit Info";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 131);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(42, 13);
            this.label35.TabIndex = 42;
            this.label35.Text = "Version";
            // 
            // txtVersion
            // 
            this.txtVersion.Enabled = false;
            this.txtVersion.Location = new System.Drawing.Point(112, 128);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(48, 20);
            this.txtVersion.TabIndex = 41;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 108);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(61, 13);
            this.label39.TabIndex = 40;
            this.label39.Text = "Order Code";
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.Enabled = false;
            this.txtOrderCode.Location = new System.Drawing.Point(112, 105);
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.ReadOnly = true;
            this.txtOrderCode.Size = new System.Drawing.Size(190, 20);
            this.txtOrderCode.TabIndex = 39;
            // 
            // buttonReadCPUInfo
            // 
            this.buttonReadCPUInfo.Location = new System.Drawing.Point(112, 159);
            this.buttonReadCPUInfo.Name = "buttonReadCPUInfo";
            this.buttonReadCPUInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonReadCPUInfo.TabIndex = 1;
            this.buttonReadCPUInfo.Text = "Read";
            this.buttonReadCPUInfo.UseVisualStyleBackColor = true;
            this.buttonReadCPUInfo.Click += new System.EventHandler(this.buttonReadCPUInfo_Click);
            // 
            // txtModuleName
            // 
            this.txtModuleName.BackColor = System.Drawing.SystemColors.Menu;
            this.txtModuleName.Enabled = false;
            this.txtModuleName.Location = new System.Drawing.Point(112, 82);
            this.txtModuleName.Name = "txtModuleName";
            this.txtModuleName.Size = new System.Drawing.Size(190, 20);
            this.txtModuleName.TabIndex = 1;
            // 
            // txtAsName
            // 
            this.txtAsName.BackColor = System.Drawing.SystemColors.Menu;
            this.txtAsName.Enabled = false;
            this.txtAsName.Location = new System.Drawing.Point(112, 59);
            this.txtAsName.Name = "txtAsName";
            this.txtAsName.Size = new System.Drawing.Size(190, 20);
            this.txtAsName.TabIndex = 1;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSerialNumber.Enabled = false;
            this.txtSerialNumber.Location = new System.Drawing.Point(112, 36);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(190, 20);
            this.txtSerialNumber.TabIndex = 1;
            // 
            // txtModuleTypeName
            // 
            this.txtModuleTypeName.BackColor = System.Drawing.SystemColors.Menu;
            this.txtModuleTypeName.Enabled = false;
            this.txtModuleTypeName.Location = new System.Drawing.Point(112, 13);
            this.txtModuleTypeName.Name = "txtModuleTypeName";
            this.txtModuleTypeName.Size = new System.Drawing.Size(190, 20);
            this.txtModuleTypeName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Module name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "AS name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Serial number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Module Type Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LogData_textbox);
            this.groupBox3.Controls.Add(this.LogData_button);
            this.groupBox3.Controls.Add(this.LogData_label);
            this.groupBox3.Controls.Add(this.LogData_checkbox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(253, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 188);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log data to file";
            // 
            // LogData_textbox
            // 
            this.LogData_textbox.Location = new System.Drawing.Point(45, 44);
            this.LogData_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogData_textbox.Name = "LogData_textbox";
            this.LogData_textbox.Size = new System.Drawing.Size(166, 20);
            this.LogData_textbox.TabIndex = 21;
            // 
            // LogData_button
            // 
            this.LogData_button.Location = new System.Drawing.Point(218, 44);
            this.LogData_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogData_button.Name = "LogData_button";
            this.LogData_button.Size = new System.Drawing.Size(24, 22);
            this.LogData_button.TabIndex = 23;
            this.LogData_button.Text = "...";
            this.LogData_button.UseVisualStyleBackColor = true;
            this.LogData_button.Click += new System.EventHandler(this.LogData_button_Click);
            // 
            // LogData_label
            // 
            this.LogData_label.AutoSize = true;
            this.LogData_label.Location = new System.Drawing.Point(9, 47);
            this.LogData_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LogData_label.Name = "LogData_label";
            this.LogData_label.Size = new System.Drawing.Size(32, 13);
            this.LogData_label.TabIndex = 22;
            this.LogData_label.Text = "Path:";
            // 
            // LogData_checkbox
            // 
            this.LogData_checkbox.AutoSize = true;
            this.LogData_checkbox.Location = new System.Drawing.Point(12, 21);
            this.LogData_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.LogData_checkbox.Name = "LogData_checkbox";
            this.LogData_checkbox.Size = new System.Drawing.Size(98, 17);
            this.LogData_checkbox.TabIndex = 20;
            this.LogData_checkbox.Text = "Log Data to file";
            this.LogData_checkbox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CPU_STATUS);
            this.groupBox1.Controls.Add(this.CPUStatus_label);
            this.groupBox1.Controls.Add(this.CPUStatus_labelconst);
            this.groupBox1.Controls.Add(this.textBoxSlot);
            this.groupBox1.Controls.Add(this.textBoxRack);
            this.groupBox1.Controls.Add(this.textBoxIP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonDisconnect);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // CPUStatus_label
            // 
            this.CPUStatus_label.AutoSize = true;
            this.CPUStatus_label.Location = new System.Drawing.Point(100, 169);
            this.CPUStatus_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPUStatus_label.Name = "CPUStatus_label";
            this.CPUStatus_label.Size = new System.Drawing.Size(53, 13);
            this.CPUStatus_label.TabIndex = 16;
            this.CPUStatus_label.Text = "Unknown";
            // 
            // CPUStatus_labelconst
            // 
            this.CPUStatus_labelconst.AutoSize = true;
            this.CPUStatus_labelconst.Location = new System.Drawing.Point(32, 169);
            this.CPUStatus_labelconst.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPUStatus_labelconst.Name = "CPUStatus_labelconst";
            this.CPUStatus_labelconst.Size = new System.Drawing.Size(65, 13);
            this.CPUStatus_labelconst.TabIndex = 15;
            this.CPUStatus_labelconst.Text = "CPU Status:";
            // 
            // textBoxSlot
            // 
            this.textBoxSlot.Location = new System.Drawing.Point(73, 64);
            this.textBoxSlot.Name = "textBoxSlot";
            this.textBoxSlot.Size = new System.Drawing.Size(35, 20);
            this.textBoxSlot.TabIndex = 3;
            this.textBoxSlot.Text = "3";
            this.textBoxSlot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRack
            // 
            this.textBoxRack.Location = new System.Drawing.Point(73, 41);
            this.textBoxRack.Name = "textBoxRack";
            this.textBoxRack.Size = new System.Drawing.Size(35, 20);
            this.textBoxRack.TabIndex = 2;
            this.textBoxRack.Text = "0";
            this.textBoxRack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(73, 18);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(95, 20);
            this.textBoxIP.TabIndex = 1;
            this.textBoxIP.Text = "192.168.0.1";
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IP_text_KeyDown);
            this.textBoxIP.MouseHover += new System.EventHandler(this.TooltipEvent);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Slot:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Rack:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP address:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(73, 119);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 0;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(73, 90);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.groupBox11);
            this.tabView.Controls.Add(this.groupBox8);
            this.tabView.Controls.Add(this.groupBox9);
            this.tabView.Controls.Add(this.groupBox5);
            this.tabView.Location = new System.Drawing.Point(4, 22);
            this.tabView.Name = "tabView";
            this.tabView.Padding = new System.Windows.Forms.Padding(3);
            this.tabView.Size = new System.Drawing.Size(1072, 194);
            this.tabView.TabIndex = 1;
            this.tabView.Text = "View";
            this.tabView.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.Miliseconds_checkBox);
            this.groupBox11.Controls.Add(this.Seconds_checkbox);
            this.groupBox11.Controls.Add(this.Minute_checkbox);
            this.groupBox11.Controls.Add(this.Hour_checkbox);
            this.groupBox11.Controls.Add(this.Day_checkbox);
            this.groupBox11.Controls.Add(this.Month_checkBox);
            this.groupBox11.Controls.Add(this.Year_checkbox);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox11.Location = new System.Drawing.Point(595, 3);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox11.Size = new System.Drawing.Size(186, 188);
            this.groupBox11.TabIndex = 46;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Date and Time";
            // 
            // Miliseconds_checkBox
            // 
            this.Miliseconds_checkBox.AutoSize = true;
            this.Miliseconds_checkBox.Checked = true;
            this.Miliseconds_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Miliseconds_checkBox.Enabled = false;
            this.Miliseconds_checkBox.Location = new System.Drawing.Point(78, 77);
            this.Miliseconds_checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.Miliseconds_checkBox.Name = "Miliseconds_checkBox";
            this.Miliseconds_checkBox.Size = new System.Drawing.Size(81, 17);
            this.Miliseconds_checkBox.TabIndex = 6;
            this.Miliseconds_checkBox.Text = "Miliseconds";
            this.Miliseconds_checkBox.UseVisualStyleBackColor = true;
            // 
            // Seconds_checkbox
            // 
            this.Seconds_checkbox.AutoSize = true;
            this.Seconds_checkbox.Checked = true;
            this.Seconds_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Seconds_checkbox.Enabled = false;
            this.Seconds_checkbox.Location = new System.Drawing.Point(78, 57);
            this.Seconds_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.Seconds_checkbox.Name = "Seconds_checkbox";
            this.Seconds_checkbox.Size = new System.Drawing.Size(68, 17);
            this.Seconds_checkbox.TabIndex = 5;
            this.Seconds_checkbox.Text = "Seconds";
            this.Seconds_checkbox.UseVisualStyleBackColor = true;
            // 
            // Minute_checkbox
            // 
            this.Minute_checkbox.AutoSize = true;
            this.Minute_checkbox.Checked = true;
            this.Minute_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Minute_checkbox.Enabled = false;
            this.Minute_checkbox.Location = new System.Drawing.Point(78, 38);
            this.Minute_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.Minute_checkbox.Name = "Minute_checkbox";
            this.Minute_checkbox.Size = new System.Drawing.Size(63, 17);
            this.Minute_checkbox.TabIndex = 4;
            this.Minute_checkbox.Text = "Minutes";
            this.Minute_checkbox.UseVisualStyleBackColor = true;
            // 
            // Hour_checkbox
            // 
            this.Hour_checkbox.AutoSize = true;
            this.Hour_checkbox.Checked = true;
            this.Hour_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Hour_checkbox.Enabled = false;
            this.Hour_checkbox.Location = new System.Drawing.Point(78, 20);
            this.Hour_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.Hour_checkbox.Name = "Hour_checkbox";
            this.Hour_checkbox.Size = new System.Drawing.Size(54, 17);
            this.Hour_checkbox.TabIndex = 3;
            this.Hour_checkbox.Text = "Hours";
            this.Hour_checkbox.UseVisualStyleBackColor = true;
            // 
            // Day_checkbox
            // 
            this.Day_checkbox.AutoSize = true;
            this.Day_checkbox.Location = new System.Drawing.Point(6, 57);
            this.Day_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.Day_checkbox.Name = "Day_checkbox";
            this.Day_checkbox.Size = new System.Drawing.Size(45, 17);
            this.Day_checkbox.TabIndex = 2;
            this.Day_checkbox.Text = "Day";
            this.Day_checkbox.UseVisualStyleBackColor = true;
            // 
            // Month_checkBox
            // 
            this.Month_checkBox.AutoSize = true;
            this.Month_checkBox.Location = new System.Drawing.Point(6, 38);
            this.Month_checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.Month_checkBox.Name = "Month_checkBox";
            this.Month_checkBox.Size = new System.Drawing.Size(56, 17);
            this.Month_checkBox.TabIndex = 1;
            this.Month_checkBox.Text = "Month";
            this.Month_checkBox.UseVisualStyleBackColor = true;
            // 
            // Year_checkbox
            // 
            this.Year_checkbox.AutoSize = true;
            this.Year_checkbox.Location = new System.Drawing.Point(6, 20);
            this.Year_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.Year_checkbox.Name = "Year_checkbox";
            this.Year_checkbox.Size = new System.Drawing.Size(48, 17);
            this.Year_checkbox.TabIndex = 0;
            this.Year_checkbox.Text = "Year";
            this.Year_checkbox.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.X_Interval_text);
            this.groupBox8.Controls.Add(this.Xgrid_checkBox);
            this.groupBox8.Controls.Add(this.X_MinorGrid_checkbox);
            this.groupBox8.Controls.Add(this.X_Interval_label);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox8.Location = new System.Drawing.Point(429, 3);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox8.Size = new System.Drawing.Size(166, 188);
            this.groupBox8.TabIndex = 44;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "X Axis";
            // 
            // X_Interval_text
            // 
            this.X_Interval_text.Location = new System.Drawing.Point(81, 62);
            this.X_Interval_text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.X_Interval_text.Name = "X_Interval_text";
            this.X_Interval_text.Size = new System.Drawing.Size(46, 20);
            this.X_Interval_text.TabIndex = 35;
            this.X_Interval_text.TextChanged += new System.EventHandler(this.Interval_text_TextChanged);
            // 
            // Xgrid_checkBox
            // 
            this.Xgrid_checkBox.AutoSize = true;
            this.Xgrid_checkBox.Location = new System.Drawing.Point(4, 20);
            this.Xgrid_checkBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Xgrid_checkBox.Name = "Xgrid_checkBox";
            this.Xgrid_checkBox.Size = new System.Drawing.Size(72, 17);
            this.Xgrid_checkBox.TabIndex = 24;
            this.Xgrid_checkBox.Text = "Major grid";
            this.Xgrid_checkBox.UseVisualStyleBackColor = true;
            this.Xgrid_checkBox.CheckedChanged += new System.EventHandler(this.Xgrid_checkBox_CheckedChanged);
            // 
            // X_MinorGrid_checkbox
            // 
            this.X_MinorGrid_checkbox.AutoSize = true;
            this.X_MinorGrid_checkbox.Location = new System.Drawing.Point(4, 44);
            this.X_MinorGrid_checkbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.X_MinorGrid_checkbox.Name = "X_MinorGrid_checkbox";
            this.X_MinorGrid_checkbox.Size = new System.Drawing.Size(72, 17);
            this.X_MinorGrid_checkbox.TabIndex = 26;
            this.X_MinorGrid_checkbox.Text = "Minor grid";
            this.X_MinorGrid_checkbox.UseVisualStyleBackColor = true;
            this.X_MinorGrid_checkbox.CheckedChanged += new System.EventHandler(this.X_MinorGrid_checkbox_CheckedChanged);
            // 
            // X_Interval_label
            // 
            this.X_Interval_label.AutoSize = true;
            this.X_Interval_label.Location = new System.Drawing.Point(4, 66);
            this.X_Interval_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X_Interval_label.Name = "X_Interval_label";
            this.X_Interval_label.Size = new System.Drawing.Size(69, 13);
            this.X_Interval_label.TabIndex = 34;
            this.X_Interval_label.Text = "Tick Interval:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.Y_Interval_text);
            this.groupBox9.Controls.Add(this.Maxscale_text);
            this.groupBox9.Controls.Add(this.MinScale_text);
            this.groupBox9.Controls.Add(this.Y_Interval_label);
            this.groupBox9.Controls.Add(this.Ygrid_checkbox);
            this.groupBox9.Controls.Add(this.Y_MinorGrid_checkbox);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.Maxscale_label);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox9.Location = new System.Drawing.Point(212, 3);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox9.Size = new System.Drawing.Size(217, 188);
            this.groupBox9.TabIndex = 45;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Y Axis";
            // 
            // Y_Interval_text
            // 
            this.Y_Interval_text.Location = new System.Drawing.Point(78, 62);
            this.Y_Interval_text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Y_Interval_text.Name = "Y_Interval_text";
            this.Y_Interval_text.Size = new System.Drawing.Size(46, 20);
            this.Y_Interval_text.TabIndex = 39;
            this.Y_Interval_text.TextChanged += new System.EventHandler(this.Y_Interval_text_TextChanged);
            // 
            // Maxscale_text
            // 
            this.Maxscale_text.Location = new System.Drawing.Point(163, 18);
            this.Maxscale_text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Maxscale_text.Name = "Maxscale_text";
            this.Maxscale_text.Size = new System.Drawing.Size(46, 20);
            this.Maxscale_text.TabIndex = 29;
            this.Maxscale_text.TextChanged += new System.EventHandler(this.Maxscale_text_TextChanged);
            // 
            // MinScale_text
            // 
            this.MinScale_text.Location = new System.Drawing.Point(163, 42);
            this.MinScale_text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinScale_text.Name = "MinScale_text";
            this.MinScale_text.Size = new System.Drawing.Size(46, 20);
            this.MinScale_text.TabIndex = 31;
            this.MinScale_text.TextChanged += new System.EventHandler(this.MinScale_text_TextChanged);
            // 
            // Y_Interval_label
            // 
            this.Y_Interval_label.AutoSize = true;
            this.Y_Interval_label.Location = new System.Drawing.Point(4, 66);
            this.Y_Interval_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y_Interval_label.Name = "Y_Interval_label";
            this.Y_Interval_label.Size = new System.Drawing.Size(69, 13);
            this.Y_Interval_label.TabIndex = 38;
            this.Y_Interval_label.Text = "Tick Interval:";
            // 
            // Ygrid_checkbox
            // 
            this.Ygrid_checkbox.AutoSize = true;
            this.Ygrid_checkbox.Location = new System.Drawing.Point(4, 20);
            this.Ygrid_checkbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Ygrid_checkbox.Name = "Ygrid_checkbox";
            this.Ygrid_checkbox.Size = new System.Drawing.Size(72, 17);
            this.Ygrid_checkbox.TabIndex = 27;
            this.Ygrid_checkbox.Text = "Major grid";
            this.Ygrid_checkbox.UseVisualStyleBackColor = true;
            this.Ygrid_checkbox.CheckedChanged += new System.EventHandler(this.Ygrid_checkbox_CheckedChanged);
            // 
            // Y_MinorGrid_checkbox
            // 
            this.Y_MinorGrid_checkbox.AutoSize = true;
            this.Y_MinorGrid_checkbox.Location = new System.Drawing.Point(4, 44);
            this.Y_MinorGrid_checkbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Y_MinorGrid_checkbox.Name = "Y_MinorGrid_checkbox";
            this.Y_MinorGrid_checkbox.Size = new System.Drawing.Size(72, 17);
            this.Y_MinorGrid_checkbox.TabIndex = 37;
            this.Y_MinorGrid_checkbox.Text = "Minor grid";
            this.Y_MinorGrid_checkbox.UseVisualStyleBackColor = true;
            this.Y_MinorGrid_checkbox.CheckedChanged += new System.EventHandler(this.Y_MinorGrid_checkbox_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(100, 45);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Min Scale:";
            // 
            // Maxscale_label
            // 
            this.Maxscale_label.AutoSize = true;
            this.Maxscale_label.Location = new System.Drawing.Point(98, 22);
            this.Maxscale_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Maxscale_label.Name = "Maxscale_label";
            this.Maxscale_label.Size = new System.Drawing.Size(60, 13);
            this.Maxscale_label.TabIndex = 28;
            this.Maxscale_label.Text = "Max Scale:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Refresh_text);
            this.groupBox5.Controls.Add(this.maxtime_textbox);
            this.groupBox5.Controls.Add(this.Minimize_checkbox);
            this.groupBox5.Controls.Add(this.Legend_checkbox);
            this.groupBox5.Controls.Add(this.Refresh_label);
            this.groupBox5.Controls.Add(this.maxtime_label);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.ms_text);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(209, 188);
            this.groupBox5.TabIndex = 43;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "General";
            // 
            // Refresh_text
            // 
            this.Refresh_text.Location = new System.Drawing.Point(94, 42);
            this.Refresh_text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Refresh_text.Name = "Refresh_text";
            this.Refresh_text.Size = new System.Drawing.Size(46, 20);
            this.Refresh_text.TabIndex = 12;
            this.Refresh_text.Text = "100";
            this.Refresh_text.Leave += new System.EventHandler(this.Refresh_text_Leave);
            this.Refresh_text.MouseLeave += new System.EventHandler(this.Refresh_text_Leave);
            this.Refresh_text.MouseHover += new System.EventHandler(this.TooltipEvent);
            // 
            // maxtime_textbox
            // 
            this.maxtime_textbox.Location = new System.Drawing.Point(94, 18);
            this.maxtime_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maxtime_textbox.Name = "maxtime_textbox";
            this.maxtime_textbox.Size = new System.Drawing.Size(46, 20);
            this.maxtime_textbox.TabIndex = 22;
            this.maxtime_textbox.Text = "10";
            this.maxtime_textbox.Leave += new System.EventHandler(this.maxtime_textbox_Leave);
            this.maxtime_textbox.MouseLeave += new System.EventHandler(this.maxtime_textbox_Leave);
            this.maxtime_textbox.MouseHover += new System.EventHandler(this.TooltipEvent);
            // 
            // Minimize_checkbox
            // 
            this.Minimize_checkbox.AutoSize = true;
            this.Minimize_checkbox.Checked = true;
            this.Minimize_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Minimize_checkbox.Location = new System.Drawing.Point(94, 64);
            this.Minimize_checkbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Minimize_checkbox.Name = "Minimize_checkbox";
            this.Minimize_checkbox.Size = new System.Drawing.Size(98, 17);
            this.Minimize_checkbox.TabIndex = 26;
            this.Minimize_checkbox.Text = "Minimize to tray";
            this.Minimize_checkbox.UseVisualStyleBackColor = true;
            // 
            // Legend_checkbox
            // 
            this.Legend_checkbox.AutoSize = true;
            this.Legend_checkbox.Checked = true;
            this.Legend_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Legend_checkbox.Location = new System.Drawing.Point(15, 64);
            this.Legend_checkbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Legend_checkbox.Name = "Legend_checkbox";
            this.Legend_checkbox.Size = new System.Drawing.Size(62, 17);
            this.Legend_checkbox.TabIndex = 25;
            this.Legend_checkbox.Text = "Legend";
            this.Legend_checkbox.UseVisualStyleBackColor = true;
            this.Legend_checkbox.CheckedChanged += new System.EventHandler(this.Legend_checkbox_CheckedChanged);
            // 
            // Refresh_label
            // 
            this.Refresh_label.AutoSize = true;
            this.Refresh_label.Location = new System.Drawing.Point(15, 46);
            this.Refresh_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Refresh_label.Name = "Refresh_label";
            this.Refresh_label.Size = new System.Drawing.Size(73, 13);
            this.Refresh_label.TabIndex = 13;
            this.Refresh_label.Text = "Refresh Rate:";
            // 
            // maxtime_label
            // 
            this.maxtime_label.AutoSize = true;
            this.maxtime_label.Location = new System.Drawing.Point(30, 22);
            this.maxtime_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxtime_label.Name = "maxtime_label";
            this.maxtime_label.Size = new System.Drawing.Size(56, 13);
            this.maxtime_label.TabIndex = 21;
            this.maxtime_label.Text = "Max Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "[s]";
            // 
            // ms_text
            // 
            this.ms_text.AutoSize = true;
            this.ms_text.Location = new System.Drawing.Point(145, 46);
            this.ms_text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ms_text.Name = "ms_text";
            this.ms_text.Size = new System.Drawing.Size(26, 13);
            this.ms_text.TabIndex = 14;
            this.ms_text.Text = "[ms]";
            // 
            // tabVariables
            // 
            this.tabVariables.Controls.Add(this.groupBox2);
            this.tabVariables.Controls.Add(this.groupBox6);
            this.tabVariables.Controls.Add(this.groupBox7);
            this.tabVariables.Location = new System.Drawing.Point(4, 22);
            this.tabVariables.Name = "tabVariables";
            this.tabVariables.Padding = new System.Windows.Forms.Padding(3);
            this.tabVariables.Size = new System.Drawing.Size(1072, 194);
            this.tabVariables.TabIndex = 2;
            this.tabVariables.Text = "Variables";
            this.tabVariables.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Pause_checkBox);
            this.groupBox2.Controls.Add(this.buttonStop);
            this.groupBox2.Controls.Add(this.buttonStart);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(795, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(80, 188);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Control";
            // 
            // Pause_checkBox
            // 
            this.Pause_checkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.Pause_checkBox.Enabled = false;
            this.Pause_checkBox.Location = new System.Drawing.Point(5, 40);
            this.Pause_checkBox.Margin = new System.Windows.Forms.Padding(4);
            this.Pause_checkBox.Name = "Pause_checkBox";
            this.Pause_checkBox.Size = new System.Drawing.Size(70, 21);
            this.Pause_checkBox.TabIndex = 12;
            this.Pause_checkBox.Text = "Pause";
            this.Pause_checkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Pause_checkBox.UseVisualStyleBackColor = true;
            this.Pause_checkBox.CheckedChanged += new System.EventHandler(this.Pause_checkBox_CheckedChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(5, 63);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(70, 21);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(5, 17);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(70, 21);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LoadVars_button);
            this.groupBox6.Controls.Add(this.SaveVars_button);
            this.groupBox6.Controls.Add(this.Variables_list);
            this.groupBox6.Controls.Add(this.AddToChart_button);
            this.groupBox6.Controls.Add(this.Remove_button);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox6.Location = new System.Drawing.Point(556, 3);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(239, 188);
            this.groupBox6.TabIndex = 33;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "List of Variables";
            // 
            // LoadVars_button
            // 
            this.LoadVars_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadVars_button.Location = new System.Drawing.Point(170, 63);
            this.LoadVars_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoadVars_button.Name = "LoadVars_button";
            this.LoadVars_button.Size = new System.Drawing.Size(60, 21);
            this.LoadVars_button.TabIndex = 9;
            this.LoadVars_button.Text = "Load";
            this.LoadVars_button.UseVisualStyleBackColor = true;
            this.LoadVars_button.Click += new System.EventHandler(this.LoadVars_button_Click);
            // 
            // SaveVars_button
            // 
            this.SaveVars_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveVars_button.Location = new System.Drawing.Point(170, 87);
            this.SaveVars_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveVars_button.Name = "SaveVars_button";
            this.SaveVars_button.Size = new System.Drawing.Size(60, 21);
            this.SaveVars_button.TabIndex = 10;
            this.SaveVars_button.Text = "Save";
            this.SaveVars_button.UseVisualStyleBackColor = true;
            this.SaveVars_button.Click += new System.EventHandler(this.SaveVars_button_Click);
            // 
            // Variables_list
            // 
            this.Variables_list.Dock = System.Windows.Forms.DockStyle.Left;
            this.Variables_list.FormattingEnabled = true;
            this.Variables_list.Location = new System.Drawing.Point(4, 18);
            this.Variables_list.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Variables_list.Name = "Variables_list";
            this.Variables_list.Size = new System.Drawing.Size(158, 165);
            this.Variables_list.TabIndex = 19;
            this.Variables_list.SelectedIndexChanged += new System.EventHandler(this.Variables_list_SelectedIndexChanged);
            // 
            // AddToChart_button
            // 
            this.AddToChart_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddToChart_button.Location = new System.Drawing.Point(170, 17);
            this.AddToChart_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddToChart_button.Name = "AddToChart_button";
            this.AddToChart_button.Size = new System.Drawing.Size(60, 21);
            this.AddToChart_button.TabIndex = 7;
            this.AddToChart_button.Text = "Add";
            this.AddToChart_button.UseVisualStyleBackColor = true;
            this.AddToChart_button.Click += new System.EventHandler(this.AddToChart_button_Click);
            // 
            // Remove_button
            // 
            this.Remove_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Remove_button.Location = new System.Drawing.Point(170, 40);
            this.Remove_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Remove_button.Name = "Remove_button";
            this.Remove_button.Size = new System.Drawing.Size(60, 21);
            this.Remove_button.TabIndex = 8;
            this.Remove_button.Text = "Remove";
            this.Remove_button.UseVisualStyleBackColor = true;
            this.Remove_button.Click += new System.EventHandler(this.Remove_button_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dbPicker_button);
            this.groupBox7.Controls.Add(this.DisplayFormat_comboBox);
            this.groupBox7.Controls.Add(this.Comment_textBox);
            this.groupBox7.Controls.Add(this.PLCMax_textbox);
            this.groupBox7.Controls.Add(this.PLCMin_textbox);
            this.groupBox7.Controls.Add(this.MaxVal_textbox);
            this.groupBox7.Controls.Add(this.MinVal_textbox);
            this.groupBox7.Controls.Add(this.SymbolicName_text);
            this.groupBox7.Controls.Add(this.Variable_text);
            this.groupBox7.Controls.Add(this.Multiply_text);
            this.groupBox7.Controls.Add(this.Add_text);
            this.groupBox7.Controls.Add(this.DisplayFormat_label);
            this.groupBox7.Controls.Add(this.Comment_label);
            this.groupBox7.Controls.Add(this.calculate_checkbox);
            this.groupBox7.Controls.Add(this.PLCMax_label);
            this.groupBox7.Controls.Add(this.PLCMin_label);
            this.groupBox7.Controls.Add(this.MaxVal_label);
            this.groupBox7.Controls.Add(this.MinVal_label);
            this.groupBox7.Controls.Add(this.Modify_button);
            this.groupBox7.Controls.Add(this.Multiply_label);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.More_button);
            this.groupBox7.Controls.Add(this.SymbolicName_label);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.Color_button);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Size = new System.Drawing.Size(553, 188);
            this.groupBox7.TabIndex = 34;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Variable Settings";
            // 
            // dbPicker_button
            // 
            this.dbPicker_button.Location = new System.Drawing.Point(482, 81);
            this.dbPicker_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dbPicker_button.Name = "dbPicker_button";
            this.dbPicker_button.Size = new System.Drawing.Size(60, 21);
            this.dbPicker_button.TabIndex = 45;
            this.dbPicker_button.Text = "DB pick";
            this.dbPicker_button.UseVisualStyleBackColor = true;
            this.dbPicker_button.Click += new System.EventHandler(this.dbPicker_button_Click);
            // 
            // DisplayFormat_comboBox
            // 
            this.DisplayFormat_comboBox.FormattingEnabled = true;
            this.DisplayFormat_comboBox.Items.AddRange(new object[] {
            "BOOL",
            "BYTE",
            "WORD",
            "DWORD",
            "INT",
            "DINT",
            "REAL",
            "TIMER1MS",
            "TIMER1S",
            "COUNTER"});
            this.DisplayFormat_comboBox.Location = new System.Drawing.Point(376, 37);
            this.DisplayFormat_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.DisplayFormat_comboBox.Name = "DisplayFormat_comboBox";
            this.DisplayFormat_comboBox.Size = new System.Drawing.Size(98, 21);
            this.DisplayFormat_comboBox.TabIndex = 4;
            // 
            // Comment_textBox
            // 
            this.Comment_textBox.Location = new System.Drawing.Point(287, 13);
            this.Comment_textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Comment_textBox.Name = "Comment_textBox";
            this.Comment_textBox.Size = new System.Drawing.Size(186, 20);
            this.Comment_textBox.TabIndex = 3;
            // 
            // PLCMax_textbox
            // 
            this.PLCMax_textbox.Location = new System.Drawing.Point(427, 60);
            this.PLCMax_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PLCMax_textbox.Name = "PLCMax_textbox";
            this.PLCMax_textbox.Size = new System.Drawing.Size(46, 20);
            this.PLCMax_textbox.TabIndex = 14;
            this.PLCMax_textbox.Text = "27648";
            this.PLCMax_textbox.Visible = false;
            // 
            // PLCMin_textbox
            // 
            this.PLCMin_textbox.Location = new System.Drawing.Point(427, 82);
            this.PLCMin_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PLCMin_textbox.Name = "PLCMin_textbox";
            this.PLCMin_textbox.Size = new System.Drawing.Size(46, 20);
            this.PLCMin_textbox.TabIndex = 15;
            this.PLCMin_textbox.Text = "0";
            this.PLCMin_textbox.Visible = false;
            // 
            // MaxVal_textbox
            // 
            this.MaxVal_textbox.Location = new System.Drawing.Point(324, 60);
            this.MaxVal_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaxVal_textbox.Name = "MaxVal_textbox";
            this.MaxVal_textbox.Size = new System.Drawing.Size(46, 20);
            this.MaxVal_textbox.TabIndex = 12;
            this.MaxVal_textbox.Visible = false;
            // 
            // MinVal_textbox
            // 
            this.MinVal_textbox.Location = new System.Drawing.Point(324, 84);
            this.MinVal_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinVal_textbox.Name = "MinVal_textbox";
            this.MinVal_textbox.Size = new System.Drawing.Size(46, 20);
            this.MinVal_textbox.TabIndex = 13;
            this.MinVal_textbox.Visible = false;
            // 
            // SymbolicName_text
            // 
            this.SymbolicName_text.Location = new System.Drawing.Point(97, 36);
            this.SymbolicName_text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SymbolicName_text.Name = "SymbolicName_text";
            this.SymbolicName_text.Size = new System.Drawing.Size(123, 20);
            this.SymbolicName_text.TabIndex = 2;
            this.SymbolicName_text.MouseHover += new System.EventHandler(this.TooltipEvent);
            // 
            // Variable_text
            // 
            this.Variable_text.Location = new System.Drawing.Point(97, 12);
            this.Variable_text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Variable_text.Name = "Variable_text";
            this.Variable_text.Size = new System.Drawing.Size(123, 20);
            this.Variable_text.TabIndex = 1;
            this.Variable_text.MouseHover += new System.EventHandler(this.TooltipEvent);
            // 
            // Multiply_text
            // 
            this.Multiply_text.Location = new System.Drawing.Point(97, 84);
            this.Multiply_text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Multiply_text.Name = "Multiply_text";
            this.Multiply_text.Size = new System.Drawing.Size(46, 20);
            this.Multiply_text.TabIndex = 6;
            this.Multiply_text.MouseHover += new System.EventHandler(this.TooltipEvent);
            // 
            // Add_text
            // 
            this.Add_text.Location = new System.Drawing.Point(97, 60);
            this.Add_text.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Add_text.Name = "Add_text";
            this.Add_text.Size = new System.Drawing.Size(46, 20);
            this.Add_text.TabIndex = 5;
            this.Add_text.MouseHover += new System.EventHandler(this.TooltipEvent);
            // 
            // DisplayFormat_label
            // 
            this.DisplayFormat_label.AutoSize = true;
            this.DisplayFormat_label.Location = new System.Drawing.Point(290, 39);
            this.DisplayFormat_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DisplayFormat_label.Name = "DisplayFormat_label";
            this.DisplayFormat_label.Size = new System.Drawing.Size(76, 13);
            this.DisplayFormat_label.TabIndex = 44;
            this.DisplayFormat_label.Text = "Display format:";
            // 
            // Comment_label
            // 
            this.Comment_label.AutoSize = true;
            this.Comment_label.Location = new System.Drawing.Point(227, 17);
            this.Comment_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Comment_label.Name = "Comment_label";
            this.Comment_label.Size = new System.Drawing.Size(54, 13);
            this.Comment_label.TabIndex = 42;
            this.Comment_label.Text = "Comment:";
            // 
            // calculate_checkbox
            // 
            this.calculate_checkbox.AutoSize = true;
            this.calculate_checkbox.Location = new System.Drawing.Point(151, 74);
            this.calculate_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.calculate_checkbox.Name = "calculate_checkbox";
            this.calculate_checkbox.Size = new System.Drawing.Size(50, 17);
            this.calculate_checkbox.TabIndex = 39;
            this.calculate_checkbox.Text = "Calc!";
            this.calculate_checkbox.UseVisualStyleBackColor = true;
            this.calculate_checkbox.CheckedChanged += new System.EventHandler(this.calculate_checkbox_CheckedChanged);
            // 
            // PLCMax_label
            // 
            this.PLCMax_label.AutoSize = true;
            this.PLCMax_label.Location = new System.Drawing.Point(373, 63);
            this.PLCMax_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PLCMax_label.Name = "PLCMax_label";
            this.PLCMax_label.Size = new System.Drawing.Size(53, 13);
            this.PLCMax_label.TabIndex = 38;
            this.PLCMax_label.Text = "PLC Max:";
            this.PLCMax_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.PLCMax_label.Visible = false;
            // 
            // PLCMin_label
            // 
            this.PLCMin_label.AutoSize = true;
            this.PLCMin_label.Location = new System.Drawing.Point(374, 86);
            this.PLCMin_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PLCMin_label.Name = "PLCMin_label";
            this.PLCMin_label.Size = new System.Drawing.Size(50, 13);
            this.PLCMin_label.TabIndex = 37;
            this.PLCMin_label.Text = "PLC Min:";
            this.PLCMin_label.Visible = false;
            // 
            // MaxVal_label
            // 
            this.MaxVal_label.AutoSize = true;
            this.MaxVal_label.Location = new System.Drawing.Point(254, 63);
            this.MaxVal_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxVal_label.Name = "MaxVal_label";
            this.MaxVal_label.Size = new System.Drawing.Size(66, 13);
            this.MaxVal_label.TabIndex = 34;
            this.MaxVal_label.Text = "Sensor Max:";
            this.MaxVal_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.MaxVal_label.Visible = false;
            // 
            // MinVal_label
            // 
            this.MinVal_label.AutoSize = true;
            this.MinVal_label.Location = new System.Drawing.Point(255, 87);
            this.MinVal_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MinVal_label.Name = "MinVal_label";
            this.MinVal_label.Size = new System.Drawing.Size(63, 13);
            this.MinVal_label.TabIndex = 33;
            this.MinVal_label.Text = "Sensor Min:";
            this.MinVal_label.Visible = false;
            // 
            // Modify_button
            // 
            this.Modify_button.Location = new System.Drawing.Point(482, 36);
            this.Modify_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Modify_button.Name = "Modify_button";
            this.Modify_button.Size = new System.Drawing.Size(60, 21);
            this.Modify_button.TabIndex = 11;
            this.Modify_button.Text = "Modify";
            this.Modify_button.UseVisualStyleBackColor = true;
            this.Modify_button.Click += new System.EventHandler(this.Modify_button_Click);
            // 
            // Multiply_label
            // 
            this.Multiply_label.AutoSize = true;
            this.Multiply_label.Location = new System.Drawing.Point(20, 87);
            this.Multiply_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Multiply_label.Name = "Multiply_label";
            this.Multiply_label.Size = new System.Drawing.Size(66, 13);
            this.Multiply_label.TabIndex = 29;
            this.Multiply_label.Text = "Multiplicator:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 63);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Offset:";
            // 
            // More_button
            // 
            this.More_button.Location = new System.Drawing.Point(221, 36);
            this.More_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.More_button.Name = "More_button";
            this.More_button.Size = new System.Drawing.Size(24, 21);
            this.More_button.TabIndex = 16;
            this.More_button.Text = "...";
            this.More_button.UseVisualStyleBackColor = true;
            this.More_button.Click += new System.EventHandler(this.More_button_Click);
            // 
            // SymbolicName_label
            // 
            this.SymbolicName_label.AutoSize = true;
            this.SymbolicName_label.Location = new System.Drawing.Point(4, 39);
            this.SymbolicName_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SymbolicName_label.Name = "SymbolicName_label";
            this.SymbolicName_label.Size = new System.Drawing.Size(83, 13);
            this.SymbolicName_label.TabIndex = 27;
            this.SymbolicName_label.Text = "Symbolic Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Address:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(474, 15);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Color";
            // 
            // Color_button
            // 
            this.Color_button.BackColor = System.Drawing.Color.Black;
            this.Color_button.Location = new System.Drawing.Point(513, 12);
            this.Color_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Color_button.Name = "Color_button";
            this.Color_button.Size = new System.Drawing.Size(30, 21);
            this.Color_button.TabIndex = 22;
            this.Color_button.UseVisualStyleBackColor = false;
            this.Color_button.Click += new System.EventHandler(this.Color_button_Click);
            // 
            // tabActual
            // 
            this.tabActual.Controls.Add(this.Variables_dataGridView);
            this.tabActual.Location = new System.Drawing.Point(4, 22);
            this.tabActual.Name = "tabActual";
            this.tabActual.Padding = new System.Windows.Forms.Padding(3);
            this.tabActual.Size = new System.Drawing.Size(1072, 194);
            this.tabActual.TabIndex = 3;
            this.tabActual.Text = "Current Values";
            this.tabActual.UseVisualStyleBackColor = true;
            // 
            // Variables_dataGridView
            // 
            this.Variables_dataGridView.AllowUserToAddRows = false;
            this.Variables_dataGridView.AllowUserToDeleteRows = false;
            this.Variables_dataGridView.AllowUserToResizeRows = false;
            this.Variables_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Variables_dataGridView.CausesValidation = false;
            this.Variables_dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Variables_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Variables_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Adres,
            this.SymbolicName,
            this.Comment,
            this.Format,
            this.StatusValue,
            this.Color});
            this.Variables_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Variables_dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Variables_dataGridView.Location = new System.Drawing.Point(3, 3);
            this.Variables_dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.Variables_dataGridView.MultiSelect = false;
            this.Variables_dataGridView.Name = "Variables_dataGridView";
            this.Variables_dataGridView.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Variables_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Variables_dataGridView.RowHeadersVisible = false;
            this.Variables_dataGridView.RowTemplate.Height = 24;
            this.Variables_dataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Variables_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Variables_dataGridView.Size = new System.Drawing.Size(1066, 188);
            this.Variables_dataGridView.TabIndex = 1;
            // 
            // Adres
            // 
            this.Adres.FillWeight = 50F;
            this.Adres.HeaderText = "Address";
            this.Adres.Name = "Adres";
            this.Adres.ReadOnly = true;
            // 
            // SymbolicName
            // 
            this.SymbolicName.FillWeight = 50F;
            this.SymbolicName.HeaderText = "Symbol ";
            this.SymbolicName.Name = "SymbolicName";
            this.SymbolicName.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // Format
            // 
            this.Format.FillWeight = 50F;
            this.Format.HeaderText = "Format";
            this.Format.Name = "Format";
            this.Format.ReadOnly = true;
            // 
            // StatusValue
            // 
            this.StatusValue.FillWeight = 40F;
            this.StatusValue.HeaderText = "Status Value";
            this.StatusValue.Name = "StatusValue";
            this.StatusValue.ReadOnly = true;
            // 
            // Color
            // 
            this.Color.FillWeight = 30F;
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            // 
            // tabHelp
            // 
            this.tabHelp.Location = new System.Drawing.Point(4, 22);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tabHelp.Size = new System.Drawing.Size(1072, 194);
            this.tabHelp.TabIndex = 4;
            this.tabHelp.Text = "Help";
            this.tabHelp.UseVisualStyleBackColor = true;
            // 
            // tabDown
            // 
            this.tabDown.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabDown.Controls.Add(this.ChartPage);
            this.tabDown.Controls.Add(this.tabTable);
            this.tabDown.Controls.Add(this.tabDir);
            this.tabDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDown.Location = new System.Drawing.Point(3, 223);
            this.tabDown.Multiline = true;
            this.tabDown.Name = "tabDown";
            this.tabDown.SelectedIndex = 0;
            this.tabDown.Size = new System.Drawing.Size(1074, 606);
            this.tabDown.TabIndex = 1;
            // 
            // ChartPage
            // 
            this.ChartPage.Controls.Add(this.chart1);
            this.ChartPage.Location = new System.Drawing.Point(23, 4);
            this.ChartPage.Name = "ChartPage";
            this.ChartPage.Size = new System.Drawing.Size(1047, 598);
            this.ChartPage.TabIndex = 3;
            this.ChartPage.Text = "Chart view";
            this.ChartPage.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ContextMenuStrip = this.Chart1_contextMenuStrip;
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1047, 598);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseEnter += new System.EventHandler(this.chart1_MouseEnter);
            this.chart1.MouseLeave += new System.EventHandler(this.chart1_MouseLeave);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // Chart1_contextMenuStrip
            // 
            this.Chart1_contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Chart1_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.exportDataToolStripMenuItem,
            this.saveImageAsToolStripMenuItem});
            this.Chart1_contextMenuStrip.Name = "Chart1_contextMenuStrip";
            this.Chart1_contextMenuStrip.Size = new System.Drawing.Size(160, 70);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            this.exportDataToolStripMenuItem.Click += new System.EventHandler(this.exportDataToolStripMenuItem_Click);
            // 
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveImageAsToolStripMenuItem.Text = "Save Image As...";
            this.saveImageAsToolStripMenuItem.Click += new System.EventHandler(this.saveImageAsToolStripMenuItem_Click);
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.dataGridView);
            this.tabTable.Location = new System.Drawing.Point(23, 4);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTable.Size = new System.Drawing.Size(1047, 598);
            this.tabTable.TabIndex = 1;
            this.tabTable.Text = "Table view";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1041, 592);
            this.dataGridView.TabIndex = 1;
            // 
            // tabDir
            // 
            this.tabDir.Controls.Add(this.buttonGetDB);
            this.tabDir.Controls.Add(this.txtDBGet);
            this.tabDir.Controls.Add(this.label37);
            this.tabDir.Controls.Add(this.label36);
            this.tabDir.Controls.Add(this.buttonBlockInfo);
            this.tabDir.Controls.Add(this.txtBI);
            this.tabDir.Controls.Add(this.txtBlockNum);
            this.tabDir.Controls.Add(this.CBBlock);
            this.tabDir.Location = new System.Drawing.Point(23, 4);
            this.tabDir.Name = "tabDir";
            this.tabDir.Padding = new System.Windows.Forms.Padding(3);
            this.tabDir.Size = new System.Drawing.Size(1047, 598);
            this.tabDir.TabIndex = 2;
            this.tabDir.Text = "Directory";
            this.tabDir.UseVisualStyleBackColor = true;
            // 
            // buttonGetDB
            // 
            this.buttonGetDB.Location = new System.Drawing.Point(10, 110);
            this.buttonGetDB.Name = "buttonGetDB";
            this.buttonGetDB.Size = new System.Drawing.Size(100, 23);
            this.buttonGetDB.TabIndex = 82;
            this.buttonGetDB.Text = "DB Get";
            this.buttonGetDB.UseVisualStyleBackColor = true;
            this.buttonGetDB.Click += new System.EventHandler(this.buttonGetDB_Click);
            // 
            // txtDBGet
            // 
            this.txtDBGet.BackColor = System.Drawing.Color.White;
            this.txtDBGet.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBGet.ForeColor = System.Drawing.Color.Black;
            this.txtDBGet.Location = new System.Drawing.Point(10, 139);
            this.txtDBGet.Multiline = true;
            this.txtDBGet.Name = "txtDBGet";
            this.txtDBGet.ReadOnly = true;
            this.txtDBGet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDBGet.Size = new System.Drawing.Size(630, 167);
            this.txtDBGet.TabIndex = 81;
            // 
            // label37
            // 
            this.label37.AutoEllipsis = true;
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(131, 9);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(44, 13);
            this.label37.TabIndex = 80;
            this.label37.Text = "Number";
            // 
            // label36
            // 
            this.label36.AutoEllipsis = true;
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(7, 9);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(61, 13);
            this.label36.TabIndex = 79;
            this.label36.Text = "Block Type";
            // 
            // buttonBlockInfo
            // 
            this.buttonBlockInfo.Location = new System.Drawing.Point(9, 56);
            this.buttonBlockInfo.Name = "buttonBlockInfo";
            this.buttonBlockInfo.Size = new System.Drawing.Size(100, 23);
            this.buttonBlockInfo.TabIndex = 78;
            this.buttonBlockInfo.Text = "Get Block Info";
            this.buttonBlockInfo.UseVisualStyleBackColor = true;
            this.buttonBlockInfo.Click += new System.EventHandler(this.buttonBlockInfo_Click);
            // 
            // txtBI
            // 
            this.txtBI.BackColor = System.Drawing.Color.White;
            this.txtBI.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBI.ForeColor = System.Drawing.Color.Black;
            this.txtBI.Location = new System.Drawing.Point(204, 29);
            this.txtBI.Multiline = true;
            this.txtBI.Name = "txtBI";
            this.txtBI.ReadOnly = true;
            this.txtBI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBI.Size = new System.Drawing.Size(436, 104);
            this.txtBI.TabIndex = 77;
            // 
            // txtBlockNum
            // 
            this.txtBlockNum.Location = new System.Drawing.Point(134, 29);
            this.txtBlockNum.Name = "txtBlockNum";
            this.txtBlockNum.Size = new System.Drawing.Size(55, 20);
            this.txtBlockNum.TabIndex = 76;
            this.txtBlockNum.Text = "1";
            // 
            // CBBlock
            // 
            this.CBBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBlock.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBBlock.FormattingEnabled = true;
            this.CBBlock.Items.AddRange(new object[] {
            "OB",
            "DB",
            "SDB",
            "FC",
            "SFC",
            "FB",
            "SFB"});
            this.CBBlock.Location = new System.Drawing.Point(9, 28);
            this.CBBlock.Name = "CBBlock";
            this.CBBlock.Size = new System.Drawing.Size(100, 22);
            this.CBBlock.TabIndex = 75;
            // 
            // textBoxError
            // 
            this.textBoxError.Location = new System.Drawing.Point(3, 835);
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.Size = new System.Drawing.Size(1074, 20);
            this.textBoxError.TabIndex = 2;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // CommunicationTimer
            // 
            this.CommunicationTimer.Tick += new System.EventHandler(this.Timer_tick);
            // 
            // InterfaceRefreshtimer
            // 
            this.InterfaceRefreshtimer.Enabled = true;
            this.InterfaceRefreshtimer.Interval = 1500;
            this.InterfaceRefreshtimer.Tick += new System.EventHandler(this.InterfaceRefreshtimer_Tick);
            // 
            // CPU_STATUS
            // 
            this.CPU_STATUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CPU_STATUS.Location = new System.Drawing.Point(14, 167);
            this.CPU_STATUS.Name = "CPU_STATUS";
            this.CPU_STATUS.Size = new System.Drawing.Size(15, 15);
            this.CPU_STATUS.TabIndex = 24;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 857);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "S7 connection - PTPL, V.1.1.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabView.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabVariables.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabActual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Variables_dataGridView)).EndInit();
            this.tabDown.ResumeLayout(false);
            this.ChartPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.Chart1_contextMenuStrip.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabDir.ResumeLayout(false);
            this.tabDir.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabView;
        private System.Windows.Forms.TabPage tabVariables;
        private System.Windows.Forms.TabPage tabActual;
        private System.Windows.Forms.TabPage tabHelp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabDown;
        private System.Windows.Forms.TabPage tabTable;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSlot;
        private System.Windows.Forms.TextBox textBoxRack;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxError;
        private System.Windows.Forms.TabPage tabDir;
        private System.Windows.Forms.Button buttonGetDB;
        internal System.Windows.Forms.TextBox txtDBGet;
        internal System.Windows.Forms.Label label37;
        internal System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button buttonBlockInfo;
        internal System.Windows.Forms.TextBox txtBI;
        internal System.Windows.Forms.TextBox txtBlockNum;
        private System.Windows.Forms.ComboBox CBBlock;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox Refresh_text;
        private System.Windows.Forms.TextBox maxtime_textbox;
        private System.Windows.Forms.CheckBox Minimize_checkbox;
        private System.Windows.Forms.CheckBox Legend_checkbox;
        private System.Windows.Forms.Label Refresh_label;
        private System.Windows.Forms.Label maxtime_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ms_text;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button LoadVars_button;
        private System.Windows.Forms.Button SaveVars_button;
        private System.Windows.Forms.ListBox Variables_list;
        private System.Windows.Forms.Button AddToChart_button;
        private System.Windows.Forms.Button Remove_button;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox DisplayFormat_comboBox;
        private System.Windows.Forms.TextBox Comment_textBox;
        private System.Windows.Forms.TextBox PLCMax_textbox;
        private System.Windows.Forms.TextBox PLCMin_textbox;
        private System.Windows.Forms.TextBox MaxVal_textbox;
        private System.Windows.Forms.TextBox MinVal_textbox;
        private System.Windows.Forms.TextBox SymbolicName_text;
        private System.Windows.Forms.TextBox Variable_text;
        private System.Windows.Forms.TextBox Multiply_text;
        private System.Windows.Forms.TextBox Add_text;
        private System.Windows.Forms.Label DisplayFormat_label;
        private System.Windows.Forms.Label Comment_label;
        private System.Windows.Forms.CheckBox calculate_checkbox;
        private System.Windows.Forms.Label PLCMax_label;
        private System.Windows.Forms.Label PLCMin_label;
        private System.Windows.Forms.Label MaxVal_label;
        private System.Windows.Forms.Label MinVal_label;
        private System.Windows.Forms.Button Modify_button;
        private System.Windows.Forms.Label Multiply_label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button More_button;
        private System.Windows.Forms.Label SymbolicName_label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Color_button;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer CommunicationTimer;
        private System.Windows.Forms.Timer InterfaceRefreshtimer;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.CheckBox Miliseconds_checkBox;
        private System.Windows.Forms.CheckBox Seconds_checkbox;
        private System.Windows.Forms.CheckBox Minute_checkbox;
        private System.Windows.Forms.CheckBox Hour_checkbox;
        private System.Windows.Forms.CheckBox Day_checkbox;
        private System.Windows.Forms.CheckBox Month_checkBox;
        private System.Windows.Forms.CheckBox Year_checkbox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox X_Interval_text;
        private System.Windows.Forms.CheckBox Xgrid_checkBox;
        private System.Windows.Forms.CheckBox X_MinorGrid_checkbox;
        private System.Windows.Forms.Label X_Interval_label;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox Y_Interval_text;
        private System.Windows.Forms.TextBox Maxscale_text;
        private System.Windows.Forms.TextBox MinScale_text;
        private System.Windows.Forms.Label Y_Interval_label;
        private System.Windows.Forms.CheckBox Ygrid_checkbox;
        private System.Windows.Forms.CheckBox Y_MinorGrid_checkbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label Maxscale_label;
        private System.Windows.Forms.DataGridView Variables_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adres;
        private System.Windows.Forms.DataGridViewTextBoxColumn SymbolicName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Format;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.Label CPUStatus_label;
        private System.Windows.Forms.Label CPUStatus_labelconst;
        private System.Windows.Forms.TextBox LogData_textbox;
        private System.Windows.Forms.Button LogData_button;
        private System.Windows.Forms.Label LogData_label;
        private System.Windows.Forms.CheckBox LogData_checkbox;
        private System.Windows.Forms.ContextMenuStrip Chart1_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage ChartPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button dbPicker_button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox Pause_checkBox;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label35;
        internal System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label39;
        internal System.Windows.Forms.TextBox txtOrderCode;
        private System.Windows.Forms.Button buttonReadCPUInfo;
        private System.Windows.Forms.TextBox txtModuleName;
        private System.Windows.Forms.TextBox txtAsName;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtModuleTypeName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CPU_STATUS;
    }
}

