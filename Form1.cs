using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Timer = System.Windows.Forms.Timer;

namespace FiksHomeWork
{
   public partial class Form1 : Form
    {
			private System.Windows.Forms.Timer moveTimer;
        private int moveSpeedX = 5; // Initial X-axis movement speed
        private int moveSpeedY = 5; // Initial Y-axis movement speed
				private PictureBox pictureBox1;

				private List<Keys> keySequence = new List<Keys> { Keys.U, Keys.W, Keys.U };

        private int currentKeyIndex = 0;

			//safe key - type "UWU" 
       protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == keySequence[currentKeyIndex])
            {
                currentKeyIndex++;

                if (currentKeyIndex == keySequence.Count)
                {
                    // Trigger the action when the full sequence is pressed
                    // For example, you can close the application
                    System.Environment.Exit(1);

                    // Reset the key sequence for the next use
                    currentKeyIndex = 0;
                }

                return true;
            }
            else
            {
                // Reset the sequence if the user presses a different key
                currentKeyIndex = 0;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public Form1()
        {
            InitializeComponent();
            Program.Heads.Append(this);
						InitializePictureBox();

            // Initialize and start the timer for form movement
            moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 1; // Adjust the interval as needed
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            // Move the form in random directions
            this.Left += moveSpeedX;
            this.Top += moveSpeedY;

            // Check if the form has reached the screen bounds on X-axis
            if (this.Right >= Screen.PrimaryScreen.Bounds.Right || this.Left <= Screen.PrimaryScreen.Bounds.Left)
            {
                // Reverse the X-axis direction
                moveSpeedX = -moveSpeedX;
            }

            // Check if the form has reached the screen bounds on Y-axis
            if (this.Bottom >= Screen.PrimaryScreen.Bounds.Bottom || this.Top <= Screen.PrimaryScreen.Bounds.Top)
            {
                // Reverse the Y-axis direction
                moveSpeedY = -moveSpeedY;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;
            ShowInTaskbar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= Program.HeadsCut; i++)
            {
                Form newForm = new Form1();
                Program.Heads.Append(newForm);
                newForm.Show();
            }

            Program.HeadsCut++;

            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
				public void InitializePictureBox()
        {
            // PictureBox
            pictureBox1 = new PictureBox();
            pictureBox1.Location = new System.Drawing.Point(50, 50);
            pictureBox1.Size = new System.Drawing.Size(200, 200);

            // Load the image from file and set it to the PictureBox
            pictureBox1.Image = System.Drawing.Image.FromFile("drag.jpg");
						

            // Set the PictureBoxSizeMode to adjust how the image is displayed
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Add the PictureBox to the form's controls
            Controls.Add(pictureBox1);
        }
				
				
    }
		
		
}