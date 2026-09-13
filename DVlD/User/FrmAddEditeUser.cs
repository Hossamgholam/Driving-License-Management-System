using DevExpress.Utils.DirectXPaint;
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
    public partial class FrmAddEditeUser : Form
    {
        private enum EnMode { Add = 0, Update = 1 }

        private int _UserID=-1;
        private ClsUser _User;

        private EnMode _EnMode;

        public FrmAddEditeUser()
        {
            InitializeComponent();
            _EnMode = EnMode.Add;
        }
        public FrmAddEditeUser(int userID)
        {
            InitializeComponent();
            _UserID = userID;
            _EnMode=EnMode.Update;
        }



        //private methods for resite the form and load the data if the mode is update
        private void _ResiteInfo()
        {
            if (_EnMode==EnMode.Add)
            {
                this.Text="Add User";
                lblTitle.Text="Add New User";

                _User= new ClsUser();

                tpLongIngInfo.Enabled=false;
               
            }
            else
            {
                this.Text="Update User";
                lblTitle.Text="Update Exsit User";

                ctrlPersonCardWithFilter1.EnableFilterGroup=false;

                tpLongIngInfo.Enabled=true;
                btnNext.Enabled =true;
            }

            lblUserId.Text="???";
            txtUserName.Text="";
            txtPassword.Text="";
            txtConfirmPassword.Text="";
            chkIsActive.Checked=true ;
        }
        private void _LoadDate()
        {
            _User=ClsUser.Find(_UserID);
            if (_User==null)
            {
                MessageBox.Show($"the User with Id {_UserID} not Exsit", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);

            lblUserId.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text=_User.Password;
            chkIsActive.Checked=_User.IsActive;
        }
        private void FrmAddEditeUser_Load(object sender, EventArgs e)
        {
            _ResiteInfo();
            if (_EnMode==EnMode.Update)
            {
                _LoadDate();
            }
        }



        //porson select event useful for resite the form if we back and select another person
        private void ctrlPersonCardWithFilter1_PersonSelect(int obj)
        {

            _ResiteInfo();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_EnMode==EnMode.Update)
            {
                tpLongIngInfo.Enabled=true;
                //to go to Log in tab
                tcUserInfo.SelectedIndex=1;
                return;
            }

            // Check if a person is selected for add
            if (ctrlPersonCardWithFilter1.PersonId==-1)
            {
                MessageBox.Show("Please select a person first.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (ClsUser.IsExistByPersonID(ctrlPersonCardWithFilter1.PersonId))
                {
                    MessageBox.Show("The selected person is already associated with an existing user. Please select a different person.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                    
                }
                else
                {

                    tpLongIngInfo.Enabled=true;
                    // Move to the next tab page
                    tcUserInfo.SelectedIndex=1;
                }
            }
        }


        //validation events
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtUserName, "User Name cannot be empty.");
            }
            else
            {




                if (_EnMode==EnMode.Add)
                {
                    if (ClsUser.IsExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "User Name already exists.");
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }
                }
                else
                {
                    if (_User.UserName!=txtUserName.Text.Trim())
                    {
                        if (ClsUser.IsExist(txtUserName.Text.Trim()))
                        {
                            e.Cancel = true;
                            errorProvider1.SetError(txtUserName, "User Name already exists.");
                        }
                        else
                        {
                            errorProvider1.SetError(txtUserName, "");
                        }
                    }
                }
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be empty.");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
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
                if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
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
            if(!this.ValidateChildren())
            {

                return;
            }
            //loding data to object in case of add or update to save
            _User.PersonID=ctrlPersonCardWithFilter1.PersonId;
            _User.UserName=txtUserName.Text.Trim();
            _User.Password=txtPassword.Text.Trim();
            _User.IsActive=chkIsActive.Checked;

            if(_User.Save())
            {
                MessageBox.Show("User information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                lblUserId.Text=_User.UserID.ToString();
                this.Text="Update User";
                lblTitle.Text="Update Exsit User";

                _EnMode=EnMode.Update;

            }
            else
            {
                MessageBox.Show("Failed to save user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
