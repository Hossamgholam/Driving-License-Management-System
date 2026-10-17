namespace DVlD
{
    partial class testFormcs
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
            this.ctrDrivingLicenseApplicationInfo1 = new DVlD.App.LocalDrivingLicenseApplications.CtrDrivingLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // ctrDrivingLicenseApplicationInfo1
            // 
            this.ctrDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(56, 38);
            this.ctrDrivingLicenseApplicationInfo1.Name = "ctrDrivingLicenseApplicationInfo1";
            this.ctrDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(879, 422);
            this.ctrDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // testFormcs
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(957, 603);
            this.Controls.Add(this.ctrDrivingLicenseApplicationInfo1);
            this.Name = "testFormcs";
            this.Text = "testFormcs";
            this.Load += new System.EventHandler(this.testFormcs_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private App.LocalDrivingLicenseApplications.CtrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo1;
    }
}