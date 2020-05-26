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
    public partial class frmUserAccess : Form
    {
        DataAccess.UserAccess oUserAccess=  new DataAccess.UserAccess();
        Model.UserAccess oMUserAccess = new Model.UserAccess();
        DataAccess.Role oRole  = new DataAccess.Role();
        Model.Role oMRole = new Model.Role();
        iMessageBox.MessageBoxForm oFrmMsgBox;
        Model.Search oMSearch = new Model.Search();

        public frmUserAccess()
        {
            InitializeComponent();
        }

        void LoadRole()
        {

            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "ID";
            oMSearch.STATUS = "ACTIVE";
            
            oRole = new DataAccess.Role();
            dgRecord.Rows.Clear();

            foreach (DataRow row in oRole.GetRole(oMSearch).Rows)
            {
                dgRecord.Rows.Add((dgRecord.Rows.Count + 1), row["ROLE"], row["STATUS"]);
            }            

        }

        private void frmUserAccess_Load(object sender, EventArgs e)
        {
            LoadRole();
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            oMUserAccess = new Model.UserAccess();
            oMSearch = new Model.Search();
            oMSearch.RECORD_SEARCH = oMRole.ROLE;
            oMSearch.RECORD_TYPE = "ROLE";
            oMSearch.STATUS = "ACTIVE";

            oMUserAccess.SALES = chkSales.Checked;
            oMUserAccess.PRODUCT = chkProduct.Checked;
            oMUserAccess.VENDOR = chkVendor.Checked;
            oMUserAccess.STOCK = chkStock.Checked;
            oMUserAccess.CATEGORY = chkCategory.Checked;
            oMUserAccess.BRAND   = chkBrand.Checked;
            oMUserAccess.RECORDS = chkRecords.Checked;
            oMUserAccess.SYSTEM_SETTINGS = chkSystemSettings.Checked;
            oMUserAccess.USER_SETTINGS = chkUserSettings.Checked;
            oMUserAccess.ROLE = oMRole.ROLE;

            oUserAccess = new DataAccess.UserAccess();
            if (oUserAccess.IsRecordExists(oMSearch))
            {
                oUserAccess.UpdateUserAccess(oMUserAccess);
            }
            else
            {
                oUserAccess.InsertUserAccess(oMUserAccess);
            }

            oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_SAVE);
            oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
            oFrmMsgBox.ShowDialog();

        }

        private void cboRole_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecord(sender, e);
        }


        private void SelectedRecord(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                oMRole = new Model.Role();
                oMRole.ROLE = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                DisplayRecord();                         
            }
        }

        private void DisplayRecord()
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "USER ACCESS";
            oMSearch.RECORD_SEARCH = oMRole.ROLE;

            oUserAccess = new DataAccess.UserAccess();
            foreach (DataRow row in oUserAccess.GetUserAccess(oMSearch).Rows)
            {
                chkSales.Checked = Convert.ToBoolean(row["SALES"]);
                chkProduct.Checked = Convert.ToBoolean(row["PRODUCT"]);
                chkVendor.Checked = Convert.ToBoolean(row["VENDOR"]);
                chkStock.Checked = Convert.ToBoolean(row["STOCK"]);
                chkCategory.Checked = Convert.ToBoolean(row["CATEGORY"]);
                chkBrand.Checked = Convert.ToBoolean(row["BRAND"]);
                chkRecords.Checked = Convert.ToBoolean(row["RECORDS"]);
                chkSystemSettings.Checked = Convert.ToBoolean(row["SYSTEM_SETTINGS"]);
                chkUserSettings.Checked = Convert.ToBoolean(row["USER_SETTINGS"]);
                return;
            }

            chkSales.Checked = false;
            chkProduct.Checked = false;
            chkVendor.Checked = false;
            chkStock.Checked = false;
            chkCategory.Checked = false;
            chkBrand.Checked = false;
            chkRecords.Checked = false;
            chkSystemSettings.Checked = false;
            chkUserSettings.Checked = false;
        }

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecord(sender, e);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStock_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
