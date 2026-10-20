using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EMS_Business_Layer;
using EMS_Presentation_Layer.Properties;
namespace EMS_Presentation_Layer.People.Controls
{
    public partial class ctrlPersonInfoCard : UserControl
    {
        public ctrlPersonInfoCard()
        {
            InitializeComponent();
        }
        private clsPeople _Person;
        private int _PersonID = -1;



        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }
        public clsPeople PersonInfo
        {
            get { return _Person; }
        }
        public void HideEditLabel()
        {
            lblEditInfo.Enabled = false;
        }
        public void _ResetValue()
        {
            lblID.Text = "[???]";
            lblName.Text = "[???]";
            lblPhone.Text = "[???]";
            lblEmail.Text = "[???]";
            lblGender.Text = "[???]";
            lblDataOfBirth.Text = "[???]";
            lblAddress.Text = "[???]";
            lblCounntryName.Text = "[???]";
            lblEditInfo.Enabled = false;
            pbPersonImage.Image = Resources.Man;
        }
        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                pbPersonImage.Image = Resources.Man;
            else
                pbPersonImage.Image = Resources.Women;

            string ImagePath = _Person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void _LoadPesonInfo()
        {
            _LoadPersonImage();
            lblID.Text = _Person.PersonID.ToString();
            lblCounntryName.Text = _Person.CountryInfo.CountryName;
            lblAddress.Text = _Person.Address;
            lblDataOfBirth.Text = _Person.DateOfBirth.ToString("dd/M/yyyy");
            lblPhone.Text = _Person.Phone;
            lblNational.Text=_Person.NationalNO.ToString(); 
            lblEmail.Text = _Person.Email;
            lblGender.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblName.Text = _Person.FullName;


        }
        public void LoadPesonInfo(int PersonID)
        {
            _Person = clsPeople.GetPersonByID(PersonID);
            _PersonID = PersonID;
            if (_Person == null)
            {
                _ResetValue();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadPesonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPeople.GetPersonByNationalNO(NationalNo);
            if (_Person == null)
            {
                _ResetValue();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
            _PersonID=_Person.PersonID;

            _LoadPesonInfo();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonInfoCard_Load(object sender, EventArgs e)
        {
        }

        private void lblEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePeople frmAddUpdatePeople = new frmAddUpdatePeople(_PersonID);
            frmAddUpdatePeople.ShowDialog();
            LoadPesonInfo(_PersonID);
        }
    }
}