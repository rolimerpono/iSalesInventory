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
    public partial class frmQuantity : Form
    {
        public int iQty = 0;
        public frmQuantity()
        {
            InitializeComponent();
            GlobalVariable.eVariable.ValidNumber(txtQty);
        }

        
        public frmQuantity(frmProductList frmList)
        {
            InitializeComponent();
            txtQty.Focus();
            GlobalVariable.eVariable.ValidNumber(txtQty);
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
        }

     

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {            
            if (Convert.ToInt32(txtQty.Text == "" ? "0" : txtQty.Text) != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    iQty = Convert.ToInt32(txtQty.Text);
                    Close();
                }
            }
        }

        private void frmQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == 27)
            {
                iQty = 0;
                Close();
            }          
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == 27)
            {
                iQty = 0;
                Close();
            }   
        }
    }
}
