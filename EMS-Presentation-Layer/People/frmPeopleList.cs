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

namespace EMS_Presentation_Layer.People
{
    public partial class frmPeopleList : Form
    {
        private static DataTable _dtAllPeople;
        private int CurrentPage = 1;

        public frmPeopleList()
        {
            InitializeComponent();
        }
        private void _MakeDataGridVewStyle()
        {
            if (dgvPeopleList.Rows.Count > 0)
            {
                dgvPeopleList.Columns[0].HeaderText = "Person ID";
                dgvPeopleList.Columns[0].Width = 110;
                dgvPeopleList.Columns[1].HeaderText = "First Name";
                dgvPeopleList.Columns[1].Width = 110;

                dgvPeopleList.Columns[2].HeaderText = "Mid Name";
                dgvPeopleList.Columns[2].Width = 110;

                dgvPeopleList.Columns[3].HeaderText = "Last Name";
                dgvPeopleList.Columns[3].Width = 110;

                dgvPeopleList.Columns[4].HeaderText = "National.No";
                dgvPeopleList.Columns[4].Width = 150;

                dgvPeopleList.Columns[5].HeaderText = "Date Of Birth";
                dgvPeopleList.Columns[5].Width = 180;

                dgvPeopleList.Columns[6].HeaderText = "Phone";
                dgvPeopleList.Columns[6].Width = 110;
                dgvPeopleList.Columns[7].HeaderText = "Email";
                dgvPeopleList.Columns[7].Width = 150;
                dgvPeopleList.Columns[8].HeaderText = "Gender";
                dgvPeopleList.Columns[8].Width = 90;
                dgvPeopleList.Columns[9].HeaderText = "Address";
                dgvPeopleList.Columns[9].Width = 180;
                dgvPeopleList.Columns[10].HeaderText = "Counntry Name";
                dgvPeopleList.Columns[10].Width = 110;
            }
        }
        private async void frmPeopleList_Load(object sender, EventArgs e)
        {
            //_MakeDataGridVewStyle();
            contextMenuStrip1.ForeColor = Color.White;
            dgvPeopleList.AllowUserToAddRows = false;
            cbFilterBy.SelectedIndex = 0;
            _dtAllPeople = await clsPeople.GetAllPeople();
            dgvPeopleList.DataSource = clsPeople.GetAllPeoplePagination(CurrentPage, 50);
           

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltervalue.Visible = (cbFilterBy.Text != "None");
            btnPrev.Visible = (cbFilterBy.Text == "None") && CurrentPage != 1;
            btnNext.Visible = (cbFilterBy.Text == "None");
            if (txtFiltervalue.Visible)
            {
                dgvPeopleList.DataSource = _dtAllPeople;
                txtFiltervalue.Text = "";
                txtFiltervalue.Focus();
            }
            if (cbFilterBy.Text != "None")
            {
                dgvPeopleList.DataSource = _dtAllPeople;
            }
            else
            {
              //  _MakeDataGridVewStyle();
                dgvPeopleList.DataSource = clsPeople.GetAllPeoplePagination(1, 50);
                CurrentPage = 1;
                btnPrev.Visible = false;
            }
        }

        private void txtFiltervalue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Mid Name":
                    FilterColumn = "MidName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;


                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }
            if (txtFiltervalue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllPeople.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "PersonID")
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFiltervalue.Text.Trim());
            else
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFiltervalue.Text.Trim());







        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePeople frmAddUpdatePeople = new frmAddUpdatePeople();
            frmAddUpdatePeople.ShowDialog();
            //_MakeDataGridVewStyle();
            frmPeopleList_Load(null,null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnPrev.Visible = true;
            dgvPeopleList.DataSource = clsPeople.GetAllPeoplePagination(++CurrentPage, 50);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentPage == 2)
                btnPrev.Visible = false;
           // _MakeDataGridVewStyle();
            dgvPeopleList.DataSource = clsPeople.GetAllPeoplePagination(--CurrentPage, 50);

        }

        private void txtFiltervalue_Validating(object sender, CancelEventArgs e)
        {


            if (string.IsNullOrEmpty(txtFiltervalue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFiltervalue, "This field is Diget!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFiltervalue, null);
            }

        }

        private void txtFiltervalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void personInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInfo j = new frmPersonInfo((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            j.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePeople frmAddUpdatePeople = new frmAddUpdatePeople((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frmAddUpdatePeople.ShowDialog();
            //_MakeDataGridVewStyle();
            frmPeopleList_Load(null,null);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePeople h = new frmAddUpdatePeople();
            h.ShowDialog();
          //  _MakeDataGridVewStyle();
            frmPeopleList_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleList.CurrentRow.Cells[0].Value;
            if (clsUsers.IsUserExistByPersonID(PersonID)||clsEmployees.IsEmployeeExistByPersonID(PersonID))
            {
                MessageBox.Show("You Can not Delete this Person With ID: " + PersonID.ToString() + "because it's refer to User or Employeer");
                return; ;
            }

            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeopleList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPeople.DeletePerson((int)dgvPeopleList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPeopleList_Load(null,null);
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }





        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
