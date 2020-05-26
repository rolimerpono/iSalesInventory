using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iMessageBox;

namespace iSalesInventory.Forms
{
    public partial class frmManageStocks : Form
    {

        iMessageBox.MessageBoxForm oFrmMsgBox;
        DataAccess.Vendor oVendor;
        DataAccess.Stocks oStocks;
        public Model.Stocks oMStocks = new Model.Stocks();
        Model.Vendor oMVendor;
        Model.Search oMSearch = new Model.Search();

        public enum RECORD_TYPE : int
        {           
            STOCKIN = 0,
            HISTORY=1
        }

        public RECORD_TYPE RecordType;
        private int iRowIndex = 0;
        public frmManageStocks()
        {
            InitializeComponent();
            RecordType = RECORD_TYPE.STOCKIN;
            GlobalVariable.eVariable.ValidNumber(txtQty);
        }

        private void lblBrowseProduct_Click(object sender, EventArgs e)
        {

            foreach (var o in tbStockIn.Controls.OfType<TextBox>().ToList())
            {
                if (o.Text.Trim() == string.Empty || cboVendor.Text == string.Empty)
                {
                    oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.ALL_FIELDS_REQUIRED);
                    oFrmMsgBox.ShowDialog();
                    o.Focus();
                    return;
                }
            }


            Forms.frmSearchProduct oFrm = new frmSearchProduct(this);            
            oFrm.ShowDialog();
            
        }

        private void LoadStockVendor()
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_SEARCH = "";
            oMSearch.RECORD_TYPE= "VENDOR";
            oMSearch.STATUS = "ACTIVE";

            oVendor = new DataAccess.Vendor();
            cboVendor.DataSource = oVendor.GetVendor(oMSearch);
            cboVendor.ValueMember = "ID";
            cboVendor.DisplayMember = "VENDOR";

