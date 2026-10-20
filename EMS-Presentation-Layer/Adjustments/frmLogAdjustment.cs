using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_Business_Layer;
using EMS_Presentation_Layer.Classes;

namespace EMS_Presentation_Layer.Adjustments
{
    public partial class frmLogAdjustment : Form
    {
        private int _AdjustmentID;
        private clsAdjustments _Adjustment;
        enum enMode { AddNew=0,Update=1 }   
        enMode Mode = enMode.AddNew;



        public frmLogAdjustment()
        {
            InitializeComponent();
             Mode=enMode.AddNew;
        }
        public frmLogAdjustment(int AdjustmentID)
        {
            InitializeComponent();
            _AdjustmentID = AdjustmentID;
            Mode = enMode.Update;
        }
        private void _ResetControls()
        {
            lblAdjustmentID.Text = "";
            lblAdjustmentDate.Text = "";
            txtAmount.Text = "";
            txtNotes.Text = "";
            rbBouns.Checked = false;
            rbPenalty.Checked = false;
            ctrlEmployeeCardWithFilter1.ResetControls();
           if(Mode==enMode.AddNew) 
                _Adjustment=new clsAdjustments();
        }

        private void _LoadData()
        {
            _Adjustment=clsAdjustments.FindAdjustment(_AdjustmentID);
            if (_Adjustment == null)
            {
                MessageBox.Show("no Adjustment with this ID: " + _AdjustmentID.ToString());
                return;
            }
            lblAdjustmentID.Text=_Adjustment.AdjustmentID.ToString();
            lblAdjustmentDate.Text= _Adjustment.AdjustmentDate.ToString("dd/M/yyyy");
            txtAmount.Text = _Adjustment.Amount.ToString();
            txtNotes.Text = _Adjustment.Notes.ToString();
            if(_Adjustment.Type==0)
                rbPenalty.Checked=true;
            else
                rbBouns.Checked=true ;

            ctrlEmployeeCardWithFilter1.LoadData(_Adjustment.EmployeeID);






        }






        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren()) return;



            _Adjustment.AdjustmentDate = DateTime.Now;
            _Adjustment.Notes=txtNotes.Text;
            _Adjustment.Amount=Convert.ToDecimal(txtAmount.Text);
            if(rbPenalty.Checked )
                _Adjustment.Type = 0;
            else
                _Adjustment.Type = 1;

            _Adjustment.EmployeeID=ctrlEmployeeCardWithFilter1.EmployeeID;
            _Adjustment.CreatedByUserID=clsGlobal.CurrentUser.UserID;

            if(_Adjustment.Save())
            {
                MessageBox.Show("Data Saved Succsecfully");
                lblAdjustmentDate.Text = _Adjustment.AdjustmentDate.ToString("dd/M/yyyy");
                lblAdjustmentID.Text = _Adjustment.AdjustmentID.ToString();
                return;
            }
            else
            {
                MessageBox.Show("Error");

            }


        }

        private void frmLogAdjustment_Load(object sender, EventArgs e)
        {
            _ResetControls();
            if (Mode == enMode.Update)
                _LoadData();
        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAmount, "This item is Required ");
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
