using BorrowingRecordsBusinessLayer;
using NotificaitonsBusinessLayer;
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
    public partial class frmListBorrowingBooks : Form
    {
        DataTable _dtBorrowingRecords;
        public frmListBorrowingBooks()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = !(cbFilterBy.Text == "None");
            if (cbFilterBy.Text != "None")
            {
                txtFilterValue.Enabled = true;
            }
            else
                txtFilterValue.Enabled = false;

            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            string FilterValue = cbFilterBy.Text;
            switch (FilterValue)
            {
                case "Borrowing Record ID":
                    FilterColumn = "BorrowingRecordID";
                    break;
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Copy ID":
                    FilterColumn = "CopyID";
                    break;

                case "Borrow Cost":
                    FilterColumn = "BorrowCost";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }
            if (FilterColumn == "" || txtFilterValue.Text.Trim() == "")
            {
                _dtBorrowingRecords.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtBorrowingRecords.Rows.Count.ToString();
                return;
            }

            _dtBorrowingRecords.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            lblRecordsCount.Text = _dtBorrowingRecords.Rows.Count.ToString();

        }

        private void frmListBorrowingBooks_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void LoadInfo()
        {

            _dtBorrowingRecords = clsBorrowingRecord.GetAllBorrowingRecords();
            dgvBorrowingBooks.DataSource = _dtBorrowingRecords;
            lblRecordsCount.Text = _dtBorrowingRecords.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            dgvBorrowingBooks.Columns[0].HeaderText = "Borrowing Record ID";
            dgvBorrowingBooks.Columns[0].Width = 140;

            dgvBorrowingBooks.Columns[1].HeaderText = "User ID";
            dgvBorrowingBooks.Columns[1].Width = 140;

           dgvBorrowingBooks.Columns[2].HeaderText = "Copy ID";
           dgvBorrowingBooks.Columns[2].Width = 300;

            dgvBorrowingBooks.Columns[3].HeaderText = "Borrowing Date";
            dgvBorrowingBooks.Columns[3].Width = 300;

            dgvBorrowingBooks.Columns[4].HeaderText = "Due Date";
           dgvBorrowingBooks.Columns[4].Width = 140;

            dgvBorrowingBooks.Columns[5].HeaderText = "ActualReturn Date";
           dgvBorrowingBooks.Columns[5].Width = 140;

           dgvBorrowingBooks.Columns[6].HeaderText = "Borrow Cost";
            dgvBorrowingBooks.Columns[6].Width = 140;
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
    }
    }

