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

namespace FiksHomeWork
{
   public partial class Form1 : Form
    {
        private string fileUrl;
        private int moveSpeedX = 1; // Initial X-axis movement speed
        private int moveSpeedY = 1; // Initial Y-axis movement speed
		private PictureBox pictureBox1;
        private List<Keys> keySequence = new List<Keys> { Keys.U, Keys.W, Keys.U };

        private readonly string[] names = new string[] {
            "Why don't you join them~", "Penis enlargement pills! Only $6.99!", "Fnaf at freddyyyyy's!", "You have been trolled",
            "This seems like something you'd like", "Do NOT use hand sanitizer as lube...", "Yep. You're a furry", "Enjoy :3",
            "My gift to you <3", "MICHAEL DON't LEAVE ME HERE!!", "UwU", "x3", "OwO", "*nuzzles you", "Gimme headpats!"
        };

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
                    System.Environment.Exit(34);

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

        public Form1(string fileUrl)
        {
            this.fileUrl = fileUrl;

            if (!Program.TickTimer.Enabled)
                Program.TickTimer.Start();

            InitializeComponent();
            InitializePictureBox();

            // Initialize and start the timer for form movement
            Program.TickTimer.Tick += MoveTimer_Tick;
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (fileUrl == Program.DefaultURL)
                fileUrl = OwOinator.GetLambSauce();

            if (Program.HeadsCut < 5)
                return;

            // Move the form in random directions
            this.Left += Program.HeadsCut * moveSpeedX;
            this.Top += Program.HeadsCut * moveSpeedY;

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
            Text = Util.GetRandomString(names);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form newForm1 = new Form1(OwOinator.GetLambSauce());
            newForm1.Show();

            Form newForm2 = new Form1(OwOinator.GetLambSauce());
            newForm2.Show();

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
            pictureBox1.Location = new(50, 50);
            pictureBox1.Size = new(500, 500);

            // Load the image from url and set it to the PictureBox
            pictureBox1.Load(fileUrl);

            // Set the PictureBoxSizeMode to adjust how the image is displayed
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Add the PictureBox to the form's controls
            Controls.Add(pictureBox1);
        }
    }
}