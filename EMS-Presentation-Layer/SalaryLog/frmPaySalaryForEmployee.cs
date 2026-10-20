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
using EMS_Presentation_Layer.Classes;

namespace EMS_Presentation_Layer.SalaryLog
{
    public partial class frmPaySalaryForEmployee : Form
    {
        private int _LogID;
        private clsSalarylog _SalaryLog= new clsSalarylog();
        public frmPaySalaryForEmployee()
        {
            InitializeComponent();
        }

        private void frmPaySalaryForEmployee_Load(object sender, EventArgs e)
        {

        }

        private void ctrlEmployeeCardWithFilter1_OnEmployeeSelectedEvent(object sender, Employees.Controls.ctrlEmployeeCardWithFilter.OnEmployeeSelectedEvenArgs e)
        {
            if(e.EmoloyeeID!=-1)
            {
                lblBaseSalary.Text=clsSalarylog.GetBaseSalaryForEmployeer(e.EmoloyeeID).ToString();
                lblBonus.Text=clsSalarylog.GetTotalBonusForEmployee(e.EmoloyeeID,DateTime.Now).ToString();
                lblPenalty.Text=clsSalarylog.GetTotalPenaltyForEmployeer(e.EmoloyeeID,DateTime.Now).ToString(); 
                lblNetSalary.Text=clsSalarylog.GetNetSalaryForEmployeer(e.EmoloyeeID, DateTime.Now).ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren()) return; 
            if(clsSalarylog.IsEmployeeHasSalaryThisMonth(ctrlEmployeeCardWithFilter1.EmployeeID,DateTime.Now))
            {
                MessageBox.Show("this Employee was take his Salary");
                return;
            }
            _SalaryLog.EmployeeID=ctrlEmployeeCardWithFilter1.EmployeeID;
            _SalaryLog.CraetedByUserID=clsGlobal.CurrentUser.UserID;
            if(_SalaryLog.Save())
            {
                MessageBox.Show("Data Saved Succsecfully");
                lblDate.Text=_SalaryLog.LogDate.ToString("dd/M/yyyy");
                lblLogID.Text=_SalaryLog.LogID.ToString();

                return;
            }
            else
            {
                MessageBox.Show("Error");

            }







        }
    }
}
