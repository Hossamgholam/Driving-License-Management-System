using DVIDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD.App.LocalDrivingLicenseApplications
{
    public partial class FrmManageLocalDrivingLicenseApplication : Form
    {
        private static  DataTable _DtAllLocalDrivingLicensApplication;
        public FrmManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void FrmLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _DtAllLocalDrivingLicensApplication=ClsLocalDrivingLicenseApplication.GetAll();

            dgvLocalDrivingLicenseApplication.DataSource=_DtAllLocalDrivingLicensApplication;
            lblRecords.Text=dgvLocalDrivingLicenseApplication.Rows.Count.ToString();

            if (dgvLocalDrivingLicenseApplication.Rows.Count>0)
            {
                dgvLocalDrivingLicenseApplication.Columns[0].HeaderText="L.D.L AppID";
                dgvLocalDrivingLicenseApplication.Columns[0].Width=100;

                dgvLocalDrivingLicenseApplication.Columns[1].HeaderText="Class Name";
                dgvLocalDrivingLicenseApplication.Columns[1].Width=250;

                dgvLocalDrivingLicenseApplication.Columns[0].HeaderText="National No";
                dgvLocalDrivingLicenseApplication.Columns[0].Width=150;

                dgvLocalDrivingLicenseApplication.Columns[0].HeaderText="Full Name";
                dgvLocalDrivingLicenseApplication.Columns[0].Width=250;

                dgvLocalDrivingLicenseApplication.Columns[0].HeaderText="Application Date";
                dgvLocalDrivingLicenseApplication.Columns[0].Width=150;

                dgvLocalDrivingLicenseApplication.Columns[0].HeaderText="Pass Test";
                dgvLocalDrivingLicenseApplication.Columns[0].Width=100;

                dgvLocalDrivingLicenseApplication.Columns[0].HeaderText="Status";
                dgvLocalDrivingLicenseApplication.Columns[0].Width=100;


            }

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm= new FrmAddEditeLocalDrivingLicenseApplications();
            frm.ShowDialog();
            FrmLocalDrivingLicenseApplication_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate=AutoValidate.Disable;
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm=new FrmShowLocalDrivingLicenseAppInfo((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmAddEditeLocalDrivingLicenseApplications((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
