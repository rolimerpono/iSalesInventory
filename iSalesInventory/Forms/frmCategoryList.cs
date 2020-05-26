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
    public partial class frmCategoryList : Form
    {

        DataAccess.Category oCategory;
        Model.Category oMCategory;
        Model.Search oMSearch;

        public frmCategoryList()
        {
            InitializeComponent();
            
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.frmCategory oFrm = new frmCategory(this);
            oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.ADD;
            oFrm.ShowDialog();
        }


        public void DisplayRecord()
        {
            dgRecord.Rows.Clear();
            oCategory = new DataAccess.Category();
            foreach (DataRow row in oCategory.GetCategory(oMSearch).Rows)
            {
                dgRecord.Rows.Add(row["ID"], row["CATEGORY"], row["STATUS"]);
            }
        }

        private void SelectedRecord(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                oMCategory = new Model.Category();
                oMCategory.ID = dgRecord.Rows[e.RowIndex].Cells[0].Value.ToString();
                oMCategory.CATEGORY = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMCategory.STATUS = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Forms.frmCategory oFrm = new frmCategory(this, oMCategory);
            oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
            oFrm.ShowDialog();
        }

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "ID";
            oMSearch.STATUS = "ACTIVE";

            DisplayRecord();
        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecord(sender, e);
        }

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecord(sender, e);
        }

        private void dgRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                Forms.frmCategory oFrm = new frmCategory(this, oMCategory);
                oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
                oFrm.ShowDialog();
            }
        }
    }
}
