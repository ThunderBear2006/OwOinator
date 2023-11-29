
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

namespace FiksHomeWork;

public partial class Form1 : Form
	{
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
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			TopMost=true;
			ShowInTaskbar = false;
		}

		public void Tick() {
			if (Program.HeadsCut > 5 && Program.HeadsCut < 7) {
				SetDesktopLocation(Location.X + Program.random.Next(-10, 10), Location.Y + Program.random.Next(-10, 10));
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
            for (int i = 0; i <= Program.HeadsCut; i++) {
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

		

		private void button1_Click_1(object sender, EventArgs e)
		{
			
		}

      

		

	}