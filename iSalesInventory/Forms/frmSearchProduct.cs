using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iSalesInventory.Forms
{
    public partial class frmSearchProduct : Form
    {
        DataAccess.Stocks oStocks;
        public Model.Stocks oMStocks;
        public Model.Search oMSearch;
        public enum RECORD_TYPE : int
        {
            PRODUCT = 0,
            STOCKIN = 1
        }
        
        public RECORD_TYPE RecordType;

        public enum ACTION_TYPE : int
        { 
            SEARCH = 0,
            ADD = 1        
        }

        public ACTION_TYPE ActionType;

        public frmSearchProduct()
        {
            InitializeComponent();

                      
        }
        frmManageStocks _frmList;
        public frmSearchProduct(frmManageStocks frmList)
        {
            InitializeComponent();
            _frmList = frmList;
            cboSearch.KeyPress += IsEscapePress;
            txtSearch.KeyPress += IsEscapePress;
            dgRecord.KeyPress += IsEscapePress;
            GlobalVariable.eVariable.DisableKeyPress(cboSearch);
            GlobalVariable.eVariable.DisableTextPanelEnterKey(pnlHeader);
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DisplayRecords()
        {
            oStocks = new DataAccess.Stocks();
            dgRecord.Rows.Clear();
            foreach (DataRow row in oStocks.GetStock(oMSearch).Rows)
            {
                dgRecord.Rows.Add((dgRecord.Rows.Count + 1).ToString(), row["PRODUCT_CODE"], row["BAR_CODE"], row["DESCRIPTION"], row["BRAND_ID"], row["BRAND"], row["CATEGORY_ID"], row["CATEGORY"], row["PRICE"], row["QTY"]);
            }
        }

        private void frmSearchProduct_Load(object sender, EventArgs e)
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_SEARCH = txtSearch.Text;
            oMSearch.RECORD_TYPE = cboSearch.Text;           
            DisplayRecords();
            txtSearch.Focus();
        }


        private void SelectedRecords(object sender, DataGridViewCellEventArgs e)
        {
            oMStocks = new Model.Stocks();
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                oMStocks._PRODUCT.PRODUCT_CODE = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMStocks._PRODUCT.BAR_CODE = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();
                oMStocks._PRODUCT.DESCRIPTION = dgRecord.Rows[e.RowIndex].Cells[3].Value.ToString();
                oMStocks._PRODUCT._BRAND.ID = dgRecord.Rows[e.RowIndex].Cells[4].Value.ToString();
                oMStocks._PRODUCT._BRAND.BRAND = dgRecord.Rows[e.RowIndex].Cells[5].Value.ToString();
                oMStocks._PRODUCT._CATEGORY.ID = dgRecord.Rows[e.RowIndex].Cells[6].Value.ToString();
                oMStocks._PRODUCT._CATEGORY.CATEGORY = dgRecord.Rows[e.RowIndex].Cells[7].Value.ToString();
                oMStocks._PRODUCT.PRICE = dgRecord.Rows[e.RowIndex].Cells[8].Value.ToString();
                oMStocks.QTY = Convert.ToInt32(dgRecord.Rows[e.RowIndex].Cells[9].Value.ToString());
            }

        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
        }

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
        }

        private void dgRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _frmList.oMStocks = oMStocks;
            _frmList.DisplayRecords();
        }

        private void dgRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgRecord_CellDoubleClick(this.dgRecord, new DataGridViewCellEventArgs(this.dgRecord.CurrentCell.ColumnIndex, this.dgRecord.CurrentRow.Index));
            }
        }

        private void IsEscapePress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == 27)
            {
                Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = cboSearch.Text;
            oMSearch.RECORD_SEARCH = txtSearch.Text;
            DisplayRecords();
        }
    }
}
