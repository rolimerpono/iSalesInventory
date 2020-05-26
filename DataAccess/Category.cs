using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlobalVariable;

namespace DataAccess
{
    public class Category
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder ssb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetCategory(Model.Search oData)
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
                        sQuery = "SELECT * FROM TBL_CATEGORY WHERE ID LIKE '%" + oData.RECORD_SEARCH + "%' AND STATUS = '" + oData.STATUS + "'";
                        break;
                    case "CATEGORY":
                        sQuery = "SELECT * FROM TBL_CATEGORY WHERE CATEGORY LIKE '%" + oData.RECORD_SEARCH + "%' AND STATUS = '" + oData.STATUS + "'";
                        break;
                    default:
                        sQuery = "SELECT * FROM TBL_CATEGORY WHERE CATEGORY LIKE '%" + oData.RECORD_SEARCH + "%' AND STATUS = '" + "ACTIVE" + "'";
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
                        sQuery = "SELECT * FROM TBL_CATEGORY WHERE ID = '" + oData.RECORD_SEARCH + "' AND STATUS = '" + oData.STATUS + "'";
                        break;
                    case "CATEGORY":
                        sQuery = "SELECT * FROM TBL_CATEGORY WHERE CATEGORY = '" + oData.RECORD_SEARCH + "' AND STATUS = '" + oData.STATUS + "'";
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

        public void InsertCategory(Model.Category oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "INSERT INTO TBL_CATEGORY VALUES ('" + oData.CATEGORY + "', '" + oData.STATUS + "')";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateCategory(Model.Category oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "UPDATE TBL_CATEGORY SET CATEGORY = '" + oData.CATEGORY + "', STATUS = '" + oData.STATUS + "' WHERE ID = '" + oData.ID + "'";
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
