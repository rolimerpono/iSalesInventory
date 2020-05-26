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
    public partial class frmBrandList : Form
    {
        DataAccess.Brand oBrand;
        Model.Brand oMBrand;
        Model.Search oMSearch;

        
        public frmBrandList()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void DisplayRecord()
        {
            dgRecord.Rows.Clear();
            oBrand = new DataAccess.Brand();
            foreach (DataRow row in oBrand.GetBrand(oMSearch).Rows)
            {
                dgRecord.Rows.Add(row["ID"], row["BRAND"],row["STATUS"]);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Forms.frmBrand oFrm = new frmBrand(this,oMBrand);
            oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
            oFrm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.frmBrand oFrm = new frmBrand(this);
            oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.ADD;
            oFrm.ShowDialog();
        }

        private void frmBrandList_Load(object sender, EventArgs e)
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "ID";
            oMSearch.STATUS = "ACTIVE";

            DisplayRecord();
        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecord(sender,e);
        }


        private void SelectedRecord(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                oMBrand = new Model.Brand();
                oMBrand.ID = dgRecord.Rows[e.RowIndex].Cells[0].Value.ToString();
                oMBrand.BRAND = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMBrand.STATUS = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();
                
            }
        }

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecord(sender,e);
        }

        private void dgRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                Forms.frmBrand oFrm = new frmBrand(this, oMBrand);
                oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
                oFrm.ShowDialog();
            }
        }
    }
}
