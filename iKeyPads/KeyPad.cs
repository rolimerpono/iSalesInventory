using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace iKeyPads
{
    public partial class KeyPad : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        frmMessageBox oFrmMsgBox;
        public bool IsTransactionSuccess = false;

        
        public KeyPad()
        {
            InitializeComponent();
            txtReceivePayment.KeyPress += ValidAmount;
            IsTransactionSuccess = false;
            foreach (Control o in pnlMain.Controls.OfType<Button>().ToList())
            {
                if (o.Name == "txtChange" || o.Name == "txtTotal")
                {

                }
                else
                {
                    o.Click += PressKey;
                }
            }
          
        }

        public KeyPad(double iTotal)
        {
            InitializeComponent();
            txtReceivePayment.KeyPress += ValidAmount;
            IsTransactionSuccess = false;
            foreach (Control o in pnlMain.Controls.OfType<Button>().ToList())
            {
                if (o.Name == "txtChange" || o.Name == "txtTotal")
                {

                }
                else
                {
                    o.Click += PressKey;
                }
            }
     
            txtTotal.Text = iTotal.ToString("n2");
        }

        private double iChange = 0;
        private double iTotalPayment = 0;
        private double iReceivePayment = 0;

        public double TotalPayment
        {
            get { return iTotalPayment; }
            set { iTotalPayment = value; }            
        }

        public double Change
        {
            get { return iChange; }
            set { iChange = value; }
        }              

        private void txtPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                IsTransactionSuccess = false;
                Close();
            }

            
        }

        private void PressKey(object sender , EventArgs e)
        {
           string sInput = ((Button)sender).Text;
           switch (sInput)
           {
               case "C":                   
                   ClearText();
                   break;
               case "ENTER":
                   Compute();
                   break;
               default:
                   txtReceivePayment.Text += ((Button)sender).Text;
                   break;
           }
            
            if (!IsValidAmountOnClick() || txtReceivePayment.TextLength == 10)
            {
                txtReceivePayment.Text = txtReceivePayment.Text.Substring(0, txtReceivePayment.Text.Length - 1);            
            }            
        }          

        private void ValidAmount(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf('.') != -1)
                {
                    e.Handled = true;
                return;
                }

                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 46)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void Compute()
        {
            iTotalPayment = Convert.ToDouble(txtTotal.Text);
            iReceivePayment = txtReceivePayment.Text == string.Empty ? 0 : Convert.ToDouble(txtReceivePayment.Text);
            if (iReceivePayment >= iTotalPayment)
            {
                Change = iReceivePayment - iTotalPayment;
                TotalPayment = iTotalPayment;
                IsTransactionSuccess = true;
                Close();
            }
            else
            {
                oFrmMsgBox = new frmMessageBox("PLEASE ENTER EXACT PAYMENT AMOUNT");
                oFrmMsgBox.MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                oFrmMsgBox.ShowDialog();
                txtReceivePayment.Focus();
                IsTransactionSuccess = false;
            }
            
        }

        private void ClearText()
        {
            txtReceivePayment.Text = "";
            txtReceivePayment.Focus();
            txtChange.Text = "0.00";
        }

        private Boolean IsValidAmountOnClick()
        {
            string sLetter = txtReceivePayment.Text;
            char[] cChar = sLetter.ToCharArray();
            foreach (char ch in cChar)
            {
                if (ch != '\b')
                {
                    if (ch == 46 && (txtReceivePayment.Text.Where(fw => fw.ToString() == ".").Count() == 2))
                    {
                        return false;
                    }

                    if (!char.IsDigit(ch) && ch != 46)
                    {

                        return false;
                    }
                }
            }
            return true;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            IsTransactionSuccess = false;
            Close();
        }

        private void KeyPad_Load(object sender, EventArgs e)
        {
            txtReceivePayment.Focus();            
            iTotalPayment = Convert.ToDouble(txtTotal.Text);
        }

        private void txtReceivePayment_TextChanged(object sender, EventArgs e)
        {

            iTotalPayment = Convert.ToDouble(txtTotal.Text);
            iReceivePayment = txtReceivePayment.Text == string.Empty ? 0 : Convert.ToDouble(txtReceivePayment.Text);

            if (iReceivePayment > iTotalPayment)
            {
                iChange = (iReceivePayment - iTotalPayment);
                if (iChange >= 0)
                {
                    txtChange.Text = iChange.ToString("n2");
                }
            }
            else
            {
                txtChange.Text = "0.00";
            }
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
