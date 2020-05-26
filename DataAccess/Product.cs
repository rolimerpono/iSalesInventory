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
    public class Product
    {


        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder ssb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetProduct(Model.Search oData)
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
                        sQuery = " SELECT P.PRODUCT_CODE,P.BAR_CODE,P.DESCRIPTION,B.ID AS BRAND_ID, B.BRAND,C.ID AS CATEGORY_ID,C.CATEGORY,P.PRICE, P.REORDER_LEVEL,P.IS_VATABLE FROM TBL_PRODUCT P " +
                                 " INNER JOIN TBL_BRAND B ON B.ID = P.BRAND_ID " +
                                 " INNER JOIN TBL_CATEGORY C ON C.ID = P.CATEGORY_ID " +
                                 " WHERE P.DESCRIPTION LIKE '%" + oData.RECORD_SEARCH + "%'";
                        break;

                    case "BRAND":
                        sQuery = " SELECT P.PRODUCT_CODE,P.BAR_CODE,P.DESCRIPTION,B.ID AS BRAND_ID, B.BRAND,C.ID AS CATEGORY_ID ,C.CATEGORY,P.PRICE, P.REORDER_LEVEL, P.IS_VATABLE FROM TBL_PRODUCT P " +
                                 " INNER JOIN TBL_BRAND B ON B.ID = P.BRAND_ID " +
                                 " INNER JOIN TBL_CATEGORY C ON C.ID = P.CATEGORY_ID " +
                                 " WHERE B.BRAND LIKE '%" + oData.RECORD_SEARCH + "%'";
                        break;

                    case "CATEGORY":
                         sQuery =   " SELECT P.PRODUCT_CODE,P.BAR_CODE,P.DESCRIPTION,B.ID AS BRAND_ID, B.BRAND,C.ID AS CATEGORY_ID,C.CATEGORY,P.PRICE, P.REORDER_LEVEL, P.IS_VATABLE FROM TBL_PRODUCT P " +
                                    " INNER JOIN TBL_BRAND B ON B.ID = P.BRAND_ID " +
                                    " INNER JOIN TBL_CATEGORY C ON C.ID = P.CATEGORY_ID " +
                                    " WHERE C.CATEGORY LIKE '%" + oData.RECORD_SEARCH + "%'";
                        break;

                    default:
                        sQuery = " SELECT P.PRODUCT_CODE,P.BAR_CODE,P.DESCRIPTION,B.ID, B.BRAND,C.ID,C.CATEGORY,P.PRICE, P.REORDER_LEVEL,P.IS_VATABLE FROM TBL_PRODUCT P " +
                                 " INNER JOIN TBL_BRAND B ON B.ID = P.BRAND_ID " +
                                 " INNER JOIN TBL_CATEGORY C ON C.ID = P.CATEGORY_ID ";
                        break;

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

        public Boolean IsRecordExists(Model.Search oData)
        {
            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                switch (oData.RECORD_TYPE)
                {
                    case "PCODE":
                        sQuery = "SELECT * FROM TBL_PRODUCT WHERE PRODUCT_CODE = '" + oData.RECORD_SEARCH + "'";
                        break;
                    case "DESCRIPTION":
                        sQuery = "SELECT * FROM TBL_PRODUCT WHERE DESCRIPTION = '" + oData.RECORD_SEARCH + "'";
                        break;
                    default:
                        sQuery = "SELECT * FROM TBL_PRODUCT WHERE DESCRIPTION = '" + oData.RECORD_SEARCH + "'";
                        break;


                }

                ddq.CommandText = sQuery;

                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public void InsertProduct(Model.Product oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "INSERT INTO TBL_PRODUCT VALUES ('" + oData.PRODUCT_CODE + "', '" + oData.BAR_CODE + "','" + oData.DESCRIPTION + "','" + oData._BRAND.ID + "','" + oData._CATEGORY.ID + "','" + oData.PRICE + "','" + oData.REORDER_LEVEL + "','" + oData.VATABLE + "')";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateProduct(Model.Product oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "UPDATE TBL_PRODUCT SET IS_VATABLE = '" + oData.VATABLE + "', PRICE= '" + oData.PRICE + "', BAR_CODE = '" + oData.BAR_CODE + "', DESCRIPTION = '" + oData.DESCRIPTION + "',BRAND_ID = '" + oData._BRAND.ID + "', CATEGORY_ID = '" + oData._CATEGORY.ID + "',REORDER_LEVEL = '" + oData.REORDER_LEVEL + "' WHERE PRODUCT_CODE = '" + oData.PRODUCT_CODE + "'";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private int GetProductNo()
        {
            ssb.ConnectionString = sConnectionString;
            ddq = new DatabaseQuery.DBQuery();
            ddq.ConnectionString = ssb.ConnectionString;


            ddq.CommandText = "SELECT TOP 1 ID FROM TBL_PRODUCT ORDER BY ID DESC";
            ds = ddq.GetDataset(CommandType.Text);

            return ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(Regex.Replace(ds.Tables[0].Rows[0][0].ToString(), "[^0-9]", "")) : 0;
        }

        public string GetProductAutoNo()
        {
            int iNo = 0;
            iNo = GetProductNo() + 1;
            return "PCD-" + iNo.ToString("00000000#");
        }

    }
}
