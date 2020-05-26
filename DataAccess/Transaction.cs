using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlobalVariable;
using System.Text.RegularExpressions;

namespace DataAccess
{
    public class Transaction
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder ssb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetRecords(Model.Search oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                switch (oData.RECORD_TYPE)
                {

                    case "SOLD ITEMS":

                        sQuery = " SELECT S.TRANSACTION_NO, S.PRODUCT_CODE,P.[DESCRIPTION],S.PRICE,S.QTY,S.DISCOUNT_PERCENTAGE,S.DISCOUNT,S.VAT_PERCENTAGE,S.VAT,S.TOTAL " +
                                 " FROM TBL_SOLDITEMS S INNER JOIN TBL_PRODUCT P ON S.PRODUCT_CODE = P.PRODUCT_CODE " +
                                 " WHERE [STATUS] = '" + oData.STATUS + "' " +
                                 " AND TRANSACTION_DATE BETWEEN '" + oData.DATE_FROM + "' AND '" + oData.DATE_TO + "' ";

                        break;

                    default:
                        return null;

                }

                ddq.CommandText = sQuery;

                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertSoldItems(Model.Transaction oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "INSERT INTO TBL_SOLDITEMS VALUES ('" + oData.TRANSACTION_NO + "', '" + oData._Product.PRODUCT_CODE + "','" + oData._Product.PRICE + "','" + oData.QTY + "','" + oData.DISCOUNT_PERCENTAGE + "','" + oData.DISCOUNT + "','" + oData.VAT_PERCENTAGE + "','" + oData.VAT + "','" + oData.TOTAL + "','" + oData.TRANSACTION_DATE + "','" + oData.TRANSACT_BY + "','" + oData.STATUS + "')";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertCancelledItems(Model.Transaction oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "INSERT INTO TBL_CANCELLEDORDER VALUES ('" + oData.TRANSACTION_NO + "', '" + oData._Product.PRODUCT_CODE + "','" + oData._Product.PRICE + "','" + oData.QTY + "','" + oData.DISCOUNT_PERCENTAGE + "', '" + oData.DISCOUNT + "','" + oData.VAT_PERCENTAGE + "','" + oData.VAT + "','" + oData.TOTAL + "','" + oData.TRANSACTION_DATE + "','" + oData.TRANSACT_BY + "','" + oData.VOID_BY + "','" + oData.REASON + "','" + oData.STATUS + "')";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateSoldItems(Model.Transaction oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "UPDATE TBL_SOLDITEMS SET STATUS = '" + oData.STATUS + "', QTY = '" + oData.QTY + "',DISCOUNT = '" + oData.DISCOUNT + "',VAT = '" + oData.VAT + "',TOTAL = '" + oData.TOTAL + "' WHERE TRANSACTION_NO = '" + oData.TRANSACTION_NO + "' AND PRODUCT_CODE = '" + oData._Product.PRODUCT_CODE + "' ";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateSoldItemStatus(Model.Transaction oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "UPDATE TBL_SOLDITEMS SET STATUS = '" + oData.STATUS + "' WHERE TRANSACTION_NO = '" + oData.TRANSACTION_NO + "' AND PRODUCT_CODE = '" + oData._Product.PRODUCT_CODE + "' ";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSoldItems(Model.Transaction oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "DELETE FROM TBL_SOLDITEMS WHERE TRANSACTION_NO = '" + oData.TRANSACTION_NO + "' AND PRODUCT_CODE = '" + oData._Product.PRODUCT_CODE + "' ";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void UpdateStocks(Model.Transaction oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "UPDATE TBL_STOCKS SET QTY = '" + oData.QTY + "',MODIFIED_DATE = '" + oData.MODIFIED_DATE + "', MODIFIED_BY = '" + oData.MODIFIED_BY + "' WHERE PRODUCT_CODE = '" + oData._Product.PRODUCT_CODE + "'";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private int GetTransactionNo()
        {
            ssb.ConnectionString = sConnectionString;
            ddq = new DatabaseQuery.DBQuery();
            ddq.ConnectionString = ssb.ConnectionString;


            ddq.CommandText = "SELECT TOP 1 SUBSTRING(TRANSACTION_NO,9,8) FROM TBL_SOLDITEMS ORDER BY TRANSACTION_NO DESC";
            ds = ddq.GetDataset(CommandType.Text);

            return ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(Regex.Replace(ds.Tables[0].Rows[0][0].ToString(), "[^0-9]", "")) : 0;
        }

        public string GeTransactionAutoNo()
        {
            int iNo = 0;
            iNo = GetTransactionNo() + 1;
            return DateTime.Now.ToString("yyyy-MM-dd").Replace("-","") + iNo.ToString("0000000#");
        }

        public string GetRandomNumber()
        {
            CommonFunction.CommonFunction oFunction = new CommonFunction.CommonFunction();
            return oFunction.GetRandomString(3);            
        }

    }
}
