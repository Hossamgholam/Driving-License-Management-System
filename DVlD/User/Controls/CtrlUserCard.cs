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

namespace DVlD.User.Controls
{
    public partial class CtrlUserCard : UserControl
    {
        private int _UserID=-1;
        private ClsUser _User;

        public int UserID { get { return _UserID; } }
        

        private void _ResiteUserInfo()
        {
            //to resite person info
            ctrlPersonCard1.LoadPersonInfo(-1);
            lblUserID.Text = "[?????]";
            lblUserName.Text="[?????]";
            lblIsActive.Text="[?????]";

        }
        private void _FillUserInfo()
        {
           ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text=_User.UserID.ToString();
            lblUserName.Text=_User.UserName.ToString();
            lblIsActive.Text=_User.IsActive ? "Yes" : "No";
        }
       
        public void LoadUser(int userID)
        {
            _User = ClsUser.Find(userID);

            if(_User == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResiteUserInfo();
                return;
            }
            _FillUserInfo();
        }
        
        public CtrlUserCard()
        {
            InitializeComponent();
        }
    }
}
