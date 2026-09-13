using DVIDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD.User
{
    public partial class FrmChangePassword : Form
    {
        private int _UserID = -1;
        private ClsUser _User;
       
        public FrmChangePassword(int userID)
        {
            InitializeComponent();
           _UserID = userID;

        }
        private void _ResiteInfo()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            
        }
        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            _ResiteInfo();

            _User=ClsUser.Find(_UserID);
            if (_User==null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlUserCard1.LoadUser(_UserID);
        }

        //validation
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password cannot be empty.");
            }
            else
            {
                if (txtCurrentPassword.Text.Trim()!=_User.Password) {
                    e.Cancel= true;
                    errorProvider1.SetError(txtCurrentPassword, "Current Password Wrong.");
                }
                else
                {
                    errorProvider1.SetError(txtCurrentPassword, null);
                }
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Password cannot be empty.");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
            ;
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Please confirm your password.");
            }
            else
            {
                if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
                {
                    e.Cancel=true;
                    errorProvider1.SetError(txtConfirmPassword, "Passwords do not match.");
                }
                else
                {
                    errorProvider1.SetError(txtConfirmPassword, null);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //i don not use static method to change password because
            //after changing password i want to update the user object in memory
            _User.Password = txtNewPassword.Text.Trim();
            if (_User.Save())
            {
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResiteInfo();
                
                txtCurrentPassword.Focus();
            }
            else
            {
                MessageBox.Show("Failed to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
