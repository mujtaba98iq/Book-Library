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

namespace Simple_Library.Forms.Main
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frm = new frmWaitForm(clsGlobal.ShortWait))
            {
                frm.ShowDialog(this);
            }
            string LibraryCardNumber = txtLibraryCardNumber.Text.Trim();
            clsUser user = clsUser.FindByUsernameAndLibraryCardNumber(txtUserName.Text.Trim(), LibraryCardNumber);


            if (user != null)
            {

                if (chkRememberMe.Checked)
                {
                    //store username and LibraryCardNumber
                    clsGlobal.RememberUsernameAndLibraryCardNumber(txtUserName.Text.Trim(), txtLibraryCardNumber.Text.Trim());

                }
                else
                {
                    //store empty username and LibraryCardNumber
                    clsGlobal.RememberUsernameAndLibraryCardNumber("", "");

                }

                //incase the user is not active
                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;
                this.Hide();
                frmHome frm = new frmHome();
                frm.ShowDialog();


            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/LibraryCardNumber.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", LibraryCardNumber = "";
            if (clsGlobal.GetStoredCredential(ref UserName, ref LibraryCardNumber))
            {
                txtUserName.Text = UserName;
                txtLibraryCardNumber.Text = LibraryCardNumber;
                btnLogin_Click(sender, e);
            }
        }
    }
}
