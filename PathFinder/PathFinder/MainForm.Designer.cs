namespace PathFinder
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
            this.CheckedItemsRTB = new System.Windows.Forms.RichTextBox();
            this.NextBtn = new System.Windows.Forms.Button();
            this.ToonPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // CheckedItemsRTB
            // 
            this.CheckedItemsRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.CheckedItemsRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckedItemsRTB.Location = new System.Drawing.Point(0, 0);
            this.CheckedItemsRTB.Margin = new System.Windows.Forms.Padding(0);
            this.CheckedItemsRTB.Name = "CheckedItemsRTB";
            this.CheckedItemsRTB.Size = new System.Drawing.Size(817, 657);
            this.CheckedItemsRTB.TabIndex = 18;
            this.CheckedItemsRTB.Text = "";
            // 
            // NextBtn
            // 
            this.NextBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NextBtn.Location = new System.Drawing.Point(0, 657);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(817, 23);
            this.NextBtn.TabIndex = 19;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // ToonPanel
            // 
            this.ToonPanel.Location = new System.Drawing.Point(316, 145);
            this.ToonPanel.Name = "ToonPanel";
            this.ToonPanel.Size = new System.Drawing.Size(200, 100);
            this.ToonPanel.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 680);
            this.Controls.Add(this.CheckedItemsRTB);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.ToonPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox CheckedItemsRTB;
        public System.Windows.Forms.Panel ToonPanel;
        public System.Windows.Forms.Button NextBtn;
    }
}

