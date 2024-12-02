using BookCopiesBusinessLayer;
using BooksBusinessLayer;
using DVLD2.GlobalClasses;
using PeopleBusinessLayer;
using Simple_Library.GlobalClasses;
using Simple_Library.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Simple_Library.Forms.People.frmAddUpdatePerson;
using static Simple_Library.Forms.Users.frmAddUpdateUser;

namespace Simple_Library.Forms.Books
{
    public partial class frmAddUpdateBook : Form
    {
        public delegate void DataBackEventHandler(object obj, int BookID);

       public DataBackEventHandler DataBack;
        int _BookID=-1;
        clsBook _Book;
        frmListBooks _frmListBooks;
        enum enMode
        {
            enAdd,enUpdate
        }
        enMode _Mode=enMode.enAdd;
        public frmAddUpdateBook()
        {
            InitializeComponent();
            _Book=new clsBook();
            _Mode = enMode.enAdd;
        }

        public frmAddUpdateBook(int BookID,frmListBooks frm)
        {
            InitializeComponent();
            _BookID = BookID;
            _Mode = enMode.enUpdate;
            _frmListBooks = frm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;
            if (_Mode == enMode.enAdd)
                if (!(MessageBox.Show("Are your shor add Book", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                    return;
                else
                if (!(MessageBox.Show("Are your shor Update Book ", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                    return;
            int Quentity =Convert.ToInt32( txtQuentity.Text);
            _HandlePersonImage();
            _Book.Title=txtTitle.Text;
            _Book.ISBN=txtISBN.Text;
            _Book.PublicationDate=dtpPublicationDate.Value;
            _Book.AdditionalDetails=txtAdditionalDetails.Text;
            _Book.Auther=txtAuther.Text;
            _Book.Genre=txtGenre.Text;
            if (_Mode == enMode.enUpdate)
                _Book.CreatedByUserID = _Book.CreatedByUserID;
            else
            _Book.CreatedByUserID=clsGlobal.CurrentUser.UserID;
            _Book.Image = pbBookImage.ImageLocation;
            if(_Book.Save())
            {

                lblBookID.Text = _Book.BookID.ToString() ;
              _BookID=_Book.BookID;
                MessageBox.Show("Book Information saved secessesfuly");
                clsBookCopies.AddBookCopy(_BookID, Quentity, clsGlobal.CurrentUser.UserID);
                DataBack?.Invoke(this,_Book.BookID);
                if(_Mode == enMode.enUpdate)
                _frmListBooks.LoadListBooks();
                _Mode = enMode.enUpdate;
                lblTitleForm.Text = "Update Book";
                RestForm();
                return;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void RestForm()
        {
                if (_Mode == enMode.enUpdate)
            {
                lblTitleForm.Text = "Add Book";
                _Book = new clsBook();
            }
            else
                lblTitleForm.Text = "Update Book";
            llRemoveImage.Visible = (pbBookImage.ImageLocation != null);
            pbBookImage.Image = Resources.books;

            lblBookID.Text = "???";
            txtAdditionalDetails.Text = "";
            txtAuther.Text = "";
            txtGenre.Text = "";
            txtISBN.Text = "";
            txtQuentity.Text = "";
            txtTitle.Text = "";
            

        }
        private bool _HandlePersonImage()
        {
            if (_Book.Image == pbBookImage.ImageLocation)
            {
                if (_Book.Image != null)
                {
                    try
                    {
                        File.Delete(_Book.Image);
                    }
                    catch (IOException)
                    {

                    }
                }
                if (pbBookImage.ImageLocation != null)
                {
                    string SourceImageFile = pbBookImage.ImageLocation;
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbBookImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           pbBookImage.ImageLocation = null;
            pbBookImage.Image = Resources.books;
            llRemoveImage.Enabled = false;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbBookImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void txtNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
      
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)(sender);
            if (string.IsNullOrEmpty(Temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
                errorProvider1.SetError(Temp, null);
            
        }

        private void frmAddUpdateBook_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.enUpdate)
                LoadBookInfo();
        }

        private void LoadBookInfo()
        {
            _Book=clsBook.Find(_BookID);
            if( _Book == null)
            {
                MessageBox.Show($"The Book is Not Exists with ID = {_BookID}");
                return;
            }
            lblBookID.Text = _Book.BookID.ToString();
            txtAdditionalDetails.Text = _Book.AdditionalDetails;
            txtAuther.Text = _Book.Auther;
            txtGenre.Text = _Book.Genre;
            txtISBN.Text = _Book.ISBN;
            txtQuentity.Text = clsBookCopies.NumberOfCopiesBook(_BookID).ToString();
            txtTitle.Text= _Book.Title;
            dtpPublicationDate.Value = _Book.PublicationDate;
            pbBookImage.ImageLocation = _Book.Image;
        }

      
    }
}
