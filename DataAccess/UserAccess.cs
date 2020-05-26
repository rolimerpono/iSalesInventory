using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlobalVariable;


namespace DataAccess
{
    public class UserAccess
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder ssb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetUserAccess(Model.Search oData)
        {
            try
            {
                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                string sQuery;

                switch (oData.RECORD_TYPE)
                {
                    case "USER ACCESS":
                        sQuery = "SELECT * FROM TBL_USERACCESS WHERE ROLE = '" + oData.RECORD_SEARCH + "'";
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

        public void InsertUserAccess(Model.UserAccess oData)
        {
            try
            {

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                ddq.CommandText = "INSERT INTO TBL_USERACCESS VALUES ('" + oData.SALES + "','" + oData.PRODUCT + "','" + oData.VENDOR + "','" + oData.STOCK + "','" + oData.CATEGORY + "','" + oData.BRAND + "','" + oData.RECORDS + "','" + oData.SYSTEM_SETTINGS + "','" + oData.USER_SETTINGS + "','" + oData.ROLE + "')";
                
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateUserAccess(Model.UserAccess oData)
        {
            try
            {

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                ddq.CommandText = "UPDATE TBL_USERACCESS SET SALES = '" + oData.SALES + "', PRODUCT = '" + oData.PRODUCT + "', VENDOR = '" + oData.VENDOR + "',STOCK = '" + oData.STOCK + "', CATEGORY = '" + oData.CATEGORY + "', BRAND = '" + oData.BRAND + "',RECORDS = '" + oData.RECORDS + "', SYSTEM_SETTINGS = '" + oData.SYSTEM_SETTINGS + "', USER_SETTINGS = '" + oData.USER_SETTINGS + "' WHERE ROLE = '" + oData.ROLE + "'";
               
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool IsRecordExists(Model.Search oData)
        {
            try
            {
                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                ddq.CommandText = "SELECT * FROM TBL_USERACCESS WHERE ROLE = '" + oData.RECORD_SEARCH + "' ";

                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return true;
            }
        
        }

    }
}
