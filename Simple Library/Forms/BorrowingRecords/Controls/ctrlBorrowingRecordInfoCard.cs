using BorrowingRecordsBusinessLayer;
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

namespace Simple_Library.Forms.BorrowingRecords.Controls
{
    public partial class ctrlBorrowingRecordInfoCard : UserControl
    {
        private clsBorrowingRecord _BorrowingRecord;
        private int _BorrowingRecordID;

        public ctrlBorrowingRecordInfoCard()
        {
            InitializeComponent();
        }
        public void LoadInfo(int BorrowingRecordID )
        {
            _BorrowingRecord = clsBorrowingRecord.Find(BorrowingRecordID);
            if (_BorrowingRecord == null)
            {
                RestInfo();
                MessageBox.Show("This Record Not Found with ID:" + BorrowingRecordID);
                return;
            }
            FillBookInfo();
        }

        public void RestInfo()
        {
            lblActualReturnDate.Text = "???";
            lblBorrowCost.Text = "???";
            lblBorrowingRecordID.Text = "???";
            lblCopyID.Text = "???";
            lblUserID.Text = "???";
            pbBookImage.Image = Resources.Book_Question;
            lblDueDate.Text = "???";
            lblBorrowDate.Text = "???";
        }

        private void FillBookInfo()
        {
            _BorrowingRecordID = _BorrowingRecord.BorrowingRecordID;

            lblUserID.Text = _BorrowingRecord.UserID.ToString() ;
            lblCopyID.Text = _BorrowingRecord.CopyID.ToString() ;
            lblBorrowingRecordID.Text = _BorrowingRecordID.ToString();
            lblBorrowCost.Text= _BorrowingRecord.BorrowCost.ToString() +"$";
            lblActualReturnDate.Text= _BorrowingRecord.ActualReturnDate.ToString() ;
            lblBorrowDate.Text = _BorrowingRecord.BorrowingDate.ToShortDateString();
            lblDueDate.Text = _BorrowingRecord.DueDate.ToShortDateString();

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

        private void ctrlBorrowingRecordInfoCard_Load(object sender, EventArgs e)
        {

        }
    }
}
