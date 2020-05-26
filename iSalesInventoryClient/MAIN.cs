using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iMessageBox;
using XMLSerialiser;

namespace iSalesInventoryClient
{
    public partial class MAIN : Form
    {


        XMLSerialiser.Serializerset oXMLSerializerSet;
        Model.SystemConfiguration oSystemConfig = new Model.SystemConfiguration();        
        Model.DefaultLogin oMDefaultLogin;
        Model.User oMuser;

        DataAccess.Stocks oStocks;
        DataAccess.Transaction oTransaction;
        Model.Transaction oMTransaction;
        
        public Model.Stocks oMStocks = new Model.Stocks();        
        private int iRowIndex = 0;
        private int iColumnIndex = 0;
        private double iTotalAmount = 0;
        private double iTotalNetSales = 0;
        private double iTotalDiscount = 0;
        private double iTotalVatAmount = 0;

        private double iVatAmount = 0;
        private double iVatPercentage = 0;
        public double iDiscountPercentage;
        MessageBoxForm oFrmMsgbox;

        Form xFrm;
        public MAIN()
        {
            InitializeComponent();
        }

       

        

        public MAIN(Model.DefaultLogin oData)
        {
            InitializeComponent();
            oMDefaultLogin = oData;
            GlobalVariable.eVariable.IsAllowVoid = false;
            lblUser.Text = "[" + oMDefaultLogin.NAME + "]";
            GlobalVariable.eVariable.IsAllowVoid = oMDefaultLogin.ALLOW_VOID;
            GlobalVariable.eVariable.DisableGridColumnSort(dgRecord);

            foreach (Control o in pnlMain.Controls)
            {                
                o.KeyDown += Main_KeyDown;                
            }
        }

        public MAIN(Model.User oData)
        {
            InitializeComponent();
            oMuser = oData;
            lblUser.Text = "[" + oData.FIRST_NAME + " " + oData.MIDDLE_NAME + " " + oData.LAST_NAME + "]";
            GlobalVariable.eVariable.IsAllowVoid = false;
            GlobalVariable.eVariable.IsAllowVoid = Convert.ToBoolean(oMuser.ALLOWED_VOID);
            GlobalVariable.eVariable.DisableGridColumnSort(dgRecord);


            foreach (Control o in pnlMain.Controls)
            {               
                o.KeyDown += Main_KeyDown;                
            }


        }

        private void LoadSystemConfig()
        {
            oXMLSerializerSet = new Serializerset(Application.StartupPath + @"\SystemConfiguration.dll");
            oSystemConfig = oXMLSerializerSet.ReadXmlSerialize(Application.StartupPath + @"\SystemConfiguration.dll");
        }
       

        private void MAIN_Load(object sender, EventArgs e)
        {
            LoadVat();
            EDControls(true);
            LoadSystemConfig();            
        }

        private void LoadVat()
        {
            DataAccess.Vat oVat = new DataAccess.Vat();
            foreach(DataRow row in oVat.GetVat().Rows)
            {
                iVatPercentage = Convert.ToDouble(row[0]);
            }

        }
        public void DisplayRecords()
        {
            oStocks = new DataAccess.Stocks();
            iVatAmount = 0;
            int iCount = (from DataGridViewRow r in dgRecord.Rows
                            where Convert.ToString(r.Cells["PCODE"].Value.ToString()) == oMStocks._PRODUCT.PRODUCT_CODE
                            select r.Cells["PCODE"].Value.ToString()).Count();

            if (iCount == 0)
            {
                if (oMStocks._PRODUCT.VATABLE)                                                
                {
                    iVatAmount = GetPercentageAmount(Convert.ToDouble(oMStocks._PRODUCT.PRICE), oMStocks.QTY, iVatPercentage);
                    dgRecord.Rows.Add((dgRecord.Rows.Count + 1).ToString(),
                                           oMStocks._PRODUCT.PRODUCT_CODE,
                                           oMStocks._PRODUCT.DESCRIPTION,
                                           oMStocks._PRODUCT.PRICE,
                                           oMStocks.QTY.ToString(),
                                           oMStocks.DISCOUNT_PERCENTAGE,
                                           oMStocks.DISCOUNT.ToString("n2"),
                                           iVatPercentage,
                                           iVatAmount.ToString("n2"),
                                           ((Convert.ToDouble(oMStocks._PRODUCT.PRICE) * oMStocks.QTY) - iVatAmount).ToString("n2"),
                                           oMStocks.STOCK_ON_HAND,
                                           oMStocks._PRODUCT.VATABLE);
                }
                else
                {
                    dgRecord.Rows.Add((dgRecord.Rows.Count + 1).ToString(),
                        oMStocks._PRODUCT.PRODUCT_CODE,
                        oMStocks._PRODUCT.DESCRIPTION,
                        oMStocks._PRODUCT.PRICE,
                        oMStocks.QTY.ToString(),
                        oMStocks.DISCOUNT_PERCENTAGE,
                        oMStocks.DISCOUNT.ToString("n2"),
                        "0.00",
                        "0.00",
                        (Convert.ToDouble(oMStocks._PRODUCT.PRICE) * oMStocks.QTY).ToString("n2"),
                        oMStocks.STOCK_ON_HAND,
                        oMStocks._PRODUCT.VATABLE);
                }

               
            }
            else
            {
                oFrmMsgbox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.RECORD_EXISTS);
                oFrmMsgbox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgbox.ShowDialog();
                return;
            }

