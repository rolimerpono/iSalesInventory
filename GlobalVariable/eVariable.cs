using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GlobalVariable
{
    public static class eVariable
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public static IntPtr HWnd { get; set; }

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr HWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public static void DisableGridColumnSort(DataGridView oGrid)
        {
            foreach (DataGridViewColumn col in oGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.Frozen = false;
            }
        }

        public static void ClearText(Control oControl)
        {
            foreach (Control o in oControl.Controls.OfType<TextBox>().ToList())
            {
                o.Text = string.Empty;
            }

            foreach (CheckBox o in oControl.Controls.OfType<CheckBox>().ToList())
            {
                o.Checked = false;
            }
        }

        public static void DisablePanelTextKeyPress(Control oControl)
        {
            foreach (Control o in oControl.Controls.OfType<TextBox>().ToList())
            {
                o.KeyPress += TextKeyPress;
            }
        }

        private static void TextKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        public static void DisableTextEnterKey(Control oControl)
        {
            oControl.KeyDown += TextKeyDown;
        }


        public static void DisableTextPanelEnterKey(Control oControl)
        {
            foreach (Control o in oControl.Controls.OfType<TextBox>().ToList())
            {
                if (!o.Name.ToLower().Contains("address"))
                {
                    o.KeyDown += TextKeyDown;
                }
            }
        }



        private static void TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        public static bool IsFieldEmpty(Control oControl)
        {
            foreach (var oText in oControl.Controls.OfType<TextBox>().ToList())
            {
                if (oText.Text.Trim() == String.Empty && !oText.Name.Contains("txtSearch"))
                {
                    return true;
                }
            }
            return false;
        }

        public static void DisableKeyPress(Control oControl)
        {
            oControl.KeyPress += NoKeyPress;
        }

        private static void NoKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public static void MoveForm(Control oControl,IntPtr handle)
        {
            HWnd = handle;
            oControl.MouseDown += MouseMove_MouseDown; 
        }

        private static void MouseMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(HWnd, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
       

        public static void ValidAmount(Control oControl)
        {
            oControl.KeyPress += ValidAmountKeyPress;
        }

        public static void ValidNumber(Control oControl)
        {
            oControl.KeyPress += ValidNumberKeyPress;
        }

        public static void ValidAmountPanel(Control oControl)
        {
            foreach (Control o in oControl.Controls.OfType<TextBox>().ToList())
            {
                o.KeyPress += ValidAmountKeyPress;
            }

        }

        public static void DisableSpacebar(Control oControl)
        {
            oControl.KeyPress += NoSpace;
        }

        private static void NoSpace(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }               

        public static void ValidNumberPanel(Control oControl)
        {
            foreach (Control o in oControl.Controls.OfType<TextBox>().ToList())
            {
                o.KeyPress += ValidNumberKeyPress;
            }

        }

        private static void ValidAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf('.') != -1)
                {
                    e.Handled = true;
                    return;
                }

                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 46)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private static void ValidNumberKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (((Control)sender).Text == "" && e.KeyChar == '0')
                {
                    e.Handled = true;
                    return;
                }
                if (e.KeyChar < '0' || e.KeyChar > '9')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        public static int GetAge(DateTime dStart, DateTime dEnd)
        {
            return (dEnd.Year - dStart.Year - 1) + (((dEnd.Month > dStart.Month) || ((dEnd.Month == dStart.Month) && (dEnd.Day >= dStart.Day))) ? 1 : 0);
        }

        public enum MESSAGE : int
        {
            ALL_FIELDS_ARE_ALL_REQUIRED = 0,
            RECORD_HAS_BEEN_SUCCESSFULLY_SAVE = 1,
            RECORD_ALREADY_EXISTS = 2,   
            TRANSACTION_HAS_BEEN_SUCCESSFULLY_SAVE = 3
        }

        public enum MESSAGE_BOX_TYPE
        {
            INFO = 0,
            QUERY = 1
        }        

        public enum TRANSACTION_TYPE : int
        {
            NONE = 0,
            ADD = 1,
            EDIT = 2,
            DELETE = 3

        }       

        public struct MESSABOX_MESSAGES
        {
            public const string ALL_FIELDS_REQUIRED = "PLEASE FILL ALL REQUIRED FIELDS";
            public const string RECORD_SAVE = "RECORD HAS BEEN SUCCESSFULLY SAVED";
            public const string VALID_DATE_RANGE = "DATE RANGE IS INVALID";
            public const string DATABASE_BACKUP = "DATABASE HAS BEEN SUCCESSFULLY BACKUP";
            public const string DATABASE_RESTORE = "DATABASE HAS BEEN SUCCESSFULLY RESTORED";
            public const string TRANSACTION_COMPLETE = "TRANSACTION HAS BEEN SUCCESSFULLY COMPLETED";
            public const string RECORD_EXISTS = "RECORD ALREADY EXISTS";
            public const string QUANTY_IS_GREATER_THAN_ONHAND = "QUANTITY ENTERED IS GREATER THAN STOCK ON-HAND";
            public const string YOU_WANT_TO_PROCEED = "ARE YOU SURE YOU WANT TO PROCEED?";
            public const string YOU_WANT_TO_REMOVE = "ARE YOU SURE YOU WANT TO REMOVE THIS RECORD?";
            public const string PASSWORD_NOT_MATCH = "THE PASSWORD YOU ENTERED DID NOT MATCH";
            public const string LOGIN_FAIL = "THE USERNAME OR PASSWORD YOU ENTERED ARE INCORRECT";
            public const string PASSWORD_CHANGE = "YOUR PASSWORD HAS BEEN SUCCESSFULLY CHANGED";
            public const string APPLY_DEDUCTION = "ARE YOU SURE YOU WANT TO APPLY DEDUCTION TO THIS ITEM?";
            public const string PERCENTAGE_VALIDATION = "PERCENTAGE SHOULD NOT EXCEED TO 100 %";
            public const string VOID_AUTHORIZATION = "YOU HAVE NO RIGHTS TO VOID A TRANSACTION";
            public const string SELECT_RECORD_FIRST = "PLEASE SELECT A RECORD FIRST";
        }
        

        public static string sID = string.Empty;
        public static string sUsername = string.Empty;
        public static string sPassword = string.Empty;
        public static string sFullname = string.Empty;
        public static string sRole = string.Empty;

        public static string sVendorID = string.Empty;
        public static string sBrandID = string.Empty;
        public static string sCategoryID = string.Empty;
        public static string sVoidBy = string.Empty;
        public static bool IsAllowVoid = false;
        public static string sGlobalConnectionString = @"Data Source=.\SQLSERVERR2;Initial Catalog=iSalesInventory;Integrated Security=True";
        public static string sGlobalMasterConnectionString = @"Data Source=.\SQLSERVERR2;Initial Catalog=master;Integrated Security=True";

    }
}
