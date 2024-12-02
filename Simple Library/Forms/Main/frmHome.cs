using NotificaitonsBusinessLayer;
using Simple_Library.Forms.Books;
using Simple_Library.Forms.BorrowingRecords;
using Simple_Library.Forms.Fines;
using Simple_Library.Forms.Main.Controls;
using Simple_Library.Forms.People;
using Simple_Library.Forms.Reservations;
using Simple_Library.Forms.Users;
using Simple_Library.GlobalClasses;
using Simple_Library.Properties;
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

namespace Simple_Library.Forms.Main
{
    public partial class frmHome : Form
    {
        Panel _panel;
        string _DashboardClickBotton;
        public string DashboardClickBotton
        {
            get { return _DashboardClickBotton; }
            set
            {
                _DashboardClickBotton = value;
            }
        }
        public frmHome()
        {
            InitializeComponent();
            // _panel = pnlBorderPnlNotifications;
        }



        private void btnMax_Min_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                FormMinimizeAndMaximize(935, 9, 903, 9, FormWindowState.Normal);
            else
                FormMinimizeAndMaximize(1080, 9, 1050, 9, FormWindowState.Maximized);



        }
        private void FormMinimizeAndMaximize(int X_ClosePoint, int Y_ClosePoint, int X_Max_MinPoint, int Y_Max_MinPoint, FormWindowState WindowState)
        {

            Point ClosePoint = new Point(0, 0);
            Point Max_MinPoint = new Point(0, 0);



            ClosePoint = new Point(X_ClosePoint, Y_ClosePoint);
            btnClose.Location = ClosePoint;

            Max_MinPoint = new Point(X_Max_MinPoint, Y_Max_MinPoint);
            btnMax_Min.Location = Max_MinPoint;


            this.WindowState = WindowState;
            if (WindowState == FormWindowState.Maximized)

                btnMax_Min.Image = Resources.minimizing_arrows;

            else
                btnMax_Min.Image = Resources.Maximaiz;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "Dashboard";
            frmDashboard frm = new frmDashboard();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "Books";

            frmListBooks frm = new frmListBooks();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();

        }

        private void btnMyBooks_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "My Books";
            frmListUserBooks frm = new frmListUserBooks();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "People";
            frmListPeople frm = new frmListPeople();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "Users";
            frmListUsers frm = new frmListUsers();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();
        }

        private void btnBorrowingRecords_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "Borrowing Records";
            frmListBorrowingBooks frm = new frmListBorrowingBooks();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "Book Reservation";
            frmListReservationsBooks frm = new frmListReservationsBooks();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();
        }

        private void btnFines_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "Fines";
            frmListFines frm = new frmListFines();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "Settings";
            frmProfile frm = new frmProfile();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "About";
            frmAbout frm = new frmAbout();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            
            HandelIsAdmin();
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            FormMinimizeAndMaximize(1080, 9, 1050, 9, FormWindowState.Maximized);
            LoadUserInfo();
        }

        private void HandelIsAdmin()
        {
            if (!clsGlobal.CurrentUser.IsAdmin)
            {
                btnBorrowingRecords.Visible = false;
                btnDashboard.Visible = false;
                btnFines.Visible = false;
                btnPeople.Visible = false;
                btnUsers.Visible = false;
                btnReservationRecords.Visible = false;
                btnBooks_Click(null, null);
            }
            else
            {
                btnDashboard_Click(null, null);

            }
        }

        private void LoadUserInfo()
        {
            lblCurrentUser.Text = clsGlobal.CurrentUser.UserName;
            pbUserImage.ImageLocation = clsGlobal.CurrentUser.PersonInfo.ImagePath;
        }

        private void btnReservationsRecords_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frmWait = new frmWaitForm(clsGlobal.ShortWait))
            {
                frmWait.ShowDialog(this);
            }
            lblCurrentPage.Text = "Reservations";
            frmListReservations frm = new frmListReservations();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnlHome.Controls.Clear();
            pnlHome.Controls.Add(frm);
            frm.Show();
        }

        private void btnNoifications_Click(object sender, EventArgs e)
        {
            frmNotifications frm = new frmNotifications();
            frm.ShowDialog();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddUpdateBook frm = new frmAddUpdateBook();
            frm.ShowDialog();
            btnBooks_Click(sender, new EventArgs());
        }
    }
}
