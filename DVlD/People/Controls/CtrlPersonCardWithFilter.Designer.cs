namespace DVlD.People.Controls
{
    partial class CtrlPersonCardWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GbFilter = new System.Windows.Forms.GroupBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.TxtFilter = new System.Windows.Forms.TextBox();
            this.CmbFilter = new System.Windows.Forms.ComboBox();
            this.lblPersonIDText = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonCardInfo = new DVlD.ctrlPersonCard();
            this.GbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // GbFilter
            // 
            this.GbFilter.BackColor = System.Drawing.Color.White;
            this.GbFilter.Controls.Add(this.btnAddPerson);
            this.GbFilter.Controls.Add(this.btnSearch);
            this.GbFilter.Controls.Add(this.TxtFilter);
            this.GbFilter.Controls.Add(this.CmbFilter);
            this.GbFilter.Controls.Add(this.lblPersonIDText);
            this.GbFilter.Location = new System.Drawing.Point(13, 14);
            this.GbFilter.Name = "GbFilter";
            this.GbFilter.Size = new System.Drawing.Size(818, 92);
            this.GbFilter.TabIndex = 1;
            this.GbFilter.TabStop = false;
            this.GbFilter.Text = "Filter";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::DVlD.Properties.Resources.AddPerson_321;
            this.btnAddPerson.Location = new System.Drawing.Point(727, 34);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(52, 43);
            this.btnAddPerson.TabIndex = 72;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::DVlD.Properties.Resources.SearchPerson;
            this.btnSearch.Location = new System.Drawing.Point(669, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 43);
            this.btnSearch.TabIndex = 71;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // TxtFilter
            // 
            this.TxtFilter.BackColor = System.Drawing.SystemColors.Control;
            this.TxtFilter.Location = new System.Drawing.Point(397, 41);
            this.TxtFilter.Name = "TxtFilter";
            this.TxtFilter.Size = new System.Drawing.Size(248, 30);
            this.TxtFilter.TabIndex = 70;
            this.TxtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFilter_KeyPress);
            this.TxtFilter.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFilter_Validating);
            // 
            // CmbFilter
            // 
            this.CmbFilter.BackColor = System.Drawing.SystemColors.Control;
            this.CmbFilter.FormattingEnabled = true;
            this.CmbFilter.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.CmbFilter.Location = new System.Drawing.Point(131, 41);
            this.CmbFilter.Name = "CmbFilter";
            this.CmbFilter.Size = new System.Drawing.Size(248, 31);
            this.CmbFilter.TabIndex = 69;
            this.CmbFilter.SelectedIndexChanged += new System.EventHandler(this.CmbFilter_SelectedIndexChanged);
            // 
            // lblPersonIDText
            // 
            this.lblPersonIDText.BackColor = System.Drawing.Color.Transparent;
            this.lblPersonIDText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonIDText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblPersonIDText.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPersonIDText.Location = new System.Drawing.Point(25, 40);
            this.lblPersonIDText.Name = "lblPersonIDText";
            this.lblPersonIDText.Size = new System.Drawing.Size(100, 30);
            this.lblPersonIDText.TabIndex = 68;
            this.lblPersonIDText.Text = "Find By:";
            this.lblPersonIDText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCardInfo
            // 
            this.ctrlPersonCardInfo.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCardInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonCardInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ctrlPersonCardInfo.Location = new System.Drawing.Point(15, 122);
            this.ctrlPersonCardInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrlPersonCardInfo.Name = "ctrlPersonCardInfo";
            this.ctrlPersonCardInfo.Size = new System.Drawing.Size(816, 353);
            this.ctrlPersonCardInfo.TabIndex = 2;
            // 
            // CtrlPersonCardWithFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.ctrlPersonCardInfo);
            this.Controls.Add(this.GbFilter);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Name = "CtrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(845, 488);
            this.Load += new System.EventHandler(this.CtrlPersonCardWithFilter_Load);
            this.GbFilter.ResumeLayout(false);
            this.GbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.GroupBox GbFilter;
        private System.Windows.Forms.TextBox TxtFilter;
        private System.Windows.Forms.ComboBox CmbFilter;
        private System.Windows.Forms.Label lblPersonIDText;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ctrlPersonCard ctrlPersonCardInfo;
    }
}
