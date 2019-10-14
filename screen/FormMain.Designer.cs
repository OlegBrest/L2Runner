namespace L2Runner
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.find_windows_bttn = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.buttonTracking = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contextMenu_otherDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateIdealValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.filter_txtbx = new System.Windows.Forms.TextBox();
            this.clients_dgv = new System.Windows.Forms.DataGridView();
            this.winname_clients_dgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winhdr_clients_dgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.log = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv_script = new System.Windows.Forms.DataGridView();
            this.id_script_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_script_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target_script_clmn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.criteria_script_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action_script_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.window_script_clmn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.result_script_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delay_script_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextuse_script_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targets_dgv = new L2Runner.MyDGrV();
            this.name_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_clmn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.coord_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentage_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ideal_value_clmn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Current_value_clmn = new System.Windows.Forms.DataGridViewImageColumn();
            this.correction_clmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenu_otherDGV.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clients_dgv)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_script)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targets_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // find_windows_bttn
            // 
            this.find_windows_bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.find_windows_bttn.Location = new System.Drawing.Point(3, 3);
            this.find_windows_bttn.Name = "find_windows_bttn";
            this.find_windows_bttn.Size = new System.Drawing.Size(259, 74);
            this.find_windows_bttn.TabIndex = 0;
            this.find_windows_bttn.Text = "Take windows";
            this.find_windows_bttn.UseVisualStyleBackColor = true;
            this.find_windows_bttn.Click += new System.EventHandler(this.find_windows_bttn_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.White;
            this.pictureBoxMain.Location = new System.Drawing.Point(0, 3);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(520, 210);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMain.TabIndex = 2;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Click += new System.EventHandler(this.pictureBoxMain_Click);
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // buttonTracking
            // 
            this.buttonTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTracking.Location = new System.Drawing.Point(268, 3);
            this.buttonTracking.Name = "buttonTracking";
            this.buttonTracking.Size = new System.Drawing.Size(254, 74);
            this.buttonTracking.TabIndex = 5;
            this.buttonTracking.Text = "Start Boting";
            this.buttonTracking.UseVisualStyleBackColor = true;
            this.buttonTracking.Click += new System.EventHandler(this.buttonTracking_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(5, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 160);
            this.panel1.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1105, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.pictureBoxMain);
            this.panel3.Location = new System.Drawing.Point(528, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(560, 299);
            this.panel3.TabIndex = 18;
            // 
            // contextMenu_otherDGV
            // 
            this.contextMenu_otherDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateIdealValuesToolStripMenuItem});
            this.contextMenu_otherDGV.Name = "contextMenu_otherDGV";
            this.contextMenu_otherDGV.Size = new System.Drawing.Size(219, 26);
            this.contextMenu_otherDGV.Text = "Editing Key Settings";
            // 
            // updateIdealValuesToolStripMenuItem
            // 
            this.updateIdealValuesToolStripMenuItem.Name = "updateIdealValuesToolStripMenuItem";
            this.updateIdealValuesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.updateIdealValuesToolStripMenuItem.Text = "Update Ideal Sample Image";
            this.updateIdealValuesToolStripMenuItem.Click += new System.EventHandler(this.updateIdealValuesToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1105, 561);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1097, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MainPage";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.filter_txtbx);
            this.panel2.Controls.Add(this.clients_dgv);
            this.panel2.Controls.Add(this.log);
            this.panel2.Controls.Add(this.find_windows_bttn);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.targets_dgv);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.buttonTracking);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1091, 529);
            this.panel2.TabIndex = 0;
            // 
            // filter_txtbx
            // 
            this.filter_txtbx.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::L2Runner.Properties.Settings.Default, "filte_string", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.filter_txtbx.Location = new System.Drawing.Point(270, 83);
            this.filter_txtbx.Name = "filter_txtbx";
            this.filter_txtbx.Size = new System.Drawing.Size(252, 20);
            this.filter_txtbx.TabIndex = 30;
            this.filter_txtbx.Text = global::L2Runner.Properties.Settings.Default.filte_string;
            this.filter_txtbx.TextChanged += new System.EventHandler(this.filter_txtbx_TextChanged);
            // 
            // clients_dgv
            // 
            this.clients_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.clients_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clients_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.winname_clients_dgv,
            this.winhdr_clients_dgv});
            this.clients_dgv.Location = new System.Drawing.Point(270, 109);
            this.clients_dgv.Name = "clients_dgv";
            this.clients_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clients_dgv.Size = new System.Drawing.Size(252, 134);
            this.clients_dgv.TabIndex = 29;
            this.clients_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clients_dgv_CellClick);
            // 
            // winname_clients_dgv
            // 
            this.winname_clients_dgv.DataPropertyName = "winname_clients_dgv";
            this.winname_clients_dgv.HeaderText = "Win Name";
            this.winname_clients_dgv.Name = "winname_clients_dgv";
            this.winname_clients_dgv.Width = 82;
            // 
            // winhdr_clients_dgv
            // 
            this.winhdr_clients_dgv.DataPropertyName = "winhdr_clients_dgv";
            this.winhdr_clients_dgv.HeaderText = "Header";
            this.winhdr_clients_dgv.Name = "winhdr_clients_dgv";
            this.winhdr_clients_dgv.Width = 67;
            // 
            // log
            // 
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(5, 246);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(517, 56);
            this.log.TabIndex = 28;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1097, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ScriptPage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv_script);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1091, 529);
            this.panel4.TabIndex = 0;
            // 
            // dgv_script
            // 
            this.dgv_script.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_script.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_script.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_script_clmn,
            this.name_script_clmn,
            this.target_script_clmn,
            this.criteria_script_clmn,
            this.action_script_clmn,
            this.window_script_clmn,
            this.result_script_clmn,
            this.delay_script_clmn,
            this.nextuse_script_clmn});
            this.dgv_script.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_script.Location = new System.Drawing.Point(0, 0);
            this.dgv_script.Name = "dgv_script";
            this.dgv_script.Size = new System.Drawing.Size(1091, 529);
            this.dgv_script.TabIndex = 0;
            this.dgv_script.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_script_CellClick);
            this.dgv_script.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_script_CellValueChanged);
            // 
            // id_script_clmn
            // 
            this.id_script_clmn.DataPropertyName = "id_script_clmn";
            this.id_script_clmn.HeaderText = "ID";
            this.id_script_clmn.Name = "id_script_clmn";
            this.id_script_clmn.ReadOnly = true;
            this.id_script_clmn.Width = 43;
            // 
            // name_script_clmn
            // 
            this.name_script_clmn.DataPropertyName = "name_script_clmn";
            this.name_script_clmn.HeaderText = "Name";
            this.name_script_clmn.Name = "name_script_clmn";
            this.name_script_clmn.Width = 60;
            // 
            // target_script_clmn
            // 
            this.target_script_clmn.DataPropertyName = "target_script_clmn";
            this.target_script_clmn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.target_script_clmn.HeaderText = "Target";
            this.target_script_clmn.Name = "target_script_clmn";
            this.target_script_clmn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.target_script_clmn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.target_script_clmn.Width = 63;
            // 
            // criteria_script_clmn
            // 
            this.criteria_script_clmn.DataPropertyName = "criteria_script_clmn";
            this.criteria_script_clmn.HeaderText = "Criteria";
            this.criteria_script_clmn.Name = "criteria_script_clmn";
            this.criteria_script_clmn.Width = 64;
            // 
            // action_script_clmn
            // 
            this.action_script_clmn.DataPropertyName = "action_script_clmn";
            this.action_script_clmn.HeaderText = "Action";
            this.action_script_clmn.Name = "action_script_clmn";
            this.action_script_clmn.Width = 62;
            // 
            // window_script_clmn
            // 
            this.window_script_clmn.DataPropertyName = "window_script_clmn";
            this.window_script_clmn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.window_script_clmn.HeaderText = "Window";
            this.window_script_clmn.Name = "window_script_clmn";
            this.window_script_clmn.Width = 52;
            // 
            // result_script_clmn
            // 
            this.result_script_clmn.DataPropertyName = "result_script_clmn";
            this.result_script_clmn.HeaderText = "Result";
            this.result_script_clmn.Name = "result_script_clmn";
            this.result_script_clmn.ReadOnly = true;
            this.result_script_clmn.Width = 62;
            // 
            // delay_script_clmn
            // 
            this.delay_script_clmn.DataPropertyName = "delay_script_clmn";
            this.delay_script_clmn.HeaderText = "Delay";
            this.delay_script_clmn.Name = "delay_script_clmn";
            this.delay_script_clmn.Width = 59;
            // 
            // nextuse_script_clmn
            // 
            this.nextuse_script_clmn.DataPropertyName = "nextuse_script_clmn";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm:ss.fff";
            this.nextuse_script_clmn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nextuse_script_clmn.HeaderText = "Next Use after";
            this.nextuse_script_clmn.Name = "nextuse_script_clmn";
            // 
            // targets_dgv
            // 
            this.targets_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targets_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.targets_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.targets_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.targets_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name_clmn,
            this.type_clmn,
            this.coord_clmn,
            this.percentage_clmn,
            this.ideal_value_clmn,
            this.Current_value_clmn,
            this.correction_clmn,
            this.last_change,
            this.idle});
            this.targets_dgv.ContextMenuStrip = this.contextMenu_otherDGV;
            this.targets_dgv.Location = new System.Drawing.Point(3, 308);
            this.targets_dgv.Name = "targets_dgv";
            this.targets_dgv.Size = new System.Drawing.Size(1083, 218);
            this.targets_dgv.TabIndex = 27;
            this.targets_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.other_targets_dgv_CellClick);
            this.targets_dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.targets_dgv_CellValueChanged);
            this.targets_dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.targets_dgv_DataError);
            // 
            // name_clmn
            // 
            this.name_clmn.DataPropertyName = "name_clmn";
            this.name_clmn.HeaderText = "Name";
            this.name_clmn.Name = "name_clmn";
            this.name_clmn.Width = 60;
            // 
            // type_clmn
            // 
            this.type_clmn.DataPropertyName = "type_clmn";
            this.type_clmn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.type_clmn.HeaderText = "Type";
            this.type_clmn.Name = "type_clmn";
            this.type_clmn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.type_clmn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.type_clmn.Width = 56;
            // 
            // coord_clmn
            // 
            this.coord_clmn.DataPropertyName = "coord_clmn";
            this.coord_clmn.HeaderText = "Coords of bar / Image finder";
            this.coord_clmn.Name = "coord_clmn";
            this.coord_clmn.Width = 126;
            // 
            // percentage_clmn
            // 
            this.percentage_clmn.DataPropertyName = "percentage_clmn";
            this.percentage_clmn.HeaderText = "Similarity";
            this.percentage_clmn.Name = "percentage_clmn";
            this.percentage_clmn.ReadOnly = true;
            this.percentage_clmn.Width = 72;
            // 
            // ideal_value_clmn
            // 
            this.ideal_value_clmn.DataPropertyName = "ideal_value_clmn";
            this.ideal_value_clmn.HeaderText = "Ideal sample";
            this.ideal_value_clmn.Name = "ideal_value_clmn";
            this.ideal_value_clmn.ReadOnly = true;
            this.ideal_value_clmn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ideal_value_clmn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ideal_value_clmn.Width = 84;
            // 
            // Current_value_clmn
            // 
            this.Current_value_clmn.DataPropertyName = "Current_value_clmn";
            this.Current_value_clmn.HeaderText = "Current";
            this.Current_value_clmn.Name = "Current_value_clmn";
            this.Current_value_clmn.ReadOnly = true;
            this.Current_value_clmn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Current_value_clmn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Current_value_clmn.Width = 66;
            // 
            // correction_clmn
            // 
            this.correction_clmn.DataPropertyName = "correction_clmn";
            this.correction_clmn.HeaderText = "PixelCorrection";
            this.correction_clmn.Name = "correction_clmn";
            this.correction_clmn.Width = 102;
            // 
            // last_change
            // 
            this.last_change.DataPropertyName = "last_change";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm:ss.fff";
            dataGridViewCellStyle1.NullValue = null;
            this.last_change.DefaultCellStyle = dataGridViewCellStyle1;
            this.last_change.HeaderText = "last_change";
            this.last_change.Name = "last_change";
            this.last_change.ReadOnly = true;
            this.last_change.Visible = false;
            this.last_change.Width = 90;
            // 
            // idle
            // 
            this.idle.DataPropertyName = "idle";
            this.idle.HeaderText = "Idle";
            this.idle.Name = "idle";
            this.idle.ReadOnly = true;
            this.idle.Width = 49;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1105, 583);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "L2 Runner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.contextMenu_otherDGV.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clients_dgv)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_script)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targets_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button find_windows_bttn;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button buttonTracking;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Panel panel3;
        private MyDGrV targets_dgv;
        private System.Windows.Forms.ContextMenuStrip contextMenu_otherDGV;
        private System.Windows.Forms.ToolStripMenuItem updateIdealValuesToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgv_script;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.DataGridView clients_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn winname_clients_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn winhdr_clients_dgv;
        private System.Windows.Forms.TextBox filter_txtbx;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_script_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_script_clmn;
        private System.Windows.Forms.DataGridViewComboBoxColumn target_script_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn criteria_script_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn action_script_clmn;
        private System.Windows.Forms.DataGridViewComboBoxColumn window_script_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn result_script_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delay_script_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextuse_script_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_clmn;
        private System.Windows.Forms.DataGridViewComboBoxColumn type_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coord_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentage_clmn;
        private System.Windows.Forms.DataGridViewImageColumn ideal_value_clmn;
        private System.Windows.Forms.DataGridViewImageColumn Current_value_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn correction_clmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_change;
        private System.Windows.Forms.DataGridViewTextBoxColumn idle;
    }
}

