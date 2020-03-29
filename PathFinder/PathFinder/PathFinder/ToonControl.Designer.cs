namespace PathFinder
{
    partial class ToonControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TestWorker = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.rtbDebug = new System.Windows.Forms.RichTextBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.PointNametb = new System.Windows.Forms.TextBox();
            this.PointsComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadHitPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveHitPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ScantBtn = new System.Windows.Forms.Button();
            this.AddTargetBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.ClearTargetsBtn = new System.Windows.Forms.Button();
            this.TargetComboBox = new System.Windows.Forms.ComboBox();
            this.TargetCountLb = new System.Windows.Forms.Label();
            this.NpcLB = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.button9 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button12 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.tabControl3.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestWorker
            // 
            this.TestWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.TestWorker_DoWork);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // rtbDebug
            // 
            this.rtbDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rtbDebug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDebug.CausesValidation = false;
            this.rtbDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDebug.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDebug.ForeColor = System.Drawing.Color.Yellow;
            this.rtbDebug.Location = new System.Drawing.Point(3, 3);
            this.rtbDebug.Margin = new System.Windows.Forms.Padding(4);
            this.rtbDebug.Name = "rtbDebug";
            this.rtbDebug.Size = new System.Drawing.Size(786, 144);
            this.rtbDebug.TabIndex = 1;
            this.rtbDebug.Text = "";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl3.Location = new System.Drawing.Point(0, 308);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(800, 176);
            this.tabControl3.TabIndex = 27;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.rtbDebug);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(792, 150);
            this.tabPage9.TabIndex = 0;
            this.tabPage9.Text = "Debug";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox2);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(792, 282);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Path Test To Points Of Interest";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button16);
            this.groupBox2.Controls.Add(this.button15);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.PointNametb);
            this.groupBox2.Controls.Add(this.PointsComboBox);
            this.groupBox2.Controls.Add(this.menuStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 282);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Point of interest name = ";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(314, 43);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(112, 23);
            this.button13.TabIndex = 12;
            this.button13.Text = "Add Point of Interest";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // PointNametb
            // 
            this.PointNametb.Location = new System.Drawing.Point(133, 46);
            this.PointNametb.Name = "PointNametb";
            this.PointNametb.Size = new System.Drawing.Size(175, 20);
            this.PointNametb.TabIndex = 11;
            // 
            // PointsComboBox
            // 
            this.PointsComboBox.FormattingEnabled = true;
            this.PointsComboBox.Location = new System.Drawing.Point(125, 82);
            this.PointsComboBox.Name = "PointsComboBox";
            this.PointsComboBox.Size = new System.Drawing.Size(121, 21);
            this.PointsComboBox.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadHitPointToolStripMenuItem,
            this.saveHitPointsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(786, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadHitPointToolStripMenuItem
            // 
            this.loadHitPointToolStripMenuItem.Name = "loadHitPointToolStripMenuItem";
            this.loadHitPointToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.loadHitPointToolStripMenuItem.Text = "Load ";
            this.loadHitPointToolStripMenuItem.Click += new System.EventHandler(this.loadHitPointToolStripMenuItem_Click);
            // 
            // saveHitPointsToolStripMenuItem
            // 
            this.saveHitPointsToolStripMenuItem.Name = "saveHitPointsToolStripMenuItem";
            this.saveHitPointsToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveHitPointsToolStripMenuItem.Text = "Save";
            this.saveHitPointsToolStripMenuItem.Click += new System.EventHandler(this.saveHitPointsToolStripMenuItem_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tabControl1);
            this.tabPage5.Controls.Add(this.StartBtn);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(792, 282);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Path Test to Mob";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 259);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btn);
            this.tabPage1.Controls.Add(this.LoadBtn);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(784, 233);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DSP.Nav files";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(3, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "5 Press start ";
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(3, 157);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(778, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "Unload Navmesh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Location = new System.Drawing.Point(3, 134);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(778, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Try Get waypoints from dll";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(3, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "4  try get waypoints";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(3, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(778, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Any path points?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(3, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(778, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Find Path Test using dsp nav";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "3 click find path";
            // 
            // btn
            // 
            this.btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn.Location = new System.Drawing.Point(3, 39);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(778, 23);
            this.btn.TabIndex = 18;
            this.btn.Text = "Is navmesh enabled?";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // LoadBtn
            // 
            this.LoadBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoadBtn.Location = new System.Drawing.Point(3, 16);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(778, 23);
            this.LoadBtn.TabIndex = 0;
            this.LoadBtn.Text = "Load Mesh file";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "2 load navmesh";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(784, 233);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = ".Nav files from Noesis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(3, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "5 Press start ";
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.Location = new System.Drawing.Point(3, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(778, 23);
            this.button6.TabIndex = 31;
            this.button6.Text = "Unload Navmesh";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.Location = new System.Drawing.Point(3, 134);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(778, 23);
            this.button7.TabIndex = 32;
            this.button7.Text = "Try Get waypoints from dll";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(3, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "4  try get waypoints";
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Top;
            this.button8.Location = new System.Drawing.Point(3, 98);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(778, 23);
            this.button8.TabIndex = 29;
            this.button8.Text = "Any path points?";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Location = new System.Drawing.Point(3, 75);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(778, 23);
            this.button5.TabIndex = 28;
            this.button5.Text = "find path using nav files made with noesis obj files";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(3, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "3 click find path";
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.Location = new System.Drawing.Point(3, 39);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(778, 23);
            this.button10.TabIndex = 28;
            this.button10.Text = "Is navmesh enabled?";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Top;
            this.button11.Location = new System.Drawing.Point(3, 16);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(778, 23);
            this.button11.TabIndex = 27;
            this.button11.Text = "Load Mesh file";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "2 load navmesh";
            // 
            // StartBtn
            // 
            this.StartBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartBtn.Location = new System.Drawing.Point(0, 259);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(792, 23);
            this.StartBtn.TabIndex = 17;
            this.StartBtn.Text = "Start";
            this.StartBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.numericUpDown1);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.NpcLB);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 282);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Target";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(559, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Search Distance";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(559, 63);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 25;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ScantBtn);
            this.groupBox1.Controls.Add(this.AddTargetBtn);
            this.groupBox1.Controls.Add(this.RemoveBtn);
            this.groupBox1.Controls.Add(this.ClearTargetsBtn);
            this.groupBox1.Controls.Add(this.TargetComboBox);
            this.groupBox1.Controls.Add(this.TargetCountLb);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(240, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 276);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(3, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(223, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "1 If Testing Path Test. please add Target First";
            // 
            // ScantBtn
            // 
            this.ScantBtn.Location = new System.Drawing.Point(15, 44);
            this.ScantBtn.Name = "ScantBtn";
            this.ScantBtn.Size = new System.Drawing.Size(130, 37);
            this.ScantBtn.TabIndex = 9;
            this.ScantBtn.Text = "Scan npc\'s";
            this.ScantBtn.UseVisualStyleBackColor = true;
            this.ScantBtn.Click += new System.EventHandler(this.ScantBtn_Click);
            // 
            // AddTargetBtn
            // 
            this.AddTargetBtn.Location = new System.Drawing.Point(15, 87);
            this.AddTargetBtn.Name = "AddTargetBtn";
            this.AddTargetBtn.Size = new System.Drawing.Size(130, 37);
            this.AddTargetBtn.TabIndex = 15;
            this.AddTargetBtn.Text = "Add Target";
            this.AddTargetBtn.UseVisualStyleBackColor = true;
            this.AddTargetBtn.Click += new System.EventHandler(this.AddTargetBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Location = new System.Drawing.Point(7, 194);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(133, 37);
            this.RemoveBtn.TabIndex = 12;
            this.RemoveBtn.Text = "Remove Target";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // ClearTargetsBtn
            // 
            this.ClearTargetsBtn.Location = new System.Drawing.Point(151, 194);
            this.ClearTargetsBtn.Name = "ClearTargetsBtn";
            this.ClearTargetsBtn.Size = new System.Drawing.Size(133, 37);
            this.ClearTargetsBtn.TabIndex = 14;
            this.ClearTargetsBtn.Text = "Clear Targets";
            this.ClearTargetsBtn.UseVisualStyleBackColor = true;
            this.ClearTargetsBtn.Click += new System.EventHandler(this.ClearTargetsBtn_Click);
            // 
            // TargetComboBox
            // 
            this.TargetComboBox.FormattingEnabled = true;
            this.TargetComboBox.Items.AddRange(new object[] {
            "View Targets"});
            this.TargetComboBox.Location = new System.Drawing.Point(6, 167);
            this.TargetComboBox.Name = "TargetComboBox";
            this.TargetComboBox.Size = new System.Drawing.Size(133, 21);
            this.TargetComboBox.TabIndex = 13;
            // 
            // TargetCountLb
            // 
            this.TargetCountLb.AutoSize = true;
            this.TargetCountLb.Location = new System.Drawing.Point(6, 151);
            this.TargetCountLb.Name = "TargetCountLb";
            this.TargetCountLb.Size = new System.Drawing.Size(86, 13);
            this.TargetCountLb.TabIndex = 10;
            this.TargetCountLb.Text = "Target count = 0";
            // 
            // NpcLB
            // 
            this.NpcLB.CausesValidation = false;
            this.NpcLB.Dock = System.Windows.Forms.DockStyle.Left;
            this.NpcLB.Location = new System.Drawing.Point(3, 3);
            this.NpcLB.Margin = new System.Windows.Forms.Padding(4);
            this.NpcLB.Name = "NpcLB";
            this.NpcLB.Size = new System.Drawing.Size(237, 276);
            this.NpcLB.TabIndex = 7;
            this.NpcLB.DoubleClick += new System.EventHandler(this.NpcLB_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(149, -17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "1 select a mob to kill";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(800, 308);
            this.tabControl2.TabIndex = 26;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(454, 44);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 14;
            this.button9.Text = "Clear";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(299, 80);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 15;
            this.button12.Text = "Start";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Select Point of interest";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(252, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "hit start";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(3, 130);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(154, 23);
            this.button14.TabIndex = 28;
            this.button14.Text = "Load Mesh file";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(3, 159);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(154, 23);
            this.button15.TabIndex = 29;
            this.button15.Text = "Is navmesh enabled?";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(3, 188);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(154, 23);
            this.button16.TabIndex = 30;
            this.button16.Text = "Any path points?";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // ToonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl3);
            this.Name = "ToonControl";
            this.Size = new System.Drawing.Size(800, 484);
            this.tabControl3.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Timer timer;
        public System.Windows.Forms.RichTextBox rtbDebug;
        public System.Windows.Forms.Button LoadBtn;
        public System.Windows.Forms.Button button11;
        public System.Windows.Forms.Button ScantBtn;
        public System.Windows.Forms.Button AddTargetBtn;
        public System.Windows.Forms.Button RemoveBtn;
        public System.Windows.Forms.Button ClearTargetsBtn;
        public System.Windows.Forms.ComboBox TargetComboBox;
        public System.Windows.Forms.Label TargetCountLb;
        public System.Windows.Forms.ListBox NpcLB;
        public System.ComponentModel.BackgroundWorker TestWorker;
        public System.Windows.Forms.TabControl tabControl3;
        public System.Windows.Forms.TabPage tabPage9;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.TabPage tabPage7;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox PointsComboBox;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem loadHitPointToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveHitPointsToolStripMenuItem;
        public System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btn;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button button6;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button button8;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button button10;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button StartBtn;
        public System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button button13;
        public System.Windows.Forms.TextBox PointNametb;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button12;
        public System.Windows.Forms.Button button16;
        public System.Windows.Forms.Button button15;
        public System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}
