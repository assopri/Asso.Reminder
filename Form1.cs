using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Asso.Reminder
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();
            labelControl1.Text = CmdArgumentHandler.getCmdArgValue(args, "label");
            string pictureTopic = CmdArgumentHandler.getCmdArgValue(args, "psearch");

            SetPicture(pictureTopic);

            //https://supportcenter.devexpress.com/ticket/details/t1006182/barmanager-how-to-drag-a-form-by-clicking-a-bar
            this.MouseDown += DragForm_MouseDown;
            
            layoutControlItem1.MouseDown += DragForm_MouseDown;
            labelControl1.MouseDown += DragForm_MouseDown;

            layoutControl1.ShowCustomization += LayoutControl1_ShowHideCustomization;
            layoutControl1.HideCustomization += LayoutControl1_ShowHideCustomization;
        }

        private void SetPicture(string psearch)
        {
            if(!String.IsNullOrEmpty(psearch))
            {
                string searchRequest = HttpUtility.UrlEncode(psearch);
                webBrowser1.Navigate("https://www.google.com/search?q=" + searchRequest + "&tbm=isch");
            }
            else
            {
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        bool allowDragForm = true;
        private void LayoutControl1_ShowHideCustomization(object sender, EventArgs e)
        {
            allowDragForm = !allowDragForm;
        }

        private void DragForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !allowDragForm) return;

            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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
