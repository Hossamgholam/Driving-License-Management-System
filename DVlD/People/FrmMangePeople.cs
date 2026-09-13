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

namespace DVlD.People
{
    public partial class FrmMangePeople : Form
    {
        public FrmMangePeople()
        {
            InitializeComponent();
        }
        private static DataTable _DgvPersonsAllCoumnu = ClsPerson.GetAllPerson();
        private DataTable _DgvPersonsSelectedCoumnu = _DgvPersonsAllCoumnu.DefaultView
            .ToTable(false, "PersonID","NationalNo", "FirstName","SecondName", "ThirdName","LastName",
                "Gender", "CountryName","Phone", "Email");
      


        //refresh person info in data grade after Data change in Database
        private void _RefreshDataGridView()
        {
         _DgvPersonsAllCoumnu = ClsPerson.GetAllPerson();

         _DgvPersonsSelectedCoumnu =_DgvPersonsAllCoumnu.DefaultView
            .ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName",
                "Gender", "CountryName", "Phone", "Email");


            
         dgvPeople.DataSource= _DgvPersonsSelectedCoumnu;
         lblRecords.Text=_DgvPersonsAllCoumnu.Rows.Count.ToString();

            
            _StartFilter();
            
            
         
            
           
        }


        //form loading
        private void FrmMangePeople_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource=_DgvPersonsSelectedCoumnu;
            lblRecords.Text=_DgvPersonsAllCoumnu.Rows.Count.ToString();

            cbFilterBy.SelectedIndex=0;

            if (dgvPeople.Rows.Count>0)
            {
                dgvPeople.Columns[0].HeaderText="Person ID";
                dgvPeople.Columns[0].Width=100;

                dgvPeople.Columns[1].HeaderText="National No";
                dgvPeople.Columns[1].Width=120;

                dgvPeople.Columns[2].HeaderText="First Name";
                dgvPeople.Columns[2].Width=120;

                dgvPeople.Columns[3].HeaderText="Second Name";
                dgvPeople.Columns[3].Width=130;

                dgvPeople.Columns[4].HeaderText="Third Name";
                dgvPeople.Columns[4].Width=120;

                dgvPeople.Columns[5].HeaderText="Last Name";
                dgvPeople.Columns[5].Width=120;

                dgvPeople.Columns[6].HeaderText="Gender";
                dgvPeople.Columns[6].Width=100;

                dgvPeople.Columns[7].HeaderText="Nationality";
                dgvPeople.Columns[7].Width=120;

                dgvPeople.Columns[8].HeaderText="Phone";
                dgvPeople.Columns[8].Width=120;

                dgvPeople.Columns[9].HeaderText="Email";
                dgvPeople.Columns[9].Width=200;
            }
        }
        
        
        //filtering Function
        private void _StartFilter()
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn="PersonID";
                    break;

                case "National No":
                    FilterColumn="NationalNo";
                    break;
                case "First Name":
                    FilterColumn="FirstName";
                    break;
                case "Second Name":
                    FilterColumn="SecondName";
                    break;
                case "Third Name":
                    FilterColumn="ThirdName";
                    break;
                case "Last Name":
                    FilterColumn="LastName";
                    break;
                case "Nationality":
                    FilterColumn="CountryName";
                    break;
                case "Gendor":
                    FilterColumn="Gender";
                    break;
                case "Phone":
                    FilterColumn="Phone";
                    break;
                case "Email":
                    FilterColumn="Email";
                    break;
                default:
                    FilterColumn="None";
                    break;
            }

            if (FilterColumn=="None"||txtFilter.Text=="")
            {
                _DgvPersonsSelectedCoumnu.DefaultView.RowFilter="";
                lblRecords.Text=_DgvPersonsSelectedCoumnu.Rows.Count.ToString();
                return;
            }

            if (FilterColumn=="PersonID")
            {
                _DgvPersonsSelectedCoumnu.DefaultView.RowFilter=$"PersonID={txtFilter.Text.Trim()}";
                lblRecords.Text=dgvPeople.Rows.Count.ToString();
            }
            else
            {
                _DgvPersonsSelectedCoumnu.DefaultView.RowFilter=$"{FilterColumn} like '{txtFilter.Text.Trim()}%'";
                lblRecords.Text=dgvPeople.Rows.Count.ToString();
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

            _StartFilter();
            
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString()=="None")
            {
                txtFilter.Visible = false;
                return;
            }
            txtFilter.Visible=true;
            txtFilter.Text="";
            txtFilter.Focus();

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text=="Person ID")
            {
                e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
            }
        }


        
        


        //CRUD Operation
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm= new FrmAddEditPeople();
            frm.ShowDialog();
            _RefreshDataGridView();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnAddPerson_Click(sender, e);
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form form = new FrmAddEditPeople((int)dgvPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshDataGridView();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            if(MessageBox.Show("Are you sure you want to delete this person?", "Delete Person", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                
                if(ClsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person deleted successfully.", "Delete Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Failed to delete person. Person related records exist.", "Delete Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FrmShowPersonInfo frm = new FrmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        



        //Feature under working
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                            "This feature is currently under development and will be available in a future version.",
                            "Send Email",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
        }
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                            "Phone calling functionality is not available yet.",
                            "Phone",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                             );
        }



        //close form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
