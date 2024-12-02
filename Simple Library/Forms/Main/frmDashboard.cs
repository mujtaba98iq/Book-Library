using BooksBusinessLayer;
using BorrowingRecordsBusinessLayer;
using FinesBusinessLayer;
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
using UsersBusinessLayer;

namespace Simple_Library.Forms.Main
{
    public partial class frmDashboard : Form
    {
        DataTable _dtNewUsers;
        DataTable _dtCurrentBorrowings;
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadNewUsers();
            LoadCurrentBorrowings();
            LoadCardsInfo();
        }
       
        private void LoadCardsInfo()
        {
            lblNumberOfBooks.Text = clsBook.GetAllBooks().Rows.Count.ToString();
            lblNumberOfBorrowingRecords.Text = clsBorrowingRecord.GetAllBorrowingRecords().Rows.Count.ToString();
            lblNumberOfUsers.Text=clsUser.GetAllUsers().Rows.Count.ToString();
            lblNumberOfReservations.Text = clsReservation.GetAllReservations().Rows.Count.ToString();
            lblFines.Text = clsFine.SumFineAmount().ToString();
            lblBilling.Text = clsBorrowingRecord.SumBilling().ToString();
        }

        private void LoadCurrentBorrowings()
        {
            _dtCurrentBorrowings = clsBorrowingRecord.GetTop5BooksBorrowing();
            dgvCurrentBorrowings.DataSource = _dtCurrentBorrowings;

            dgvCurrentBorrowings.Columns[0].HeaderText = "Name";
            dgvCurrentBorrowings.Columns[0].Width = 140;

            dgvCurrentBorrowings.Columns[1].HeaderText = "Borrowing Date";
            dgvCurrentBorrowings.Columns[1].Width = 140;

            dgvCurrentBorrowings.Columns[2].HeaderText = "Deu Date";
            dgvCurrentBorrowings.Columns[2].Width = 300;
        }

        private void LoadNewUsers()
        {
            _dtNewUsers = clsUser.GetNewUsers();
            dgvNewUsers.DataSource = _dtNewUsers;

            dgvNewUsers.Columns[0].HeaderText = "Name";
            dgvNewUsers.Columns[0].Width = 140;

            dgvNewUsers.Columns[1].HeaderText = "Email";
            dgvNewUsers.Columns[1].Width = 140;

            dgvNewUsers.Columns[2].HeaderText = "Date Time";
            dgvNewUsers.Columns[2].Width = 300;

        }

        private void panelLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
