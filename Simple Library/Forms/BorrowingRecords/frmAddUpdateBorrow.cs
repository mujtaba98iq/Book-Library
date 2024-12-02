using BookCopiesBusinessLayer;
using BooksBusinessLayer;
using BorrowingRecordsBusinessLayer;
using ReservationsBusinessLayer;
using SettingsBusinessLayer;
using Simple_Library.Forms.Books;
using Simple_Library.GlobalClasses;
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

namespace Simple_Library.Forms.BorrowingRecords
{
    public partial class frmAddUpdateBorrow : Form
    {
        int _BorrowingRecordID = -1;
        int _BookID = -1;
        clsBorrowingRecord _BorrowingRecord;
        frmListBooks _frmListBooks;
        public enum _enMode
        {
            enAdd,
            enUpdate
        }
        _enMode _Mode = _enMode.enAdd;
        public frmAddUpdateBorrow(int bookID,frmListBooks frm)
        {
            InitializeComponent();
            _BorrowingRecord = new clsBorrowingRecord();
            _Mode = _enMode.enAdd;
            _BookID = bookID;
            _frmListBooks= frm;
        }
        public frmAddUpdateBorrow(int BorrowingRecordID, int BookID, frmListBooks frm)
        {
            InitializeComponent();
            _BorrowingRecordID = BorrowingRecordID;
            _BookID = BookID;
            _Mode = _enMode.enUpdate;
            _frmListBooks= frm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmAddUpdateBorrow_Load(object sender, EventArgs e)
        {
            if (_Mode == _enMode.enUpdate)
                LoadBorrowRecordInfo();
            else
                LoadBorrowRecordInfoForAddRecord();

        }

        private void LoadBorrowRecordInfoForAddRecord()
        {
            ctrlBookCardWithDetails1.LoadInfo(_BookID);
            nudBorrowingCost.Enabled= false;
            dtpBorrowDate.Enabled= false;
            dtpDueDate.Enabled= false;
            nudBorrowingCost.Value=clsDefualtSettings.GetDeffultBorrowCost() * clsDefualtSettings.GetDeffultBorrowDays();
            dtpBorrowDate.Text = DateTime.Now.ToString();
            dtpDueDate.Text=DateTime.Now.AddDays(clsDefualtSettings.GetDeffultBorrowDays()).ToString();
        }

        private void LoadBorrowRecordInfo()
        {
          _BorrowingRecord = clsBorrowingRecord.Find(_BorrowingRecordID);
            if (_BorrowingRecord == null)
            {
                MessageBox.Show($"This Record not found with ID={_BorrowingRecordID}");
                return;
            }
            FillBorrowRecordInfo();
        }

        private void FillBorrowRecordInfo()
        {
            int DeffultDueDayes = clsDefualtSettings.GetDeffultBorrowDays();
            int DeffultBorrowcost = clsDefualtSettings.GetDeffultBorrowDays();
            ctrlBookCardWithDetails1.LoadInfo(_BorrowingRecord.CopyInfo.BookID);
            dtpBorrowDate.Text = _BorrowingRecord.BorrowingDate.ToString();
            dtpDueDate.Text = _BorrowingRecord.DueDate.ToString();
            nudBorrowingCost.Text = _BorrowingRecord.BorrowCost.ToString()+"$";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ReservationID=-1;
            if (clsBorrowingRecord.isUserBorrowBook(_BookID, clsGlobal.CurrentUser.UserID))
            {
                MessageBox.Show("You already have this book","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (_Mode == _enMode.enAdd)
            {

                if (!(MessageBox.Show("Are your shor add Borrow Record Data", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                    return;
            }
            else
                if (!(MessageBox.Show("Are your shor Update Borrow Record Data ", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                    return;
            if(clsReservation.FindByUserIDAndBookID(clsGlobal.CurrentUser.UserID, _BookID) != null)
                 ReservationID = clsReservation.FindByUserIDAndBookID(clsGlobal.CurrentUser.UserID, _BookID).ReservationID;

            
            if (ReservationID>-1)
            {
                if (clsReservation.DeleteReservation(ReservationID))
                    MessageBox.Show("Your reservation request has been removed from the records.");

            }

            _BorrowingRecord.BorrowingDate =dtpBorrowDate.Value;
            _BorrowingRecord.DueDate = dtpBorrowDate.Value;
            _BorrowingRecord.BorrowCost =Convert.ToDecimal(nudBorrowingCost.Text);
            _BorrowingRecord.CopyID = clsBookCopies.GetAvailabelCopyIDForBookID(_BookID);
            if (_Mode == _enMode.enUpdate)
                _BorrowingRecord.UserID = _BorrowingRecord.UserID;
            else
                _BorrowingRecord.UserID = clsGlobal.CurrentUser.UserID;
            _BorrowingRecord.ActualReturnDate = DateTime.MinValue;

            if (_BorrowingRecord.Save())
            {

                clsBookCopies.SetBookCopyNotAvailabe(_BorrowingRecord.CopyID);
                lblTitle.Text = "Update Borrow";
                MessageBox.Show("Borrow Record Information saved secessesfuly");
                _Mode = _enMode.enUpdate;
                RestForm();
                _frmListBooks.LoadListBooks();
                return;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void RestForm()
        {
            if (_Mode == _enMode.enUpdate)
            {
                lblTitle.Text = "New Borrow";
                _BorrowingRecord = new clsBorrowingRecord();
            }
            else
                lblTitle.Text = "Update Borrow";
            ctrlBookCardWithDetails1.RestInfo();
            dtpBorrowDate.Value =DateTime.Now;
            dtpDueDate.Value = DateTime.Now;
            nudBorrowingCost.Value = 0;
        }
    }
}
