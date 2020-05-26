namespace iSalesInventory.Forms
{
    partial class frmManageStocks
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tbStock = new System.Windows.Forms.TabControl();
            this.tbStockIn = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBrowseProduct = new System.Windows.Forms.Button();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlEntry = new System.Windows.Forms.Panel();
            this.dgStockIn = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboVendor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddess = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStockInDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStockInBy = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtReferrenceNo = new System.Windows.Forms.TextBox();
            this.tbStockAdjust = new System.Windows.Forms.TabPage();
            this.pnlAdjust = new System.Windows.Forms.Panel();
            this.dgStockAdjust = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboVendorAdjust = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnACancel = new System.Windows.Forms.Button();
            this.btnSaveAdjust = new System.Windows.Forms.Button();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.tbStock.SuspendLayout();
            this.tbStockIn.SuspendLayout();
            this.pnlEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockIn)).BeginInit();
            this.tbStockAdjust.SuspendLayout();
            this.pnlAdjust.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockAdjust)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.tbStock);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(920, 640);
            this.pnlMain.TabIndex = 1;
            // 
            // tbStock
            // 
            this.tbStock.Controls.Add(this.tbStockIn);
            this.tbStock.Controls.Add(this.tbStockAdjust);
            this.tbStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStock.Location = new System.Drawing.Point(0, 32);
            this.tbStock.Name = "tbStock";
            this.tbStock.SelectedIndex = 0;
            this.tbStock.Size = new System.Drawing.Size(918, 606);
            this.tbStock.TabIndex = 100;
            this.tbStock.SelectedIndexChanged += new System.EventHandler(this.tbStock_SelectedIndexChanged);
            // 
            // tbStockIn
            // 
            this.tbStockIn.Controls.Add(this.btnCancel);
            this.tbStockIn.Controls.Add(this.btnBrowseProduct);
            this.tbStockIn.Controls.Add(this.btnGenerateCode);
            this.tbStockIn.Controls.Add(this.btnSave);
            this.tbStockIn.Controls.Add(this.pnlEntry);
            this.tbStockIn.Controls.Add(this.cboVendor);
            this.tbStockIn.Controls.Add(this.label2);
            this.tbStockIn.Controls.Add(this.txtAddess);
            this.tbStockIn.Controls.Add(this.label3);
            this.tbStockIn.Controls.Add(this.txtContact);
            this.tbStockIn.Controls.Add(this.label4);
            this.tbStockIn.Controls.Add(this.label1);
            this.tbStockIn.Controls.Add(this.txtStockInDate);
            this.tbStockIn.Controls.Add(this.label6);
            this.tbStockIn.Controls.Add(this.txtStockInBy);
            this.tbStockIn.Controls.Add(this.lblCode);
            this.tbStockIn.Controls.Add(this.txtReferrenceNo);
            this.tbStockIn.Location = new System.Drawing.Point(4, 22);
            this.tbStockIn.Name = "tbStockIn";
            this.tbStockIn.Padding = new System.Windows.Forms.Padding(3);
            this.tbStockIn.Size = new System.Drawing.Size(910, 580);
            this.tbStockIn.TabIndex = 0;
            this.tbStockIn.Text = "STOCK ENTRY";
            this.tbStockIn.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(818, 548);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBrowseProduct
            // 
            this.btnBrowseProduct.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBrowseProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseProduct.ForeColor = System.Drawing.Color.White;
            this.btnBrowseProduct.Location = new System.Drawing.Point(132, 99);
            this.btnBrowseProduct.Name = "btnBrowseProduct";
            this.btnBrowseProduct.Size = new System.Drawing.Size(146, 24);
            this.btnBrowseProduct.TabIndex = 3;
            this.btnBrowseProduct.Text = "BROWSE PRODUCT";
            this.btnBrowseProduct.UseVisualStyleBackColor = false;
            this.btnBrowseProduct.Click += new System.EventHandler(this.btnBrowseProduct_Click);
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGenerateCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateCode.ForeColor = System.Drawing.Color.White;
            this.btnGenerateCode.Location = new System.Drawing.Point(306, 12);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(146, 24);
            this.btnGenerateCode.TabIndex = 0;
            this.btnGenerateCode.Text = "GENERATE CODE";
            this.btnGenerateCode.UseVisualStyleBackColor = false;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(731, 548);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlEntry
            // 
            this.pnlEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEntry.Controls.Add(this.dgStockIn);
            this.pnlEntry.Location = new System.Drawing.Point(2, 132);
            this.pnlEntry.Name = "pnlEntry";
            this.pnlEntry.Size = new System.Drawing.Size(907, 410);
            this.pnlEntry.TabIndex = 119;
            // 
            // dgStockIn
            // 
            this.dgStockIn.AllowUserToAddRows = false;
            this.dgStockIn.AllowUserToDeleteRows = false;
            this.dgStockIn.AllowUserToResizeColumns = false;
            this.dgStockIn.AllowUserToResizeRows = false;
            this.dgStockIn.BackgroundColor = System.Drawing.Color.White;
            this.dgStockIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStockIn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgStockIn.ColumnHeadersHeight = 30;
            this.dgStockIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgStockIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.PCODE,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column9,
            this.Column8});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStockIn.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgStockIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStockIn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgStockIn.EnableHeadersVisualStyles = false;
            this.dgStockIn.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgStockIn.Location = new System.Drawing.Point(0, 0);
            this.dgStockIn.Name = "dgStockIn";
            this.dgStockIn.ReadOnly = true;
            this.dgStockIn.RowHeadersVisible = false;
            this.dgStockIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStockIn.Size = new System.Drawing.Size(905, 408);
            this.dgStockIn.TabIndex = 75;
            this.dgStockIn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStockIn_CellClick);
            this.dgStockIn.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStockIn_CellEndEdit);
            this.dgStockIn.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStockIn_CellEnter);
            this.dgStockIn.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgStockIn_EditingControlShowing);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 41;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "REF #";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // PCODE
            // 
            this.PCODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PCODE.HeaderText = "PCODE";
            this.PCODE.Name = "PCODE";
            this.PCODE.ReadOnly = true;
            this.PCODE.Width = 73;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "DESCRIPTION";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "QTY";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 55;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "STOCK DATE";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 107;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "STOCKIN BY";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 105;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "VENDOR_ID";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "VENDOR";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 81;
            // 
            // cboVendor
            // 
            this.cboVendor.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVendor.ForeColor = System.Drawing.Color.Black;
            this.cboVendor.FormattingEnabled = true;
            this.cboVendor.Location = new System.Drawing.Point(596, 11);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Size = new System.Drawing.Size(307, 24);
            this.cboVendor.TabIndex = 4;
            this.cboVendor.SelectedIndexChanged += new System.EventHandler(this.cboVendor_SelectedIndexChanged);
            this.cboVendor.SelectionChangeCommitted += new System.EventHandler(this.cboVendor_SelectionChangeCommitted);
            this.cboVendor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboVendor_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(477, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "ADDRESS";
            // 
            // txtAddess
            // 
            this.txtAddess.BackColor = System.Drawing.Color.White;
            this.txtAddess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddess.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddess.Enabled = false;
            this.txtAddess.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddess.Location = new System.Drawing.Point(596, 71);
            this.txtAddess.Multiline = true;
            this.txtAddess.Name = "txtAddess";
            this.txtAddess.Size = new System.Drawing.Size(307, 24);
            this.txtAddess.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(477, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "CONTACT PERSON";
            // 
            // txtContact
            // 
            this.txtContact.BackColor = System.Drawing.Color.White;
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContact.Enabled = false;
            this.txtContact.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(596, 41);
            this.txtContact.Multiline = true;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(307, 24);
            this.txtContact.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(477, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "VENDOR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "STOCKIN DATE";
            // 
            // txtStockInDate
            // 
            this.txtStockInDate.BackColor = System.Drawing.Color.White;
            this.txtStockInDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockInDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStockInDate.Enabled = false;
            this.txtStockInDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockInDate.Location = new System.Drawing.Point(132, 71);
            this.txtStockInDate.Multiline = true;
            this.txtStockInDate.Name = "txtStockInDate";
            this.txtStockInDate.Size = new System.Drawing.Size(320, 24);
            this.txtStockInDate.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(13, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "STOCKIN BY";
            // 
            // txtStockInBy
            // 
            this.txtStockInBy.BackColor = System.Drawing.Color.White;
            this.txtStockInBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockInBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStockInBy.Enabled = false;
            this.txtStockInBy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockInBy.Location = new System.Drawing.Point(132, 41);
            this.txtStockInBy.Multiline = true;
            this.txtStockInBy.Name = "txtStockInBy";
            this.txtStockInBy.Size = new System.Drawing.Size(320, 24);
            this.txtStockInBy.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Black;
            this.lblCode.Location = new System.Drawing.Point(13, 18);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(41, 13);
            this.lblCode.TabIndex = 61;
            this.lblCode.Text = "REF #";
            // 
            // txtReferrenceNo
            // 
            this.txtReferrenceNo.BackColor = System.Drawing.Color.White;
            this.txtReferrenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferrenceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReferrenceNo.Enabled = false;
            this.txtReferrenceNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferrenceNo.Location = new System.Drawing.Point(132, 12);
            this.txtReferrenceNo.Multiline = true;
            this.txtReferrenceNo.Name = "txtReferrenceNo";
            this.txtReferrenceNo.Size = new System.Drawing.Size(168, 24);
            this.txtReferrenceNo.TabIndex = 0;
            // 
            // tbStockAdjust
            // 
            this.tbStockAdjust.Controls.Add(this.pnlAdjust);
            this.tbStockAdjust.Controls.Add(this.panel2);
            this.tbStockAdjust.Controls.Add(this.panel1);
            this.tbStockAdjust.Location = new System.Drawing.Point(4, 22);
            this.tbStockAdjust.Name = "tbStockAdjust";
            this.tbStockAdjust.Padding = new System.Windows.Forms.Padding(3);
            this.tbStockAdjust.Size = new System.Drawing.Size(910, 580);
            this.tbStockAdjust.TabIndex = 2;
            this.tbStockAdjust.Text = "STOCK ADJUSTMENT";
            this.tbStockAdjust.UseVisualStyleBackColor = true;
            this.tbStockAdjust.Click += new System.EventHandler(this.tbStockAdjust_Click);
            // 
            // pnlAdjust
            // 
            this.pnlAdjust.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAdjust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdjust.Controls.Add(this.dgStockAdjust);
            this.pnlAdjust.Location = new System.Drawing.Point(2, 40);
            this.pnlAdjust.Name = "pnlAdjust";
            this.pnlAdjust.Size = new System.Drawing.Size(904, 372);
            this.pnlAdjust.TabIndex = 123;
            // 
            // dgStockAdjust
            // 
            this.dgStockAdjust.AllowUserToAddRows = false;
            this.dgStockAdjust.AllowUserToDeleteRows = false;
            this.dgStockAdjust.AllowUserToResizeColumns = false;
            this.dgStockAdjust.AllowUserToResizeRows = false;
            this.dgStockAdjust.BackgroundColor = System.Drawing.Color.White;
            this.dgStockAdjust.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStockAdjust.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgStockAdjust.ColumnHeadersHeight = 30;
            this.dgStockAdjust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgStockAdjust.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.Column2,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn12,
            this.Column10,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStockAdjust.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgStockAdjust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStockAdjust.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgStockAdjust.EnableHeadersVisualStyles = false;
            this.dgStockAdjust.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgStockAdjust.Location = new System.Drawing.Point(0, 0);
            this.dgStockAdjust.Name = "dgStockAdjust";
            this.dgStockAdjust.ReadOnly = true;
            this.dgStockAdjust.RowHeadersVisible = false;
            this.dgStockAdjust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStockAdjust.Size = new System.Drawing.Size(902, 370);
            this.dgStockAdjust.TabIndex = 123;
            this.dgStockAdjust.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStockAdjust_CellClick);
            this.dgStockAdjust.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStockAdjust_CellDoubleClick);
            this.dgStockAdjust.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStockAdjust_CellEnter);
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn13.HeaderText = "#";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 41;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn14.HeaderText = "PCODE";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 73;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn15.HeaderText = "BCODE";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 74;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "DESCRIPTION";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "BRD_ID";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.HeaderText = "BRAND";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 73;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "CAT_ID";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.HeaderText = "CATEGORY";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 95;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.HeaderText = "PRICE";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 68;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.HeaderText = "STOCK ON HAND";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 131;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.cboVendorAdjust);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btnACancel);
            this.panel2.Controls.Add(this.btnSaveAdjust);
            this.panel2.Controls.Add(this.cboAction);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtQty);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtUser);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtRemarks);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtProductCode);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtRefNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 408);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 169);
            this.panel2.TabIndex = 122;
            // 
            // cboVendorAdjust
            // 
            this.cboVendorAdjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVendorAdjust.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVendorAdjust.ForeColor = System.Drawing.Color.Black;
            this.cboVendorAdjust.FormattingEnabled = true;
            this.cboVendorAdjust.Location = new System.Drawing.Point(589, 13);
            this.cboVendorAdjust.Name = "cboVendorAdjust";
            this.cboVendorAdjust.Size = new System.Drawing.Size(311, 24);
            this.cboVendorAdjust.TabIndex = 5;
            this.cboVendorAdjust.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboVendorAdjust_KeyPress);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(488, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 105;
            this.label13.Text = "VENDOR";
            // 
            // btnACancel
            // 
            this.btnACancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnACancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnACancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnACancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnACancel.ForeColor = System.Drawing.Color.White;
            this.btnACancel.Location = new System.Drawing.Point(815, 136);
            this.btnACancel.Name = "btnACancel";
            this.btnACancel.Size = new System.Drawing.Size(85, 25);
            this.btnACancel.TabIndex = 9;
            this.btnACancel.Text = "CANCEL";
            this.btnACancel.UseVisualStyleBackColor = false;
            this.btnACancel.Click += new System.EventHandler(this.btnACancel_Click);
            // 
            // btnSaveAdjust
            // 
            this.btnSaveAdjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAdjust.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveAdjust.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAdjust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAdjust.ForeColor = System.Drawing.Color.White;
            this.btnSaveAdjust.Location = new System.Drawing.Point(728, 136);
            this.btnSaveAdjust.Name = "btnSaveAdjust";
            this.btnSaveAdjust.Size = new System.Drawing.Size(85, 25);
            this.btnSaveAdjust.TabIndex = 8;
            this.btnSaveAdjust.Text = "SAVE";
            this.btnSaveAdjust.UseVisualStyleBackColor = false;
            this.btnSaveAdjust.Click += new System.EventHandler(this.btnSaveAdjust_Click);
            // 
            // cboAction
            // 
            this.cboAction.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAction.ForeColor = System.Drawing.Color.Black;
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Items.AddRange(new object[] {
            "ADD TO STOCKS",
            "REMOVE TO STOCKS"});
            this.cboAction.Location = new System.Drawing.Point(135, 136);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(320, 24);
            this.cboAction.TabIndex = 5;
            this.cboAction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboAction_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 102;
            this.label5.Text = "QTY";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(135, 106);
            this.txtQty.Multiline = true;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(320, 24);
            this.txtQty.TabIndex = 4;
            this.txtQty.Text = "1";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(488, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 100;
            this.label7.Text = "USER";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUser.Enabled = false;
            this.txtUser.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(589, 75);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(311, 24);
            this.txtUser.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(488, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 98;
            this.label8.Text = "REMARKS";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemarks.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(589, 45);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(311, 24);
            this.txtRemarks.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(16, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 96;
            this.label9.Text = "ACTION";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(16, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 94;
            this.label10.Text = "DESCRIPTION";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Enabled = false;
            this.txtDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(135, 75);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(320, 24);
            this.txtDescription.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(16, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 92;
            this.label11.Text = "PCODE";
            // 
            // txtProductCode
            // 
            this.txtProductCode.BackColor = System.Drawing.Color.White;
            this.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductCode.Enabled = false;
            this.txtProductCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(135, 45);
            this.txtProductCode.Multiline = true;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(320, 24);
            this.txtProductCode.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(16, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 90;
            this.label12.Text = "REF #";
            // 
            // txtRefNo
            // 
            this.txtRefNo.BackColor = System.Drawing.Color.White;
            this.txtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRefNo.Enabled = false;
            this.txtRefNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNo.Location = new System.Drawing.Point(135, 16);
            this.txtRefNo.Multiline = true;
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(320, 24);
            this.txtRefNo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cboSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 38);
            this.panel1.TabIndex = 120;
            // 
            // cboSearch
            // 
            this.cboSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearch.ForeColor = System.Drawing.Color.Black;
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Items.AddRange(new object[] {
            "DESCRIPTION",
            "BRAND",
            "CATEGORY"});
            this.cboSearch.Location = new System.Drawing.Point(1, 7);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(124, 24);
            this.cboSearch.TabIndex = 0;
            this.cboSearch.Text = "DESCRIPTION";
            this.cboSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSearch_KeyPress);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(131, 7);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(391, 24);
            this.txtSearch.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(918, 32);
            this.pnlHeader.TabIndex = 28;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblClose.Location = new System.Drawing.Point(847, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(67, 13);
            this.lblClose.TabIndex = 9;
            this.lblClose.Text = "[ CLOSE ]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // frmManageStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 640);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageStocks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStockIn_Load);
            this.pnlMain.ResumeLayout(false);
            this.tbStock.ResumeLayout(false);
            this.tbStockIn.ResumeLayout(false);
            this.tbStockIn.PerformLayout();
            this.pnlEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStockIn)).EndInit();
            this.tbStockAdjust.ResumeLayout(false);
            this.pnlAdjust.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStockAdjust)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.TabControl tbStock;
        private System.Windows.Forms.TabPage tbStockIn;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtAddess;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtStockInDate;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtStockInBy;
        private System.Windows.Forms.Label lblCode;
        public System.Windows.Forms.TextBox txtReferrenceNo;
        private System.Windows.Forms.ComboBox cboVendor;
        private System.Windows.Forms.Panel pnlEntry;
        private System.Windows.Forms.DataGridView dgStockIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tbStockAdjust;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSaveAdjust;
        private System.Windows.Forms.ComboBox cboAction;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlAdjust;
        private System.Windows.Forms.DataGridView dgStockAdjust;
        public System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Button btnBrowseProduct;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Button btnACancel;
        private System.Windows.Forms.ComboBox cboVendorAdjust;
        private System.Windows.Forms.Label label13;
    }
}