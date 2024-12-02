using BL.SimpleLibrary;
using Simple_Library.Forms.BorrowingRecords;
using Simple_Library.Forms.Reservations;
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

namespace Simple_Library.Forms.Books
{
    public partial class frmBookDetails : Form
    {
        int _UserRate=-1;
        bool _CanRate=false;
        int _BookID = -1;
        frmListBooks _frmListBooks;
        frmListReservationsBooks _frmListReservations;
        bool _IsComeFromListBooks=false;
        public frmBookDetails(int BookID, frmListBooks frm)
        {
            InitializeComponent();
            _frmListBooks = frm;
            _IsComeFromListBooks = true;
            LoadBookInfo(BookID);
        }
        public frmBookDetails(int BookID, frmListReservationsBooks frm)
        {
            InitializeComponent();
            _frmListReservations = frm;
            LoadBookInfo(BookID);
        }
      
        public void LoadBookInfo(int BookID)
        {

            ctrlBookCardWithDetails1.LoadInfo(BookID);
            _BookID = ctrlBookCardWithDetails1.BookID;
            if (_BookID== -1)
            {
                rtBookRate.Enabled = false;
                rtYourRate.Enabled = false;
            }

            rtBookRate.Text = ctrlBookCardWithDetails1.BookRate.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if ( _BookID!= -1 && _UserRate != -1)
                clsRatings.RateABook(_BookID, clsGlobal.CurrentUser.UserID, _UserRate);
            
            if (_IsComeFromListBooks)
                _frmListBooks.LoadListBooks();
            else
                _frmListReservations.LoadListBooks();
            this.Close();
        }

        private void rtYourRate_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            if (clsRatings.CanRate(_BookID, clsGlobal.CurrentUser.UserID))
                _UserRate = rtYourRate.Value;
            else
                MessageBox.Show("You have previously reviewed this book!.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
