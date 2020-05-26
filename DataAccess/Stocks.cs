using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalVariable;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace DataAccess
{
    public class Stocks
    {
        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder ssb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetStock(Model.Search oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                switch (oData.RECORD_TYPE)
                {

                    case "DESCRIPTION":
                        sQuery =  " SELECT P.PRODUCT_CODE,P.BAR_CODE,P.[DESCRIPTION],B.ID AS BRAND_ID, B.BRAND,C.ID AS CATEGORY_ID,C.CATEGORY,P.PRICE,   " +
		                          " ISNULL((SELECT SUM(QTY) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND STATUS = 'OUT')   " +
		                          " FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND [STATUS] ='IN' ) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_SOLDITEMS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND [STATUS] = 'SOLD'),0) [QTY],   " +
                                  " P.IS_VATABLE " +
                                  " FROM TBL_PRODUCT P INNER JOIN TBL_BRAND B ON B.ID = P.BRAND_ID  " +
                                  " INNER JOIN TBL_CATEGORY C ON C.ID = P.CATEGORY_ID  " +
                                  " WHERE P.DESCRIPTION LIKE '%" + oData.RECORD_SEARCH +"%' ";
                        break;

                    case "BRAND":
                        sQuery = " SELECT P.PRODUCT_CODE,P.BAR_CODE,P.[DESCRIPTION],B.ID AS BRAND_ID, B.BRAND,C.ID AS CATEGORY_ID,C.CATEGORY,P.PRICE,   " +
                                  " ISNULL((SELECT SUM(QTY) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND STATUS = 'OUT')   " +
                                  " FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND [STATUS] ='IN' ) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_SOLDITEMS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND [STATUS] = 'SOLD'),0) [QTY],   " +
                                  " P.IS_VATABLE " +
                                  " FROM TBL_PRODUCT P INNER JOIN TBL_BRAND B ON B.ID = P.BRAND_ID  " +
                                  " INNER JOIN TBL_CATEGORY C ON C.ID = P.CATEGORY_ID  " +
                                  " WHERE B.BRAND LIKE '%" + oData.RECORD_SEARCH + "%' ";

                        break;

                    case "CATEGORY":
                        sQuery =  " SELECT P.PRODUCT_CODE,P.BAR_CODE,P.[DESCRIPTION],B.ID AS BRAND_ID, B.BRAND,C.ID AS CATEGORY_ID,C.CATEGORY,P.PRICE,   " +
                                  " ISNULL((SELECT SUM(QTY) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND STATUS = 'OUT')   " +
                                  " FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND [STATUS] ='IN' ) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_SOLDITEMS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND [STATUS] = 'SOLD'),0) [QTY],   " +
                                  " P.IS_VATABLE " +
                                  " FROM TBL_PRODUCT P INNER JOIN TBL_BRAND B ON B.ID = P.BRAND_ID  " +
                                  " INNER JOIN TBL_CATEGORY C ON C.ID = P.CATEGORY_ID  " +
                                  " WHERE C.CATEGORY LIKE '%" + oData.RECORD_SEARCH + "%' ";

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

                    case "INVENTORY LIST": //ok
                        sQuery =  " SELECT P.PRODUCT_CODE,P.BAR_CODE,P.[DESCRIPTION],B.ID AS BRAND_ID, B.BRAND,C.ID AS CATEGORY_ID,C.CATEGORY,P.PRICE ,P.REORDER_LEVEL,   " +
                                  " ISNULL((SELECT SUM(QTY) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND STATUS = 'OUT')   " +
                                  " FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND [STATUS] ='IN' ) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_SOLDITEMS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND [STATUS] = 'SOLD'),0) [QTY]   " +
                                  " FROM TBL_PRODUCT P INNER JOIN TBL_BRAND B ON B.ID = P.BRAND_ID  " +
                                  " INNER JOIN TBL_CATEGORY C ON C.ID = P.CATEGORY_ID  " ;                     
                        break;  

                    case "SOLD ITEMS": //ok
                        sQuery = " SELECT S.TRANSACTION_NO,S.PRODUCT_CODE, P.[DESCRIPTION],S.PRICE ,S.QTY,CASE WHEN S.DISCOUNT IS NULL THEN 0 ELSE S.DISCOUNT END DISCOUNT,ISNULL(S.VAT,0) VAT, (S.PRICE * S.QTY) - CASE WHEN S.DISCOUNT IS NULL THEN  0 ELSE S.DISCOUNT END AS TOTAL_SALES " +
                                 " FROM TBL_SOLDITEMS S INNER JOIN TBL_PRODUCT P " +
                                 " ON S.PRODUCT_CODE = P.PRODUCT_CODE " +
                                 " WHERE S.TRANSACTION_DATE BETWEEN '" + oData.DATE_FROM + "' AND '" + oData.DATE_TO + "' AND [STATUS] = 'SOLD' ";
                        break; 

                    case "TOP SELLING"://ok
                        sQuery = " SELECT TOP 10 S.PRODUCT_CODE, P.[DESCRIPTION], SUM(S.QTY) QTY , SUM(S.TOTAL) TOTAL_SALES   " +
                                 " FROM TBL_SOLDITEMS S INNER JOIN TBL_PRODUCT P  " +
                                 " ON S.PRODUCT_CODE = P.PRODUCT_CODE  " +
                                 " WHERE S.TRANSACTION_DATE BETWEEN '" + oData.DATE_FROM + "' AND '" + oData.DATE_TO + "' AND [STATUS] = 'SOLD' " +
                                 " GROUP BY S.PRODUCT_CODE, P.[DESCRIPTION] " +
                                 " ORDER BY SUM(S.TOTAL) DESC ";
                        break; 

                    case "CANCELLED ORDER":
                        sQuery = " SELECT C.TRANSACTION_NO,P.PRODUCT_CODE,P.[DESCRIPTION],C.PRICE,C.QTY,C.DISCOUNT,C.VAT,C.TOTAL, " +
                                 " C.TRANSACTION_DATE,C.TRANSACT_BY,C.VOID_BY,C.REASON,C.[ACTION] " +
                                 " FROM TBL_CANCELLEDORDER C INNER JOIN TBL_PRODUCT P ON C.PRODUCT_CODE = P.PRODUCT_CODE " +
                                 " WHERE C.TRANSACTION_DATE BETWEEN '" + oData.DATE_FROM + "' AND '" + oData.DATE_TO + "' ";
                        break; 

                    case "CRITICAL STOCKS"://OK

                        sQuery =  " SELECT P.PRODUCT_CODE,P.[DESCRIPTION], B.BRAND,C.CATEGORY,P.PRICE ,P.REORDER_LEVEL,   " +
                                  " ISNULL((SELECT SUM(QTY) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND STATUS = 'OUT')   " +
                                  " FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND [STATUS] ='IN' ) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_SOLDITEMS WHERE PRODUCT_CODE = P.PRODUCT_CODE),0) [QTY]   " +
                                  " FROM TBL_PRODUCT P INNER JOIN TBL_BRAND B ON B.ID = P.BRAND_ID  " +
                                  " INNER JOIN TBL_CATEGORY C ON C.ID = P.CATEGORY_ID  " +
                                  " WHERE ISNULL((SELECT SUM(QTY) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND STATUS = 'OUT')   " +
                                  " FROM TBL_STOCKS WHERE PRODUCT_CODE = P.PRODUCT_CODE AND [STATUS] ='IN' ) - (SELECT ISNULL(SUM(QTY),0) FROM TBL_SOLDITEMS WHERE PRODUCT_CODE = P.PRODUCT_CODE),0) <= P.REORDER_LEVEL ";                                                                   
                                 
                    break; 
                    case "STOCK HISTORY"://ok
                    sQuery = " SELECT S.REFERRENCE_NO,S.PRODUCT_CODE,P.[DESCRIPTION],S.QTY ,S.TRANSACTION_DATE,S.TRANSACT_BY,S.REMARKS,S.[STATUS] " +
                             " FROM TBL_STOCKS S INNER JOIN TBL_PRODUCT P  " +
                             " ON S.PRODUCT_CODE = P.PRODUCT_CODE " +
                             " WHERE S.TRANSACTION_DATE BETWEEN '" + oData.DATE_FROM + "' AND '" + oData.DATE_TO + "' " +
                             " AND STATUS = '" + oData.STATUS +"' ";

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
  

        public void InsertStock(Model.Stocks oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "INSERT INTO TBL_STOCKS VALUES ('" + oData.REFERENCE_NO + "', '" + oData._PRODUCT.PRODUCT_CODE + "','" + oData.QTY + "','" + oData.STOCK_DATE + "','" + oData.STOCK_BY + "','" + oData._VENDOR.ID + "','" + oData.REMARKS + "','" + oData.STATUS + "')";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateStock(Model.Product oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "UPDATE TBL_PRODUCT SET BAR_CODE = '" + oData.BAR_CODE + "', DESCRIPTION = '" + oData.DESCRIPTION + "',BRAND_ID = '" + oData._BRAND.ID + "', CATEGORY_ID = '" + oData._CATEGORY.ID + "' WHERE PRODUCT_CODE = '" + oData.PRODUCT_CODE + "'";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private int GetReferrenceNo()
        {
            ssb.ConnectionString = sConnectionString;
            ddq = new DatabaseQuery.DBQuery();
            ddq.ConnectionString = ssb.ConnectionString;


            ddq.CommandText = "SELECT TOP 1 REFERRENCE_NO FROM TBL_STOCKS ORDER BY REFERRENCE_NO DESC";
            ds = ddq.GetDataset(CommandType.Text);

            return ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(Regex.Replace(ds.Tables[0].Rows[0][0].ToString(), "[^0-9]", "")) : 0;
        }

        public string GetRefferenceAutoNo()
        {
            int iNo = 0;
            iNo = GetReferrenceNo() + 1;
            return "REF-" + iNo.ToString("00000000#");
        }


    }
}
