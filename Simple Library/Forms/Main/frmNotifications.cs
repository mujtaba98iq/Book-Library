using NotificaitonsBusinessLayer;
using Simple_Library.Forms.Main.Controls;
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

namespace Simple_Library.Forms.Main
{
    public partial class frmNotifications : Form
    {
        public frmNotifications()
        {
            InitializeComponent();
        }

        private void frmNotifications_Load(object sender, EventArgs e)
        {
            int secreenwidth=Screen.PrimaryScreen.Bounds.Width;
            int formWidth=this.Width;
            this.Location=new Point ((secreenwidth-formWidth)-160,50);  
            LoadNotifications();

        }

        private void LoadNotifications()
        {
            pnlNotifications.Controls.Clear();
            DataTable dt = clsNotification.GetAllNotificaitonsForUser(clsGlobal.CurrentUser.UserID);
            foreach (DataRow row in dt.Rows)
            {
                ctrlNotification ctrlNotification = new ctrlNotification();
                ctrlNotification.LoadInfo(row["Description"].ToString());
                pnlNotifications.Controls.Add(ctrlNotification);
            }
        }

        private void btnCloseNotifications_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteAllNotifications_Click(object sender, EventArgs e)
        {
            if (pnlNotifications.Controls.Count <= 0)
            {
                MessageBox.Show("No Items found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!(MessageBox.Show("Are your shor Delete all Notifications", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                return;
            pnlNotifications.Controls.Clear();
            clsNotification.DeleteAllNotificationsForUserID(clsGlobal.CurrentUser.UserID);
        }
    }
}
