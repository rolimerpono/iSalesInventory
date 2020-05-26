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
    public partial class frmBrand : Form
    {
        DataAccess.Brand oBrand;
        Model.Brand oMBrand;
        Model.Search oMSearch;
        public eVariable.TRANSACTION_TYPE TransactionType;
        MessageBoxForm oFrmMsgBox;
        public frmBrand()
        {
            InitializeComponent();            
        }

        public frmBrand(frmBrandList frmList)
        {
            InitializeComponent();            
            _frmList = frmList;
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
            GlobalVariable.eVariable.DisableTextEnterKey(txtBrand);
            
        }

        frmBrandList _frmList;
        public frmBrand(frmBrandList frmList, Model.Brand oBrd)
        {
            InitializeComponent();
            txtBrand.Focus();
            _frmList = frmList;
            oMBrand = oBrd;
            DisplayRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oBrand = new DataAccess.Brand();
            oMBrand = new Model.Brand();

            oMSearch = new Model.Search();

            oMSearch.RECORD_SEARCH = txtBrand.Text.Trim();
            oMSearch.RECORD_TYPE = "BRAND";
            oMSearch.STATUS = "ACTIVE";

            if (oBrand.IsRecordExists(oMSearch) && TransactionType == eVariable.TRANSACTION_TYPE.ADD)
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_EXISTS);
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (TransactionType == GlobalVariable.eVariable.TRANSACTION_TYPE.ADD)
            {
                oMBrand.BRAND = txtBrand.Text;
                oMBrand.STATUS = chkStatus.Checked == true ? "ACTIVE" : "INACTIVE";
                oBrand.InsertBrand(oMBrand);
            
            }
            else if (TransactionType == GlobalVariable.eVariable.TRANSACTION_TYPE.EDIT)
            {
                oMBrand.ID = eVariable.sBrandID;
                oMBrand.BRAND = txtBrand.Text;
                oMBrand.STATUS = chkStatus.Checked == true ? "ACTIVE" : "INACTIVE";
                oBrand.UpdateBrand(oMBrand);
            }

            oFrmMsgBox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_SAVE);
            oFrmMsgBox.ShowDialog();

            _frmList.DisplayRecord();
            Close();

        }

        private void DisplayRecord()
        {
            eVariable.sBrandID = oMBrand.ID;
            txtBrand.Text = oMBrand.BRAND;
            chkStatus.Checked = oMBrand.STATUS == "ACTIVE" ? true : false;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            txtBrand.Focus();
        }


    }
}
