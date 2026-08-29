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

namespace DVlD
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            
        }

        private void PeopleMenuStripItem_Click(object sender, EventArgs e)
        {
            Form frm=new FrmMangePeople();
            //frm.MdiParent=this;
            
            frm.Show();
        }

      
    }
}
