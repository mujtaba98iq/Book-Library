using Simple_Library.Forms.Users;
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
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
            InitializeComponent();
            
        }

       

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            int UserID = clsGlobal.CurrentUser.UserID;
            frmChangePassword frm = new frmChangePassword(UserID);
            frm.ShowDialog();
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            int UserID=clsGlobal.CurrentUser.UserID;
            ctrlUserCard1.LoadUserInfo(UserID);
        }
    }
}
