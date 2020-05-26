using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlobalVariable;

namespace DataAccess
{
    public class Brand
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder ssb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetBrand(Model.Search oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                switch (oData.RECORD_TYPE)
                {
                    case "ID":
                        sQuery = "SELECT * FROM TBL_BRAND WHERE ID LIKE '%" + oData.RECORD_SEARCH + "%' AND STATUS = '" + oData.STATUS + "'";
                        break;
                    case "BRAND":
                        sQuery = "SELECT * FROM TBL_BRAND WHERE BRAND LIKE '%" + oData.RECORD_SEARCH + "%' AND STATUS = '" + oData.STATUS + "'";
                        break;
                    default:
                        sQuery = "SELECT * FROM TBL_BRAND WHERE BRAND LIKE '%" + oData.RECORD_SEARCH + "%' AND STATUS = '" + "ACTIVE" + "'";
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
                    case "ID":
                        sQuery = "SELECT * FROM TBL_BRAND WHERE ID = '" + oData.RECORD_SEARCH + "' AND STATUS = '" + oData.STATUS + "'";
                        break;
                    case "BRAND":
                        sQuery = "SELECT * FROM TBL_BRAND WHERE BRAND = '" + oData.RECORD_SEARCH + "' AND STATUS = '" + oData.STATUS + "'";
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

        public void InsertBrand(Model.Brand oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "INSERT INTO TBL_BRAND VALUES ('" + oData.BRAND + "', '" + oData.STATUS + "')";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateBrand(Model.Brand oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "UPDATE TBL_BRAND SET BRAND = '" + oData.BRAND + "', STATUS = '" + oData.STATUS + "' WHERE ID = '" + oData.ID + "'";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
