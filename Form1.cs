using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asso.Reminder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();
            labelControl1.Text = CmdArgumentHandler.getCmdArgValue(args, "label");

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
