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
    public partial class frmChangePass : Form
    {
        DataAccess.User oUser;
        Model.User oMUser;
        iMessageBox.MessageBoxForm oFrmMsgBox;

        public frmChangePass()
        {
            InitializeComponent();
            GlobalVariable.eVariable.DisableTextPanelEnterKey(pnlMain);
            GlobalVariable.eVariable.MoveForm(pnlHeader, Handle);
            GlobalVariable.eVariable.DisableSpacebar(txtOldpass);
            GlobalVariable.eVariable.DisableSpacebar(txtNewPass);
            GlobalVariable.eVariable.DisableSpacebar(txtConfirmPass);
        }
      

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOldpass.Text.Trim() == GlobalVariable.eVariable.sPassword)
            {
                if (txtNewPass.Text.Trim() == txtConfirmPass.Text.Trim())
                {
                    oUser = new DataAccess.User();
                    oMUser = new Model.User();
                    oMUser.USERNAME = GlobalVariable.eVariable.sUsername;
                    oMUser.PASSWORD = txtConfirmPass.Text;
                    oUser.ChangePassword(oMUser);

                    oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.PASSWORD_CHANGE);
                    oFrmMsgBox.StartPosition = FormStartPosition.Manual;
                    oFrmMsgBox.ShowDialog();
                    Close();
                    
                }
                else
                {
                    oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.PASSWORD_NOT_MATCH);
                    oFrmMsgBox.StartPosition = FormStartPosition.Manual;
                    oFrmMsgBox.ShowDialog();
                    return;
                }
            }
            else
            {
                oFrmMsgBox = new iMessageBox.MessageBoxForm(GlobalVariable.eVariable.MESSABOX_MESSAGES.PASSWORD_NOT_MATCH);
                oFrmMsgBox.StartPosition = FormStartPosition.Manual;
                oFrmMsgBox.ShowDialog();
                return;
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
