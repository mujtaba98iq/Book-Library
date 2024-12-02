using BorrowingRecordsBusinessLayer;
using ReservationsBusinessLayer;
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

namespace Simple_Library.Forms.Reservations.Controls
{
    public partial class ctrlReservationCardInfo : UserControl
    {

        private clsReservation _Reservation;
        private int _ReservationID;

        public ctrlReservationCardInfo()
        {
            InitializeComponent();
        }
        public void LoadInfo(int ReservationID)
        {
            _Reservation = clsReservation.Find(ReservationID);
            if (_Reservation == null)
            {
                RestInfo();
                MessageBox.Show("This Record Not Found with ID:" + ReservationID);
                return;
            }
            FillBookInfo();
        }

        public void RestInfo()
        {
            lblBookID.Text = "???";
            lblReservationDate.Text = "???";
            lblReservationID.Text = "???";
            lblUserID.Text = "???";
        }

        private void FillBookInfo()
        {
            _ReservationID = _Reservation.ReservationID;
            lblReservationID.Text= _ReservationID.ToString();
            lblBookID.Text = _Reservation.BookID.ToString();
            lblReservationDate.Text = _Reservation.ReservationDate.ToString();
            lblUserID.Text = _Reservation.UserID.ToString();

            LoadImage();
        }
        private void LoadImage()
        {
            string ImagePath = _Reservation.BookInfo.Image;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbBookImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
