using DevExpress.XtraEditors.Filtering.Templates;
using DVIDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD.People.Controls
{
    //Person ID
    //National No
    public partial class CtrlPersonCardWithFilter : UserControl
    {
        public event Action<int> PersonSelect;
        public CtrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        //properity to access PersonId and another Info
        public int PersonId{ get { return ctrlPersonCardInfo.PersonID; }  }
        public ClsPerson PersonInfo { get { return ctrlPersonCardInfo.PersonInfo;  }   }


        private bool _EnableAddPerson = true;
        public bool EnableAddPerson
        {
            set {  btnAddPerson.Enabled = value; }
            get { return _EnableAddPerson; }
        }

        private bool _EnableFilterGroup = true;
        public bool EnableFilterGroup
        {
            set { GbFilter.Enabled = value;  } 
            get { return _EnableFilterGroup; }
        }


        private void CtrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            CmbFilter.SelectedIndex = 0;
            TxtFilter.Focus();
        }

        public void LoadPersonInfo(int PersonID)
        {
            CmbFilter.SelectedIndex=0;
            TxtFilter.Text=Convert.ToString(PersonID);
            _FoundNow();
        }


        //Serch Function
        private void _FoundNow()
        {
            switch (CmbFilter.Text)
            {
                case "Person ID":
                    ctrlPersonCardInfo.LoadPersonInfo(int.Parse(TxtFilter.Text.Trim())); break;

                case "National No":
                       ctrlPersonCardInfo.LoadPersonInfo(TxtFilter.Text.Trim()); break;

                default:
                    return;

            }
            if (PersonSelect!=null&&EnableFilterGroup==true)
            {
                PersonSelect(ctrlPersonCardInfo.PersonID);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the errors before searching.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            _FoundNow();


        }
        
        //add function
        private void _DataBackEvent(object sender,int PersonId)
        {
            CmbFilter.SelectedIndex=0;
            TxtFilter.Text=Convert.ToString(PersonId);
            ctrlPersonCardInfo.LoadPersonInfo(PersonId);
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPeople frm= new FrmAddEditPeople();
            frm.DataBack+=_DataBackEvent;
            frm.ShowDialog();
        }


        // Event handler for the Validating event of the TxtFilter TextBox
        private void TxtFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtFilter.Text.Trim())){
                e.Cancel = true;
                errorProvider1.SetError(TxtFilter, "Filter cannot be empty.");
            }
            else
            {
                errorProvider1.SetError(TxtFilter, null);
            }
        }
       
        //Every Time user Enter key he check if it apply condation
        private void TxtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar== (char)Keys.Enter)
            {
                
                btnSearch.PerformClick(); // Trigger the filter button click event
            }
            if(CmbFilter.Text=="Person ID")
            {
                if (char.IsControl(e.KeyChar)||char.IsDigit(e.KeyChar))
                {
                    e.Handled=false;
                }
                else
                {
                    e.Handled=true;
                }
            }
        }

        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFilter.Text="";
            TxtFilter.Focus(); 
        }
    }
}
