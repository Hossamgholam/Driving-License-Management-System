using DVlD.App.ApplicationType;
using DVlD.Global_Class;
using DVlD.Login;
using DVlD.People;
using DVlD.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD
{
    public partial class FrmMain : Form
    {
        private FrmLogIn _frmLogIn;
        public FrmMain(FrmLogIn frmLogIn)
        {
            InitializeComponent();
            _frmLogIn = frmLogIn;
        }

        private void PeopleMenuStripItem_Click(object sender, EventArgs e)
        {
            Form frm=new FrmMangePeople();
            //frm.MdiParent=this;
            
            frm.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Form frm = new FrmMangeUser();
            frm.ShowDialog();
        }

        private void CurrentUserInfotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmShowUserInfo(ClsGlobalUser.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void ChangeasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm=new FrmChangePassword(ClsGlobalUser.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void SignOuttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsGlobalUser.CurrentUser = null;
            _frmLogIn.Show();
            this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmManageApplication();
            frm.ShowDialog();
        }
    }
}
