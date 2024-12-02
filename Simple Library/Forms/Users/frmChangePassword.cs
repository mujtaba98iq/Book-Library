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

namespace Simple_Library.Forms.Users
{
    public partial class frmChangePassword : Form
    {
        int _UserID;
        clsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            clsUser CurrentUser = clsUser.Find(_UserID);
            string LibraryCardNumber = txtCurrentPassword.Text.Trim();
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "This field is required!");
                return;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, null);


            if (!CurrentUser.IsLibraryCardNumberMatch(LibraryCardNumber))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "The Passwrod doesn't Match!");
                return;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This field is required!");
                return;
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);

            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "The Passwrod doesn't Match!");
                return;
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void LoadInfo()
        {
            _User = clsUser.Find(_UserID);
            if (_User != null)
            {
                ctrlUserCard1.LoadUserInfo(_UserID);
                btnSave.Enabled = true;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to Update Info", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            _User.PersonID=_User.PersonID;
            _User.UserName = _User.UserName;
            _User.CreatedByUserID = _User.CreatedByUserID;
            _User.DateTime = _User.DateTime;
            _User.IsAdmin = _User.IsAdmin;
            _User.LibraryCardNumber = txtNewPassword.Text;
            _User.IsActive = true;
            if (_User.Save())
            {
                MessageBox.Show("Data Saved Seccessufly");
                RestInfo();
            }
            else

                MessageBox.Show("Data saved felid!");

        }

        private void RestInfo()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
    }
}
