using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_Business_Layer;

namespace EMS_Presentation_Layer.JobLevels
{
    public partial class frmJobLevelList : Form
    {
        public frmJobLevelList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmJobLevelList_Load(object sender, EventArgs e)
        {
            dgvLevels.DataSource=clsJobLevels.GetAllLevels();
        }
    }
}
