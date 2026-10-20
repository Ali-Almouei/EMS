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

namespace EMS_Presentation_Layer.People.Controls
{
    public partial class ctrlPesonCardWithFilter : UserControl
    {
        public ctrlPesonCardWithFilter()
        {
            InitializeComponent();
        }
      
        public class onPersonSelectEventArgs:EventArgs
        {
           public int PersonID {  get; set; }   
              public   string FirstName {  get; set; }
               public string MidName { get; set; }
              public  string LastName { get; set; }
                public string NationalNo { get; set; }

            public     DateTime DateofBirth { get; set; }
              public  byte Gender { get; set; }
           public   string Phone {  get; set; }
               public string Email { get; set; }
                public string Address { get; set; }
              public  string ImagePath { get; set; }
              public  int NationalID { get; set; }
            public onPersonSelectEventArgs(int PersonID,string FirstName,string MidName,string LastName,string NationalNo,
                DateTime DateofBirth,byte Gender,string Phone,string Email,string Address,string ImagePaht,int NationalID)

            {
                this.PersonID = PersonID;
                this.FirstName = FirstName;
                this.MidName = MidName;
                this.LastName = LastName;
                this.NationalNo = NationalNo;
                this.DateofBirth = DateofBirth;
                this.Gender = Gender;
                this.Phone = Phone;
                this.Email = Email;
                this.Address = Address;
                this.ImagePath = ImagePath;
                this.NationalID = NationalID;

            }



        }



        public event EventHandler<onPersonSelectEventArgs> OnPersonSelected;

        protected virtual void RaiseOnCalculationComplete(onPersonSelectEventArgs e)
        {
            OnPersonSelected?.Invoke(this, e);
        }

        public void RaiseOnPersonSelectedComplete(int PersonID, string FirstName, string MidName, string LastName, string NationalNo,
                DateTime DateofBirth, byte Gender, string Phone, string Email, string Address, string ImagePaht, int NationalID)
        {
            RaiseOnCalculationComplete(new onPersonSelectEventArgs( PersonID,  FirstName,  MidName,  LastName,  NationalNo,
                 DateofBirth,  Gender,  Phone,  Email,  Address,  ImagePaht,  NationalID));
        }





        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

       

        private int _PersonID = -1;

        public int PersonID
        {
            get { return ctrlPersonInfoCard1.PersonID; }
        }

        public clsPeople SelectedPersonInfo
        {
            get { return ctrlPersonInfoCard1.PersonInfo; }
        }

        public void LoadPersonInfo(int PersonID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();

        }
        public void ResetControls()
        {
            ctrlPersonInfoCard1._ResetValue();
        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonInfoCard1.LoadPesonInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "National No.":
                    ctrlPersonInfoCard1.LoadPersonInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (SelectedPersonInfo != null && FilterEnabled)
                RaiseOnPersonSelectedComplete(SelectedPersonInfo.PersonID, SelectedPersonInfo.FirstName, SelectedPersonInfo.MidName, SelectedPersonInfo.LastName, SelectedPersonInfo.NationalNO,
                    SelectedPersonInfo.DateOfBirth, SelectedPersonInfo.Gendor, SelectedPersonInfo.Phone, SelectedPersonInfo.Email, SelectedPersonInfo.Address,
                    SelectedPersonInfo.ImagePath, SelectedPersonInfo.NationalID);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();

        }

       

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePeople frm1 = new frmAddUpdatePeople();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();

        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonInfoCard1.LoadPesonInfo(PersonID);
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

       

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            frmAddUpdatePeople frm1 = new frmAddUpdatePeople();
            frm1.DataBack += DataBackEvent; 
            frm1.ShowDialog();
        }

        private void ctrlPersonInfoCard1_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
        }

        private void txtFilterValue_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void ctrlPersonInfoCard1_Load_1(object sender, EventArgs e)
        {

        }

        private void gbFilters_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlPesonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;                       
        }
    }
}
