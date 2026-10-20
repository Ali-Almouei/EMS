using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS_Presentation_Layer.InterviewAppointment
{
    public partial class frmAppointmentListforPerson : Form
    {
        private int _PersonID;
        public frmAppointmentListforPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmAppointmentListforPerson_Load(object sender, EventArgs e)
        {

        }

        private void btnCloes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
