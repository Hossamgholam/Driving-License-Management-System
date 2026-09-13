using DevExpress.XtraEditors.Filtering;
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

namespace DVlD.User
{
    public partial class FrmMangeUser : Form
    {
      
        private DataTable _DataGridViewUserCoulmn = ClsUser.GetAll();


        public FrmMangeUser()
        {
            InitializeComponent();
        }

        private void _RefreshDataGridView()
        {
            
            _DataGridViewUserCoulmn = ClsUser.GetAll();

            dgvUser.DataSource= _DataGridViewUserCoulmn;

            lblRecords.Text=_DataGridViewUserCoulmn.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;

            if (_DataGridViewUserCoulmn.Rows.Count>0)
            {
                dgvUser.Columns[0].HeaderText="User ID";
                dgvUser.Columns[0].Width=100;

                dgvUser.Columns[1].HeaderText="Person ID";
                dgvUser.Columns[1].Width=100;

                dgvUser.Columns[2].HeaderText="Full Name";
                dgvUser.Columns[2].Width=250;

                dgvUser.Columns[3].HeaderText="User Name";
                dgvUser.Columns[3].Width=150;

                dgvUser.Columns[4].HeaderText="Is Active";
                dgvUser.Columns[4].Width=100;

            }


        }
        private void FrmMangeUser_Load(object sender, EventArgs e)
        {

            _RefreshDataGridView();
        }



        //Filtering
        private void _StartFilter()
        {

            string ColumnFilter = "";
            switch (cbFilterBy.Text.Trim())
            {
                case "User ID":
                    ColumnFilter="UserID";
                    break;
                case "Person ID":
                    ColumnFilter="PersonID";
                    break;
                case "Full Name":
                    ColumnFilter="FullName";
                    break;
                case "User Name":
                    ColumnFilter="UserName";
                    break;
                case "Is Active":
                    ColumnFilter="IsActive";
                    break;
                default:
                    ColumnFilter="None";
                    break;
            }

            if (ColumnFilter =="None"||txtFilter.Text=="")
            {
                _DataGridViewUserCoulmn.DefaultView.RowFilter="";
                lblRecords.Text=_DataGridViewUserCoulmn.Rows.Count.ToString();
                return;
            }

             if (ColumnFilter =="UserID"||ColumnFilter=="PersonID")
             {
                _DataGridViewUserCoulmn.DefaultView.RowFilter=$"{ColumnFilter}={txtFilter.Text.Trim()}";
                lblRecords.Text=_DataGridViewUserCoulmn.Rows.Count.ToString();
             }
            else
            {
                _DataGridViewUserCoulmn.DefaultView.RowFilter=$"{ColumnFilter} like '{txtFilter.Text.Trim()}%'";
                lblRecords.Text=_DataGridViewUserCoulmn.Rows.Count.ToString();
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _StartFilter();
        }
        private void CbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (CbIsActive.Text)
            {
                
                case "Yes":
                    _DataGridViewUserCoulmn.DefaultView.RowFilter=$"IsActive =true";
                    break;
                case "No":
                    _DataGridViewUserCoulmn.DefaultView.RowFilter=$"IsActive =false";
                    break;
                default:
                    _DataGridViewUserCoulmn.DefaultView.RowFilter="";
                    break;
            }
            
            lblRecords.Text=_DataGridViewUserCoulmn.Rows.Count.ToString();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString()=="None") {

                CbIsActive.Visible= false;
                txtFilter.Visible= false;
                return;
            }
            if(cbFilterBy.SelectedItem.ToString()=="Is Active")
            {
                txtFilter.Visible = false;
                CbIsActive.Visible=true;
                CbIsActive.SelectedIndex=0;
                return;
            }
            CbIsActive.Visible = false;
            txtFilter.Visible=true;
            txtFilter.Focus();

        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text=="Person ID"||cbFilterBy.Text=="User ID")
            {
                e.Handled=!(char.IsDigit(e.KeyChar)||char.IsControl(e.KeyChar));
                
            }
            else if(cbFilterBy.Text=="Full Name")
            {
                e.Handled=!(char.IsLetter(e.KeyChar)||char.IsControl(e.KeyChar) );
            }
        }


        //CRUD Operation
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Form form = new FrmAddEditeUser();
            form.ShowDialog();
            _RefreshDataGridView();
        }
        private void AddNewUsertoolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddUser_Click(sender, e);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmShowUserInfo((int)dgvUser.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FrmAddEditeUser((int)dgvUser.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshDataGridView();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You Want to Delete This User?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes) {
                if (ClsUser.Delete((int)dgvUser.CurrentRow.Cells[0].Value)){
                    MessageBox.Show("User Deleted Successfully", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Failed to Delete User ", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Error);     
                }
                
            }
            
        }
         
        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FrmChangePassword((int)dgvUser.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshDataGridView();
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
        private void phoneCallToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(
                           "Phone calling functionality is not available yet.",
                           "Phone",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                            );
        }

        //Close 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate=AutoValidate.Disable;
            this.Close();
        }

    }
}
