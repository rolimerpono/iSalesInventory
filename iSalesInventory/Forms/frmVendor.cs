using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlobalVariable;

namespace iSalesInventory.Forms
{
    public partial class frmVendor : Form
    {

        DataAccess.Vendor oVendor;
        Model.Vendor oMVendor;
        Model.Search oMSearch;
        iMessageBox.MessageBoxForm oFrmMsgBox;
        public GlobalVariable.eVariable.TRANSACTION_TYPE TransactionType;        
        public frmVendor()
        {
            InitializeComponent();
            
            
        }
        frmVendorList _frmList;
        public frmVendor(frmVendorList frmList)
        {
            InitializeComponent();            
            _frmList = frmList;
            GlobalVariable.eVariable.DisableTextPanelEnterKey(pnlMain);
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
            
        }

        public frmVendor(frmVendorList frmList , Model.Vendor oVdr)
        {
            InitializeComponent();            
            oMVendor = oVdr; 
            _frmList = frmList;
            DisplayRecord();
            GlobalVariable.eVariable.DisableTextPanelEnterKey(pnlMain);
            GlobalVariable.eVariable.MoveForm(pnlHeader,Handle);
            
        }


        private void DisplayRecord()
        {
            eVariable.sVendorID = oMVendor.ID;
            txtVendor.Text = oMVendor.VENDOR;
            txtAdddress.Text = oMVendor.ADDRESS;
            txtContactPerson.Text = oMVendor.CONTACT_PERSON;
            txtTelephone.Text = oMVendor.TELEPHONE_NUMBER;
            txtPhoneNo.Text = oMVendor.PHONE_NO;
            txtEmail.Text = oMVendor.EMAIL;
            txtFax.Text = oMVendor.FAX_NO;
            chkStatus.Checked = oMVendor.STATUS == "ACTIVE" ? true : false;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oVendor = new DataAccess.Vendor();
            oMSearch = new Model.Search();

            oMSearch.RECORD_SEARCH = txtVendor.Text.Trim();
            oMSearch.RECORD_TYPE = "VENDOR";
            oMSearch.STATUS = "ACTIVE";

            if (GlobalVariable.eVariable.IsFieldEmpty(pnlMain))
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.ALL_FIELDS_REQUIRED);
                oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (oVendor.IsRecordExists(oMSearch) && TransactionType == eVariable.TRANSACTION_TYPE.ADD)
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_EXISTS);
                oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgBox.ShowDialog();
                return;            
            }


            

            if (TransactionType == eVariable.TRANSACTION_TYPE.ADD)
            {
                oMVendor = new Model.Vendor();
                oMVendor.ID = eVariable.sVendorID;
                oMVendor.VENDOR = txtVendor.Text;
                oMVendor.ADDRESS = txtAdddress.Text;
                oMVendor.CONTACT_PERSON = txtContactPerson.Text;
                oMVendor.TELEPHONE_NUMBER = txtTelephone.Text;
                oMVendor.EMAIL = txtEmail.Text;
                oMVendor.PHONE_NO = txtPhoneNo.Text;                
                oMVendor.FAX_NO = txtFax.Text;
                oMVendor.STATUS = chkStatus.Checked == true ? "ACTIVE" : "INACTIVE";
                oVendor.InserVendor(oMVendor);

            }
            else
            {
                oMVendor = new Model.Vendor();
                oMVendor.ID = eVariable.sVendorID;
                oMVendor.VENDOR = txtVendor.Text;
                oMVendor.ADDRESS = txtAdddress.Text;
                oMVendor.CONTACT_PERSON = txtContactPerson.Text;
                oMVendor.TELEPHONE_NUMBER = txtTelephone.Text;
                oMVendor.EMAIL = txtEmail.Text;
                oMVendor.PHONE_NO = txtPhoneNo.Text;
                oMVendor.FAX_NO = txtFax.Text;
                oMVendor.STATUS = chkStatus.Checked == true ? "ACTIVE" : "INACTIVE";                
                oVendor.UpdateVendor(oMVendor);
            }

            oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_SAVE);
            oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
            oFrmMsgBox.ShowDialog();
            _frmList.DisplayRecords();
            Close();
        }

        private void frmVendor_Load(object sender, EventArgs e)
        {
            txtVendor.Focus();
        }
    }
}
