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

namespace DVlD.Tests.TestType
{
    public partial class FrmManageTestType : Form
    {
        private static DataTable dtTestTabl = ClsTestTypes.GetAll();
        public FrmManageTestType()
        {
            InitializeComponent();
        }

        private void FrmManageTestType_Load(object sender, EventArgs e)
        {
            dtTestTabl=ClsTestTypes.GetAll();

            dgvTestType.DataSource = dtTestTabl;
            lblRecords.Text=dgvTestType.Rows.Count.ToString();

            if (dgvTestType.Rows.Count>0)
            {

                dgvTestType.Columns[0].HeaderText="ID";
                dgvTestType.Columns[0].Width=50;

                dgvTestType.Columns[1].HeaderText="title";
                dgvTestType.Columns[1].Width=100;

                dgvTestType.Columns[2].HeaderText="Description";
                dgvTestType.Columns[2].Width=250;

                dgvTestType.Columns[3].HeaderText="Fees";
                dgvTestType.Columns[3].Width=100;




            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FrmUpdateTest((int)dgvTestType.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            FrmManageTestType_Load(null, null);
        }
    }
}
