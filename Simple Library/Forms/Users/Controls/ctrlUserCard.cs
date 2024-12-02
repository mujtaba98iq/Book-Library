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

namespace Simple_Library.Forms.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        int _UserID;
        clsUser _User;

        public int UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
            }
        }
        public clsUser User
        {
            get { return _User; }
        }
        public ctrlUserCard()
        {
            InitializeComponent();

        }
        public void LoadUserInfo(int UserID)
        {

            _User = clsUser.Find(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("User is NOt Found!");
                return;
            }
            FillUserInfo();

        }

        private void _ResetPersonInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
            lblIsActive.Text = "[???]";
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";

        }

        private void FillUserInfo()
        {
            _UserID = _User.UserID;

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _UserID.ToString();
            lblUserName.Text = _User.UserName;

            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }
    }
}
