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
    public partial class frmVendorList : Form
    {

        DataAccess.Vendor oVendor;
        Model.Vendor oMVendor;
        Model.Search oMSearch;

        public frmVendorList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmVendor oFrm = new frmVendor(this);
            oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.ADD;
            oFrm.ShowDialog();
        }


        public void DisplayRecords()
        {            
            
            oVendor = new DataAccess.Vendor();
            dgRecord.Rows.Clear();
            foreach (DataRow row in oVendor.GetVendor(oMSearch).Rows)
            {
                dgRecord.Rows.Add((dgRecord.Rows.Count + 1).ToString(), row["ID"], row["VENDOR"], row["ADDRESS"], row["CONTACT_PERSON"], row["TELEPHONE_NUMBER"], row["EMAIL"], row["PHONE_NUMBER"], row["FAX_NUMBER"],row["STATUS"]);
            }
        }

        private void frmVendorList_Load(object sender, EventArgs e)
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "VENDOR";
            oMSearch.STATUS = "ACTIVE";
            oMSearch.RECORD_SEARCH = "";


            DisplayRecords();

        }

        private void SelectedRecords(object sender, DataGridViewCellEventArgs e)
        {
            oMVendor = new Model.Vendor();
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                oMVendor.ID = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMVendor.VENDOR = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();
                oMVendor.ADDRESS = dgRecord.Rows[e.RowIndex].Cells[3].Value.ToString();
                oMVendor.CONTACT_PERSON = dgRecord.Rows[e.RowIndex].Cells[4].Value.ToString();
                oMVendor.TELEPHONE_NUMBER = dgRecord.Rows[e.RowIndex].Cells[5].Value.ToString();
                oMVendor.EMAIL= dgRecord.Rows[e.RowIndex].Cells[6].Value.ToString();
                oMVendor.PHONE_NO = dgRecord.Rows[e.RowIndex].Cells[7].Value.ToString();
                oMVendor.FAX_NO = dgRecord.Rows[e.RowIndex].Cells[8].Value.ToString();
                oMVendor.STATUS = dgRecord.Rows[e.RowIndex].Cells[9].Value.ToString();
            }

        }

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
        }

        private void dgRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmVendor oFrm = new frmVendor(this,oMVendor);
            oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
            oFrm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgRecord.Rows.Count > 0)
            {
                frmVendor oFrm = new frmVendor(this, oMVendor);
                oFrm.TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
                oFrm.ShowDialog();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