            cboVendor.Text = string.Empty;
        }


        private void LoadAdjustVendor()
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_SEARCH = "";
            oMSearch.RECORD_TYPE = "VENDOR";
            oMSearch.STATUS = "ACTIVE";

            oVendor = new DataAccess.Vendor();
            cboVendorAdjust.DataSource = oVendor.GetVendor(oMSearch);
            cboVendorAdjust.ValueMember = "ID";
            cboVendorAdjust.DisplayMember = "VENDOR";

            cboVendorAdjust.Text = string.Empty;

        }

        

    


        public void DisplayRecords()
        {
            oStocks = new DataAccess.Stocks();
            

            if (RecordType == RECORD_TYPE.STOCKIN)
            {
                int iCount = (from DataGridViewRow r in dgStockIn.Rows
                              where Convert.ToString(r.Cells["PCODE"].Value.ToString()) == oMStocks._PRODUCT.PRODUCT_CODE
                              select r.Cells["PCODE"].Value.ToString()).Count(); 

                if (iCount == 0)
                {
                    dgStockIn.Rows.Add((dgStockIn.Rows.Count + 1).ToString(),txtReferrenceNo.Text, oMStocks._PRODUCT.PRODUCT_CODE, oMStocks._PRODUCT.DESCRIPTION,"1", txtStockInDate.Text,txtStockInBy.Text, cboVendor.SelectedValue.ToString(), cboVendor.Text);
                    EDStockInControls(false);
                }
                else
                {
                    oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_EXISTS);
                    oFrmMsgBox.ShowDialog();
                    return;
                }
            }
            else
            { 
            
            }
        }

        private void frmStockIn_Load(object sender, EventArgs e)
        {
            LoadStockVendor();                       
        }

        private void cboVendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lblGetRefNo_Click(object sender, EventArgs e)
        {
            
        }

      
       

        private void dgStockIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgStockIn.Rows.Count > 0 && e.RowIndex >= 0)
                {
                    iRowIndex = e.RowIndex;
                    if (e.ColumnIndex == 4)
                    {

                        dgStockIn.ReadOnly = false;
                        DataGridViewCell cell = dgStockIn.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dgStockIn.CurrentCell = cell;
                        dgStockIn.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        dgStockIn.BeginEdit(true);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

  

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgStockIn.Rows.Count > 0)
            {

                oFrmMsgBox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.YOU_WANT_TO_PROCEED);
                oFrmMsgBox.StartPosition =  FormStartPosition.CenterScreen;
                oFrmMsgBox.MessageType = MessageBoxForm.MESSAGE_TYPE.QUERY;
                oFrmMsgBox.ShowDialog();

                if (oFrmMsgBox.sAnswer == "YES")
                {
                    oStocks = new DataAccess.Stocks();
                    foreach (DataGridViewRow row in dgStockIn.Rows)
                    {
                        oMStocks = new Model.Stocks();
                        oMStocks.REFERENCE_NO = txtReferrenceNo.Text;
                        oMStocks._PRODUCT.PRODUCT_CODE = row.Cells[2].Value.ToString();
                        oMStocks.QTY = Convert.ToInt32(row.Cells[4].Value);
                        oMStocks.STOCK_DATE = txtStockInDate.Text;
                        oMStocks.STOCK_BY = txtStockInBy.Text;
                        oMStocks._VENDOR.ID = row.Cells[7].Value.ToString();
                        oMStocks.STATUS = "IN";

                        oStocks.InsertStock(oMStocks);

                    }

                    oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_SAVE);
                    oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                    oFrmMsgBox.ShowDialog();
                    ClearStockIn();                
                    EDStockInControls(true);
                }
                
            }
        }

        private void tbStockAdjust_Click(object sender, EventArgs e)
        {

        }

        private void cboSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboAction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            oStocks = new DataAccess.Stocks();
            txtReferrenceNo.Text = oStocks.GetRefferenceAutoNo();
            txtStockInBy.Text = GlobalVariable.eVariable.sFullname;
            txtStockInDate.Text = DateTime.Now.ToString("yyyy-MM-dd");             
        }

        private void btnBrowseProduct_Click(object sender, EventArgs e)
        {
            foreach (var o in tbStockIn.Controls.OfType<TextBox>().ToList())
            {
                if (o.Text.Trim() == string.Empty || cboVendor.Text == string.Empty)
                {
                    oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.ALL_FIELDS_REQUIRED);
                    oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                    oFrmMsgBox.ShowDialog();
                    o.Focus();
                    return;
                }
            }


            Forms.frmSearchProduct oFrm = new frmSearchProduct(this);
            oFrm.ShowDialog();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearStockIn();
            EDStockInControls(true);
        }

        private void ClearStockIn()
        {
            txtReferrenceNo.Text = string.Empty;
            txtStockInBy.Text = string.Empty;
            txtStockInDate.Text = string.Empty;
            cboVendor.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAddess.Text = string.Empty;
            dgStockIn.Rows.Clear();
        }

        private void EDStockInControls(bool bFlag)
        {
            btnGenerateCode.Enabled = bFlag;                     
            cboVendor.Enabled = bFlag;       
        }

        private void tbStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbStock.SelectedIndex)
            { 
                case 0:
                    txtStockInDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    LoadAdjustVendor();
                    ClearAdjustStock();
                    break;
                case 1:
                    ClearStockIn();
                    EDStockInControls(true);
                    LoadAdjustVendor();
                    GetStockAdjustRefNo();
                    DisplayStockList();                 
                    break;                     
            }
        }

        private void GetStockAdjustRefNo()
        {
            oStocks = new DataAccess.Stocks();
            txtRefNo.Text = oStocks.GetRefferenceAutoNo();
        }

        private void DisplayStockList()
        {
            oStocks = new DataAccess.Stocks();            
            oMSearch = new Model.Search();

            dgStockAdjust.Rows.Clear();                      
            
            if (tbStock.SelectedIndex == 1)
            {
                oMSearch.RECORD_TYPE = cboSearch.Text;      
                foreach (DataRow row in oStocks.GetStock(oMSearch).Rows)
                {
                    dgStockAdjust.Rows.Add((dgStockAdjust.Rows.Count + 1).ToString(), row["PRODUCT_CODE"], row["BAR_CODE"], row["DESCRIPTION"], row["BRAND_ID"], row["BRAND"], row["CATEGORY_ID"], row["CATEGORY"], row["PRICE"], row["QTY"]);
                }
            }                          
        
        }

        private void btnACancel_Click(object sender, EventArgs e)
        {
            ClearAdjustStock();
        }

        private void ClearAdjustStock()
        {
            txtProductCode.Text = string.Empty;
            txtDescription.Text=  string.Empty;
            cboAction.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtQty.Text = string.Empty;
            cboVendorAdjust.Text = string.Empty;
            txtUser.Text = string.Empty;

        }



        private void AdjustSelectedRecords(object sender, DataGridViewCellEventArgs e)
        {
            oMStocks = new Model.Stocks();
            if (dgStockAdjust.Rows.Count > 0 && e.RowIndex >= 0)
            {
                iRowIndex = e.RowIndex;
                oMStocks._PRODUCT.PRODUCT_CODE = dgStockAdjust.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMStocks._PRODUCT.BAR_CODE = dgStockAdjust.Rows[e.RowIndex].Cells[2].Value.ToString();
                oMStocks._PRODUCT.DESCRIPTION = dgStockAdjust.Rows[e.RowIndex].Cells[3].Value.ToString();  
                oMStocks._PRODUCT._BRAND.ID  = dgStockAdjust.Rows[e.RowIndex].Cells[4].Value.ToString();
                oMStocks._PRODUCT._BRAND.BRAND = dgStockAdjust.Rows[e.RowIndex].Cells[5].Value.ToString();
                oMStocks._PRODUCT._CATEGORY.ID = dgStockAdjust.Rows[e.RowIndex].Cells[6].Value.ToString();
                oMStocks._PRODUCT._CATEGORY.CATEGORY = dgStockAdjust.Rows[e.RowIndex].Cells[7].Value.ToString();
                oMStocks._PRODUCT.PRICE = dgStockAdjust.Rows[e.RowIndex].Cells[8].Value.ToString();
                oMStocks.QTY = Convert.ToInt32(dgStockAdjust.Rows[e.RowIndex].Cells[9].Value);
            }

        }

        private void dgStockAdjust_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AdjustSelectedRecords(sender, e);
        }

        private void dgStockAdjust_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AdjustSelectedRecords(sender, e);
        }

        private void dgStockAdjust_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgStockAdjust.Rows.Count > 0 && e.RowIndex >= 0)
            {
                txtProductCode.Text = oMStocks._PRODUCT.PRODUCT_CODE;
                txtDescription.Text = oMStocks._PRODUCT.DESCRIPTION;

                txtUser.Text = GlobalVariable.eVariable.sFullname;
            }
        }

       

        private bool IsAdjustStockFieldEmpty()
        {           
            foreach (Control o in panel2.Controls.OfType<TextBox>().ToList() )
            {
                if ((o.Name == "txtQty" && o.Text == string.Empty) || (o.Name == "txtRemarks" && o.Text == string.Empty))
                {                    
                    return true;
                }               
            }
            if (cboAction.Text == string.Empty || cboVendorAdjust.Text == string.Empty)
            {                
                return true;
            }
            return false;
        }

        private void cboVendorAdjust_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tbStockHistory_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DisplayStockList();
        }

        private void cboVendor_SelectionChangeCommitted(object sender, EventArgs e)
        {

            oMSearch = new Model.Search();
            oVendor = new DataAccess.Vendor();
            oMVendor = new Model.Vendor();

            if (cboVendor.Items.Count > 0)
            {
                oMSearch.RECORD_TYPE = "ID";
                oMSearch.RECORD_SEARCH = cboVendor.SelectedValue.ToString();
                oMSearch.STATUS = "ACTIVE";
                foreach (DataRow row in oVendor.GetVendor(oMSearch).Rows)
                {
                    oMVendor.ID = row["ID"].ToString();
                    oMVendor.VENDOR = row["VENDOR"].ToString();
                    oMVendor.ADDRESS = row["ADDRESS"].ToString();
                    oMVendor.CONTACT_PERSON = row["CONTACT_PERSON"].ToString();
                }

                txtContact.Text = oMVendor.CONTACT_PERSON;
                txtAddess.Text = oMVendor.ADDRESS;
            }

        }

        private void dgStockIn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgStockIn.Rows.Count > 0 && iRowIndex >= 0)
            {
                if (dgStockIn.CurrentCell.ColumnIndex == 4)
                {
                    TextBox T = e.Control as TextBox;
                    if (T != null)
                    {
                        GlobalVariable.eVariable.ValidNumber(T);
                    }
                }
            }
        }

        private void dgStockIn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int iQuantity = 0;
            if (dgStockIn.Rows.Count > 0 && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    iQuantity = Convert.ToInt32(dgStockIn.Rows[e.RowIndex].Cells[4].Value);

                    if (iQuantity == 0)
                    {
                        dgStockIn.Rows[e.RowIndex].Cells[4].Value = 1;
                    }                                      
                }
            }
        }

        private void dgStockIn_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgStockIn.Rows.Count > 0 && e.RowIndex >= 0)
            {
                iRowIndex = e.RowIndex;
            }
        }

        private void btnSaveAdjust_Click(object sender, EventArgs e)
        {
            oStocks = new DataAccess.Stocks();
            int iQty = txtQty.Text == "" ? 1 : Convert.ToInt32(txtQty.Text);

            if (iQty > oMStocks.QTY)
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.QUANTY_IS_GREATER_THAN_ONHAND);
                oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgBox.ShowDialog();
                return;
            }


            if (!IsAdjustStockFieldEmpty())
            {
                oFrmMsgBox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.YOU_WANT_TO_PROCEED);
                oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgBox.MessageType = MessageBoxForm.MESSAGE_TYPE.QUERY;
                oFrmMsgBox.ShowDialog();

                if (oFrmMsgBox.sAnswer == "YES")
                {
                    oMStocks.REFERENCE_NO = txtRefNo.Text;
                    oMStocks._VENDOR.ID = cboVendorAdjust.SelectedValue.ToString();
                    oMStocks.QTY = iQty;
                    oMStocks.STOCK_BY = txtUser.Text;
                    oMStocks.STOCK_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                    oMStocks.REMARKS = txtRemarks.Text;
                    if (cboAction.Text.Contains("ADD"))
                    {
                        oMStocks.STATUS = "IN";
                    }
                    else
                    {
                        oMStocks.STATUS = "OUT";
                    }
                    oStocks.InsertStock(oMStocks);


                    oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_SAVE);
                    oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                    oFrmMsgBox.ShowDialog();

                    ClearAdjustStock();
                    DisplayStockList();
                    GetStockAdjustRefNo();
                }
            }
            else
            {

                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.ALL_FIELDS_REQUIRED);
                oFrmMsgBox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgBox.ShowDialog();
                return;
            }  
        }

       

      
    }
}
