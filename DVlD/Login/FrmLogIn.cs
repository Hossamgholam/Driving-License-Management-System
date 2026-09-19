using DVIDBusinessLayer;
using DVlD.Global_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD.Login
{
    public partial class FrmLogIn : Form
    {
        public FrmLogIn()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
           
            if(ClsGlobalUser.GetStoredCreditional(ref UserName,ref Password)){
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                ChkRemember.Checked = true;
            }
            else
            {
                txtUserName.Text = "";
                txtPassword.Text="";
                ChkRemember.Checked= false;
            }
            
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            ClsUser user=ClsUser.FindByUserNamePassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (user==null)
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid UserName or Password", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (ChkRemember.Checked)
                {
                    ClsGlobalUser.RememberMe(txtUserName.Text.Trim() ,txtPassword.Text.Trim());
                }
                else
                {
                    ClsGlobalUser.RememberMe("", "");
                }

                //check is active 

                if (!user.IsActive)
                {
                    MessageBox.Show("Your account is not active. Please contact the administrator.", "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClsGlobalUser.CurrentUser=user;

                // Clear the text boxes after successful login because the user might log out and log in with different credentials
                if(!ChkRemember.Checked)
                {
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                }


                this.Hide();
                FrmMain main = new FrmMain(this);
                main.ShowDialog ();
            }
        }
    }
}
