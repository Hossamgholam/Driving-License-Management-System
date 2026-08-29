using DVIDBusinessLayer;
using DVlD.People;
using DVlD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD
{
    public partial class ctrlPersonCard : UserControl
    {
        private ClsPerson _PersonInfo;
        private int _PersonID;

        public ClsPerson PersonInfo { get { return _PersonInfo; } }
        public int PersonID { get { return _PersonID; } }


        public ctrlPersonCard()
        {
            InitializeComponent();
            
        }

        private void _ResitPersonInfo()
        {
            LnkEditPerson.Enabled = false;
            lblPersonID.Text="[??????]";
            lblFullName.Text = "[??????]";
            lblEmail.Text = "[??????]";
            lblAddress.Text = "[??????]";
            lblNationalNo.Text = "[??????]";
            lblPhone.Text = "[??????]";
            lblDateOfBirth.Text = "[??????]";
            lblGender.Text = "[??????]";
            lblCountry.Text = "[??????]";
            pbpersonImage.ImageLocation=null;
            pbpersonImage.Image=Resources.Male_512;


        }
        private void _loadImage()
        {
            if (_PersonInfo.ImagePath!="")
            {
                if (File.Exists(_PersonInfo.ImagePath))
                {
                    pbpersonImage.ImageLocation=_PersonInfo.ImagePath;
                }
                else
                {
                    MessageBox.Show("Image file not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if(_PersonInfo.Gender==0)
                {
                    pbpersonImage.Image=Resources.Male_512;
                }
                else
                {
                   pbpersonImage.Image = Resources.Female_512;
                }
            }
        }
        private void _FillPersonInfo()
        {
            LnkEditPerson.Enabled=true;
            lblPersonID.Text=_PersonInfo.PersonID.ToString();
            _PersonID=_PersonInfo.PersonID;
            lblFullName.Text=_PersonInfo.FirstName+" "+_PersonInfo.SecondName+" "+_PersonInfo.ThirdName+" "+_PersonInfo.LastName;
            lblNationalNo.Text=_PersonInfo.NationalNo;
            lblPhone.Text=_PersonInfo.Phone;
            lblEmail.Text=_PersonInfo.Email;    
            lblAddress.Text=_PersonInfo.Address;
            lblCountry.Text=_PersonInfo.Country.CountryName;
            lblDateOfBirth.Text=_PersonInfo.DateOfBirth.ToShortDateString();
            
            if (_PersonInfo.Gender==0)
            {
                lblGender.Text="Male";
            }
            else
            {
                lblGender.Text="Femal";
            }

            _loadImage();
        }

        //Public Function To Load Data By ID or Natioinal Number
        public void LoadPersonInfo(int personID)
        {
            _PersonInfo = ClsPerson.Find(personID);
            if (_PersonInfo == null)
            {
                _ResitPersonInfo();
                MessageBox.Show("Person not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
               
            }

            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _PersonInfo = ClsPerson.Find(NationalNo);
            if (_PersonInfo == null)
            {
                _ResitPersonInfo();
                MessageBox.Show("Person not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            _FillPersonInfo();
        }


        private void LnkEditPerson_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddEditPeople frm = new FrmAddEditPeople(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}
