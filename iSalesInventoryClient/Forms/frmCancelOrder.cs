using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iSalesInventoryClient.Forms
{
    public partial class frmCancelOrder : Form
    {
        DataAccess.Transaction oTransaction = new DataAccess.Transaction();
        DataAccess.Stocks oStocks = new DataAccess.Stocks();
        DataAccess.Vendor oVendor = new DataAccess.Vendor();
        Model.Stocks oMStocks = new Model.Stocks();
        Model.Transaction oMTransaction = new Model.Transaction();
        Model.Search oMSearch = new Model.Search();
        iMessageBox.MessageBoxForm oFrmMsgBox;

        frmDailySales _frmList;
        public frmCancelOrder()
        {
            InitializeComponent();
        }

        public frmCancelOrder(frmDailySales frmlist, Model.Transaction oTrans)
        {
            InitializeComponent();
            oMTransaction = oTrans;
            DisplayRecord();
            _frmList = frmlist;
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
            GlobalVariable.eVariable.DisableKeyPress(cboAction);
            GlobalVariable.eVariable.ValidNumber(txtCancelledQty);
            GlobalVariable.eVariable.DisableKeyPress(cboVendor);
            txtCancelledBy.Text = GlobalVariable.eVariable.sFullname;
        }

        private void DisplayRecord()
        {
            txtTransactionNo.Text = oMTransaction.TRANSACTION_NO;
            txtProductCode.Text = oMTransaction._Product.PRODUCT_CODE;
            txtDescription.Text = oMTransaction._Product.DESCRIPTION;
            txtPrice.Text = oMTransaction._Product.PRICE;
            txtQty.Text = oMTransaction.QTY.ToString();
            txtDiscPerc.Text = oMTransaction.DISCOUNT_PERCENTAGE.ToString();
            txtDiscount.Text = oMTransaction.DISCOUNT.ToString();
            txtVatPerc.Text = oMTransaction.VAT_PERCENTAGE.ToString();
            txtVat.Text = oMTransaction.VAT.ToString();
            txtTotalAmount.Text = oMTransaction.TOTAL.ToString();                            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            oTransaction = new DataAccess.Transaction();
            oMTransaction = new Model.Transaction();
            oStocks = new DataAccess.Stocks();
            oMStocks = new Model.Stocks();



            Forms.frmVoid oFrm = new frmVoid();
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.ShowDialog();

            if (oFrm.sAnswer == "OK")
            {
                if (Convert.ToInt32(txtCancelledQty.Text) > Convert.ToInt32(txtQty.Text))
                {
                    oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.QUANTY_IS_GREATER_THAN_ONHAND);
                    oFrmMsgBox.ShowDialog();
                    return;
                }

                oTransaction = new DataAccess.Transaction();
                if (Convert.ToInt32(txtCancelledQty.Text) == Convert.ToInt32(txtQty.Text))
                {
                    oMTransaction = new Model.Transaction();
                    oMTransaction.TRANSACTION_NO = txtTransactionNo.Text;
                    oMTransaction._Product.PRODUCT_CODE = txtProductCode.Text;
                    //oMTransaction.STATUS = "CANCELLED";
                    //oTransaction.UpdateSoldItemStatus(oMTransaction);
                    oTransaction.DeleteSoldItems(oMTransaction);
                }

                if (cboAction.Text.Contains("ADD"))
                {

                    int iResult = Convert.ToInt32(txtQty.Text) - Convert.ToInt32(txtCancelledQty.Text);

                    oTransaction = new DataAccess.Transaction();
                    oMTransaction = new Model.Transaction();
                    oMTransaction.TRANSACTION_NO = txtTransactionNo.Text;
                    oMTransaction._Product.PRODUCT_CODE = txtProductCode.Text;
                    oMTransaction.MODIFIED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                    oMTransaction.MODIFIED_BY = txtCancelledBy.Text;                    
                    oMTransaction.QTY = iResult;
                    oMTransaction.TOTAL = Convert.ToDouble(txtPrice.Text) * iResult;

                    if (Convert.ToDouble(txtVatPerc.Text) != 0)
                    {
                        oMTransaction.VAT = (Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(iResult)) * (Convert.ToDouble(txtVatPerc.Text) / 100);
                        oMTransaction.TOTAL = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(iResult) - oMTransaction.VAT;
                    }

                    if (Convert.ToDouble(txtDiscPerc.Text) != 0)
                    {
                        oMTransaction.DISCOUNT = (Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(iResult)) * (Convert.ToDouble(txtDiscPerc.Text) / 100);
                        oMTransaction.TOTAL = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(iResult) - oMTransaction.DISCOUNT;      
                    }                    

                    if (iResult > 0)
                    {
                        oMTransaction.STATUS = "SOLD";
                        oTransaction.UpdateSoldItems(oMTransaction);
                    }
                }
                else
                {
                    oMStocks.REFERENCE_NO = oStocks.GetRefferenceAutoNo();
                    oMStocks._PRODUCT.PRODUCT_CODE = txtProductCode.Text;
                    oMStocks.QTY = Convert.ToInt32(txtCancelledQty.Text);
                    oMStocks.STOCK_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                    oMStocks.STOCK_BY = txtCancelledBy.Text;
                    oMStocks.REMARKS = txtReason.Text;
                    oMStocks._VENDOR.ID = cboVendor.SelectedValue.ToString();
                    oMStocks.STATUS = "OUT";
                    oStocks.InsertStock(oMStocks);
                }

                oTransaction = new DataAccess.Transaction();
                oMTransaction = new Model.Transaction();
                oMTransaction.TRANSACTION_NO = txtTransactionNo.Text;
                oMTransaction._Product.PRODUCT_CODE = txtProductCode.Text;
                oMTransaction._Product.PRICE = txtPrice.Text;
                oMTransaction.QTY = Convert.ToInt32(txtCancelledQty.Text);
                oMTransaction.VAT_PERCENTAGE = Convert.ToDouble(txtVatPerc.Text);
                oMTransaction.DISCOUNT_PERCENTAGE = Convert.ToDouble(txtDiscPerc.Text);
                oMTransaction.TOTAL = Convert.ToDouble(txtTotalAmount.Text);

                if (Convert.ToDouble(txtVatPerc.Text) != 0)
                {
                    oMTransaction.VAT = (Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtCancelledQty.Text)) * (Convert.ToDouble(txtVatPerc.Text) / 100);
                    oMTransaction.TOTAL = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtCancelledQty.Text) - oMTransaction.VAT;
                }

                if (Convert.ToDouble(txtDiscPerc.Text) != 0)
                {
                    oMTransaction.DISCOUNT_PERCENTAGE = Convert.ToDouble(txtDiscPerc.Text);
                    oMTransaction.DISCOUNT = oMTransaction.TOTAL * (Convert.ToDouble(txtDiscPerc.Text) / 100);
                }

                oMTransaction.TOTAL = oMTransaction.TOTAL - (oMTransaction.VAT + oMTransaction.DISCOUNT);

                oMTransaction.TRANSACTION_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                oMTransaction.TRANSACT_BY = txtCancelledBy.Text;
                oMTransaction.VOID_BY = GlobalVariable.eVariable.sVoidBy;
                oMTransaction.REASON = txtReason.Text;
                oMTransaction.STATUS = cboAction.Text;
                oTransaction.InsertCancelledItems(oMTransaction);

                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.TRANSACTION_COMPLETE);
                oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgBox.ShowDialog();
                _frmList.DisplayRecords();
                Close();
            }
        }

        private void LoadVendor()
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_SEARCH = "";
            oMSearch.RECORD_TYPE = "VENDOR";
            oMSearch.STATUS = "ACTIVE";

            oVendor = new DataAccess.Vendor();
            cboVendor.DataSource = oVendor.GetVendor(oMSearch);
            cboVendor.ValueMember = "ID";
            cboVendor.DisplayMember = "VENDOR";
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCancelOrder_Load(object sender, EventArgs e)
        {
            LoadVendor();
        }

       
    }
}
