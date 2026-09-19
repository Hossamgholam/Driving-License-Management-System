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

namespace DVlD.App
{
    public partial class FrmUpdateApplication : Form
    {
       
         private int _ApplicationID = -1;
         private ClsApplicationTypes _ApplicationTypeInfo;
         public FrmUpdateApplication(int applicationID)
         {
             InitializeComponent();
             _ApplicationID = applicationID;
         }

         private void FrmUpdateApplication_Load(object sender, EventArgs e)
         {
             _ApplicationTypeInfo=ClsApplicationTypes.Find(_ApplicationID);

             if (_ApplicationTypeInfo != null)
             {
                 lblApplicationID.Text=_ApplicationTypeInfo.ApplicationTypesID.ToString();
                 tbTitle.Text=_ApplicationTypeInfo.ApplicationTypesTitle.ToString();
                 tbFees.Text=_ApplicationTypeInfo.ApplicationFees.ToString();
                 return;
             }

             MessageBox.Show("Application Type not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             lblApplicationID.Text = "Not Found";


         }

        

        //validation for the textboxes before updating the application type
        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTitle, "");
            }
            else
            {
                errorProvider1.SetError(tbTitle, null);
            }
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
            e.Handled=(char.IsLetter(e.KeyChar));
        }

       
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.AutoValidate= AutoValidate.Disable;
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Please fill in all required fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ApplicationTypeInfo.ApplicationTypesTitle=tbTitle.Text.Trim();
            _ApplicationTypeInfo.ApplicationFees=Convert.ToDouble(tbFees.Text.Trim());
            if (_ApplicationTypeInfo.Save())
            {
                MessageBox.Show("Application Type updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update Application Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
