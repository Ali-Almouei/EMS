using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_Business_Layer;
using EMS_Presentation_Layer.Classes;

namespace EMS_Presentation_Layer.Users
{
    public partial class frmUserList : Form
    {
        private static DataTable _dtAllUsers;

        public frmUserList()
        {
            InitializeComponent();
        }
        private void MakeDGVDisgn()
        {
            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 110;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 120;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 350;

                dgvUsers.Columns[3].HeaderText = "UserName";
                dgvUsers.Columns[3].Width = 120;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 120;
                dgvUsers.Columns[5].HeaderText = "Is Admin";
                dgvUsers.Columns[5].Width = 120;
            }
        }
        private  async void frmUserList_Load(object sender, EventArgs e)
        {
            dgvUsers.ForeColor=Color.Black;
            dgvUsers.AllowUserToAddRows = false;
            _dtAllUsers = await clsUsers.GetAllUsers();
          dgvUsers.DataSource = _dtAllUsers;
            
            cbFilterBy.SelectedIndex = 0;
           MakeDGVDisgn();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            
            if (cbFilterBy.Text == "Is Active" || cbFilterBy.Text == "Is Admin")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;


                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
               _dtAllUsers.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilterBy.Text == "Is Active" ? "IsActive" : "IsAdmin";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
        }



        

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID"|| cbFilterBy.Text=="User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser();
            frmAddUpdateUser.ShowDialog();
            frmUserList_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            if(clsGlobal.CurrentUser.UserID!=1&& UserID==1)
            {
                MessageBox.Show("You Cant Edit CEO Account");
                return;
            }


            frmAddUpdateUser s = new frmAddUpdateUser(UserID);
            s.ShowDialog();
            frmUserList_Load(null, null);   
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo n = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            n.ShowDialog();
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            if(clsGlobal.CurrentUser.UserID!=UserID)
            {
                MessageBox.Show("You Can not Change your freind's Passwod!!!");
                return;
            }


            frmChangePassword fuy = new frmChangePassword(UserID);
            fuy.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser opie= new frmAddUpdateUser();
            opie.ShowDialog();
            frmUserList_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            if(UserID==1)
            {
                MessageBox.Show("You Cant delete CEO Account");

                return;
            }
            if (MessageBox.Show("Are you sure you want to delete Person [" + UserID + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK);

            {

                //Perform Delele and refresh
                if (clsUsers.DeleteUser(UserID))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmUserList_Load(null, null);
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
