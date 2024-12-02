using Simple_Library.Forms.People.Controls;
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

namespace Simple_Library.Forms.Users
{
    public partial class frmAddUpdateUser : Form
    {
        int _UserID;
        clsUser _User;
        public enum _enMode
        {
            Add,
            Update
        }
        _enMode _Mode = _enMode.Add;
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = _enMode.Add;
            _User = new clsUser();
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = _enMode.Update;
            _User = clsUser.Find(_UserID);
        }
        void LoadInfo()
        {
            if (_User == null)
            {
                MessageBox.Show("User is Not found!");
                return;
            }
            lblUserID.Text = _UserID.ToString();
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.LibraryCardNumber;
            chkIsActive.Checked = _User.IsActive;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Chose Person first!");
                return;
            }
            tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fild is required!");
                return;
            }

            if (_Mode == _enMode.Add)
                if (!(MessageBox.Show("Are your shor add User Data", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                    return;
                else
                if (!(MessageBox.Show("Are your shor Update User Data ", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                    return;
            _User.UserName = txtUserName.Text;
            _User.LibraryCardNumber = txtPassword.Text;
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _User.DateTime=DateTime.Now;
            if (chkIsActive.Checked)
                _User.IsActive = true;
            else
                _User.IsActive = false;
            if (cbIsAdmin.Checked)
                _User.IsAdmin = true;
            else
                _User.IsAdmin = false;
            if (_User.Save())
            {
                MessageBox.Show("Saved Data Seccessfuly!");
                return;
            }
            else
            {
                MessageBox.Show("Saved Data field!");
                return;
            }

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                e.Cancel = true;

                errorProvider1.SetError(txtUserName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);

            }
            if (_Mode == _enMode.Add)
            {
                if (clsUser.isUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "This UserName is userd by other user!,chose another one.");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);

                }
            }
            else
            {
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.isUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    };
                }
            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                e.Cancel = true;

                errorProvider1.SetError(txtPassword, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() == "")
            {
                e.Cancel = true;

                errorProvider1.SetError(txtConfirmPassword, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;

                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if (_Mode == _enMode.Update)
            {
                this.Text = "Update User";
                lblTitle.Text = "Update User";
                LoadInfo();
            }
            else
            {

                this.Text = "Add User";
                lblTitle.Text = "Add User";
            }
        }
    }
}
