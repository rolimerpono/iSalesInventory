using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using GlobalVariable;

namespace DataAccess
{
    public class User
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public OleDbConnectionStringBuilder osb = new OleDbConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetUser(Model.Search oData)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                string sQuery;

                switch (oData.RECORD_TYPE)
                {
                    case "FIRST NAME":
                        sQuery = "SELECT * FROM TBL_USER WHERE FIRST_NAME LIKE '%" + oData.RECORD_SEARCH + "%'";
                        break;
                    case "MIDDLE NAME":
                        sQuery = "SELECT * FROM TBL_USER WHERE MIDDLE_NAME LIKE '%" + oData.RECORD_SEARCH + "%'";
                        break;
                    case "LAST NAME":
                        sQuery = "SELECT * FROM TBL_USER WHERE LAST_NAME LIKE '%" + oData.RECORD_SEARCH + "%'";
                        break;
                    case "USERNAME":
                        sQuery = "SELECT * FROM TBL_USER WHERE USERNAME = '" + oData.RECORD_SEARCH + "'";
                        break;
                    default:
                        sQuery = "SELECT * FROM TBL_USER WHERE FIRST_NAME LIKE '%" + oData.RECORD_SEARCH + "%'";
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
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "SELECT * FROM TBL_USER WHERE USERNAME = '" + oData.RECORD_SEARCH + "'";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        

        public void InsertUser(Model.User oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "INSERT INTO TBL_USER VALUES ('" + oData.FIRST_NAME + "','" + oData.MIDDLE_NAME + "','" + oData.LAST_NAME + "','" + oData.CONTACT_NO + "','" + oData.USERNAME + "','" + oData.PASSWORD + "','" + oData.ROLE + "','" + oData.STATUS + "' , '" + oData.ALLOWED_VOID + "')";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public Boolean IsUserRoleExists(Model.Search oData)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "Select * from tbl_UserAccess where Role = '" + oData.RECORD_SEARCH + "'";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public void UpdateUser(Model.User oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "UPDATE TBL_USER SET FIRST_NAME = '" + oData.FIRST_NAME + "', MIDDLE_NAME = '" + oData.MIDDLE_NAME + "', LAST_NAME = '" + oData.LAST_NAME + "', CONTACT_NO = '" + oData.CONTACT_NO + "',PASSWORD = '" + oData.PASSWORD + "',ROLE = '" + oData.ROLE + "',[STATUS] ='" + oData.STATUS + "' ,ALLOW_VOID = '" + oData.ALLOWED_VOID + "' WHERE USERNAME = '" + oData.USERNAME +"'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ChangePassword(Model.User oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "UPDATE TBL_USER SET PASSWORD = '" + oData.PASSWORD + "' WHERE USERNAME = '" + oData.USERNAME + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean IsLogin(Model.User oData)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "SELECT * FROM TBL_USER WHERE USERNAME = '" + oData.USERNAME + "' AND PASSWORD = '" + oData.PASSWORD + "'";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        

    }
}
