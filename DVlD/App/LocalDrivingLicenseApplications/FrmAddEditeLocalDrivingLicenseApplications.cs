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
    public partial class FrmAddEditeLocalDrivingLicenseApplications : Form
    {
        private enum _EnMode { Add=0 ,Update=1};

        private int _LocalDrivingLicenseApplicationsID = -1;
        private ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationsInfo;
        private _EnMode _mode;


        
        public FrmAddEditeLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _mode = _EnMode.Add;
        }
        public FrmAddEditeLocalDrivingLicenseApplications(int ID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationsID=ID;
            _mode = _EnMode.Update;
        }


        
        private void _FillLicenseClassComboBox()
        {
           DataTable td = ClsLicenseClasses.GetAll();
            
            foreach (DataRow item in td.Rows)
           {
                cmbLicenseClass.Items.Add(item["ClassName"]);
           }
        }
        private void _ResiteInfo()
        {
            _FillLicenseClassComboBox();

            if (_mode == _EnMode.Add)
            {
                this.Text="Add New Local Driving License Application";
                lblTitle.Text="New Local Driving License Application";


                _LocalDrivingLicenseApplicationsInfo=new ClsLocalDrivingLicenseApplication();

                tpApplicationInfo.Enabled=false;

                ctrlPersonCardWithFilter1.FocusFilterGroup();


                lblLocalDrivingLicenseApplicatiioinID.Text="[?????]";
                lblApplicationDate.Text=DateTime.Now.ToShortDateString();

                cmbLicenseClass.SelectedIndex=0;
                //this is fees for application type not for licenseClass
                lblApplicationFees.Text=ClsApplicationTypes.Find((int) ClsApplication.EnApplicationType.NewLocalDrivingLicense).ApplicationFees.ToString();

                lblCreatedBy.Text=ClsGlobalUser.CurrentUser.UserName;

            }
            else
            {
                this.Text="Update  Local Driving License Application";
                lblTitle.Text="Update Local Driving License Application";

                tpApplicationInfo.Enabled=true;
                ctrlPersonCardWithFilter1.EnableFilterGroup=false;
                btnSave.Enabled=true;
            }

          
            


        }
        private void _loadLicenseInfo()
        {
            _LocalDrivingLicenseApplicationsInfo=ClsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationsID);

            if (_LocalDrivingLicenseApplicationsInfo==null)
            {
                if(MessageBox.Show("The Local Driving License Application with ID "+_LocalDrivingLicenseApplicationsID+" not found,We close the form", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error)==DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplicationsInfo.ApplicationPersonID);

            lblLocalDrivingLicenseApplicatiioinID.Text=_LocalDrivingLicenseApplicationsInfo.LocalDrivingLicenseApplicationID.ToString();

            lblApplicationDate.Text=_LocalDrivingLicenseApplicationsInfo.ApplicationDate.ToShortDateString() ;

            cmbLicenseClass.SelectedIndex=cmbLicenseClass.FindString(ClsLicenseClasses.Find(_LocalDrivingLicenseApplicationsInfo.LicenseClassID).ClassName);
            //local dirving license application inherity from application so it have its properity and methode
            lblApplicationFees.Text=_LocalDrivingLicenseApplicationsInfo.PaidFees.ToString();
            
            lblCreatedBy.Text=ClsUser.Find(_LocalDrivingLicenseApplicationsInfo.CreatedByUserID).UserName;


        }

        private void FrmAddEditeLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _ResiteInfo();
            if(_mode == _EnMode.Update)
            {
                _loadLicenseInfo();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_mode==_EnMode.Update)
            {
                btnSave.Enabled = true;

                tpApplicationInfo.Enabled=true;

                tcApplicationInfo.SelectedIndex=1;
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonId!=-1)
            {
                btnSave.Enabled=true;
                tpApplicationInfo.Enabled=true;
                tcApplicationInfo.SelectedIndex=1;
            }
            else
            {
                MessageBox.Show("Please Select a Person to Add New Local Driving License Application", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate=AutoValidate.Disable;
            this.Close();

        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {
                MessageBox.Show("Please correct the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            int LicensesClassID = ClsLicenseClasses.Find(cmbLicenseClass.Text).LicenseClassID;

            //if not equel to -1  this mean there is active appplication for this licess orredy exsit
            bool HaveActiveApplication = ClsLocalDrivingLicenseApplication.GetActiveApplicationIDFroLicense(ctrlPersonCardWithFilter1.PersonId, ClsApplication.EnApplicationType.NewLocalDrivingLicense, LicensesClassID)!=-1;

            if (HaveActiveApplication)
            {
                MessageBox.Show("The person already has an active application for the specified license class.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (ClsLicenses.IsExsit(ctrlPersonCardWithFilter1.PersonId, LicensesClassID))
            {
                MessageBox.Show("The person already has a license of the specified class.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LocalDrivingLicenseApplicationsInfo.LicenseClassID = LicensesClassID;
            _LocalDrivingLicenseApplicationsInfo.ApplicationPersonID= ctrlPersonCardWithFilter1.PersonId;
           // _LocalDrivingLicenseApplicationsInfo.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplicationsInfo.ApplicationTypeID=(int)ClsApplication.EnApplicationType.NewLocalDrivingLicense;
            _LocalDrivingLicenseApplicationsInfo.ApplicationStatus=ClsApplication.EnApplicationStatus.New;
            _LocalDrivingLicenseApplicationsInfo.LastStatusDate= DateTime.Now;
            _LocalDrivingLicenseApplicationsInfo.PaidFees=Convert.ToSingle(lblApplicationFees.Text);
            _LocalDrivingLicenseApplicationsInfo.CreatedByUserID=ClsGlobalUser.CurrentUser.UserID;

            if (_LocalDrivingLicenseApplicationsInfo.Save())
            {
                this.Text="Update  Local Driving License Application";
                lblTitle.Text="Update Local Driving License Application";

                _mode=_EnMode.Update;

                lblLocalDrivingLicenseApplicatiioinID.Text=_LocalDrivingLicenseApplicationsInfo.LocalDrivingLicenseApplicationID.ToString();

                MessageBox.Show("The Local Driving License Application has been saved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The Local Driving License Application has not been saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmAddEditeLocalDrivingLicenseApplications_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FocusFilterGroup();
        }
    }
}
