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
    public partial class frmRecords : Form
    {

        DataAccess.Stocks oStocks;
        Model.Search oMSearch;

        public frmRecords()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLockStockHistory_Click(object sender, EventArgs e)
        {
            LoadStockHistory();
        }
    
        private void LoadInventoryList()
        {

            oStocks = new DataAccess.Stocks();
            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "INVENTORY LIST";
            dgInventoryList.Rows.Clear();
            foreach (DataRow row in oStocks.GetRecords(oMSearch).Rows)
            {
                dgInventoryList.Rows.Add((dgInventoryList.Rows.Count + 1).ToString(), row["PRODUCT_CODE"], row["BAR_CODE"], row["DESCRIPTION"], row["BRAND"], row["CATEGORY"], row["PRICE"], row["REORDER_LEVEL"], row["QTY"]);
            }
        }

        private void LoadSoldItems()
        {

            oStocks = new DataAccess.Stocks();
            oMSearch = new Model.Search();
            oMSearch.DATE_FROM = dtSoldFrom.Value.ToString("yyyy-MM-dd");
            oMSearch.DATE_TO = dtSoldTo.Value.ToString("yyyy-MM-dd");
            oMSearch.RECORD_TYPE = "SOLD ITEMS";
            oMSearch.STATUS = "SOLD";
            dgSoldItems.Rows.Clear();
            foreach (DataRow row in oStocks.GetRecords(oMSearch).Rows)
            {
                dgSoldItems.Rows.Add((dgSoldItems.Rows.Count + 1).ToString(), row["TRANSACTION_NO"], row["PRODUCT_CODE"],  row["DESCRIPTION"],  row["PRICE"],row["QTY"],row["DISCOUNT"],row["VAT"], row["TOTAL_SALES"]);
            }
        }

        private void LoadTopSelling()
        {

            oStocks = new DataAccess.Stocks();
            oMSearch = new Model.Search();
            oMSearch.DATE_FROM = dtTopFrom.Value.ToString("yyyy-MM-dd");
            oMSearch.DATE_TO = dtTopTo.Value.ToString("yyyy-MM-dd");
            oMSearch.RECORD_TYPE = "TOP SELLING";
            oMSearch.STATUS = "SOLD";
            dgTopSelling.Rows.Clear();
            foreach (DataRow row in oStocks.GetRecords(oMSearch).Rows)
            {
                dgTopSelling.Rows.Add((dgTopSelling.Rows.Count + 1).ToString(), row["PRODUCT_CODE"], row["DESCRIPTION"],  row["QTY"], row["TOTAL_SALES"]);
            }
        }

        private void LoadCancelledOrder()
        {

            oStocks = new DataAccess.Stocks();
            oMSearch = new Model.Search();
            oMSearch.DATE_FROM = dtCancelFrom.Value.ToString("yyyy-MM-dd");
            oMSearch.DATE_TO = dtCancelTo.Value.ToString("yyyy-MM-dd");
            oMSearch.RECORD_TYPE = "CANCELLED ORDER";
            dgCancelledOrder.Rows.Clear();
            foreach (DataRow row in oStocks.GetRecords(oMSearch).Rows)
            {
                dgCancelledOrder.Rows.Add((dgCancelledOrder.Rows.Count + 1).ToString(), row["TRANSACTION_NO"], row["PRODUCT_CODE"], row["DESCRIPTION"], row["PRICE"], row["QTY"],row["DISCOUNT"],row["VAT"], row["TOTAL"],row["TRANSACTION_DATE"],row["TRANSACT_BY"],row["VOID_BY"],row["REASON"],row["ACTION"]);
            }
        }

        private void LoadCriticalStocks()
        {

            oStocks = new DataAccess.Stocks();
            oMSearch = new Model.Search();            
            oMSearch.RECORD_TYPE = "CRITICAL STOCKS";
            dgCriticalStocks.Rows.Clear();
            foreach (DataRow row in oStocks.GetRecords(oMSearch).Rows)
            {
                dgCriticalStocks.Rows.Add((dgCriticalStocks.Rows.Count + 1).ToString(), row["PRODUCT_CODE"], row["DESCRIPTION"], row["BRAND"], row["CATEGORY"], row["PRICE"], row["REORDER_LEVEL"], row["QTY"]);
            }
        }

        private void LoadStockHistory()
        {

            oStocks = new DataAccess.Stocks();
            oMSearch = new Model.Search();
            oMSearch.DATE_FROM = dtHistoryFrom.Value.ToString("yyyy-MM-dd");
            oMSearch.DATE_TO = dtHistoryTo.Value.ToString("yyyy-MM-dd");
            oMSearch.RECORD_TYPE = "STOCK HISTORY";
            oMSearch.STATUS = rdMovingIn.Checked == true ? "IN" : "OUT";
            dgStockHistory.Rows.Clear();
            foreach (DataRow row in oStocks.GetRecords(oMSearch).Rows)
            {
                dgStockHistory.Rows.Add((dgStockHistory.Rows.Count + 1).ToString(), row["REFERRENCE_NO"], row["PRODUCT_CODE"], row["DESCRIPTION"], row["QTY"],  row["TRANSACTION_DATE"], row["TRANSACT_BY"],row["REMARKS"],row["STATUS"]);
            }
        }

        private void tbRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void frmRecords_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            LoadInventoryList();
        }

        private void btnSoldItems_Click(object sender, EventArgs e)
        {
            LoadSoldItems();
        }

        private void btnTopSelling_Click(object sender, EventArgs e)
        {
            LoadTopSelling();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            LoadCancelledOrder();
        }

        private void btnCriticalStocks_Click(object sender, EventArgs e)
        {
            LoadCriticalStocks();
        }

      

       
    }
}