            dgRecord_CellClick(this.dgRecord, new DataGridViewCellEventArgs(this.dgRecord.CurrentCell.ColumnIndex, iRowIndex));
            UpdateDataGridViewData(oMStocks);
        }
      

        private void btnSearchProd_Click(object sender, EventArgs e)
        {
            Forms.frmProductList oFrm = new Forms.frmProductList(this);
            oFrm.ShowDialog();
        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            if (dgRecord.Rows.Count > 0 && iRowIndex >= 0)
            {
                dgRecord_CellClick(this.dgRecord, new DataGridViewCellEventArgs(this.dgRecord.CurrentCell.ColumnIndex, iRowIndex));
                Forms.frmDiscount oFrm = new Forms.frmDiscount(this, oMStocks);
                oFrm.StartPosition = FormStartPosition.CenterScreen;
                oFrm.ShowDialog();
                oMStocks = oFrm.oMStocks;
                UpdateDataGridViewData(oMStocks);                
            }
            else
            {

                oFrmMsgbox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.SELECT_RECORD_FIRST);
                oFrmMsgbox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgbox.ShowDialog();
                return;
            }
        }

        private void UpdateDataGridViewData(Model.Stocks oData)                                        
        {
       
            double iDeductAmount = 0;
            if (dgRecord.Rows.Count > 0)
            {
                dgRecord.Rows[iRowIndex].Cells[5].Value = oData.DISCOUNT_PERCENTAGE;
                //if (oData.DISCOUNT_PERCENTAGE != 0 || Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[6].Value) != 0)
                //{
                iDeductAmount = ((Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[3].Value) * Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[4].Value)) - Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[8].Value)) * (oData.DISCOUNT_PERCENTAGE / 100);
                //}
                dgRecord.Rows[iRowIndex].Cells[6].Value = iDeductAmount.ToString("n2");
                if (Convert.ToBoolean(dgRecord.Rows[iRowIndex].Cells[11].Value))
                {
                    dgRecord.Rows[iRowIndex].Cells[9].Value = ((Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[3].Value) * Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[4].Value)) - (Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[8].Value) + iDeductAmount)).ToString("n2");
                }
                else
                {
                    dgRecord.Rows[iRowIndex].Cells[9].Value = ((Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[3].Value) * Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[4].Value)) - iDeductAmount).ToString("n2");
                }
            }                        

            iTotalAmount = 0;
            iTotalNetSales = 0;
            iTotalDiscount = 0;
            iTotalVatAmount = 0;
            foreach (DataGridViewRow row in dgRecord.Rows)
            {
                iTotalAmount += (Convert.ToDouble(row.Cells[3].Value) * Convert.ToInt32(row.Cells[4].Value));
                iTotalVatAmount += Convert.ToDouble(row.Cells[8].Value);
                iTotalDiscount += Convert.ToDouble(row.Cells[6].Value);                
                iTotalNetSales += Convert.ToDouble(row.Cells[9].Value);
            }

            lblTotalAmount.Text = iTotalAmount.ToString("n2");  
            lblVat.Text = iTotalVatAmount.ToString("n2");                      
            lblDiscount.Text = iTotalDiscount.ToString("n2");
            lblTotalPayment.Text = iTotalNetSales.ToString("n2");
            if (dgRecord.Rows.Count > 0)
            {
                btnAddDiscount.Enabled = true;
                btnSettlePay.Enabled = true;
            }
            else
            {
                btnAddDiscount.Enabled = false;
                btnSettlePay.Enabled = false;
            }
           
        }

        public double GetPercentageAmount(double price, int qty,double percentage)
        { 
             return ((price * qty) * percentage) / 100;
        }

        private void btnSettlePay_Click(object sender, EventArgs e)
        {
            if (dgRecord.Rows.Count > 0)
            {
                iKeyPads.KeyPad okey = new iKeyPads.KeyPad(Convert.ToDouble(lblTotalPayment.Text));
                okey.ShowDialog();
                if (okey.IsTransactionSuccess)
                {
                    oStocks = new DataAccess.Stocks();
                    oTransaction = new DataAccess.Transaction();
                    foreach (DataGridViewRow row in dgRecord.Rows)
                    {
                        oMTransaction = new Model.Transaction();
                        oMTransaction.TRANSACTION_NO = lblTransNo.Text;
                        oMTransaction._Product.PRODUCT_CODE = row.Cells[1].Value.ToString();
                        oMTransaction._Product.PRICE = row.Cells[3].Value.ToString();
                        oMTransaction.QTY = Convert.ToInt32(row.Cells[4].Value);
                        oMTransaction.DISCOUNT_PERCENTAGE = Convert.ToDouble(row.Cells[5].Value);
                        oMTransaction.DISCOUNT = Convert.ToDouble(row.Cells[6].Value);
                        oMTransaction.VAT_PERCENTAGE =  Convert.ToDouble(row.Cells[7].Value);
                        oMTransaction.VAT = Convert.ToDouble(row.Cells[8].Value);
                        oMTransaction.TOTAL = Convert.ToDouble(row.Cells[9].Value);
                        oMTransaction.TRANSACTION_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                        oMTransaction.TRANSACT_BY = GlobalVariable.eVariable.sFullname;
                        oMTransaction.STATUS = "SOLD";

                        oTransaction.InsertSoldItems(oMTransaction);
                    
                    }

                    oFrmMsgbox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.TRANSACTION_COMPLETE);
                    oFrmMsgbox.StartPosition = FormStartPosition.CenterScreen;
                    oFrmMsgbox.ShowDialog();
                    ResetData();                    
                }
                else
                {
                    return;
                }
             
            }
            else
            {
                oFrmMsgbox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.SELECT_RECORD_FIRST);
                oFrmMsgbox.StartPosition = FormStartPosition.CenterScreen;
                oFrmMsgbox.ShowDialog();
            }
        }

        private void btnNewTrans_Click(object sender, EventArgs e)
        {
            oTransaction = new DataAccess.Transaction();
            lblTransNo.Text = oTransaction.GeTransactionAutoNo();
            lblTransDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            EDControls(false);
        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)                        
        {
            try
            {

                if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
                {

                    SelectedRecords(sender, e);

                    if (e.ColumnIndex == 4)
                    {

                        dgRecord.ReadOnly = false;
                        DataGridViewCell cell = dgRecord.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dgRecord.CurrentCell = cell;
                        dgRecord.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        dgRecord.BeginEdit(true);

                    }
                    AddMinusQuantity();

                    if (e.ColumnIndex == 14)
                    {
                        oFrmMsgbox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.YOU_WANT_TO_REMOVE);
                        oFrmMsgbox.StartPosition = FormStartPosition.CenterScreen;
                        oFrmMsgbox.MessageType = MessageBoxForm.MESSAGE_TYPE.QUERY;
                        oFrmMsgbox.ShowDialog();

                        if (oFrmMsgbox.sAnswer == "YES")
                        {
                            dgRecord.Rows.RemoveAt(e.RowIndex);
                        }                        
                    }
                    UpdateDataGridViewData(oMStocks);
                                                     
                    
                }
            }
            catch (Exception ex)
            { 
            
            }
        }


        private void AddMinusQuantity()
        {
            if (iColumnIndex == 13)
            {
                if ((oMStocks.QTY + 1) > oMStocks.STOCK_ON_HAND)
                {

                }
                else
                {
                    dgRecord.Rows[iRowIndex].Cells[4].Value = Convert.ToInt32(dgRecord.Rows[iRowIndex].Cells[4].Value) + 1;
                    oMStocks.QTY = Convert.ToInt32(dgRecord.Rows[iRowIndex].Cells[4].Value);
                    UpdateTotal();
                    
                }
                UpdateDataGridViewData(oMStocks);
            }
            if (iColumnIndex == 12)
            {
                if ((oMStocks.QTY - 1) <= 0)
                {

                }
                else
                {
                    dgRecord.Rows[iRowIndex].Cells[4].Value = Convert.ToInt32(dgRecord.Rows[iRowIndex].Cells[4].Value) - 1;
                    oMStocks.QTY = Convert.ToInt32(dgRecord.Rows[iRowIndex].Cells[4].Value);
                    UpdateTotal();
                }
                UpdateDataGridViewData(oMStocks);
            }        
        }

        private void UpdateTotal()
        {
            double iDeductAmount = 0;
            if (Convert.ToBoolean(dgRecord.Rows[iRowIndex].Cells[11].Value))
            {
                dgRecord.Rows[iRowIndex].Cells[8].Value = GetPercentageAmount(Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[3].Value), Convert.ToInt32(dgRecord.Rows[iRowIndex].Cells[4].Value), iVatPercentage).ToString("n2");
            }
            else
            {
                dgRecord.Rows[iRowIndex].Cells[8].Value = "0.00";
            }

            iVatAmount = Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[8].Value);
            if (Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[5].Value) != 0)
            {
                iDeductAmount = ((Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[3].Value) * Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[4].Value)) - iVatAmount) * (Convert.ToDouble(dgRecord.Rows[iRowIndex].Cells[5].Value) / 100);
            }
            dgRecord.Rows[iRowIndex].Cells[6].Value = iDeductAmount.ToString("n2");
        }

        private void AddMinus(string Action)
        {
            
            if (Action == "Right")
            {               
                if ((oMStocks.QTY + 1) > oMStocks.STOCK_ON_HAND)
                {

                }
                else
                {
                    dgRecord.Rows[iRowIndex].Cells[4].Value = Convert.ToInt32(dgRecord.Rows[iRowIndex].Cells[4].Value) + 1;
                    oMStocks.QTY = Convert.ToInt32(dgRecord.Rows[iRowIndex].Cells[4].Value);
                    UpdateTotal();
                }
                UpdateDataGridViewData(oMStocks);
                
            }

            if (Action == "Left")
            {               
                if ((oMStocks.QTY - 1) <= 0)
                {

                }
                else
                {
                    dgRecord.Rows[iRowIndex].Cells[4].Value = Convert.ToInt32(dgRecord.Rows[iRowIndex].Cells[4].Value) - 1;
                    oMStocks.QTY = Convert.ToInt32(dgRecord.Rows[iRowIndex].Cells[4].Value);
                    UpdateTotal();
                }
                UpdateDataGridViewData(oMStocks);
                
            }
        }
   
        private void ResetData()
        {                                    
            lblTransNo.Text = "#############";            
            lblTransDate.Text = "####-##-##";
            lblTotalAmount.Text = "0.00";
            lblTotalPayment.Text = "0.00";                       
            lblVat.Text = "0.00";
            lblDiscount.Text = "0.00";
            EDControls(true);
            dgRecord.Rows.Clear();
        }

        private void EDControls(bool bFlag)
        {
            btnNewTrans.Enabled = bFlag;
            btnDailySales.Enabled = bFlag;
            btnChangePass.Enabled = bFlag;
            btnLogout.Enabled = bFlag;

            btnSearchProd.Enabled = !bFlag;

            if (dgRecord.Rows.Count > 0)
            {
                btnAddDiscount.Enabled = !bFlag;
                btnSettlePay.Enabled = !bFlag;
            }           
            btnCancelTrans.Enabled = !bFlag;

        }

   

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecords(sender, e);
        }

        private void SelectedRecords(object sender, DataGridViewCellEventArgs e)
        {
            oMStocks = new Model.Stocks();
            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {

                iRowIndex = e.RowIndex;
                iColumnIndex = e.ColumnIndex;
                oMStocks._PRODUCT.PRODUCT_CODE = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMStocks._PRODUCT.PRICE = dgRecord.Rows[e.RowIndex].Cells[3].Value.ToString();                
                oMStocks.QTY = Convert.ToInt32(dgRecord.Rows[e.RowIndex].Cells[4].Value);
                oMStocks.DISCOUNT_PERCENTAGE = Convert.ToDouble(dgRecord.Rows[e.RowIndex].Cells[5].Value);
                oMStocks.DISCOUNT = Convert.ToDouble(dgRecord.Rows[e.RowIndex].Cells[6].Value);
                oMStocks.VAT_PERCENTAGE = Convert.ToDouble(dgRecord.Rows[e.RowIndex].Cells[7].Value);
                oMStocks.VAT_AMOUNT = Convert.ToDouble(dgRecord.Rows[e.RowIndex].Cells[8].Value);
                oMStocks.TOTAL = Convert.ToDouble(dgRecord.Rows[e.RowIndex].Cells[9].Value);
                oMStocks.STOCK_ON_HAND = Convert.ToInt32(dgRecord.Rows[e.RowIndex].Cells[10].Value);
                oMStocks._PRODUCT.VATABLE = Convert.ToBoolean(dgRecord.Rows[e.RowIndex].Cells[11].Value);
                
            }

        }

        private void dgRecord_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int iQuantity = 0;
            if  (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    iQuantity = Convert.ToInt32(dgRecord.Rows[e.RowIndex].Cells[4].Value);

                    if (iQuantity == 0)
                    {
                        dgRecord.Rows[e.RowIndex].Cells[4].Value = 1;
                    }

                    if (iQuantity > oMStocks.STOCK_ON_HAND)
                    {
                        oFrmMsgbox = new MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.QUANTY_IS_GREATER_THAN_ONHAND);
                        oFrmMsgbox.ShowDialog();
                        dgRecord.Rows[e.RowIndex].Cells[4].Value = 1;
                    }

                    if (oMStocks._PRODUCT.VATABLE)
                    {
                        iVatAmount = GetPercentageAmount(Convert.ToDouble(dgRecord.Rows[e.RowIndex].Cells[3].Value), Convert.ToInt32(dgRecord.Rows[e.RowIndex].Cells[4].Value), iVatPercentage);
                        dgRecord.Rows[e.RowIndex].Cells[8].Value = Convert.ToDouble(iVatAmount).ToString("n2");
                    }
                    
                    UpdateDataGridViewData(oMStocks);                
                }            
            }
        }

       

        private void lblSalesTotal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgRecord_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgRecord.Rows.Count > 0 && iRowIndex >= 0)
            {
                if (dgRecord.CurrentCell.ColumnIndex == 4)
                {
                    TextBox T = e.Control as TextBox;
                    if (T != null)
                    {
                        GlobalVariable.eVariable.ValidNumber(T);
                    }
                }
            }
        }

        private void btnDailySales_Click(object sender, EventArgs e)
        {
            Forms.frmDailySales oFrm = new Forms.frmDailySales();
            oFrm.ShowDialog();
        }

        void Form_Load(Form xForm)
        {
            xForm.TopLevel = false;

            foreach (Control item in pnlMain.Controls)
            {
                if (!item.Name.Contains("SubMenu"))
                {
                    pnlMain.Controls.Remove(item);
                    break;
                }
            }

            pnlMain.Controls.Add(xForm);
            xForm.Show();
        }

        private void dgRecord_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dgRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                AddMinus(e.KeyCode.ToString());  
            }
        }


        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.F1:
                    if (btnNewTrans.Enabled)
                    {
                        btnNewTrans_Click(sender, e);
                    }
                    break;
                case Keys.F2:
                    if (btnSearchProd.Enabled)
                    {
                        btnSearchProd_Click(sender, e);
                    }
                    break;
                case Keys.F3:
                    if (btnAddDiscount.Enabled)
                    {
                        btnAddDiscount_Click(sender, e);
                    }
                    break;
                case Keys.F4:
                    if (btnSettlePay.Enabled)
                    {
                        btnSettlePay_Click(sender, e);
                    }
                    break;
                case Keys.F5:
                    if (btnCancelTrans.Enabled)
                    {
                        btnCancelTrans_Click(sender, e);
                    }
                    
                    break;    
                case Keys.F6:
                    if (btnDailySales.Enabled)
                    {
                        btnDailySales_Click(sender, e);
                    }
                    break;
                case Keys.F7:
                    if (btnChangePass.Enabled)
                    {
                        btnChangePass_Click(sender, e);
                    }
                    break;
                case Keys.F8:
                    break;  
                case Keys.F9:
                    if (btnLogout.Enabled)
                    {
                        btnLogout_Click(sender, e);
                    }
                    break;
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            Forms.frmChangePass oFrm = new Forms.frmChangePass();
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelTrans_Click(object sender, EventArgs e)
        {
            ResetData();
            EDControls(true);
        }
                                 
    }
}
