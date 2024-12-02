using FinesBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBusinessLayer;

namespace Simple_Library.Forms.Fines
{
    public partial class frmListFines : Form
    {
        DataTable _dtFines;
        public frmListFines()
        {
            InitializeComponent();
        }

        private void frmListFines_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void LoadInfo()
        {
            _dtFines = clsFine.GetAllFines();
            if (_dtFines.Rows.Count == 0)
            {
                MessageBox.Show("NOOOOOOe");
            }
           
            dgvFines.DataSource = _dtFines;
            lblRecordsCount.Text = _dtFines.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            dgvFines.Columns[0].HeaderText = "Fine ID";
            dgvFines.Columns[0].Width = 70;

            dgvFines.Columns[1].HeaderText = "User ID";
            dgvFines.Columns[1].Width = 70;

            dgvFines.Columns[2].HeaderText = "Dorrowing Record ID";
            dgvFines.Columns[2].Width = 150;

            dgvFines.Columns[3].HeaderText = "Number Of Late Days";
            dgvFines.Columns[3].Width = 140;

            dgvFines.Columns[4].HeaderText = "Fine Amount";
            dgvFines.Columns[4].Width = 150;
            
            dgvFines.Columns[5].HeaderText = "Payment Status";
            dgvFines.Columns[5].Width = 120;
            
            dgvFines.Columns[6].HeaderText = "Created By User ID";
            dgvFines.Columns[6].Width =150;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Payment Status")
            {
                txtFilterValue.Visible = false;
                cbIsPaid.Visible = true;
                cbIsPaid.Enabled = true;

                cbIsPaid.Focus();
                cbIsPaid.SelectedIndex = 0;
            }
            else
            {
                cbIsPaid.Enabled = false;
                cbIsPaid.Visible=false;
                

                txtFilterValue.Visible = !(cbFilterBy.Text == "None");
                if (cbFilterBy.Text != "None")
                {
                    txtFilterValue.Enabled = true;
                }
                else
                    txtFilterValue.Enabled = false;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            string FilterValue = cbFilterBy.Text;
            switch (FilterValue)
            {
                case "Fine ID":
                    FilterColumn = "FineID";
                    break;
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Dorrowing Record ID":
                    FilterColumn = "DorrowingRecordID";
                    break;

                case "Number Of Late Days":
                    FilterColumn = "NumberOfLateDays";
                    break;
                    
                case "Fine Amount":
                    FilterColumn = "FineAmount";
                    break;
                        case "Payment Status":
                    FilterColumn = "PaymentStatus";
                    break;
                          case "Created By User ID":
                    FilterColumn = "CreatedByUserID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }
            if (FilterColumn == "" || txtFilterValue.Text.Trim() == "")
            {
                _dtFines.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtFines.Rows.Count.ToString();
                return;
            }

            _dtFines.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            lblRecordsCount.Text = _dtFines.Rows.Count.ToString();

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FIlterColumn = "PaymentStatus";
            string FilterValue = cbIsPaid.Text;
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
                _dtFines.DefaultView.RowFilter = "";
            else
                _dtFines.DefaultView.RowFilter = string.Format("[{0}]={1}", FIlterColumn, FilterValue);
            lblRecordsCount.Text = _dtFines.Rows.Count.ToString();

        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
