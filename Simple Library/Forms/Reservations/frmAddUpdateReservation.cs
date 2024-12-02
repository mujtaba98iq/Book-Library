using BookCopiesBusinessLayer;
using BorrowingRecordsBusinessLayer;
using ReservationsBusinessLayer;
using SettingsBusinessLayer;
using Simple_Library.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Library.Forms.Reservations
{
    public partial class frmAddUpdateReservation : Form
    {
        int _ReservationsID = -1;
        int _BookID = -1;
        clsReservation _Reservations;
        public enum _enMode
        {
            enAdd,
            enUpdate
        }
        _enMode _Mode = _enMode.enAdd;
        public frmAddUpdateReservation(int bookID)
        {
            InitializeComponent();
            _Reservations = new clsReservation();
            _Mode = _enMode.enAdd;
            _BookID = bookID;
        }
        public frmAddUpdateReservation(int ReservationsID, int bookID)
        {
            InitializeComponent();
            _Mode = _enMode.enUpdate;
            _ReservationsID = ReservationsID;
            _BookID = bookID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (_Mode == _enMode.enAdd)
            {
                if (clsReservation.isUserReserveThisBook(clsGlobal.CurrentUser.UserID, _BookID))
                {
                    MessageBox.Show("You already Reserve this book", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(MessageBox.Show("Are your sure add Reserve Record Data", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                    return;
            }
            else
                if (!(MessageBox.Show("Are your sure Update Reserve Record Data ", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                return;

            _Reservations.ReservationDate = dtpReservationDate.Value;
            _Reservations.BookID = _BookID;

            if (_Mode == _enMode.enUpdate)
                _Reservations.UserID =Convert.ToInt32(txtUserID.Text);
            else
                _Reservations.UserID = clsGlobal.CurrentUser.UserID;

            if (_Reservations.Save())
            {
                lblTitle.Text = "Update Reservations";
                lblReservationID.Text = _Reservations.ReservationID.ToString();
                MessageBox.Show("Reservations Record Information saved secessesfuly");
                _Mode = _enMode.enUpdate;
                return;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void RestForm()
        {
            lblReservationID.Text = "???";
            txtUserID.Text = "???";
            dtpReservationDate.Text = DateTime.Now.ToShortDateString();
        }

        private void frmAddUpdateReservation_Load(object sender, EventArgs e)
        {

            if (_Mode == _enMode.enUpdate)
                LoadReservationInfoForAddRecord();
            else
                LoadReservationInfo();
        }

        private void LoadReservationInfoForAddRecord()
        {
            _Reservations = clsReservation.Find(_ReservationsID);
            if( _Reservations == null )
            {
                MessageBox.Show($"This Reservation Record not found with ID={_ReservationsID}");
                return;
            }

            FillBorrowRecordInfo();
        }

        private void FillBorrowRecordInfo()
        {
            lblTitle.Text = "Update Reservations";
            lblReservationID.Text = _ReservationsID.ToString();
            ctrlBookCardWithDetails1.LoadInfo(_Reservations.BookID);
            dtpReservationDate.Text = _Reservations.ReservationDate.ToString();
            txtUserID.Text = clsGlobal.CurrentUser.UserID.ToString() ;
        }
        private void LoadReservationInfo()
        {
            ctrlBookCardWithDetails1.LoadInfo(_BookID);
            dtpReservationDate.Enabled = false;
            txtUserID.Text = clsGlobal.CurrentUser.UserID.ToString();
            dtpReservationDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
