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
    public partial class frmProductList : Form
    {

        DataAccess.Product oProduct;
        Model.Product oMProduct;
        Model.Search oMSearch;

   
        public frmProductList()
        {
            InitializeComponent();            
        }

      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.frmProduct oFrm = new frmProduct(this);
            oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.ADD;    
            oFrm.ShowDialog();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Forms.frmProduct oFrm = new frmProduct(this,oMProduct);
            oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
            oFrm.ShowDialog();
        }

        public void DisplayRecords()
        {
            oProduct = new DataAccess.Product();
            dgRecord.Rows.Clear();
            foreach (DataRow row in oProduct.GetProduct(oMSearch).Rows)
            {
                dgRecord.Rows.Add((dgRecord.Rows.Count + 1).ToString(), row["PRODUCT_CODE"], row["BAR_CODE"],row["DESCRIPTION"], row["BRAND_ID"], row["BRAND"],row["CATEGORY_ID"], row["CATEGORY"], row["PRICE"], row["REORDER_LEVEL"]);
            }
        }


        private void frmProductList_Load(object sender, EventArgs e)
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "DESCRIPTION";
            oMSearch.STATUS = "ACTIVE";

            DisplayRecords();
        }

        private void SelectedRecords(object sender, DataGridViewCellEventArgs e)
        {
            oMProduct = new Model.Product();
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                oMProduct.PRODUCT_CODE = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMProduct.BAR_CODE = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();
                oMProduct.DESCRIPTION = dgRecord.Rows[e.RowIndex].Cells[3].Value.ToString();
                oMProduct._BRAND.ID = dgRecord.Rows[e.RowIndex].Cells[4].Value.ToString();
                oMProduct._BRAND.BRAND = dgRecord.Rows[e.RowIndex].Cells[5].Value.ToString();
                oMProduct._CATEGORY.ID = dgRecord.Rows[e.RowIndex].Cells[6].Value.ToString();
                oMProduct._CATEGORY.CATEGORY = dgRecord.Rows[e.RowIndex].Cells[7].Value.ToString();
                oMProduct.PRICE = dgRecord.Rows[e.RowIndex].Cells[8].Value.ToString();
                oMProduct.REORDER_LEVEL = dgRecord.Rows[e.RowIndex].Cells[9].Value.ToString();                                
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
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                Forms.frmProduct oFrm = new frmProduct(this, oMProduct);
                oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
                oFrm.ShowDialog();
            }
        }
    }
}
