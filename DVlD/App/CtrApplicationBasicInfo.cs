using DVIDBusinessLayer;
using DVlD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD.App
{
    public partial class CtrApplicationBasicInfo : UserControl
    {
        private int _ApplicationID = -1;
        private ClsApplication _ApplicationInof;

        public int ApplicationID { get { return _ApplicationID; } }

        public CtrApplicationBasicInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// when i find Exsit ApplicationID then fill the info in the control and if i requested ApplicationID not found then reset the control to default values
        private void _ResiteInfo()
        {
            lblAppID.Text = "[??????]";
            lblAppStatus.Text = "[??????]";
            lblAppFees.Text = "0.00";
            lblAppType.Text = "[??????]";
            lblPersonFullName.Text = "[??????]";
            LnkViewPersonInfo.Enabled= false;
            lblAppDate.Text = "dd/MM/yyyy";
            lblAppStatusData.Text = "dd/MM/yyyy";
            lblCreatedBy.Text = "[??????]";

        }
        private void FillInfo()
        {
            lblAppID.Text = _ApplicationInof.ApplicationID.ToString() ;
            lblAppStatus.Text = _ApplicationInof.StatusName;
            lblAppFees.Text = _ApplicationInof.PaidFees.ToString();
            lblAppType.Text = _ApplicationInof.ApplicationTypesInfo.ApplicationTypesTitle;
            lblPersonFullName.Text = _ApplicationInof.PersonInfo.FullName;
            LnkViewPersonInfo.Enabled= true;
            lblAppDate.Text = _ApplicationInof.ApplicationDate.ToShortDateString();
            lblAppStatusData.Text = _ApplicationInof.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = _ApplicationInof.UserInfo.UserName;
        }
        public void LoadInfo(int ApplicationID)
        {
            _ApplicationInof=ClsApplication.Find(ApplicationID);
            if (_ApplicationInof == null)
            {
                
                _ResiteInfo();
                return;
            }
            FillInfo();
        }

        private void LnkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new FrmShowPersonInfo(_ApplicationInof.ApplicationPersonID);
            frm.Show();
        }
    }
}
