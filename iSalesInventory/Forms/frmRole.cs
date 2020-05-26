using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlobalVariable;
using iMessageBox;

namespace iSalesInventory.Forms
{
    public partial class frmRole : Form
    {
        DataAccess.Role oRole  = new DataAccess.Role();
        Model.Role oMRole = new Model.Role();
        Model.Search oMSearch = new Model.Search();
        public eVariable.TRANSACTION_TYPE TransactionType;
        iMessageBox.MessageBoxForm oFrmMsgBox;
        frmRoleList _frmList;
        public frmRole()
        {
            InitializeComponent();
        }

        public frmRole(frmRoleList frmList)
        {
            InitializeComponent();            
            _frmList = frmList;
        }

        public frmRole(frmRoleList frmList, Model.Role oRle)
        {
            InitializeComponent();
            oMRole = oRle;
            _frmList = frmList;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oRole = new DataAccess.Role();
            oMRole = new Model.Role();

            oMSearch = new Model.Search();

            oMSearch.RECORD_SEARCH = txtRole.Text.Trim();
            oMSearch.RECORD_TYPE = "ROLE";
            oMSearch.STATUS = "ACTIVE";

            if (oRole.IsRecordExists(oMSearch) && TransactionType == eVariable.TRANSACTION_TYPE.ADD)
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_EXISTS);
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (TransactionType == GlobalVariable.eVariable.TRANSACTION_TYPE.ADD)
            {
                oMRole.ROLE = txtRole.Text;
                oMRole.STATUS = chkStatus.Checked == true ? "ACTIVE" : "INACTIVE";
                oRole.InsertRole(oMRole);

            }
            else if (TransactionType == GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT)
            {
                oMRole.ID = eVariable.sID;
                oMRole.ROLE = txtRole.Text;
                oMRole.STATUS = chkStatus.Checked == true ? "ACTIVE" : "INACTIVE";
                oRole.UpdateRole(oMRole);
            }

            oFrmMsgBox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_SAVE);
            oFrmMsgBox.ShowDialog();
            _frmList.DisplayRecord();
            Close();
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            if (TransactionType == eVariable.TRANSACTION_TYPE.EDIT)
            {
                eVariable.sID = oMRole.ID;
                txtRole.Text = oMRole.ROLE;
                chkStatus.Checked = oMRole.STATUS == "ACTIVE" ? true : false;
            }
        }
    }
}
