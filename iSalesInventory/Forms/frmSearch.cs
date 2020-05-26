using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iSalesInventory.Forms
{
    public partial class frmSearch : Form
    {

        
        DataAccess.Brand oBrand;
        DataAccess.Category oCategory;

        
        public Model.Brand oMBrand;
        public Model.Category oMCategory;


        Model.Search oMSearch;

        public enum RECORD_TYPE : int
        {            
            BRAND = 0,
            CATEGORY = 1        
        }
        public RECORD_TYPE RecordType;

        public frmSearch()
        {
            InitializeComponent();

            GlobalVariable.eVariable.MoveForm(pnlHeader,Handle);
            GlobalVariable.eVariable.DisablePanelTextKeyPress(pnlHeader);
            
        }
       

        private void LoadRecords()
        {
            try
            {
                if (RecordType == RECORD_TYPE.BRAND)
                {
                    BrandGrid();
                    oBrand = new DataAccess.Brand();
                    dgRecord.Rows.Clear();

                    foreach (DataRow row in oBrand.GetBrand(oMSearch).Rows)
                    {
                        dgRecord.Rows.Add(row["ID"], row["BRAND"]);
                    }
                }
                else if (RecordType == RECORD_TYPE.CATEGORY)
                {
                    CategoryGrid();
                    oCategory = new DataAccess.Category();
                    dgRecord.Rows.Clear();

                    foreach (DataRow row in oCategory.GetCategory(oMSearch).Rows)
                    {
                        dgRecord.Rows.Add(row["ID"], row["CATEGORY"]);
                    }
                }
            }
            catch (Exception ex)
            { }

        }
       
        private void BrandGrid()
        {
            dgRecord.Columns.Clear();
            dgRecord.Columns.Add("", "ID");
            dgRecord.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRecord.Columns.Add("", "BRAND");
            dgRecord.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void CategoryGrid()
        {
            dgRecord.Columns.Clear();
            dgRecord.Columns.Add("", "ID");
            dgRecord.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgRecord.Columns.Add("", "CATEGORY");
            dgRecord.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void SearchFilter()
        {
            if (RecordType == RECORD_TYPE.BRAND)
            {
                cboSearch.Items.Clear();
                cboSearch.Text = "BRAND";
                cboSearch.Items.Add("BRAND");                
            }
            else if (RecordType == RECORD_TYPE.CATEGORY)
            {
                cboSearch.Items.Clear();
                cboSearch.Text = "CATEGORY";
                cboSearch.Items.Add("CATEGORY");                
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            oMSearch = new Model.Search();

            SearchFilter();
           if (RecordType == RECORD_TYPE.BRAND)
            {
                oMSearch.RECORD_TYPE = cboSearch.Text;
                oMSearch.RECORD_SEARCH = txtSearch.Text;
                oMSearch.STATUS = "ACTIVE";
            }
            else if (RecordType == RECORD_TYPE.CATEGORY)
            {
                oMSearch.RECORD_TYPE = cboSearch.Text;
                oMSearch.RECORD_SEARCH = txtSearch.Text;
                oMSearch.STATUS = "ACTIVE";
            }

            LoadRecords();
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            oMSearch = new Model.Search();
            if (RecordType == RECORD_TYPE.BRAND)
            {
                oMSearch.RECORD_TYPE = cboSearch.Text;
                oMSearch.RECORD_SEARCH = txtSearch.Text;
                oMSearch.STATUS = "ACTIVE";
            }
            else if (RecordType == RECORD_TYPE.CATEGORY)
            {
                oMSearch.RECORD_TYPE = cboSearch.Text;
                oMSearch.RECORD_SEARCH = txtSearch.Text;
                oMSearch.STATUS = "ACTIVE";
            }

        }

        private void dgRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecord(sender, e);
        }

        private void SelectedRecord(object sender, DataGridViewCellEventArgs e)
        {
            
            oMBrand = new Model.Brand();
            oMCategory = new Model.Category();

            if (dgRecord.Rows.Count > 0 && e.RowIndex >= 0)
            {
                if (RecordType == RECORD_TYPE.BRAND)
                {
                    oMBrand.ID = dgRecord.Rows[e.RowIndex].Cells[0].Value.ToString();
                    oMBrand.BRAND = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                    //oMBrand.STATUS = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();
                    
                }
                else if (RecordType == RECORD_TYPE.CATEGORY)
                {
                    oMCategory.ID = dgRecord.Rows[e.RowIndex].Cells[0].Value.ToString();
                    oMCategory.CATEGORY = dgRecord.Rows[e.RowIndex].Cells[1].Value.ToString();
                    //oMBrand.STATUS = dgRecord.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
            
            
            }        
        }

        private void dgRecord_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRecord(sender, e);
        }

        private void dgRecord_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Close();
        }

       
    }
}
