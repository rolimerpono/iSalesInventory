using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlobalVariable;

namespace DataAccess
{
    public class Role
    {
        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetRole(Model.Search oData)
        {
            try
            {
                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                string sQuery = "";

                switch (oData.RECORD_TYPE)
                {
                    case "ID":
                        sQuery = "SELECT * FROM TBL_ROLE WHERE ID LIKE '%" + oData.RECORD_SEARCH + "%'";
                        break;

                    case "ROLE":
                        sQuery = "SELECT * FROM TBL_ROLE WHERE ROLE LIKE '%" + oData.RECORD_SEARCH + "%'";
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

        public Boolean IsRecordExists(Model.Search oData)
        {

            try
            {
                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                string sQuery = "";


                sQuery = "SELECT * FROM TBL_ROLE WHERE ROLE = '" + oData.RECORD_SEARCH + "'";

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return true;
            }

        }


        public void InsertRole(Model.Role oData)
        {
            try
            {

                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                ddq.CommandText = "INSERT INTO TBL_ROLE (ROLE,STATUS) VALUES ('" + oData.ROLE + "','" + oData.STATUS + "')";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateRole(Model.Role oData)
        {
            try
            {

                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                ddq.CommandText = "UPDATE TBL_ROLE SET ROLE = '" + oData.ROLE + "', STATUS = '" + oData.STATUS + "' WHERE [ID] = '" + oData.ID + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
