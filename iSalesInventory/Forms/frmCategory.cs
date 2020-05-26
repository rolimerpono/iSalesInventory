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
    public partial class frmCategory : Form
    {


        DataAccess.Category oCategory;
        Model.Category oMCategory;
        Model.Search oMSearch;

        public eVariable.TRANSACTION_TYPE TransactionType;
        frmCategoryList _frmList;
        MessageBoxForm oFrmMsgBox;
        public frmCategory()
        {
            InitializeComponent();
        }


        public frmCategory(frmCategoryList frmList)
        {
            InitializeComponent();
            _frmList = frmList;
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
            
        }


        public frmCategory(frmCategoryList frmList, Model.Category oCatgry)
        {
            InitializeComponent();
            
            _frmList = frmList;            
            oMCategory = oCatgry;
            DisplayRecords();
            GlobalVariable.eVariable.DisableTextEnterKey(txtCategory);            
        }

        private void DisplayRecords()
        {
            eVariable.sCategoryID = oMCategory.ID;
            txtCategory.Text = oMCategory.CATEGORY;
            chkStatus.Checked = oMCategory.STATUS == "ACTIVE" ? true : false;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oCategory = new DataAccess.Category();
            oMCategory = new Model.Category();

            oMSearch = new Model.Search();

            oMSearch.RECORD_SEARCH = txtCategory.Text.Trim();
            oMSearch.RECORD_TYPE = "CATEGORY";
            oMSearch.STATUS = "ACTIVE";

            if (oCategory.IsRecordExists(oMSearch) && TransactionType == eVariable.TRANSACTION_TYPE.ADD)
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_EXISTS);
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (TransactionType == GlobalVariable.eVariable.TRANSACTION_TYPE.ADD)
            {
                oMCategory.CATEGORY = txtCategory.Text;
                oMCategory.STATUS = chkStatus.Checked == true ? "ACTIVE" : "INACTIVE";
                oCategory.InsertCategory(oMCategory);

            }
            else if (TransactionType == GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT)
            {
                oMCategory.ID = eVariable.sCategoryID;
                oMCategory.CATEGORY = txtCategory.Text;
                oMCategory.STATUS = chkStatus.Checked == true ? "ACTIVE" : "INACTIVE";
                oCategory.UpdateCategory(oMCategory);
            }

            oFrmMsgBox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_SAVE);
            oFrmMsgBox.ShowDialog();
            _frmList.DisplayRecord();
            Close();
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            txtCategory.Focus();
        }
    }
}
