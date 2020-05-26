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
    public partial class frmDailySales : Form
    {
        DataAccess.Transaction oTransaction;
        Model.Transaction oMTransaction;
        Model.Search oMSearch;
        private int iRowIndex = 0;
        iMessageBox.MessageBoxForm oFrmMsgBox;
        public frmDailySales()
        {
            InitializeComponent();

            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
        }

        public void DisplayRecords()
        {
            oTransaction = new DataAccess.Transaction();
            oMTransaction = new Model.Transaction();
            oMSearch = new Model.Search();

            oMSearch.DATE_FROM = dtFrom.Value.ToString("yyyy-MM-dd");
            oMSearch.DATE_TO = dtTo.Value.ToString("yyyy-MM-dd");
            oMSearch.RECORD_TYPE = "SOLD ITEMS";
            oMSearch.STATUS = "SOLD";

            dgRecord.Rows.Clear();            
            foreach (DataRow row in oTransaction.GetRecords(oMSearch).Rows)
            {
                dgRecord.Rows.Add((dgRecord.Rows.Count + 1).ToString(), row["TRANSACTION_NO"], row["PRODUCT_CODE"], row["DESCRIPTION"], row["PRICE"], row["QTY"],row["DISCOUNT_PERCENTAGE"], row["DISCOUNT"],row["VAT_PERCENTAGE"],row["VAT"], row["TOTAL"]);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DisplayRecords();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();            
        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
            if (e.ColumnIndex == 11)
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.YOU_WANT_TO_PROCEED);
                oFrmMsgBox.MessageType = iMessageBox.MessageBoxForm.MESSAGE_TYPE.QUERY;
                oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgBox.ShowDialog();

                if (oFrmMsgBox.sAnswer == "YES")
                {
                    Forms.frmCancelOrder oFrm = new frmCancelOrder(this,oMTransaction);
                    oFrm.ShowDialog();
                }
                else
                { 
                    
                
                }            
            }            
        }


        private void SelectedRecords(object sender, DataGridViewCellEventArgs e)
        {
            oMTransaction = new Model.Transaction();
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                oMTransaction.TRANSACTION_NO = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMTransaction._Product.PRODUCT_CODE = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();
                oMTransaction._Product.DESCRIPTION = dgRecord.Rows[e.RowIndex].Cells[3].Value.ToString();
                oMTransaction._Product.PRICE = dgRecord.Rows[e.RowIndex].Cells[4].Value.ToString();
                oMTransaction.QTY = Convert.ToInt32(dgRecord.Rows[e.RowIndex].Cells[5].Value.ToString());
                oMTransaction.DISCOUNT_PERCENTAGE = Convert.ToDouble(dgRecord.Rows[e.RowIndex].Cells[6].Value);
                oMTransaction.DISCOUNT = Convert.ToDouble(dgRecord.Rows[e.RowIndex].Cells[7].Value);
                oMTransaction.VAT_PERCENTAGE = Convert.ToDouble(dgRecord.Rows[e.RowIndex].Cells[8].Value);
                oMTransaction.VAT = Convert.ToDouble(dgRecord.Rows[e.RowIndex].Cells[9].Value);
                oMTransaction.TOTAL = Convert.ToInt32(dgRecord.Rows[e.RowIndex].Cells[10].Value);
            }

        }

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
        }
    }
}
