using BL.SimpleLibrary;
using BooksBusinessLayer;
using BorrowingRecordsBusinessLayer;
using FinesBusinessLayer;
using SettingsBusinessLayer;
using Simple_Library.Forms.BorrowingRecords;
using Simple_Library.Forms.Reservations;
using Simple_Library.GlobalClasses;
using Simple_Library.Properties;
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

namespace Simple_Library.Forms.Books.Controls
{
    public partial class ctrlBookUserCard : UserControl
    {
        clsBorrowingRecord _BorrowingRecord;
        int _BorrowingRecordID;
        frmListUserBooks _frmListBorrowingBooks;
        frmListReservationsBooks _frmListBorrowingBooksForfrmReservations;
        int _LateDays = -1;
        public ctrlBookUserCard()
        {
            InitializeComponent();
        }
        public void LoadInfo(int BorrowingRecordID, frmListUserBooks frm)
        {
            _BorrowingRecord = clsBorrowingRecord.Find(BorrowingRecordID);
            if (_BorrowingRecord == null)
            {
                RestInfo();
                MessageBox.Show("This Book Not Found with ID:" + BorrowingRecordID);
                return;
            }
            _frmListBorrowingBooks = frm;
            FillBookInfo();
        }
        public void LoadInfoForfrmReservation(int BorrowingRecordID, frmListReservationsBooks frm)
        {
            _BorrowingRecord = clsBorrowingRecord.Find(BorrowingRecordID);
            if (_BorrowingRecord == null)
            {
                RestInfo();
                MessageBox.Show("This Book Not Found with ID:" + BorrowingRecordID);
                return;
            }
            _frmListBorrowingBooksForfrmReservations = frm;
            FillBookInfo();
        }

        public void RestInfo()
        {
            lblAuther.Text = "???";
            lblTitle.Text = "???";
            pbBookImage.Image = Resources.Book_Question;
            lblDueDate.Text = "???";
            lblBorrowDate.Text = "???";
            lblLateDays.Text = "???";   
        }

        private void FillBookInfo()
        {
            _BorrowingRecordID = _BorrowingRecord.BorrowingRecordID;
            _LateDays = clsBorrowingRecord.LateDays(_BorrowingRecordID);

            lblTitle.Text = _BorrowingRecord.BookInfo.Title;
            lblAuther.Text = _BorrowingRecord.BookInfo.Auther;
            lblBorrowDate.Text = _BorrowingRecord.BorrowingDate.ToShortDateString();
            lblDueDate.Text = _BorrowingRecord.DueDate.ToShortDateString();
            lblLateDays.Text = _LateDays.ToString();
            
            LoadImage();
        }
        private void LoadImage()
        {
            string ImagePath = _BorrowingRecord.BookInfo.Image;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbBookImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
         
            if (_BorrowingRecord.ReturnBook())
            {
                if(_LateDays==0)
                MessageBox.Show("Return Book successfuly No extra Fine","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                {
                    clsFine fine= new clsFine();
                    fine.UserID = _BorrowingRecord.UserID;
                    fine.DorrowingRecordID = _BorrowingRecordID;
                    fine.FineAmount=_LateDays*clsDefualtSettings.GetDeffultBorrowCost();
                    fine.CreatedByUserID=clsGlobal.CurrentUser.UserID;
                    fine.PaymentStatus = false;
                    fine.NumberOfLateDays =(short)_LateDays;
                    if (fine.Save())
                        MessageBox.Show($"You are {_LateDays} days late \n We Will charge you: {fine.FineAmount} USD", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Fine operation faield!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                _frmListBorrowingBooks.LoadListBooks();
            }
            else
                MessageBox.Show("Return Book Faield", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
