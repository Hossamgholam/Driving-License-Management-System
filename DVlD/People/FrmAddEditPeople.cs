using DevExpress.XtraBars.Docking2010;
using DVIDBusinessLayer;
using DVlD.Global_Class;
using DVlD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD.People
{
    public partial class FrmAddEditPeople : Form
    {
       /// <summary>
       /// regis services:
       ///  if some one call this form and regist in this services 
       ///  he get formName personID
       /// </summary>
       /// <param name="form"></param>
       /// <param name="PersonID"></param>
        public delegate void FrmAddEditPeopleEventHandler(object form, int PersonID);
        public event FrmAddEditPeopleEventHandler DataBack;


        private enum EnMode { Add = 0, Update = 1 };
        private enum EnGender:byte { Male=0, Female=1 };

        private int _PersonID;
        private ClsPerson _person;
        private EnMode _Mode;
        public FrmAddEditPeople()
        {
            InitializeComponent();
            _Mode=EnMode.Add;
        }
        public FrmAddEditPeople(int PersonID)
        {
            InitializeComponent ();
            _PersonID = PersonID;
            _Mode = EnMode.Update;
        }
       
        //private Function To Full Country ComBox from Data Base of country
        private void _FillCountryComboBox()
        {
            DataTable table = ClsCountry.GetAll();
            foreach (DataRow row in table.Rows)
            {
                cmbCountry.Items.Add(row["CountryName"]);
            }
        }

        //Loading Form Info Frist time
        private void _loadExsitPersonInfo()
        {
            _person=ClsPerson.Find(_PersonID);
            if (_person == null)
            {
                MessageBox.Show($"the person with Id {_PersonID} not Exsit","Wrong Information",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            lblTitle.Text="Update Person";

            //fill form with _perosn info
            lblPersonID.Text= _person.PersonID.ToString();
            lblPersonID.Tag=_person.PersonID;
            tbFrist.Text = _person.FirstName;
            tbSecond.Text = _person.SecondName;
            tbThird.Text = _person.ThirdName;
            tbLast.Text = _person.LastName;
            tbNationalNO.Text = _person.NationalNo;
            tbPhone.Text = _person.Phone;
            tbEmail.Text = _person.Email;
            tbAddress.Text = _person.Address;

            if (_person.Gender==0)
            {
                rbMale.Checked=true;
            }
            else
            {
                rbFemal.Checked=true;
            }

            dtpDateOfBirth.Value= _person.DateOfBirth;

            cmbCountry.SelectedIndex=cmbCountry.FindString(_person.Country.CountryName);

            if (_person.ImagePath!="")
            {
                pbImagePerson.ImageLocation=_person.ImagePath;

            }

            lnkRemove.Visible=(_person.ImagePath!="");
        }
        private void _LoadDataAcordingToMode()
        {
            _FillCountryComboBox();
            dtpDateOfBirth.MaxDate=DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate=DateTime.Now.AddYears(-100);

            if (_Mode==EnMode.Add)
            {
                _person=new ClsPerson();

                lblTitle.Text="Add New Person";
                //no value for id untill now
                lblPersonID.Tag=0;
                tbFrist.Text="";
                tbSecond.Text="";
                tbThird.Text="";
                tbLast.Text="";
                tbPhone.Text="";
                tbEmail.Text="";
                tbAddress.Text="";
                rbMale.Checked=true;
                dtpDateOfBirth.Value=dtpDateOfBirth.MaxDate;
                cmbCountry.SelectedIndex=cmbCountry.FindString("Egypt");
                
                lnkRemove.Visible=(pbImagePerson.ImageLocation!=null);
            }
            else
            {
                _loadExsitPersonInfo();
            }
            

        }
        private void FrmAddEditPeople_Load(object sender, EventArgs e)
        {
            _LoadDataAcordingToMode();
        }


        //Validation
        private void ValidateEmptyTextBox(object sender,CancelEventArgs e)
        {
            TextBox temp=(TextBox)sender;

            if (string.IsNullOrEmpty(temp.Text.Trim()) ){
                e.Cancel = true;
                errorProvider1.SetError(temp, "Filed is requerid");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
        }
        private void tbNationalNO_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNationalNO.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNO, "Filed is requerid");
                return;
            }
           
            if (ClsPerson.isExsit(tbNationalNO.Text.Trim(),(int)lblPersonID.Tag)) {

                errorProvider1.SetError(tbNationalNO, "The National Number Is Exist");
                return;
            }
            errorProvider1.SetError(tbNationalNO, null);

        }
        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            string phone = tbPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPhone, "Phone number is required.");
                return;
            }

            if (!Regex.IsMatch(phone, @"^\+?[0-9\s\-\(\)]{7,20}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPhone, "Enter a valid phone number.");
                return;
            }

            errorProvider1.SetError(tbPhone, null);
        }
        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email = tbEmail.Text.Trim();

            if (string.IsNullOrEmpty(Email))
            {
                return;
            }

            if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Pleas Enter Valid Email");
                return;
            }
            errorProvider1.SetError(tbEmail, null);
        }




        //close and save
        private void btnClose_Click(object sender, EventArgs e)
        {
            //for stop validate to close 
            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private bool HandelImage()
        {
            if (_person.ImagePath!=pbImagePerson.ImageLocation)
            {
                if (_person.ImagePath!="")
                {
                    try
                    {
                        File.Delete(_person.ImagePath);
                    }
                    catch(Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
                if (pbImagePerson.ImageLocation!=null)
                {
                    string ImageSourcePathe=pbImagePerson.ImageLocation.ToString();

                    if(ClsUtil.CopyImageToProjectFolder(ref ImageSourcePathe))
                    {
                        pbImagePerson.ImageLocation = ImageSourcePathe;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Error Copy Image to Project Folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    //copy image to folder 
                   
                }
            }
                return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show(
                    "Please fix the errors before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;

            }
            else
            {

                //handerl image
                //if it handel retrun ture  !true =false
                if (!HandelImage())
                {
                    return;
                }


                //full person info into object
                _person.FirstName=tbFrist.Text.Trim();
                _person.SecondName=tbSecond.Text.Trim();
                _person.ThirdName=tbThird.Text.Trim();
                _person.LastName=tbLast.Text.Trim();
                _person.NationalNo=tbNationalNO.Text.Trim();
                _person.Phone=tbPhone.Text.Trim();
                _person.Email=tbEmail.Text.Trim();
                _person.Address=tbAddress.Text.Trim();

                if (rbFemal.Checked)
                {
                    _person.Gender=(byte)EnGender.Female;
                }
                else
                {
                    _person.Gender=(byte)(EnGender.Male);
                }

                _person.DateOfBirth=dtpDateOfBirth.Value;

                _person.NationalityCountryID=ClsCountry.Find(cmbCountry.Text.Trim()).CountryID;

                if (pbImagePerson.ImageLocation!=null)
                {
                    _person.ImagePath=pbImagePerson.ImageLocation.ToString();
                }
                else
                {
                    _person.ImagePath="";
                }


                //check if it save or not
                if (_person.save())
                {
                    MessageBox.Show(
                       "Person saved successfully.",
                       "Success",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information
                   );

                    lblTitle.Text="Update Person";
                    lblPersonID.Text=_person.PersonID.ToString();
                    lblPersonID.Tag=_person.PersonID;
                    _Mode=EnMode.Update;


                    //the data that return to form that call this form and  regist in service 
                    DataBack?.Invoke(this, _person.PersonID);


                    // Update the UI
                }
                else
                {
                    MessageBox.Show(
                        "Failed to save person.",
                        "Save Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

            }
        }


        //event
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImagePerson.ImageLocation==null)
            {
                pbImagePerson.Image=Resources.Male_512;
            }
            
        }
        private void rbFemal_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImagePerson.ImageLocation==null)
            {
                pbImagePerson.Image= Resources.Female_512;    
            }
        }

        private void lnkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory=@"H:\desktop picture";
            openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png|Bitmap Files (*.bmp)|*.bmp|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            openFileDialog1.Title="open";
            openFileDialog1.FilterIndex=1;


            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pbImagePerson.ImageLocation=openFileDialog1.FileName;
                lnkRemove.Visible=true;

            }
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImagePerson.ImageLocation=null;

            if (rbFemal.Checked)
            {
                pbImagePerson.Image=Resources.Female_512;
            }
            else
            {
                pbImagePerson.Image= Resources.Male_512;
            }
            lnkRemove.Visible = false;
        }

      
    }
}
