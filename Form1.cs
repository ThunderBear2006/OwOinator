using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace FiksHomeWork
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer moveTimer;
        private int moveSpeed = 5; // Adjust the move speed as needed

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (ModifierKeys == Keys.None && keyData == Keys.U)
            {
                System.Environment.Exit(1);
            }
            return base.ProcessDialogKey(keyData);
        }

        public Form1()
        {
            InitializeComponent();
            Program.Heads.Append(this);

            // Initialize and start the timer for form movement
            moveTimer = new Timer();
            moveTimer.Interval = 20; // Adjust the interval as needed
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            // Move the form horizontally
            this.Left += moveSpeed;

            // Check if the form has reached the screen bounds
            if (this.Right >= Screen.PrimaryScreen.Bounds.Right || this.Left <= Screen.PrimaryScreen.Bounds.Left)
            {
                // Reverse the horizontal direction
                moveSpeed = -moveSpeed;
            }

            // Move the form vertically
            this.Top += moveSpeed;

            // Check if the form has reached the screen bounds
            if (this.Bottom >= Screen.PrimaryScreen.Bounds.Bottom || this.Top <= Screen.PrimaryScreen.Bounds.Top)
            {
                // Reverse the vertical direction
                moveSpeed = -moveSpeed;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;
            ShowInTaskbar = false;
        }

        public void Tick()
        {
            if (Program.HeadsCut > 5 && Program.HeadsCut < 7)
            {
                SetDesktopLocation(Location.X + Program.random.Next(-10, 10), Location.Y + Program.random.Next(-10, 10));
            }
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
    }
}