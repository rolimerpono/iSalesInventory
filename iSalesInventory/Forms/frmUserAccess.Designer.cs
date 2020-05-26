namespace iSalesInventory.Forms
{
    partial class frmUserAccess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.chkUserSettings = new System.Windows.Forms.CheckBox();
            this.chkSystemSettings = new System.Windows.Forms.CheckBox();
            this.chkRecords = new System.Windows.Forms.CheckBox();
            this.chkBrand = new System.Windows.Forms.CheckBox();
            this.chkCategory = new System.Windows.Forms.CheckBox();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.chkVendor = new System.Windows.Forms.CheckBox();
            this.chkProduct = new System.Windows.Forms.CheckBox();
            this.chkSales = new System.Windows.Forms.CheckBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgRecord = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecord)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.chkUserSettings);
            this.pnlMain.Controls.Add(this.chkSystemSettings);
            this.pnlMain.Controls.Add(this.chkRecords);
            this.pnlMain.Controls.Add(this.chkBrand);
            this.pnlMain.Controls.Add(this.chkCategory);
            this.pnlMain.Controls.Add(this.chkStock);
            this.pnlMain.Controls.Add(this.chkVendor);
            this.pnlMain.Controls.Add(this.chkProduct);
            this.pnlMain.Controls.Add(this.chkSales);
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(777, 406);
            this.pnlMain.TabIndex = 3;
            // 
            // chkUserSettings
            // 
            this.chkUserSettings.AutoSize = true;
            this.chkUserSettings.Location = new System.Drawing.Point(649, 341);
            this.chkUserSettings.Name = "chkUserSettings";
            this.chkUserSettings.Size = new System.Drawing.Size(120, 17);
            this.chkUserSettings.TabIndex = 9;
            this.chkUserSettings.Text = "USER SETTINGS";
            this.chkUserSettings.UseVisualStyleBackColor = true;
            // 
            // chkSystemSettings
            // 
            this.chkSystemSettings.AutoSize = true;
            this.chkSystemSettings.Location = new System.Drawing.Point(477, 364);
            this.chkSystemSettings.Name = "chkSystemSettings";
            this.chkSystemSettings.Size = new System.Drawing.Size(135, 17);
            this.chkSystemSettings.TabIndex = 8;
            this.chkSystemSettings.Text = "SYSTEM SETTINGS";
            this.chkSystemSettings.UseVisualStyleBackColor = true;
            // 
            // chkRecords
            // 
            this.chkRecords.AutoSize = true;
            this.chkRecords.Location = new System.Drawing.Point(477, 341);
            this.chkRecords.Name = "chkRecords";
            this.chkRecords.Size = new System.Drawing.Size(84, 17);
            this.chkRecords.TabIndex = 7;
            this.chkRecords.Text = "RECORDS";
            this.chkRecords.UseVisualStyleBackColor = true;
            // 
            // chkBrand
            // 
            this.chkBrand.AutoSize = true;
            this.chkBrand.Location = new System.Drawing.Point(313, 364);
            this.chkBrand.Name = "chkBrand";
            this.chkBrand.Size = new System.Drawing.Size(67, 17);
            this.chkBrand.TabIndex = 6;
            this.chkBrand.Text = "BRAND";
            this.chkBrand.UseVisualStyleBackColor = true;
            // 
            // chkCategory
            // 
            this.chkCategory.AutoSize = true;
            this.chkCategory.Location = new System.Drawing.Point(313, 341);
            this.chkCategory.Name = "chkCategory";
            this.chkCategory.Size = new System.Drawing.Size(89, 17);
            this.chkCategory.TabIndex = 5;
            this.chkCategory.Text = "CATEGORY";
            this.chkCategory.UseVisualStyleBackColor = true;
            this.chkCategory.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Location = new System.Drawing.Point(164, 364);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(67, 17);
            this.chkStock.TabIndex = 4;
            this.chkStock.Text = "STOCK";
            this.chkStock.UseVisualStyleBackColor = true;
            this.chkStock.CheckedChanged += new System.EventHandler(this.chkStock_CheckedChanged);
            // 
            // chkVendor
            // 
            this.chkVendor.AutoSize = true;
            this.chkVendor.Location = new System.Drawing.Point(164, 341);
            this.chkVendor.Name = "chkVendor";
            this.chkVendor.Size = new System.Drawing.Size(75, 17);
            this.chkVendor.TabIndex = 3;
            this.chkVendor.Text = "VENDOR";
            this.chkVendor.UseVisualStyleBackColor = true;
            // 
            // chkProduct
            // 
            this.chkProduct.AutoSize = true;
            this.chkProduct.Location = new System.Drawing.Point(9, 364);
            this.chkProduct.Name = "chkProduct";
            this.chkProduct.Size = new System.Drawing.Size(83, 17);
            this.chkProduct.TabIndex = 2;
            this.chkProduct.Text = "PRODUCT";
            this.chkProduct.UseVisualStyleBackColor = true;
            // 
            // chkSales
            // 
            this.chkSales.AutoSize = true;
            this.chkSales.Location = new System.Drawing.Point(9, 341);
            this.chkSales.Name = "chkSales";
            this.chkSales.Size = new System.Drawing.Size(63, 17);
            this.chkSales.TabIndex = 1;
            this.chkSales.Text = "SALES";
            this.chkSales.UseVisualStyleBackColor = true;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.dgRecord);
            this.pnlGrid.Location = new System.Drawing.Point(9, 38);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(757, 286);
            this.pnlGrid.TabIndex = 60;
            // 
            // dgRecord
            // 
            this.dgRecord.AllowUserToAddRows = false;
            this.dgRecord.AllowUserToDeleteRows = false;
            this.dgRecord.AllowUserToResizeColumns = false;
            this.dgRecord.AllowUserToResizeRows = false;
            this.dgRecord.BackgroundColor = System.Drawing.Color.White;
            this.dgRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgRecord.ColumnHeadersHeight = 30;
            this.dgRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgRecord.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRecord.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgRecord.EnableHeadersVisualStyles = false;
            this.dgRecord.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgRecord.Location = new System.Drawing.Point(0, 0);
            this.dgRecord.Name = "dgRecord";
            this.dgRecord.ReadOnly = true;
            this.dgRecord.RowHeadersVisible = false;
            this.dgRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRecord.Size = new System.Drawing.Size(755, 284);
            this.dgRecord.TabIndex = 0;
            this.dgRecord.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRecord_CellClick);
            this.dgRecord.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRecord_CellEnter);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 41;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "ROLE";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 399);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(775, 5);
            this.pnlFooter.TabIndex = 41;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlHeader.Controls.Add(this.btnSave);
            this.pnlHeader.Controls.Add(this.lblClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(775, 32);
            this.pnlHeader.TabIndex = 30;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(8, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 25);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(700, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(67, 13);
            this.lblClose.TabIndex = 10;
            this.lblClose.Text = "[ CLOSE ]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // frmUserAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(777, 406);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserAccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUserAccess_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRecord)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgRecord;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.CheckBox chkUserSettings;
        private System.Windows.Forms.CheckBox chkSystemSettings;
        private System.Windows.Forms.CheckBox chkRecords;
        private System.Windows.Forms.CheckBox chkBrand;
        private System.Windows.Forms.CheckBox chkCategory;
        private System.Windows.Forms.CheckBox chkStock;
        private System.Windows.Forms.CheckBox chkVendor;
        private System.Windows.Forms.CheckBox chkProduct;
        private System.Windows.Forms.CheckBox chkSales;
    }
}