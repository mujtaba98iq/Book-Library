using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Library.Forms.People
{
    public partial class frmListPeople : Form
    {
        private static DataTable _dtListPeople = clsPerson.GetAllPeople();

        //private DataTable _dtPeople = _dtListPeople.DefaultView.ToTable(true, "PersonID", "NationalNo",
        //                                               "FirstName", "SecondName", "ThirdName", "LastName",
        //                                               "GendorCaption", "DateOfBirth", "CountryName",
        //                                               "Phone", "Email");


        public frmListPeople()
        {
            InitializeComponent();
        }
        public void LoadPeople()
        {
            dgvPeople.DataSource = _dtListPeople;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = (dgvPeople.Rows.Count - 1).ToString();

            if (dgvPeople.Rows.Count > 0)
            {

                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;


                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gendor";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;


                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;


                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 170;
            }

        }
        private void _RefreshPeople()
        {
            _dtListPeople = clsPerson.GetAllPeople();
            //_dtPeople = _dtListPeople.DefaultView.ToTable(true, "PersonID", "NationalNo",
            //                                           "FirstName", "SecondName", "ThirdName", "LastName",
            //                                           "GendorCaption", "DateOfBirth", "CountryName",
            //                                           "Phone", "Email");
            dgvPeople.DataSource = _dtListPeople;
            lblRecordsCount.Text = (dgvPeople.Rows.Count - 1).ToString();
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            LoadPeople();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshPeople();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
            _RefreshPeople();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeople();
        }

        private void uPdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            frmAddUpdatePerson frm = new frmAddUpdatePerson(PersonID);
            frm.ShowDialog();
            _RefreshPeople();


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeople();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeople();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterClolumn = "";
            string FilterValue = cbFilterBy.Text;
            switch (FilterValue)
            {
                case "Person ID":
                    FilterClolumn = "PersonID";
                    break;
                case "National No":
                    FilterClolumn = "NationalNo";
                    break;
                case "First Name":
                    FilterClolumn = "FirstName";
                    break;
                case "Second Name":
                    FilterClolumn = "SecondName";
                    break;
                case "Third Name":
                    FilterClolumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterClolumn = "LastName";
                    break;
                case "Nationality":
                    FilterClolumn = "Nationality";
                    break;
                case "Gendor":
                    FilterClolumn = "Gendor";
                    break;
                case "Phone":
                    FilterClolumn = "Phone";
                    break;
                case "Email":
                    FilterClolumn = "Email";
                    break;
                default:
                    FilterClolumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterClolumn == "None")
            {
                _dtListPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = (dgvPeople.Rows.Count - 1).ToString();

                return;
            }
            if (FilterClolumn == "PersonID")

                _dtListPeople.DefaultView.RowFilter = string.Format("[{0}] ={1}", FilterClolumn, txtFilterValue.Text.Trim());

            else
                _dtListPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterClolumn, txtFilterValue.Text.Trim());
            lblRecordsCount.Text = (dgvPeople.Rows.Count - 1).ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm =new frmAddUpdatePerson();
            frm.ShowDialog();
        }
    }
}
