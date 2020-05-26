using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iSalesInventoryClient.Forms
{
    public partial class frmVoid : Form
    {
        DataAccess.User oUser = new DataAccess.User();
        Model.User oMUser = new Model.User();
        Model.Search oMSearch = new Model.Search();
        public string sAnswer = "NO";
        iMessageBox.MessageBoxForm oFrmMsgBox;
        public frmVoid()
        {
            InitializeComponent();

            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
            GlobalVariable.eVariable.DisableTextPanelEnterKey(pnlMain);
        }       

        private void btnVoid_Click(object sender, EventArgs e)
        {
            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "USERNAME";
            oMSearch.RECORD_SEARCH = txtUsername.Text;            

            oUser = new DataAccess.User();
            oMUser = new Model.User();
            oMUser.USERNAME = txtUsername.Text;
            oMUser.PASSWORD = txtPassword.Text;
            GlobalVariable.eVariable.sVoidBy = string.Empty;
            if (oUser.IsLogin(oMUser))
            {

                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.YOU_WANT_TO_PROCEED);
                oFrmMsgBox.MessageType = iMessageBox.MessageBoxForm.MESSAGE_TYPE.QUERY;
                oFrmMsgBox.ShowDialog();

                if (oFrmMsgBox.sAnswer == "NO")
                {
                    return;
                }                

                foreach (DataRow row in oUser.GetUser(oMSearch).Rows)
                {
                    oMUser = new Model.User();
                    oMUser.FIRST_NAME = row[1].ToString();
                    oMUser.MIDDLE_NAME = row[2].ToString();
                    oMUser.LAST_NAME = row[3].ToString();
                    oMUser.CONTACT_NO = row[4].ToString();
                    oMUser.USERNAME = row[5].ToString();
                    oMUser.PASSWORD = row[6].ToString();
                    oMUser.ROLE = row[7].ToString();
                    oMUser.STATUS = row[8].ToString();
                    oMUser.ALLOWED_VOID = Convert.ToInt32(row[9]);
                }

                if (Convert.ToBoolean(oMUser.ALLOWED_VOID))
                {
                    GlobalVariable.eVariable.sVoidBy = oMUser.FIRST_NAME + " " + oMUser.MIDDLE_NAME + " " + oMUser.LAST_NAME ;                    
                    sAnswer = "OK";
                    Close();
                }
                else
                {
                    oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.VOID_AUTHORIZATION);
                    oFrmMsgBox.StartPosition = FormStartPosition.Manual;
                    oFrmMsgBox.ShowDialog();
                    txtUsername.Focus();
                    sAnswer = "NO";
                }
                
            }
            else
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.LOGIN_FAIL);
                oFrmMsgBox.StartPosition = FormStartPosition.Manual;
                oFrmMsgBox.ShowDialog();
                txtUsername.Focus();
                sAnswer = "NO";
            }
           
        }
    }
}
