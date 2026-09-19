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

namespace DVlD.App.ApplicationType
{
    public partial class FrmManageApplication : Form
    {
        private DataTable _DTApplication = ClsApplicationTypes.GetAll();

        public FrmManageApplication()
        {
            InitializeComponent();

            
        }

        private void _RefreshDataGridView()
        {
            _DTApplication=ClsApplicationTypes.GetAll();

            dgvApplication.DataSource= _DTApplication;
            lblRecords.Text=_DTApplication.Rows.Count.ToString();

            if (_DTApplication.Rows.Count>0)
            {

                
                dgvApplication.Columns[0].Width=50;

                
                dgvApplication.Columns[1].Width=250;


                dgvApplication.Columns[2].Width=100;




            }

        }
        private void FrmManageApplication_Load(object sender, EventArgs e)
        {
            _RefreshDataGridView();
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FrmUpdateApplication((int)dgvApplication.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshDataGridView();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

    }
}
