namespace HMM_Solve
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTransitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openEmissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openObservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.startTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOpenTransitions = new System.Windows.Forms.Button();
            this.buttonOpenEmissions = new System.Windows.Forms.Button();
            this.buttonCreateHMM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.transmissionsTab = new System.Windows.Forms.TabPage();
            this.transitionsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.emissionsTab = new System.Windows.Forms.TabPage();
            this.emissionsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.computationTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.controlsBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.loadObservationsButton = new System.Windows.Forms.Button();
            this.evaluateCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.forwardButton = new System.Windows.Forms.RadioButton();
            this.backwardButton = new System.Windows.Forms.RadioButton();
            this.viterbiCheckbox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.generateButton = new System.Windows.Forms.Button();
            this.numSeq = new System.Windows.Forms.NumericUpDown();
            this.trainButton = new System.Windows.Forms.Button();
            this.observationsBox = new System.Windows.Forms.GroupBox();
            this.observationsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.resultTab = new System.Windows.Forms.TabPage();
            this.resultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.startTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.transmissionsTab.SuspendLayout();
            this.emissionsTab.SuspendLayout();
            this.computationTab.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.controlsBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSeq)).BeginInit();
            this.observationsBox.SuspendLayout();
            this.resultTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(875, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTransitionsToolStripMenuItem,
            this.openEmissionsToolStripMenuItem,
            this.openObservationsToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openTransitionsToolStripMenuItem
            // 
            this.openTransitionsToolStripMenuItem.Name = "openTransitionsToolStripMenuItem";
            this.openTransitionsToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.openTransitionsToolStripMenuItem.Text = "Open Transitions";
            this.openTransitionsToolStripMenuItem.Click += new System.EventHandler(this.openTransition_Click);
            // 
            // openEmissionsToolStripMenuItem
            // 
            this.openEmissionsToolStripMenuItem.Enabled = false;
            this.openEmissionsToolStripMenuItem.Name = "openEmissionsToolStripMenuItem";
            this.openEmissionsToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.openEmissionsToolStripMenuItem.Text = "Open Emissions";
            this.openEmissionsToolStripMenuItem.Click += new System.EventHandler(this.openEmissions_Click);
            // 
            // openObservationsToolStripMenuItem
            // 
            this.openObservationsToolStripMenuItem.Enabled = false;
            this.openObservationsToolStripMenuItem.Name = "openObservationsToolStripMenuItem";
            this.openObservationsToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.openObservationsToolStripMenuItem.Text = "Open Observations";
            this.openObservationsToolStripMenuItem.Click += new System.EventHandler(this.loadObservations_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(207, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(875, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.settingsTab);
            this.tabControl1.Controls.Add(this.computationTab);
            this.tabControl1.Controls.Add(this.resultTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(875, 456);
            this.tabControl1.TabIndex = 5;
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.tabControl2);
            this.settingsTab.Location = new System.Drawing.Point(4, 25);
            this.settingsTab.Margin = new System.Windows.Forms.Padding(4);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(4);
            this.settingsTab.Size = new System.Drawing.Size(867, 427);
            this.settingsTab.TabIndex = 0;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.startTab);
            this.tabControl2.Controls.Add(this.transmissionsTab);
            this.tabControl2.Controls.Add(this.emissionsTab);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(4, 4);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(859, 419);
            this.tabControl2.TabIndex = 0;
            // 
            // startTab
            // 
            this.startTab.Controls.Add(this.tableLayoutPanel1);
            this.startTab.Location = new System.Drawing.Point(4, 25);
            this.startTab.Margin = new System.Windows.Forms.Padding(4);
            this.startTab.Name = "startTab";
            this.startTab.Padding = new System.Windows.Forms.Padding(4);
            this.startTab.Size = new System.Drawing.Size(851, 390);
            this.startTab.TabIndex = 0;
            this.startTab.Text = "Start";
            this.startTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonOpenTransitions, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonOpenEmissions, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonCreateHMM, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(843, 382);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // buttonOpenTransitions
            // 
            this.buttonOpenTransitions.AutoSize = true;
            this.buttonOpenTransitions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenTransitions.Location = new System.Drawing.Point(4, 99);
            this.buttonOpenTransitions.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenTransitions.Name = "buttonOpenTransitions";
            this.buttonOpenTransitions.Size = new System.Drawing.Size(835, 87);
            this.buttonOpenTransitions.TabIndex = 9;
            this.buttonOpenTransitions.Text = "Open transitions file";
            this.buttonOpenTransitions.UseVisualStyleBackColor = true;
            this.buttonOpenTransitions.Click += new System.EventHandler(this.openTransition_Click);
            // 
            // buttonOpenEmissions
            // 
            this.buttonOpenEmissions.AutoSize = true;
            this.buttonOpenEmissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenEmissions.Enabled = false;
            this.buttonOpenEmissions.Location = new System.Drawing.Point(4, 194);
            this.buttonOpenEmissions.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenEmissions.Name = "buttonOpenEmissions";
            this.buttonOpenEmissions.Size = new System.Drawing.Size(835, 87);
            this.buttonOpenEmissions.TabIndex = 10;
            this.buttonOpenEmissions.Text = "Open emissions file";
            this.buttonOpenEmissions.UseVisualStyleBackColor = true;
            this.buttonOpenEmissions.Click += new System.EventHandler(this.openEmissions_Click);
            // 
            // buttonCreateHMM
            // 
            this.buttonCreateHMM.AutoSize = true;
            this.buttonCreateHMM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreateHMM.Enabled = false;
            this.buttonCreateHMM.Location = new System.Drawing.Point(3, 287);
            this.buttonCreateHMM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateHMM.Name = "buttonCreateHMM";
            this.buttonCreateHMM.Size = new System.Drawing.Size(837, 93);
            this.buttonCreateHMM.TabIndex = 11;
            this.buttonCreateHMM.Text = "Create HMM";
            this.buttonCreateHMM.UseVisualStyleBackColor = true;
            this.buttonCreateHMM.Click += new System.EventHandler(this.createHMM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(835, 95);
            this.label1.TabIndex = 12;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // transmissionsTab
            // 
            this.transmissionsTab.Controls.Add(this.transitionsRichTextBox);
            this.transmissionsTab.Location = new System.Drawing.Point(4, 25);
            this.transmissionsTab.Margin = new System.Windows.Forms.Padding(4);
            this.transmissionsTab.Name = "transmissionsTab";
            this.transmissionsTab.Padding = new System.Windows.Forms.Padding(4);
            this.transmissionsTab.Size = new System.Drawing.Size(851, 390);
            this.transmissionsTab.TabIndex = 1;
            this.transmissionsTab.Text = "Transmissions";
            this.transmissionsTab.UseVisualStyleBackColor = true;
            // 
            // transitionsRichTextBox
            // 
            this.transitionsRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transitionsRichTextBox.Location = new System.Drawing.Point(4, 4);
            this.transitionsRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.transitionsRichTextBox.Name = "transitionsRichTextBox";
            this.transitionsRichTextBox.ReadOnly = true;
            this.transitionsRichTextBox.Size = new System.Drawing.Size(843, 382);
            this.transitionsRichTextBox.TabIndex = 0;
            this.transitionsRichTextBox.Text = "";
            // 
            // emissionsTab
            // 
            this.emissionsTab.Controls.Add(this.emissionsRichTextBox);
            this.emissionsTab.Location = new System.Drawing.Point(4, 25);
            this.emissionsTab.Margin = new System.Windows.Forms.Padding(4);
            this.emissionsTab.Name = "emissionsTab";
            this.emissionsTab.Padding = new System.Windows.Forms.Padding(4);
            this.emissionsTab.Size = new System.Drawing.Size(851, 390);
            this.emissionsTab.TabIndex = 2;
            this.emissionsTab.Text = "Emissions";
            this.emissionsTab.UseVisualStyleBackColor = true;
            // 
            // emissionsRichTextBox
            // 
            this.emissionsRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emissionsRichTextBox.Location = new System.Drawing.Point(4, 4);
            this.emissionsRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.emissionsRichTextBox.Name = "emissionsRichTextBox";
            this.emissionsRichTextBox.ReadOnly = true;
            this.emissionsRichTextBox.Size = new System.Drawing.Size(843, 382);
            this.emissionsRichTextBox.TabIndex = 0;
            this.emissionsRichTextBox.Text = "";
            // 
            // computationTab
            // 
            this.computationTab.Controls.Add(this.tableLayoutPanel6);
            this.computationTab.Location = new System.Drawing.Point(4, 25);
            this.computationTab.Margin = new System.Windows.Forms.Padding(4);
            this.computationTab.Name = "computationTab";
            this.computationTab.Padding = new System.Windows.Forms.Padding(4);
            this.computationTab.Size = new System.Drawing.Size(867, 427);
            this.computationTab.TabIndex = 1;
            this.computationTab.Text = "Computation";
            this.computationTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.controlsBox, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.observationsBox, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(859, 419);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // controlsBox
            // 
            this.controlsBox.AutoSize = true;
            this.controlsBox.Controls.Add(this.tableLayoutPanel2);
            this.controlsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsBox.Location = new System.Drawing.Point(433, 4);
            this.controlsBox.Margin = new System.Windows.Forms.Padding(4);
            this.controlsBox.Name = "controlsBox";
            this.controlsBox.Padding = new System.Windows.Forms.Padding(4);
            this.controlsBox.Size = new System.Drawing.Size(422, 411);
            this.controlsBox.TabIndex = 3;
            this.controlsBox.TabStop = false;
            this.controlsBox.Text = "Controls";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonStart, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.loadObservationsButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.evaluateCheckBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.viterbiCheckbox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.trainButton, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(414, 388);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // buttonStart
            // 
            this.buttonStart.AutoSize = true;
            this.buttonStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStart.Location = new System.Drawing.Point(4, 224);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(406, 47);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.evaluationStart_Click);
            // 
            // loadObservationsButton
            // 
            this.loadObservationsButton.AutoSize = true;
            this.loadObservationsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadObservationsButton.Location = new System.Drawing.Point(4, 4);
            this.loadObservationsButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadObservationsButton.Name = "loadObservationsButton";
            this.loadObservationsButton.Size = new System.Drawing.Size(406, 47);
            this.loadObservationsButton.TabIndex = 3;
            this.loadObservationsButton.Text = "Load observations";
            this.loadObservationsButton.UseVisualStyleBackColor = true;
            this.loadObservationsButton.Click += new System.EventHandler(this.loadObservations_Click);
            // 
            // evaluateCheckBox
            // 
            this.evaluateCheckBox.AutoSize = true;
            this.evaluateCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluateCheckBox.Location = new System.Drawing.Point(4, 59);
            this.evaluateCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.evaluateCheckBox.Name = "evaluateCheckBox";
            this.evaluateCheckBox.Size = new System.Drawing.Size(406, 47);
            this.evaluateCheckBox.TabIndex = 6;
            this.evaluateCheckBox.Text = "Probability that the model generated the sequences (Forward/Backward)";
            this.evaluateCheckBox.UseVisualStyleBackColor = true;
            this.evaluateCheckBox.CheckedChanged += new System.EventHandler(this.evaluate_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.forwardButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.backwardButton, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 113);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(408, 49);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // forwardButton
            // 
            this.forwardButton.AutoSize = true;
            this.forwardButton.Checked = true;
            this.forwardButton.Enabled = false;
            this.forwardButton.Location = new System.Drawing.Point(4, 4);
            this.forwardButton.Margin = new System.Windows.Forms.Padding(4);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(142, 21);
            this.forwardButton.TabIndex = 9;
            this.forwardButton.TabStop = true;
            this.forwardButton.Text = "Forward algorithm";
            this.forwardButton.UseVisualStyleBackColor = true;
            // 
            // backwardButton
            // 
            this.backwardButton.AutoSize = true;
            this.backwardButton.Enabled = false;
            this.backwardButton.Location = new System.Drawing.Point(208, 4);
            this.backwardButton.Margin = new System.Windows.Forms.Padding(4);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(152, 21);
            this.backwardButton.TabIndex = 10;
            this.backwardButton.TabStop = true;
            this.backwardButton.Text = "Backward algorithm";
            this.backwardButton.UseVisualStyleBackColor = true;
            // 
            // viterbiCheckbox
            // 
            this.viterbiCheckbox.AutoSize = true;
            this.viterbiCheckbox.Location = new System.Drawing.Point(4, 169);
            this.viterbiCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.viterbiCheckbox.Name = "viterbiCheckbox";
            this.viterbiCheckbox.Size = new System.Drawing.Size(305, 21);
            this.viterbiCheckbox.TabIndex = 7;
            this.viterbiCheckbox.Text = "Most probable sequences of states (Viterbi)";
            this.viterbiCheckbox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.generateButton, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.numSeq, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 278);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(408, 49);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // generateButton
            // 
            this.generateButton.AutoSize = true;
            this.generateButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateButton.Location = new System.Drawing.Point(207, 3);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(198, 43);
            this.generateButton.TabIndex = 11;
            this.generateButton.Text = "Generate sequences";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // numSeq
            // 
            this.numSeq.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSeq.Location = new System.Drawing.Point(3, 9);
            this.numSeq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSeq.Name = "numSeq";
            this.numSeq.Size = new System.Drawing.Size(198, 30);
            this.numSeq.TabIndex = 12;
            this.numSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSeq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // trainButton
            // 
            this.trainButton.AutoSize = true;
            this.trainButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainButton.Location = new System.Drawing.Point(4, 334);
            this.trainButton.Margin = new System.Windows.Forms.Padding(4);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(406, 50);
            this.trainButton.TabIndex = 8;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // observationsBox
            // 
            this.observationsBox.AutoSize = true;
            this.observationsBox.Controls.Add(this.observationsRichTextBox);
            this.observationsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.observationsBox.Location = new System.Drawing.Point(4, 4);
            this.observationsBox.Margin = new System.Windows.Forms.Padding(4);
            this.observationsBox.Name = "observationsBox";
            this.observationsBox.Padding = new System.Windows.Forms.Padding(4);
            this.observationsBox.Size = new System.Drawing.Size(421, 411);
            this.observationsBox.TabIndex = 2;
            this.observationsBox.TabStop = false;
            this.observationsBox.Text = "Observations";
            // 
            // observationsRichTextBox
            // 
            this.observationsRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.observationsRichTextBox.Location = new System.Drawing.Point(4, 19);
            this.observationsRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.observationsRichTextBox.Name = "observationsRichTextBox";
            this.observationsRichTextBox.Size = new System.Drawing.Size(413, 388);
            this.observationsRichTextBox.TabIndex = 0;
            this.observationsRichTextBox.Text = "";
            // 
            // resultTab
            // 
            this.resultTab.Controls.Add(this.resultRichTextBox);
            this.resultTab.Location = new System.Drawing.Point(4, 25);
            this.resultTab.Margin = new System.Windows.Forms.Padding(4);
            this.resultTab.Name = "resultTab";
            this.resultTab.Padding = new System.Windows.Forms.Padding(4);
            this.resultTab.Size = new System.Drawing.Size(867, 427);
            this.resultTab.TabIndex = 2;
            this.resultTab.Text = "Results";
            this.resultTab.UseVisualStyleBackColor = true;
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultRichTextBox.Location = new System.Drawing.Point(4, 4);
            this.resultRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.Size = new System.Drawing.Size(859, 419);
            this.resultRichTextBox.TabIndex = 0;
            this.resultRichTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 506);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Hidden Markov Model";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.startTab.ResumeLayout(false);
            this.startTab.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.transmissionsTab.ResumeLayout(false);
            this.emissionsTab.ResumeLayout(false);
            this.computationTab.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.controlsBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSeq)).EndInit();
            this.observationsBox.ResumeLayout(false);
            this.resultTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem openEmissionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTransitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.TabPage computationTab;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage startTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage emissionsTab;
        private System.Windows.Forms.Button buttonCreateHMM;
        private System.Windows.Forms.Button buttonOpenEmissions;
        private System.Windows.Forms.Button buttonOpenTransitions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox transitionsRichTextBox;
        private System.Windows.Forms.TabPage transmissionsTab;
        private System.Windows.Forms.RichTextBox emissionsRichTextBox;
        private System.Windows.Forms.ToolStripMenuItem openObservationsToolStripMenuItem;
        private System.Windows.Forms.GroupBox controlsBox;
        private System.Windows.Forms.RichTextBox observationsRichTextBox;
        private System.Windows.Forms.GroupBox observationsBox;
        private System.Windows.Forms.Button loadObservationsButton;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.CheckBox viterbiCheckbox;
        private System.Windows.Forms.CheckBox evaluateCheckBox;
        private System.Windows.Forms.RadioButton backwardButton;
        private System.Windows.Forms.RadioButton forwardButton;
        private System.Windows.Forms.TabPage resultTab;
        private System.Windows.Forms.RichTextBox resultRichTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.NumericUpDown numSeq;
    }
}

