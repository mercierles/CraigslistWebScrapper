namespace CraigslistScrapper
{
	partial class frmScrapper
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
			this.chkBoxCondition = new System.Windows.Forms.CheckedListBox();
			this.lblCondition = new System.Windows.Forms.Label();
			this.txtBoxSearch = new System.Windows.Forms.TextBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.lblMinPrice = new System.Windows.Forms.Label();
			this.lblMaxPrice = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblZipCode = new System.Windows.Forms.Label();
			this.txtBoxZipCode = new System.Windows.Forms.TextBox();
			this.lblCategory = new System.Windows.Forms.Label();
			this.lblState = new System.Windows.Forms.Label();
			this.ddlCategory = new System.Windows.Forms.ComboBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtBoxCraigslistURL = new System.Windows.Forms.TextBox();
			this.upDwnRadius = new System.Windows.Forms.NumericUpDown();
			this.upDwnMaxPrice = new System.Windows.Forms.NumericUpDown();
			this.upDwnMinPrice = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.upDwnRadius)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.upDwnMaxPrice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.upDwnMinPrice)).BeginInit();
			this.SuspendLayout();
			// 
			// chkBoxCondition
			// 
			this.chkBoxCondition.CheckOnClick = true;
			this.chkBoxCondition.FormattingEnabled = true;
			this.chkBoxCondition.Location = new System.Drawing.Point(15, 94);
			this.chkBoxCondition.Name = "chkBoxCondition";
			this.chkBoxCondition.Size = new System.Drawing.Size(121, 94);
			this.chkBoxCondition.TabIndex = 0;
			this.chkBoxCondition.ThreeDCheckBoxes = true;
			// 
			// lblCondition
			// 
			this.lblCondition.AutoSize = true;
			this.lblCondition.Location = new System.Drawing.Point(31, 78);
			this.lblCondition.Name = "lblCondition";
			this.lblCondition.Size = new System.Drawing.Size(84, 13);
			this.lblCondition.TabIndex = 1;
			this.lblCondition.Text = "Select Condition";
			// 
			// txtBoxSearch
			// 
			this.txtBoxSearch.AllowDrop = true;
			this.txtBoxSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.txtBoxSearch.Location = new System.Drawing.Point(62, 38);
			this.txtBoxSearch.Name = "txtBoxSearch";
			this.txtBoxSearch.Size = new System.Drawing.Size(205, 20);
			this.txtBoxSearch.TabIndex = 2;
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(12, 41);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(44, 13);
			this.lblSearch.TabIndex = 3;
			this.lblSearch.Text = "Search:";
			// 
			// lblMinPrice
			// 
			this.lblMinPrice.AutoSize = true;
			this.lblMinPrice.Location = new System.Drawing.Point(154, 94);
			this.lblMinPrice.Name = "lblMinPrice";
			this.lblMinPrice.Size = new System.Drawing.Size(78, 13);
			this.lblMinPrice.TabIndex = 5;
			this.lblMinPrice.Text = "Minimum Price:";
			// 
			// lblMaxPrice
			// 
			this.lblMaxPrice.AutoSize = true;
			this.lblMaxPrice.Location = new System.Drawing.Point(154, 120);
			this.lblMaxPrice.Name = "lblMaxPrice";
			this.lblMaxPrice.Size = new System.Drawing.Size(81, 13);
			this.lblMaxPrice.TabIndex = 7;
			this.lblMaxPrice.Text = "Maximum Price:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(154, 172);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Search Radius (Miles):";
			// 
			// lblZipCode
			// 
			this.lblZipCode.AutoSize = true;
			this.lblZipCode.Location = new System.Drawing.Point(154, 146);
			this.lblZipCode.Name = "lblZipCode";
			this.lblZipCode.Size = new System.Drawing.Size(53, 13);
			this.lblZipCode.TabIndex = 9;
			this.lblZipCode.Text = "Zip Code:";
			// 
			// txtBoxZipCode
			// 
			this.txtBoxZipCode.Location = new System.Drawing.Point(273, 143);
			this.txtBoxZipCode.MaxLength = 5;
			this.txtBoxZipCode.Name = "txtBoxZipCode";
			this.txtBoxZipCode.Size = new System.Drawing.Size(210, 20);
			this.txtBoxZipCode.TabIndex = 8;
			// 
			// lblCategory
			// 
			this.lblCategory.AutoSize = true;
			this.lblCategory.Location = new System.Drawing.Point(288, 41);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(52, 13);
			this.lblCategory.TabIndex = 15;
			this.lblCategory.Text = "Category:";
			// 
			// lblState
			// 
			this.lblState.AutoSize = true;
			this.lblState.Location = new System.Drawing.Point(11, 15);
			this.lblState.Name = "lblState";
			this.lblState.Size = new System.Drawing.Size(70, 13);
			this.lblState.TabIndex = 13;
			this.lblState.Text = "CraigslistURL";
			// 
			// ddlCategory
			// 
			this.ddlCategory.FormattingEnabled = true;
			this.ddlCategory.Location = new System.Drawing.Point(343, 38);
			this.ddlCategory.Name = "ddlCategory";
			this.ddlCategory.Size = new System.Drawing.Size(140, 21);
			this.ddlCategory.TabIndex = 16;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(15, 195);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(468, 23);
			this.btnSearch.TabIndex = 18;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtBoxCraigslistURL
			// 
			this.txtBoxCraigslistURL.Location = new System.Drawing.Point(130, 12);
			this.txtBoxCraigslistURL.Name = "txtBoxCraigslistURL";
			this.txtBoxCraigslistURL.Size = new System.Drawing.Size(353, 20);
			this.txtBoxCraigslistURL.TabIndex = 20;
			this.txtBoxCraigslistURL.Text = "https://maine.craigslist.org/";
			// 
			// upDwnRadius
			// 
			this.upDwnRadius.Location = new System.Drawing.Point(273, 168);
			this.upDwnRadius.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.upDwnRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.upDwnRadius.Name = "upDwnRadius";
			this.upDwnRadius.Size = new System.Drawing.Size(210, 20);
			this.upDwnRadius.TabIndex = 21;
			this.upDwnRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// upDwnMaxPrice
			// 
			this.upDwnMaxPrice.Location = new System.Drawing.Point(273, 117);
			this.upDwnMaxPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.upDwnMaxPrice.Name = "upDwnMaxPrice";
			this.upDwnMaxPrice.Size = new System.Drawing.Size(210, 20);
			this.upDwnMaxPrice.TabIndex = 22;
			this.upDwnMaxPrice.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			// 
			// upDwnMinPrice
			// 
			this.upDwnMinPrice.Location = new System.Drawing.Point(273, 87);
			this.upDwnMinPrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.upDwnMinPrice.Name = "upDwnMinPrice";
			this.upDwnMinPrice.Size = new System.Drawing.Size(210, 20);
			this.upDwnMinPrice.TabIndex = 23;
			// 
			// frmScrapper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 223);
			this.Controls.Add(this.upDwnMinPrice);
			this.Controls.Add(this.upDwnMaxPrice);
			this.Controls.Add(this.upDwnRadius);
			this.Controls.Add(this.txtBoxCraigslistURL);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.ddlCategory);
			this.Controls.Add(this.lblCategory);
			this.Controls.Add(this.lblState);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblZipCode);
			this.Controls.Add(this.txtBoxZipCode);
			this.Controls.Add(this.lblMaxPrice);
			this.Controls.Add(this.lblMinPrice);
			this.Controls.Add(this.lblSearch);
			this.Controls.Add(this.txtBoxSearch);
			this.Controls.Add(this.lblCondition);
			this.Controls.Add(this.chkBoxCondition);
			this.Name = "frmScrapper";
			this.Text = "Scrapper";
			((System.ComponentModel.ISupportInitialize)(this.upDwnRadius)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.upDwnMaxPrice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.upDwnMinPrice)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox chkBoxCondition;
		private System.Windows.Forms.Label lblCondition;
		private System.Windows.Forms.TextBox txtBoxSearch;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.Label lblMinPrice;
		private System.Windows.Forms.Label lblMaxPrice;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblZipCode;
		private System.Windows.Forms.TextBox txtBoxZipCode;
		private System.Windows.Forms.Label lblCategory;
		private System.Windows.Forms.Label lblState;
		private System.Windows.Forms.ComboBox ddlCategory;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox txtBoxCraigslistURL;
		private System.Windows.Forms.NumericUpDown upDwnRadius;
		private System.Windows.Forms.NumericUpDown upDwnMaxPrice;
		private System.Windows.Forms.NumericUpDown upDwnMinPrice;
	}
}

