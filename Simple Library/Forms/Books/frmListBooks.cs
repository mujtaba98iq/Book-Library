using BooksBusinessLayer;
using Simple_Library.Forms.Books.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Library.Forms.Books
{
    public partial class frmListBooks : Form
    {
        DataTable _ListBooks;
        int _BookID;
        public frmListBooks()
        {
            InitializeComponent();
            LoadListBooks();
        }
        public void LoadListBooks()
        {
            flowLayoutPanel1.Controls.Clear();
            _ListBooks=clsBook.GetAllBooks();

            foreach (DataRow row in _ListBooks.Rows)
            {
                _BookID =Convert.ToInt32(row["BookID"].ToString());
                 ctrlBookCard ctrlBookCard = new ctrlBookCard();
                ctrlBookCard.LoadInfo(_BookID,this);
                flowLayoutPanel1.Controls.Add(ctrlBookCard);
            }

        }

        
    }
}
