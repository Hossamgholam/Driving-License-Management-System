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

namespace DVlD.App.LocalDrivingLicenseApplications
{
    public partial class CtrDrivingLicenseApplicationInfo : UserControl
    {

        private int _LocalDrivingLicenseApplicationID = -1;
        private ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public int LocalDrivingLicenseApplicationID { get { return _LocalDrivingLicenseApplicationID; } }

        public CtrDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        private void _ResetInfo()
        {
            lblLocalDrivingLicenseApplicatiioinID.Text="[?????]";
            lblLicenseClass.Text="[?????]";
            lblPassedTests.Text="0";

            lnkShowLicenseInfo.Enabled=false;

            ctrApplicationBasicInfo1.LoadInfo(-1);

           

        }
        private void _FillInfo()
        {
            lblLocalDrivingLicenseApplicatiioinID.Text=_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString() ;
            
            lblLicenseClass.Text=_LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;

            //function to git passed test
            lblPassedTests.Text="0";

            //GetActiveLicenseID in local
            lnkShowLicenseInfo.Enabled=true;
            ctrApplicationBasicInfo1.LoadInfo(_LocalDrivingLicenseApplication.ApplicationID);

           

        }
        public void LoadInfo(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication=ClsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);

            if( _LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Local Driving License Application Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetInfo();
                return;
            }
            _FillInfo();
        }
        public void LoadInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplication=ClsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Local Driving License Application Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetInfo();
                return;
            }
            _FillInfo();
        }


    }
}
