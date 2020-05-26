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
    public partial class frmUser : Form
    {

        iMessageBox.MessageBoxForm oFrmMsgBox;
        GlobalVariable.eVariable.TRANSACTION_TYPE TransactionType;
        DataAccess.Role oRole;
        DataAccess.User oUser;
        Model.User oMUser;
        Model.Role oMRole;
        Model.Search oMSearch;
        private int iRowIndex = 0;
        public frmUser()
        {
            InitializeComponent();
            GlobalVariable.eVariable.DisableTextPanelEnterKey(pnlMain);
            GlobalVariable.eVariable.DisableSpacebar(txtUsername);
            GlobalVariable.eVariable.DisableSpacebar(txtPassword);
            GlobalVariable.eVariable.DisableSpacebar(txtConfirmPass);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnableDisableField(Boolean bFlag)
        {
            foreach (Control o in pnlMain.Controls.OfType<TextBox>().ToList())
            {
                if (!o.Name.Contains("txtSearch"))
                {
                    o.Enabled = bFlag;
                }
            }
            cboRole.Enabled = bFlag;
            chkAllowVoid.Enabled = bFlag;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            EnableDisableField(false);
            DisplayRecords();
            LoadRole();
        }

        private void EDButton(Boolean bFlag)
        {
            btnAdd.Enabled = !bFlag;
            btnEdit.Enabled = !bFlag;
            btnSave.Enabled = bFlag;
            btnCancel.Enabled = bFlag;
        }

        void LoadRole()
        {

            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "ID";
            oMSearch.STATUS = "ACTIVE";
            cboRole.Items.Clear();
            oRole = new DataAccess.Role();

            cboRole.DataSource = oRole.GetRole(oMSearch);

            cboRole.DisplayMember = "ROLE";
            cboRole.ValueMember = "ROLE";
            cboRole.Text = string.Empty;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.ADD;
            EDButton(true);
            EnableDisableField(true);
            txtFirstName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TransactionType = GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT;
            txtFirstName.Text = oMUser.FIRST_NAME;
            txtMiddleName.Text = oMUser.MIDDLE_NAME;
            txtLastName.Text = oMUser.LAST_NAME;
            txtContactNo.Text = oMUser.CONTACT_NO;
            cboRole.Text = oMUser.ROLE;
            txtUsername.Text = oMUser.USERNAME;
            txtPassword.Text = oMUser.PASSWORD;
            txtConfirmPass.Text = oMUser.PASSWORD;
            chkStatus.Checked = oMUser.STATUS == "ACTIVE" ? true : false;
            chkAllowVoid.Checked = oMUser.ALLOWED_VOID == 1 ? true : false; 
            EDButton(true);
            EnableDisableField(true);
            txtUsername.Enabled = false;
            txtFirstName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oUser = new DataAccess.User();
            oMUser = new Model.User();
            oMSearch = new Model.Search();
            oMSearch.RECORD_SEARCH = txtUsername.Text;
            oMSearch.RECORD_TYPE = "USER";

            if (oUser.IsRecordExists(oMSearch) && TransactionType == GlobalVariable.eVariable.TRANSACTION_TYPE.ADD)
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_EXISTS);
                oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim())
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.PASSWORD_NOT_MATCH);
                oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgBox.ShowDialog();
                return;            
            }

            if (GlobalVariable.eVariable.IsFieldEmpty(pnlMain))
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.ALL_FIELDS_REQUIRED);
                oFrmMsgBox.ShowDialog();
                return;            
            }


            oMUser.FIRST_NAME = txtFirstName.Text;
            oMUser.MIDDLE_NAME = txtMiddleName.Text;
            oMUser.LAST_NAME = txtLastName.Text;
            oMUser.CONTACT_NO = txtContactNo.Text;
            oMUser.ROLE = cboRole.Text;
            oMUser.USERNAME = txtUsername.Text;
            oMUser.PASSWORD = txtPassword.Text;
            oMUser.STATUS = chkStatus.Checked == true ? "ACTIVE" : "INACTIVE";
            oMUser.ALLOWED_VOID = chkAllowVoid.Checked == true ? 1 : 0;

            if (TransactionType == GlobalVariable.eVariable.TRANSACTION_TYPE.ADD)
            {             
                oUser.InsertUser(oMUser);
            }
            else if (TransactionType == GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT)
            {                
                oUser.UpdateUser(oMUser);
            }

            oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_SAVE);
            oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
            oFrmMsgBox.ShowDialog();
            GlobalVariable.eVariable.ClearText(pnlMain);
            EDButton(false);
            EnableDisableField(false);
            DisplayRecords();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EDButton(false);
            EnableDisableField(false);
            GlobalVariable.eVariable.ClearText(pnlMain);
            cboRole.Text = string.Empty;
        }

        private void DisplayRecords()
        {
            oMSearch = new Model.Search();
            

            oUser = new DataAccess.User();
            dgRecord.Rows.Clear();
            foreach(DataRow row in oUser.GetUser(oMSearch).Rows)
            {
                dgRecord.Rows.Add( Convert.ToInt32(dgRecord.Rows.Count + 1), row["FIRST_NAME"], row["MIDDLE_NAME"], row["LAST_NAME"], row["CONTACT_NO"], row["ROLE"], row["USERNAME"], row["PASSWORD"], row["STATUS"], row["ALLOW_VOID"]);
            }

        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
        }

        private void SelectedRecords(object sender, DataGridViewCellEventArgs e)
        {
            oMUser = new Model.User();
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                iRowIndex = e.RowIndex;
                oMUser.FIRST_NAME = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMUser.MIDDLE_NAME = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();
                oMUser.LAST_NAME = dgRecord.Rows[e.RowIndex].Cells[3].Value.ToString();
                oMUser.CONTACT_NO = dgRecord.Rows[e.RowIndex].Cells[4].Value.ToString();
                oMUser.ROLE = dgRecord.Rows[e.RowIndex].Cells[5].Value.ToString();
                oMUser.USERNAME = dgRecord.Rows[e.RowIndex].Cells[6].Value.ToString();
                oMUser.PASSWORD = dgRecord.Rows[e.RowIndex].Cells[7].Value.ToString();
                oMUser.STATUS = dgRecord.Rows[e.RowIndex].Cells[8].Value.ToString();
                oMUser.ALLOWED_VOID = Convert.ToInt32(dgRecord.Rows[e.RowIndex].Cells[9].Value);
            }

        }

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
        }

        private void txtRole_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
