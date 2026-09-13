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
    public partial class FrmShowUserInfo : Form
    {
        private int _userID;
        public FrmShowUserInfo(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUser(_userID);
        }
    }
}
