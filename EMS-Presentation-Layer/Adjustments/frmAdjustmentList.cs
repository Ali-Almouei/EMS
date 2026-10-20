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

namespace EMS_Presentation_Layer.Adjustments
{
    public partial class frmAdjustmentList : Form
    {
        private DataTable _dtAllAdjustments;
        public frmAdjustmentList()
        {
            InitializeComponent();
        }

        private async void frmAdjustmentList_Load(object sender, EventArgs e)
        {
            _dtAllAdjustments=await clsAdjustments.GetAllAdjustments(DateTime.Now); 
            dgvAdjustments.DataSource= _dtAllAdjustments;
        }

        private async void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            dgvAdjustments.DataSource=await clsAdjustments.GetAllAdjustments(dtpFilter.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogAdjustment trh = new frmLogAdjustment((int)dgvAdjustments.CurrentRow.Cells[0].Value);
            trh.ShowDialog();
            frmAdjustmentList_Load(null,null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Adjustment [" + dgvAdjustments.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsAdjustments.DeleteAdjustment((int)dgvAdjustments.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Adjustment Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmAdjustmentList_Load(null, null);
                }

                else
                    MessageBox.Show("Adjustment was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogAdjustment sdf = new frmLogAdjustment();
            sdf.ShowDialog();
            frmAdjustmentList_Load(null, null);
        }
    }
}
