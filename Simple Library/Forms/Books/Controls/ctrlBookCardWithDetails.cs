using BL.SimpleLibrary;
using BookCopiesBusinessLayer;
using BooksBusinessLayer;
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
    public partial class ctrlBookCardWithDetails : UserControl
    {
        clsBook _Book;
        int _BookID=-1;
        int _BookRate=-1;
        public int BookRate
        {
            get
            {
                return _BookRate;
            }
        }
      
        public int BookID
        {
            get
            {
                return _BookID;
            }
        }
        public ctrlBookCardWithDetails()
        {
            InitializeComponent();
        }
        public void LoadInfo(int BookID)
        {
            _Book = clsBook.Find(BookID);
            if (_Book == null)
            {
                RestInfo();
                MessageBox.Show("This Book Not Found with ID:" + BookID);
                return;
            }

            FillBookInfo();

        }
        public void LoadInfo(string Title)
        {
            _Book = clsBook.FindByTitle(Title);
            if (_Book == null)
            {
                RestInfo();
                MessageBox.Show("This Book Not Found with ID:" + BookID);
                return;
            }

            FillBookInfo();

        }

        private void FillBookInfo()
        {
            _BookID = _Book.BookID;
            lblBookID.Text = _BookID.ToString();
            lblAdditionalDetails.Text = _Book.AdditionalDetails;
            lblPublicationDate.Text=_Book.PublicationDate.ToString();
            lblQuentity.Text = clsBookCopies.NumberOfCopiesBook(_BookID).ToString();
            lblTitle.Text = _Book.Title;
            lblAuther.Text = _Book.Auther;
            lblISBN.Text = _Book.ISBN;
            lblGenre.Text = _Book.Genre;
            _BookRate=clsRatings.GetBookRate(_BookID);
            if (clsBook.IsAvailabel(_BookID))
            {
                lblIsAvailabel.Text = "Availabile";
                lblIsAvailabel.BackColor = Color.Green;
            }
            else
            {
                lblIsAvailabel.Text = "Not Availabile";
                lblIsAvailabel.BackColor = Color.Red;
            }
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
            lblIsAvailabel.Text = "???";
            lblTitle.Text = "???";
            pbBookImage.Image = Resources.Book_Question;
        }
    }
}
