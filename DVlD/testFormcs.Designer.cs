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
            this.ctrlPersonCardWithFilter1 = new DVlD.People.Controls.CtrlPersonCardWithFilter();
            this.SuspendLayout();
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(35, 12);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(845, 574);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // testFormcs
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(957, 603);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Name = "testFormcs";
            this.Text = "testFormcs";
            this.Load += new System.EventHandler(this.testFormcs_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private People.Controls.CtrlPersonCardWithFilter ctrlPersonCardWithFilter1;
    }
}