namespace FiksHomeWork;

partial class Form1
{
    /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.Diagnostics.Process process1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Help = new System.Windows.Forms.Button();
            process1 = new System.Diagnostics.Process();
            this.SuspendLayout();
            // 
            // process1
            // 
            process1.StartInfo.Domain = "";
            process1.StartInfo.LoadUserProfile = false;
            process1.StartInfo.Password = null;
            process1.StartInfo.StandardErrorEncoding = null;
            process1.StartInfo.StandardInputEncoding = null;
            process1.StartInfo.StandardOutputEncoding = null;
            process1.StartInfo.UserName = "";
            process1.SynchronizingObject = this;
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OK.Location = new System.Drawing.Point(367, 141);
            this.OK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OK.Name = "Close";
            this.OK.Size = new System.Drawing.Size(86, 43);
            this.OK.TabIndex = 0;
            this.OK.Text = "Close";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hckd by Ethrody and ThunderBear";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 

            // 
            // Help
            /*
            this.Help.Location = new System.Drawing.Point(14, 141);
            this.Help.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(86, 43);
            this.Help.TabIndex = 3;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.button1_Click_1);
            */
            // Hydra
            // 
            Random random = new Random();
            int x = random.Next(0, Screen.PrimaryScreen.Bounds.Width - this.Width);
            int y = random.Next(0, Screen.PrimaryScreen.Bounds.Height - this.Height);

            // Set the location of the form
            this.Location = new System.Drawing.Point(x, y);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            //setup for auto size based on picture ?? if so, set this.AutoSize = false
            this.ClientSize = new System.Drawing.Size(800, 200);

            this.StartPosition = FormStartPosition.Manual;
            this.Controls.Add(this.Help);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.Name = "Hydra";
            this.ShowInTaskbar = false;
            this.Text = "Hydra";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Help;
}
