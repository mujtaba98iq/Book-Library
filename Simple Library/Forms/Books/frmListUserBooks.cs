using BooksBusinessLayer;
using BorrowingRecordsBusinessLayer;
using Simple_Library.Forms.Books.Controls;
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

namespace Simple_Library.Forms.BorrowingRecords
{
  
    public partial class frmListUserBooks : Form
    {
        DataTable _ListBooks;
        int _BorrowingRecordID;
        public frmListUserBooks()
        {
            InitializeComponent();
            LoadListBooks();
        }

        public void LoadListBooks()
        {
            int UserID=clsGlobal.CurrentUser.UserID;
           flowLayoutPanel1.Controls.Clear();
            _ListBooks = clsBorrowingRecord.GetAllBorrowingRecordsForUser(UserID);
            if (_ListBooks.Rows.Count == 0)
            {
              
                Label lblBooksStatus =new Label();
                lblBooksStatus.Text = "Not Found";
                lblBooksStatus.Font = new Font(lblBooksStatus.Font.FontFamily, 14);
                lblBooksStatus.ForeColor = Color.Red;
                flowLayoutPanel1.Controls.Add(lblBooksStatus);

            }

            foreach (DataRow row in _ListBooks.Rows)
            {
                _BorrowingRecordID = Convert.ToInt32(row["BorrowingRecordID"].ToString());
                ctrlBookUserCard ctrlBookCard = new ctrlBookUserCard();
                ctrlBookCard.LoadInfo(_BorrowingRecordID, this);
                flowLayoutPanel1.Controls.Add(ctrlBookCard);
            }
        }
    }
}
