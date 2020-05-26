using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iSalesInventoryClient.Forms
{
    public partial class frmDiscount : Form
    {
        iMessageBox.MessageBoxForm oFrmMsgBox;
        public frmDiscount()
        {
            InitializeComponent();                        
            GlobalVariable.eVariable.ValidNumber(txtTotalPrice);
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
        }
        public Model.Stocks oMStocks = new Model.Stocks();
        private double iPercentage = 0;
        MAIN _frmList;
        public frmDiscount(MAIN frmList, Model.Stocks oStcks)
        {
            InitializeComponent();                        
            oMStocks = oStcks;
            _frmList = frmList;                    
            txtPercentage.KeyPress += IsEscapePress;
            btnConfirm.KeyPress += IsEscapePress;
            GlobalVariable.eVariable.ValidNumber(txtPercentage);
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
            DisplayRecord();
        }

        private void DisplayRecord()
        {
            txtTotalPrice.Text = oMStocks.TOTAL.ToString("n2");
            txtPercentage.Text = "0";
            txtDiscount.Text = "0.00";        
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            oMStocks = new Model.Stocks();
            Close();
        }       

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            iPercentage = 0;
            iPercentage = txtPercentage.Text == string.Empty ? 0 : Convert.ToDouble(txtPercentage.Text);

            if (iPercentage == 0)
            {
                txtPercentage.Text = "0";
            }

            iMessageBox.MessageBoxForm oFrm = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.APPLY_DEDUCTION);
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.MessageType = iMessageBox.MessageBoxForm.MESSAGE_TYPE.QUERY;
            oFrm.ShowDialog();

            if (oFrm.sAnswer == "YES")
            {
                oMStocks.DISCOUNT_PERCENTAGE = Convert.ToDouble(txtPercentage.Text);
                _frmList.oMStocks = oMStocks;
            }
            else
            {
                _frmList.oMStocks = oMStocks;
            }
            Close();
            
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtPercentage_TextChanged(object sender, EventArgs e)
        {
            iPercentage = 0;
            iPercentage = txtPercentage.Text == string.Empty ? 0 : Convert.ToDouble(txtPercentage.Text);
            if (iPercentage > 100)
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.PERCENTAGE_VALIDATION);
                oFrmMsgBox.StartPosition = FormStartPosition.Manual;
                oFrmMsgBox.ShowDialog();
                txtPercentage.Text = "0";
                txtPercentage.Focus();
                return;
            }

            txtDiscount.Text = (Convert.ToDouble(txtTotalPrice.Text) * iPercentage / 100).ToString();
        }       

        private void IsEscapePress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == 27)
            {
                oMStocks.DISCOUNT_PERCENTAGE = 0;
                Close();
            }   
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            txtPercentage.Focus();    
        }
        
    }
}
