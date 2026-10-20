using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_Business_Layer;
using EMS_Presentation_Layer.Classes;
using EMS_Presentation_Layer.Properties;

namespace EMS_Presentation_Layer.People
{
    public partial class frmAddUpdatePeople : Form
    {
        private int _PersonID = -1;
        private clsPeople _Person;
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };

        private enMode _Mode;
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public frmAddUpdatePeople(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
            _Mode=enMode.Update;
        }
        public frmAddUpdatePeople()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        private async void _FillCountrirsInComboBox()
        {
            DataTable dt = await clsCountries.GetAllCountries();
            foreach (DataRow dr in dt.Rows)
            {
                cbCountry.Items.Add(dr["CountryName"].ToString());
            }


        }
        private void _ResetControls()
        {
            _FillCountrirsInComboBox();
            if (_Mode == enMode.AddNew)
            {
                _Person = new clsPeople();
                lblTitle.Text = "Add New Person";
                return;
            }
            else
            {
                lblTitle.Text = "Update Person info";
            }
            rbMale.Checked = true;
            
            txtFirstName.Text = "";
            txtMidName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            if (rbMale.Checked)
            pbPersonImage.Image = Resources.Man;
            else
                pbPersonImage.Image = Resources.Women;

            cbCountry.SelectedIndex = cbCountry.FindString("Syria");
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            lnkRemove.Visible = pbPersonImage.ImageLocation != null;


        }
        private void _LoadData()
        {
            _Person = clsPeople.GetPersonByID(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("This Person with " + _PersonID.ToString() + " Not Found!");
                this.Close();
                return;
            }
            lblID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtMidName.Text = _Person.MidName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text=_Person.NationalNO;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);
            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            lnkRemove.Visible = pbPersonImage.ImageLocation != null;

        }
        private bool _HandlePersonImage()
        {


            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                    }
                }



                if (pbPersonImage.ImageLocation != null)
                {
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtils.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        private void frmAddUpdatePeople_Load(object sender, EventArgs e)
        {
            _ResetControls();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            if (!_HandlePersonImage())
                return;


            int NationalID = clsCountries.FindCountryByName(cbCountry.Text).CountryID;
            _Person.FirstName = txtFirstName.Text;
            _Person.MidName = txtMidName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.NationalNO = txtNationalNo.Text;    
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalID = NationalID;
            if (rbMale.Checked)
            {
                _Person.Gendor = (byte)enGendor.Male;
            }
            else
            {
                _Person.Gendor = (byte)enGendor.Female;

            }
            if (pbPersonImage.ImageLocation != null)
            {
                _Person.ImagePath = pbPersonImage.ImageLocation.ToString();
            }
            else
            {
                _Person.ImagePath = "";
            }

            if (_Person.Save())
            {
                lblID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
               DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void lnkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = clsConstantVar.ImageFormat;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = openFileDialog1.FileName;
                pbPersonImage.Load(ImagePath);
                lnkRemove.Visible = true;
            }
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;



            //if (rbMale.Checked)
            //    pbPersonImage.Image = Resources.Male_512;
            //else
            //    pbPersonImage.Image = Resources.Female_512;

            lnkRemove.Visible = false;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            //if (pbPersonImage.ImageLocation == null)
            //    pbPersonImage.Image = Resources.Male_512;
        }

        private void rbFemle_CheckedChanged(object sender, EventArgs e)
        {
            //if (pbPersonImage.ImageLocation == null)
                //pbPersonImage.Image = Resources.Male_512;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "This item is Required ");
            }
            else
            {
                e.Cancel=false;
            }
        }

        private void txtMidName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMidName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMidName, "This item is Required ");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLastName, "This item is Required ");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This item is Required ");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "This item is Required ");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This item is Required ");
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
