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
    public partial class frmProduct : Form
    {
        DataAccess.Product oProduct;
        Model.Product oMproduct;
        Model.Search oMSearch = new Model.Search();
        public eVariable.TRANSACTION_TYPE TransactionType;
        MessageBoxForm oFrmMsgBox;

        public frmProduct()
        {
            InitializeComponent();
            
        }
        frmProductList _FrmList;
        public frmProduct(frmProductList frmList)
        {
            InitializeComponent();
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
            GlobalVariable.eVariable.DisableTextPanelEnterKey(pnlMain);
            GlobalVariable.eVariable.ValidAmount(txtPrice);
            GlobalVariable.eVariable.ValidNumber(txtReOrderLevel);
            _FrmList = frmList;
        }

        
        public frmProduct(frmProductList frmList, Model.Product oPrd)
        {
            InitializeComponent();            
            _FrmList = frmList;
            oMproduct = oPrd;
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
            GlobalVariable.eVariable.DisableTextPanelEnterKey(pnlMain);
            GlobalVariable.eVariable.ValidAmount(txtPrice);
            GlobalVariable.eVariable.ValidNumber(txtReOrderLevel);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            oProduct = new DataAccess.Product();
            if (TransactionType == eVariable.TRANSACTION_TYPE.ADD)
            {
                txtProductCode.Text = oProduct.GetProductAutoNo();
            }
            else
            {
                DisplayRecord();
            }
            txtDescription.Focus();
        }

        private void DisplayRecord()
        {
            txtProductCode.Text = oMproduct.PRODUCT_CODE;
            txtBarCode.Text = oMproduct.BAR_CODE;
            txtDescription.Text = oMproduct.DESCRIPTION;
            eVariable.sBrandID = oMproduct._BRAND.ID;
            txtBrand.Text = oMproduct._BRAND.BRAND;
            eVariable.sCategoryID = oMproduct._CATEGORY.ID;
            txtCategory.Text = oMproduct._CATEGORY.CATEGORY;
            txtPrice.Text = oMproduct.PRICE;
            txtReOrderLevel.Text = oMproduct.REORDER_LEVEL;        
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                oMSearch.RECORD_SEARCH = txtDescription.Text;
                oMSearch.RECORD_TYPE = "DESCRIPTION";

                oProduct = new DataAccess.Product();

                if (GlobalVariable.eVariable.IsFieldEmpty(pnlMain))
                {
                    oFrmMsgBox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.ALL_FIELDS_REQUIRED);
                    oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                    oFrmMsgBox.ShowDialog();
                    return;
                }

                if (oProduct.IsRecordExists(oMSearch) && TransactionType == eVariable.TRANSACTION_TYPE.ADD)
                {
                    oFrmMsgBox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_EXISTS);
                    oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                    oFrmMsgBox.ShowDialog();
                    return;
                }

                oMproduct = new Model.Product();
                if (TransactionType == eVariable.TRANSACTION_TYPE.EDIT)
                {
                    oMproduct.PRODUCT_CODE = txtProductCode.Text;
                    oMproduct.BAR_CODE = txtBarCode.Text;
                    oMproduct.DESCRIPTION = txtDescription.Text;
                    oMproduct._BRAND.ID = eVariable.sBrandID;
                    oMproduct._CATEGORY.ID = eVariable.sCategoryID;
                    oMproduct.PRICE = txtPrice.Text;
                    oMproduct.REORDER_LEVEL = txtReOrderLevel.Text;
                    oMproduct.VATABLE = chkVatable.Checked;
                    oProduct.UpdateProduct(oMproduct);
                }
                else
                {
                    oMproduct.PRODUCT_CODE = txtProductCode.Text;
                    oMproduct.BAR_CODE = txtBarCode.Text;
                    oMproduct.DESCRIPTION = txtDescription.Text;
                    oMproduct._BRAND.ID = eVariable.sBrandID;
                    oMproduct._CATEGORY.ID = eVariable.sCategoryID;
                    oMproduct.PRICE = txtPrice.Text;
                    oMproduct.REORDER_LEVEL = txtReOrderLevel.Text;
                    oMproduct.VATABLE = chkVatable.Checked;
                    oProduct.InsertProduct(oMproduct);
                }

                oFrmMsgBox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_SAVE);
                oFrmMsgBox.ShowDialog();

                _FrmList.DisplayRecords();
                Close();
            }
            catch (Exception ex)
            {
                oFrmMsgBox = new MessageBoxForm(ex.Message);
                oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgBox.ShowDialog();
            }
        }

        

        private void btnBrand_Click(object sender, EventArgs e)
        {
            Forms.frmSearch oFrm = new frmSearch();
            oFrm.RecordType = frmSearch.RECORD_TYPE.BRAND;
            oFrm.Size = new Size(429, 226);
            oFrm.ShowDialog();

            eVariable.sBrandID = oFrm.oMBrand.ID;
            txtBrand.Text = oFrm.oMBrand.BRAND;

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Forms.frmSearch oFrm = new frmSearch();
            oFrm.RecordType = frmSearch.RECORD_TYPE.CATEGORY;
            oFrm.Size = new Size(429, 226);
            oFrm.ShowDialog();

            eVariable.sCategoryID = oFrm.oMCategory.ID;
            txtCategory.Text = oFrm.oMCategory.CATEGORY;
        }

        private void txtBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;   
        }

        private void txtCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;   
        }


    }
}
