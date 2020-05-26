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
    public partial class frmProductList : Form
    {

        DataAccess.Stocks oStocks;
        Model.Stocks oMStocks = new Model.Stocks();
        Model.Search oMSearch;
        private int iQty  = 0;
        iMessageBox.MessageBoxForm oFrmMsgBox;
        public frmProductList()
        {
            InitializeComponent();
        }

        MAIN _frmList;

        public frmProductList(MAIN frmList)
        {
            InitializeComponent();
            _frmList = frmList;

            txtSearch.KeyPress += IsEscapePress;
            dgRecord.KeyPress += IsEscapePress;
            cboSearch.KeyPress += IsEscapePress;
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
        }

        private void cboSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DisplayRecords()
        {
            oStocks = new DataAccess.Stocks();
            oMSearch = new Model.Search();

            dgRecord.Rows.Clear();
            oMSearch.RECORD_SEARCH = txtSearch.Text;
            oMSearch.RECORD_TYPE = cboSearch.Text;
            foreach (DataRow row in oStocks.GetStock(oMSearch).Rows)
            {
                dgRecord.Rows.Add((dgRecord.Rows.Count + 1).ToString(), row["PRODUCT_CODE"], row["BAR_CODE"], row["DESCRIPTION"], row["BRAND"], row["CATEGORY"], row["PRICE"], row["QTY"],row["IS_VATABLE"]);
            }

        }

        private void SelectedRecords(object sender, DataGridViewCellEventArgs e)
        {
            oMStocks = new Model.Stocks();
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                oMStocks._PRODUCT.PRODUCT_CODE = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMStocks._PRODUCT.BAR_CODE = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();
                oMStocks._PRODUCT.DESCRIPTION = dgRecord.Rows[e.RowIndex].Cells[3].Value.ToString();
                oMStocks._PRODUCT._BRAND.BRAND = dgRecord.Rows[e.RowIndex].Cells[4].Value.ToString();
                oMStocks._PRODUCT._CATEGORY.CATEGORY = dgRecord.Rows[e.RowIndex].Cells[5].Value.ToString();
                oMStocks._PRODUCT.PRICE = dgRecord.Rows[e.RowIndex].Cells[6].Value.ToString();
                oMStocks.STOCK_ON_HAND = Convert.ToInt32(dgRecord.Rows[e.RowIndex].Cells[7].Value);
                iQty = Convert.ToInt32(dgRecord.Rows[e.RowIndex].Cells[7].Value);
                oMStocks._PRODUCT.VATABLE = Convert.ToBoolean(dgRecord.Rows[e.RowIndex].Cells[8].Value);                
            }

        }

        private void frmProductList_Load(object sender, EventArgs e)
        {
            DisplayRecords();
        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
            if (e.ColumnIndex == 9 && e.RowIndex >=0)
            {
                dgRecord_CellDoubleClick(this.dgRecord, new DataGridViewCellEventArgs(this.dgRecord.CurrentCell.ColumnIndex, this.dgRecord.CurrentRow.Index));
            }
        }

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
        }

        private void dgRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {                        
            Forms.frmQuantity oFrm = new frmQuantity();
            oFrm.ShowDialog();
            oMStocks.QTY = oFrm.iQty;
            if (oMStocks.QTY != 0)
            {
                if (oMStocks.QTY > iQty)
                {
                    oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.QUANTY_IS_GREATER_THAN_ONHAND);
                    oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                    oFrmMsgBox.ShowDialog();
                    return;                
                }
                _frmList.oMStocks = oMStocks;
                _frmList.DisplayRecords();
            }
        }

        private void IsEscapePress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == 27)
            {
                Close();
            }
        }

        private void dgRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgRecord_CellDoubleClick(this.dgRecord, new DataGridViewCellEventArgs(this.dgRecord.CurrentCell.ColumnIndex, this.dgRecord.CurrentRow.Index));
            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayRecords();
        }

    }
}
