using BorrowingRecordsBusinessLayer;
using ReservationsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Library.Forms.Reservations
{
    public partial class frmListReservations : Form
    {
        DataTable _dtReservations;
        public frmListReservations()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            string FilterValue = cbFilterBy.Text;
            switch (FilterValue)
            {
                case "Reservation ID":
                    FilterColumn = "ReservationID";
                    break;
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Book ID":
                    FilterColumn = "BookID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }
            if (FilterColumn == "" || txtFilterValue.Text.Trim() == "")
            {
                _dtReservations.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtReservations.Rows.Count.ToString();
                return;
            }

            _dtReservations.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            lblRecordsCount.Text = _dtReservations.Rows.Count.ToString();

        }

        private void frmListReservations_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void LoadInfo()
        {
            _dtReservations = clsReservation.GetAllReservations();
            dgvBorrowingBooks.DataSource = _dtReservations;
            lblRecordsCount.Text = _dtReservations.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            dgvBorrowingBooks.Columns[0].HeaderText = "Reservation ID";
            dgvBorrowingBooks.Columns[0].Width = 140;

            dgvBorrowingBooks.Columns[1].HeaderText = "User ID";
            dgvBorrowingBooks.Columns[1].Width = 140;

            dgvBorrowingBooks.Columns[2].HeaderText = "Book ID";
            dgvBorrowingBooks.Columns[2].Width = 300;

            dgvBorrowingBooks.Columns[3].HeaderText = "Reservation Date";
            dgvBorrowingBooks.Columns[3].Width = 300;

        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            int ReservationID = (int)dgvBorrowingBooks.CurrentRow.Cells[0].Value;
            frmShowReservationInfo frm = new frmShowReservationInfo(ReservationID);
            frm.ShowDialog();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
