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
namespace EMS_Presentation_Layer.Departments
{
    public partial class frmDepartmentList : Form
    {
        public frmDepartmentList()
        {
            InitializeComponent();
        }

        private void frmDepartmentList_Load(object sender, EventArgs e)
        {
            dgvDepartments.DataSource=clsDepartments.GetAllDepartmets();    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
