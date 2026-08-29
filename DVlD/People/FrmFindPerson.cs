using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD.People
{
    public partial class FrmFindPerson : Form
    {
        public FrmFindPerson()
        {
            InitializeComponent();
        }
        public delegate void DataBackEventHader(object sender, int PersonId);
        public event DataBackEventHader DataBack;

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlPersonCardWithFilter1.PersonId);
            this.Close();
        }
    }
}
