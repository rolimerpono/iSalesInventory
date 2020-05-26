using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalVariable;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class Vendor
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder ssb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetVendor(Model.Search oData)
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
                        sQuery = "SELECT * FROM TBL_VENDOR WHERE ID LIKE '%" + oData.RECORD_SEARCH + "%' AND STATUS = '" + oData.STATUS + "'";
                        break;
                    case "VENDOR":
                        sQuery = "SELECT * FROM TBL_VENDOR WHERE VENDOR LIKE '%" + oData.RECORD_SEARCH + "%' AND STATUS = '" + oData.STATUS + "'";
                        break;
                    default:
                        sQuery = "SELECT * FROM TBL_VENDOR WHERE VENDOR LIKE '%" + oData.RECORD_SEARCH + "%' AND STATUS = '" + "ACTIVE" + "'";
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
                        sQuery = "SELECT * FROM TBL_VENDOR WHERE ID = '" + oData.RECORD_SEARCH + "' AND STATUS = '" + oData.STATUS + "'";
                        break;
                    case "VENDOR":
                        sQuery = "SELECT * FROM TBL_VENDOR WHERE VENDOR = '" + oData.RECORD_SEARCH + "' AND STATUS = '" + oData.STATUS + "'";
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

        public void InserVendor(Model.Vendor oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "INSERT INTO TBL_VENDOR VALUES ('" + oData.VENDOR + "', '" + oData.ADDRESS + "','" + oData.CONTACT_PERSON + "','" + oData.TELEPHONE_NUMBER + "','" + oData.EMAIL + "','" + oData.PHONE_NO + "','" + oData.FAX_NO + "','" + oData.STATUS + "')";
                ddq.CommandText = sQuery;
                ddq.ExecuteNonQuery(CommandType.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public void UpdateVendor(Model.Vendor oData)
        {

            try
            {
                string sQuery = string.Empty;

                ssb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = ssb.ConnectionString;

                sQuery = "UPDATE TBL_VENDOR SET VENDOR = '" + oData.VENDOR + "', ADDRESS = '" + oData.ADDRESS + "', CONTACT_PERSON = '" + oData.CONTACT_PERSON + "', EMAIL = '" + oData.EMAIL + "', PHONE_NUMBER = '" + oData.PHONE_NO + "', FAX_NUMBER = '" + oData.FAX_NO + "', STATUS = '" + oData.STATUS + "' WHERE ID = '" + oData.ID + "'";
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
