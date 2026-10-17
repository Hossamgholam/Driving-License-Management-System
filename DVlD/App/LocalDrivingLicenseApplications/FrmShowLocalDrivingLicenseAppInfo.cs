using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD.App.LocalDrivingLicenseApplications
{
    public partial class FrmShowLocalDrivingLicenseAppInfo : Form
    {
        public FrmShowLocalDrivingLicenseAppInfo(int LocalDrivingLicenseID)
        {
            InitializeComponent();

            ctrDrivingLicenseApplicationInfo1.LoadInfo(LocalDrivingLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
