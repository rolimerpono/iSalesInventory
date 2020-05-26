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

namespace iSalesInventory
{
    public partial class MAIN : Form
    {
        XMLSerialiser.Serializerset oXMLSerializerSet;
        Model.SystemConfiguration oSystemConfig = new Model.SystemConfiguration();

        Form xFrm;
        Model.DefaultLogin oMDefaultLogin;
        Model.User oMuser;
        DataAccess.UserAccess oUserAccess = new DataAccess.UserAccess();
        Model.UserAccess oMUserAccess = new Model.UserAccess();
        Model.Search oMSearch = new Model.Search();
        public MAIN()
        {
            InitializeComponent();
        }

        public MAIN(Model.DefaultLogin oData)
        {
            InitializeComponent();
            oMDefaultLogin = oData;

            lblUser.Text = "[" + oMDefaultLogin.NAME + "]";
        }

        public MAIN(Model.User oData)
        {
            InitializeComponent();
            oMuser = oData;
            lblUser.Text = "[" + oData.FIRST_NAME + " " + oData.MIDDLE_NAME + " " + oData.LAST_NAME + "]";

            LoadAccess();
        }

        private void LoadAccess()
        {

            oMSearch = new Model.Search();
            oMSearch.RECORD_TYPE = "USER ACCESS";
            oMSearch.RECORD_SEARCH = oMuser.ROLE;
            oUserAccess = new DataAccess.UserAccess();
            oMUserAccess = new Model.UserAccess();
            foreach (DataRow row in oUserAccess.GetUserAccess(oMSearch).Rows)
            { 
                oMUserAccess.SALES = Convert.ToBoolean(row["SALES"]);
                oMUserAccess.PRODUCT = Convert.ToBoolean(row["PRODUCT"]);
                oMUserAccess.VENDOR = Convert.ToBoolean(row["VENDOR"]);
                oMUserAccess.STOCK = Convert.ToBoolean(row["STOCK"]);
                oMUserAccess.CATEGORY = Convert.ToBoolean(row["CATEGORY"]);
                oMUserAccess.BRAND = Convert.ToBoolean(row["BRAND"]);
                oMUserAccess.RECORDS = Convert.ToBoolean(row["RECORDS"]);
                oMUserAccess.SYSTEM_SETTINGS = Convert.ToBoolean(row["SYSTEM_SETTINGS"]);
                oMUserAccess.USER_SETTINGS = Convert.ToBoolean(row["USER_SETTINGS"]);
                oMUserAccess.ROLE = row["ROLE"].ToString();
            }

            btnManageProduct.Enabled = oMUserAccess.PRODUCT;
            btnManageVendor.Enabled = oMUserAccess.VENDOR;
            btnManageStock.Enabled = oMUserAccess.STOCK;
            btnRecords.Enabled = oMUserAccess.RECORDS;
            btnSystemSettings.Enabled = oMUserAccess.SYSTEM_SETTINGS;
            btnUserSettings.Enabled = oMUserAccess.USER_SETTINGS;
         
        }  

        void Form_Load(Form xForm)
        {
            xForm.TopLevel = false;

            foreach (Control item in pnlMain.Controls)
            {
                if (!item.Name.Contains("SubMenu"))
                {
                    pnlMain.Controls.Remove(item);
                    break;
                }
            }

            pnlMain.Controls.Add(xForm);
            xForm.Show();
        }

   
                 
        private void LoadSystemConfig()
        {            
            oXMLSerializerSet = new Serializerset(Application.StartupPath + @"\SystemConfiguration.dll");
            oSystemConfig = oXMLSerializerSet.ReadXmlSerialize(Application.StartupPath + @"\SystemConfiguration.dll");
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

        private void MAIN_Load(object sender, EventArgs e)
        {
            LoadSystemConfig();
            Thread T = new Thread(new ThreadStart(GetCurrentDate));
            T.Start();
        }

       

        private void btnRecords_Click(object sender, EventArgs e)
        {
            ClearControls();
            xFrm = new Forms.frmRecords();
            Form_Load(xFrm);
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnPOSClient_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            ClearControls();
            MovePanel(btnUserSettings, pnlUserSubMenu);
            if (pnlUserSubMenu.Visible == true)
            {
                pnlUserSubMenu.Visible = false;
                btnUserSettings.Text = btnUserSettings.Text.Replace("-", "+");

            }
            else
            {
                ClearControls();
                pnlUserSubMenu.Visible = true;
                btnUserSettings.Text = btnUserSettings.Text.Replace("+", "-");
            }
        }

        void MovePanel(Control btn, Control oPanel)
        {
            oPanel.Top = btn.Top - 70;
            oPanel.Left = btn.Left;
        }

        void ClearControls()
        {
            foreach (Control item in pnlMain.Controls)
            {
                if (!item.Name.Contains("SubMenu"))
                {
                    if (item.Name.Contains("dashboard"))
                    {
                        return;
                    }
                    pnlMain.Controls.Remove(item);
                }
                else
                {
                    pnlUserSubMenu.Visible = false;
                    pnlSystemSettingsSubMenu.Visible = false;
                    break;
                }

            }
            btnUserSettings.Text = btnUserSettings.Text.Replace("-", "+");
            btnSystemSettings.Text = btnSystemSettings.Text.Replace("-", "+");
        }

        private void btnUserAccount_Click(object sender, EventArgs e)
        {
            ClearControls();
            pnlUserSubMenu.Visible = false;
            
            Forms.frmUser oFrm = new Forms.frmUser();
            oFrm.ShowDialog();
        }

        private void btnUserRole_Click(object sender, EventArgs e)
        {
            ClearControls();
            pnlUserSubMenu.Visible = false;

            xFrm = new Forms.frmRoleList();
            Form_Load(xFrm);
        }

        private void btnUserAccess_Click(object sender, EventArgs e)
        {
            ClearControls();
            pnlUserSubMenu.Visible = false;

            Forms.frmUserAccess oFrm = new Forms.frmUserAccess();
            oFrm.ShowDialog();
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            ClearControls();
            xFrm = new Forms.frmProductList();
            Form_Load(xFrm);
        }

        private void btnSystemSettings_Click(object sender, EventArgs e)
        {
            ClearControls();
            MovePanel(btnSystemSettings, pnlSystemSettingsSubMenu);
            if (pnlSystemSettingsSubMenu.Visible == true)
            {
                pnlSystemSettingsSubMenu.Visible = false;
                btnSystemSettings.Text = btnSystemSettings.Text.Replace("-", "+");

            }
            else
            {
                ClearControls();
                pnlSystemSettingsSubMenu.Visible = true;
                btnSystemSettings.Text = btnSystemSettings.Text.Replace("+", "-");
            }
        }

        private void btnManageVendor_Click(object sender, EventArgs e)
        {
            ClearControls();
            xFrm = new Forms.frmVendorList();
            Form_Load(xFrm);
        }

        private void btnManageStock_Click(object sender, EventArgs e)
        {
            ClearControls();
            xFrm = new Forms.frmManageStocks();
            Form_Load(xFrm);
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            ClearControls();
            xFrm = new Forms.frmCategoryList();
            Form_Load(xFrm);
        }

        private void btnManageBrand_Click(object sender, EventArgs e)
        {
            ClearControls();
            xFrm = new Forms.frmBrandList();
            Form_Load(xFrm);
        }

        private void btnBackupRestoreDB_Click(object sender, EventArgs e)
        {

        }

      

      

   
      

    }
}
