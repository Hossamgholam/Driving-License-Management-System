using DVIDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD.Tests.TestType
{
    public partial class FrmUpdateTest : Form
    {
        private int _TestTypeID = -1;

        private ClsTestTypes _TestTypeInfo;

        public FrmUpdateTest(int testTypeID)
        {
            InitializeComponent();

            _TestTypeID=testTypeID;
        }

        private void FrmUpdateTest_Load(object sender, EventArgs e)
        {
            _TestTypeInfo=ClsTestTypes.Find(_TestTypeID);

            lblTestID.Text=_TestTypeID.ToString();

            if (_TestTypeInfo!=null)
            {
                tbTitle.Text=_TestTypeInfo.Title;
                tbDescription.Text=_TestTypeInfo.Description;
                tbFees.Text=_TestTypeInfo.Fees.ToString();
                return;
            }

            MessageBox.Show("Test type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tbTitle.Text="";
            tbDescription.Text="";
            tbFees.Text="";
            this.Close();
        }



        //validation
        private void ValidateEmptyTextBox(object sender,CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This field is required.");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTextBox(sender, e);
        }
        private void tbDescription_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTextBox(sender, e);
        }
        private void tbFees_Validating(object sender, CancelEventArgs e)
        {


            string pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            if (string.IsNullOrEmpty(tbFees.Text.Trim()))
            {
                e.Cancel= true;
                errorProvider1.SetError(tbFees, "Fees cannot be empty");
            }
            else
            {

                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(tbFees.Text.Trim()))
                {
                    e.Cancel=true;
                    errorProvider1.SetError(tbFees, "Please enter a valid number");
                }
                else
                {
                    errorProvider1.SetError(tbFees, null);
                }

            }


        }
        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=char.IsLetter(e.KeyChar);
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

            _TestTypeInfo.Title=tbTitle.Text.Trim();
            _TestTypeInfo.Description=tbDescription.Text.Trim();
            _TestTypeInfo.Fees=Convert.ToSingle(tbFees.Text.Trim());

            if (_TestTypeInfo.Save())
            {
                MessageBox.Show("Test type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update test type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
