using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using XMLSerialiser;

namespace iSalesInventoryClient.Forms
{
    public partial class frmLogin : Form
    {
        XMLSerialiser.Serializerset oXMLSerializerSet;
        Model.SystemConfiguration oSystemConfig = new Model.SystemConfiguration();
        Thread ThDate;
        iMessageBox.MessageBoxForm oFrmMsgBox;
        DataAccess.User oUser;
        Model.User oMUser;
        Model.DefaultLogin oMDefaulLogin;
        Model.Search oMsearch;
        CommonFunction.CommonFunction oFunction;

        MAIN oMainForm;

        public frmLogin()
        {
            InitializeComponent();
            GlobalVariable.eVariable.DisableTextPanelEnterKey(pnlMain);
            GlobalVariable.eVariable.DisableSpacebar(txtUsername);
            GlobalVariable.eVariable.DisableSpacebar(txtPassword);
        }

        void GetCurrentDate()
        {
            for (int i = 0; i <= 2000; i++)
            {
                Thread.Sleep(1000);
                this.Invoke((MethodInvoker)delegate
                {
                    lblCurrentDate.Text = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                });
                if (i == 1001)
                {
                    i = 0;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            oUser = new DataAccess.User();
            oFunction = new CommonFunction.CommonFunction();

            if (oFunction.Decrypt(oSystemConfig._DefaultLogin.USERNAME.Trim()) == txtUsername.Text && oFunction.Decrypt(oSystemConfig._DefaultLogin.PASSWORD.Trim()) == txtPassword.Text) //Default Login
            {
                oMDefaulLogin = new Model.DefaultLogin();
                oMDefaulLogin.USERNAME = txtUsername.Text;
                oMDefaulLogin.PASSWORD = txtPassword.Text;
                oMDefaulLogin.NAME = oFunction.Decrypt(oSystemConfig._DefaultLogin.NAME);
                oMDefaulLogin.ROLE = oFunction.Decrypt(oSystemConfig._DefaultLogin.ROLE);
                oMDefaulLogin.ALLOW_VOID = oSystemConfig._DefaultLogin.ALLOW_VOID;
                GlobalVariable.eVariable.sFullname = oMDefaulLogin.NAME;
                GlobalVariable.eVariable.sUsername = txtUsername.Text;
                GlobalVariable.eVariable.sPassword = txtPassword.Text;                
                this.ShowInTaskbar = false;
                this.Hide();
                oMainForm = new MAIN(oMDefaulLogin);
                oMainForm.ShowDialog();
                return;
            }

            else
            {
                #region CheckDatabase

                //oDatabase = new DataAccess.BackupRestoreDB();

                //if (!oDatabase.IsDatabaseExits())
                //{
                //    oFrmMsgBox = new frmMessageBox(ePublicVariable.eVariable.TransactionMessage.THE_DATABASE_DOES_NOT_EXITS.ToString().Replace("_", " "));
                //    oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                //    oFrmMsgBox.ShowDialog();

                //    Maintenance.frmBackupRestoreDB oFrm = new Maintenance.frmBackupRestoreDB();
                //    oFrm.ShowDialog();
                //}

                #endregion

                #region DBLogin

                oMsearch = new Model.Search();
                oMsearch.RECORD_TYPE = "USERNAME";
                oMsearch.RECORD_SEARCH = txtUsername.Text;

                oMUser = new Model.User();
                oMUser.USERNAME = txtUsername.Text;
                oMUser.PASSWORD = txtPassword.Text;

                if (oUser.IsLogin(oMUser))
                {
                    foreach (DataRow row in oUser.GetUser(oMsearch).Rows)
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

                    GlobalVariable.eVariable.sFullname = oMUser.FIRST_NAME + " " + oMUser.MIDDLE_NAME + " " + oMUser.LAST_NAME;
                    GlobalVariable.eVariable.sUsername = txtUsername.Text;
                    GlobalVariable.eVariable.sPassword = txtPassword.Text; 
                    this.ShowInTaskbar = false;
                    this.Hide();
                    oMainForm = new MAIN(oMUser);
                    oMainForm.ShowDialog();
                    return;
                }
                else
                {
                    lblNotification.Text = "THE USERNAME AND PASSWORD YOU HAVE ENTERED ARE INCORRECT";
                    txtUsername.Focus();
                }
                #endregion
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadSystemConfig();
            ThDate = new Thread(new ThreadStart(GetCurrentDate));
            ThDate.Start();
        }

        private void LoadSystemConfig()
        {
            oXMLSerializerSet = new Serializerset(Application.StartupPath + @"\SystemConfiguration.dll");
            oSystemConfig = oXMLSerializerSet.ReadXmlSerialize(Application.StartupPath + @"\SystemConfiguration.dll");
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThDate.Abort();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
