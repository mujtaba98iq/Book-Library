using BL.SimpleLibrary;
using BooksBusinessLayer;
using BorrowingRecordsBusinessLayer;
using ReservationsBusinessLayer;
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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBusinessLayer;

namespace Simple_Library.Forms.Books.Controls
{
    public partial class ctrlBookCard : UserControl
    {
        clsBook _Book;
        int _BookID;
        frmListBooks _frmListBooks;
        frmListReservationsBooks _frmListReservationsBooks;
        bool IsComeFromfrmListBooks=false;
        public ctrlBookCard()
        {
            InitializeComponent();
        }
        public void LoadInfo(int BookID,frmListBooks frm)
        {
            this.ContextMenuStrip = cmsManageBook;
            IsComeFromfrmListBooks = true;
            _Book = clsBook.Find(BookID);
            if (_Book == null)
            {
                RestInfo();
                MessageBox.Show("This Book Not Found with ID:" + BookID);
                return;
            }
            _frmListBooks = frm;
            FillBookInfo();
        }
        public void LoadInfo(int BookID,frmListReservationsBooks frm)
        {
            this.ContextMenuStrip = cmsManageReservations;
            _Book = clsBook.Find(BookID);
            if (_Book == null)
            {
                RestInfo();
                MessageBox.Show("This Book Not Found with ID:" + BookID);
                return;
            }
            _frmListReservationsBooks = frm;
            FillBookInfo();

        }

        private void FillBookInfo()
        {
            _BookID= _Book.BookID;
            lblTitle.Text = _Book.Title;
            lblAuther.Text = _Book.Auther;
            if (clsBook.IsAvailabel(_BookID))
            {
                lblIsAvailabel.Text = "Availabile";
                lblIsAvailabel.BackColor = Color.Green;
            }
            else
            {
                lblIsAvailabel.Text = "Not Availabile";
                lblIsAvailabel.BackColor= Color.Red;
            }
            Rate.Value = clsRatings.GetBookRate(_Book.BookID);
            LoadImage();
        }

        private void LoadImage()
        {
            string ImagePath = _Book.Image;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbBookImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void RestInfo()
        {
            _BookID = -1;
            lblAuther.Text = "???";
            lblIsAvailabel.Text="???";
            lblTitle.Text="???";
            pbBookImage.Image = Resources.Book_Question;
            Rate.Value = 0;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tsBookDetails_Click(object sender, EventArgs e)
        {
            if(IsComeFromfrmListBooks)
            {
                frmBookDetails frm = new frmBookDetails(_BookID, _frmListBooks);
                frm.ShowDialog();
            }
            else
            {
                frmBookDetails frm = new frmBookDetails(_BookID, _frmListReservationsBooks);
                frm.ShowDialog();
            }
            
        }

        private void cmsManageBook_Opening(object sender, CancelEventArgs e)
        {
            if (!clsUser.isUserAdmin(clsGlobal.CurrentUser.UserID))
            {
                tsmEdit.Visible = false;
                tsmEdit.Enabled= false;
                tsmDelete.Visible = false;
                tsmDelete.Enabled= false;
            }
        }

        private void tsmReserveBook_Click(object sender, EventArgs e)
        {
            if (clsReservation.isUserReserveThisBook(clsGlobal.CurrentUser.UserID,_BookID))
            {
                MessageBox.Show("Indeed, there is already a reservation for you for this book.","Not Complete",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                   return;
            }

            if (clsBorrowingRecord.isUserBorrowBook(_BookID,clsGlobal.CurrentUser.UserID))
            {
                MessageBox.Show("You indeed own this book.", "Not Complete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsReservation reservation = new clsReservation();
            reservation.ReservationDate = DateTime.Now;
            reservation.UserID = clsGlobal.CurrentUser.UserID;
            reservation.BookID = _BookID;
            if (reservation.Save())
            {
                MessageBox.Show("Your reservation for this book has been recorded. You will be notified when it becomes available.");
            }
        }

        private void tsmBorrow_Click(object sender, EventArgs e)
        {
            if (clsBook.IsAvailabel(_BookID))
            {
                frmAddUpdateBorrow frm = new frmAddUpdateBorrow(_BookID, _frmListBooks);
                frm.ShowDialog();
            }
            else 
            {
                MessageBox.Show("This book is not Availabel","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmAddUpdateBook frm = new frmAddUpdateBook(_BookID, _frmListBooks);
            frm.ShowDialog();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (!(MessageBox.Show("Are your shor Delete Book", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                return;
            clsBook.DeleteBook(_BookID);
            _frmListBooks.LoadListBooks();
        }
    }
}
