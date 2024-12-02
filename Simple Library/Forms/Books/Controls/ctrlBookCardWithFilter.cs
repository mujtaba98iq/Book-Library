using Simple_Library.Forms.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Library.Forms.Books.Controls
{
    public partial class ctrlBookCardWithFilter : UserControl
    {
        public event Action<int> OnBookSelected;
        protected virtual void PersonSelected(int BookID)
        {
            Action<int> handler = OnBookSelected;
            if (handler != null)
            {
                handler(BookID);
            }
        }
        public ctrlBookCardWithFilter()
        {
            InitializeComponent();
        }
        public void GetData(object obj,int BookID)
        {
            txtFilterValue.Text = BookID.ToString();
            btnFind_Click(null,null);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                FindNow();
        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Book ID":
                    ctrlBookCardWithDetails1.LoadInfo(int.Parse(txtFilterValue.Text));
                    break;
                case "Title":
                    ctrlBookCardWithDetails1.LoadInfo(txtFilterValue.Text);
                    break;
                default:
                    break;
            }
            if (OnBookSelected != null)
                OnBookSelected(ctrlBookCardWithDetails1.BookID);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "BookID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdateBook frm=new frmAddUpdateBook();
            frm.DataBack += GetData;
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void ctrlBookCardWithFilter_Load(object sender, EventArgs e)
        {
            
            cbFilterBy.SelectedIndex = 0;
        }
    }
}
