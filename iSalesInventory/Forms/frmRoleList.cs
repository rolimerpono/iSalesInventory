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
    public partial class frmRoleList : Form
    {

        DataAccess.Role oRole;
        Model.Role oMRole;
        Model.Search oMSearch;
        public frmRoleList()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void DisplayRecord()
        {
            dgRecord.Rows.Clear();
            oRole = new DataAccess.Role();
            foreach (DataRow row in oRole.GetRole(oMSearch).Rows)
            {
                dgRecord.Rows.Add(row["ID"], row["ROLE"], row["STATUS"]);
            }
        }

        private void SelectedRecord(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                oMRole = new Model.Role();
                oMRole.ID = dgRecord.Rows[e.RowIndex].Cells[0].Value.ToString();
                oMRole.ROLE = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMRole.STATUS = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.frmRole oFrm = new frmRole(this);
            oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.ADD;
            oFrm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Forms.frmRole oFrm = new frmRole(this, oMRole);
            oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
            oFrm.ShowDialog();
        }

        private void dgRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                Forms.frmRole oFrm = new frmRole(this, oMRole);
                oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
                oFrm.ShowDialog();
            }
        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecord(sender, e);
        }

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecord(sender, e);
        }

        private void frmRoleList_Load(object sender, EventArgs e)
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "ID";
            oMSearch.STATUS = "ACTIVE";

            DisplayRecord();
        }
    }
}
