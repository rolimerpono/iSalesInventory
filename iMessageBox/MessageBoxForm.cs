using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace iMessageBox
{
    public partial class MessageBoxForm : Form
    {

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        public string sAnswer = string.Empty;
        private string sMessage = string.Empty;

        Thread ThTimer;
        public MessageBoxForm()
        {
            InitializeComponent();
            MessageType = MESSAGE_TYPE.INFO;
        }

        public MessageBoxForm(string sMsg)
        {
            InitializeComponent();
            sMessage = sMsg;
            MessageType = MESSAGE_TYPE.INFO;

            this.StartPosition = FormStartPosition.Manual;
            this.Left = System.Windows.Forms.Control.MousePosition.X - 250;
            this.Top = System.Windows.Forms.Control.MousePosition.Y - 20;
         
        }

        public enum MESSAGE_TYPE : int
        {
            NONE = 0,
            INFO = 1,
            QUERY = 2
        }

        public MESSAGE_TYPE MessageType;
        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            ThTimer = new Thread(new ThreadStart(GetCurrentTime));
            ThTimer.Start();

            if (MessageType == MESSAGE_TYPE.INFO)
            {
                lblMessage.Text = sMessage.ToUpper();
                ShowInfo();
            }
            else if (MessageType == MESSAGE_TYPE.QUERY)
            {
                lblMessage.Text = sMessage.ToUpper();
                ShowQuery();
            }
        }

        void GetCurrentTime()
        {
            for (int i = 0; i <= 2000; i++)
            {
                Thread.Sleep(1000);
                this.Invoke((MethodInvoker)delegate
                {
                    lblTime.Text = DateTime.Now.ToString("h:mm:ss tt");
                });
                if (i == 1001)
                {
                    i = 0;
                }
            }
        }

        private void ShowInfo()
        {
            btnLeft.Visible = true;
            btnLeft.Text = "OK";
            btnRight.Visible = false;
        }

        private void ShowQuery()
        {
            btnLeft.Visible = true;
            btnLeft.Text = "NO";
            btnRight.Visible = true;
            btnRight.Text = "YES";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            switch (MessageType)
            {
                case MESSAGE_TYPE.INFO:
                    break;
                case MESSAGE_TYPE.QUERY:
                    sAnswer = "NO";
                    break;
            }
            ThTimer.Abort();
            Close();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (MessageType == MESSAGE_TYPE.QUERY)
            {
                sAnswer = "YES";
            }
            Close();
        }

        private void pnlBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MessageBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThTimer.Abort();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
