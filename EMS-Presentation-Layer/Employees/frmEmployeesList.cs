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
using EMS_Presentation_Layer.Adjustments;

namespace EMS_Presentation_Layer.Employees
{
    public partial class frmEmployeesList : Form
    {
        private DataTable _dtAllEmployees;
        public frmEmployeesList()
        {
            InitializeComponent();
        }
        private void _MakedgvDisen()
        {
            if (dgvEmployees.Rows.Count > 0)
            {

                dgvEmployees.Columns[0].HeaderText = "Employee ID";
                dgvEmployees.Columns[0].Width = 110;

                dgvEmployees.Columns[1].HeaderText = "Full Name";
                dgvEmployees.Columns[1].Width = 210;

                dgvEmployees.Columns[2].HeaderText = "Department Name";
                dgvEmployees.Columns[2].Width = 160;


                dgvEmployees.Columns[3].HeaderText = "Level Name";
                dgvEmployees.Columns[3].Width = 90;


                dgvEmployees.Columns[4].HeaderText = "Hire Date";
                dgvEmployees.Columns[4].Width = 160;


                dgvEmployees.Columns[5].HeaderText = "Expired Date";
                dgvEmployees.Columns[5].Width = 160;


                dgvEmployees.Columns[6].HeaderText = "Status";
                dgvEmployees.Columns[6].Width = 90;


                dgvEmployees.Columns[7].HeaderText = "Created User";
                dgvEmployees.Columns[7].Width = 100;

                





            }
        }

        private async void  frmEmployeesList_Load(object sender, EventArgs e)
        {
            dgvEmployees.ForeColor=Color.Black;
            cbFilterBy.SelectedIndex = 0;
            _dtAllEmployees= await clsEmployees.GetAllEmplooyees();
            dgvEmployees.DataSource = _dtAllEmployees;
            _MakedgvDisen();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltervalue.Visible = (cbFilterBy.Text != "None");
            if (txtFiltervalue.Visible)
            {
                txtFiltervalue.Text = "";
                txtFiltervalue.Focus();
            }
        }

        private void txtFiltervalue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Employee ID":
                    {
                        FilterColumn = "EmployeeID";
                        break;
                    }
                case "Full Name":
                    {
                        FilterColumn = "FullName";
                        break;
                    }
                    default:
                    {
                        FilterColumn = "None";
                        break;
                    }
            }
            if (txtFiltervalue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllEmployees.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "EmployeeID")
                _dtAllEmployees.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiltervalue.Text.Trim());
            else
                _dtAllEmployees.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiltervalue.Text.Trim());
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frmAddUpdateEmployee = new frmAddUpdateEmployee();
            frmAddUpdateEmployee.ShowDialog();
            frmEmployeesList_Load(null,null);
        }

        private void employeeerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeIinfo ifdsh= new frmEmployeeIinfo((int)dgvEmployees.CurrentRow.Cells[0].Value);
            ifdsh.ShowDialog();

            frmEmployeesList_Load(null, null);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee ji = new frmAddUpdateEmployee();
            ji.ShowDialog();
            frmEmployeesList_Load(null, null);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee hy = new frmAddUpdateEmployee((int)dgvEmployees.CurrentRow.Cells[0].Value);
            hy.ShowDialog();
            frmEmployeesList_Load(null, null);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete Employeer [" + dgvEmployees.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsEmployees.DeleteEmployee((int)dgvEmployees.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Employeer Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmEmployeesList_Load(null, null);
                }

                else
                    MessageBox.Show("Employeer was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmListEmployeerAdjustment g = new frmListEmployeerAdjustment((int)dgvEmployees.CurrentRow.Cells[0].Value);
            g.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFiltervalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Employee ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void expireEmployeerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to deleExpire Employeer [" + dgvEmployees.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsEmployees.ExpireEmployeer((int)dgvEmployees.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Employeer Expired Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmEmployeesList_Load(null, null);
                }

                else
                    MessageBox.Show("Employeer was not Expired because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
