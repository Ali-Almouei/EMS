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

namespace EMS_Presentation_Layer.Attendance
{
    public partial class frmAttendanceList : Form
    {
        public frmAttendanceList()
        {
            InitializeComponent();
        }

        private async void frmAttendanceList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await clsAttendance.GetAllAttendance(DateTime.Now);
            dtpFilter.MaxDate=DateTime.Now;
            dtpFilter.Format = DateTimePickerFormat.Long;
            contextMenuStrip1.Enabled=dtpFilter.Value!=DateTime.Now.Date;
            cheackOutOrUpdateToolStripMenuItem.Enabled=dtpFilter.Value!=DateTime.Now;
        }

        private async void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            contextMenuStrip1.Enabled = dtpFilter.Value != DateTime.Now;
            cheackOutOrUpdateToolStripMenuItem.Enabled = dtpFilter.Value != DateTime.Now;

            dataGridView1.DataSource= await clsAttendance.GetAllAttendance(dtpFilter.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogAttendanceForEmployee  rfg=new LogAttendanceForEmployee();
            rfg.ShowDialog();
            frmAttendanceList_Load(null, null);
        }

        private void cheackOutOrUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogAttendanceForEmployee j=new LogAttendanceForEmployee( (int)dataGridView1.CurrentRow.Cells[0].Value,dtpFilter.Value);
            j.ShowDialog();
            frmAttendanceList_Load(null, null);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Employeer [" + dataGridView1.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsAttendance.DeleteAttendance((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Attendance Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmAttendanceList_Load(null, null);
                }

                else
                    MessageBox.Show("Attendance was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
