using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Library.Forms.Main.Controls
{
    public partial class ctrlNotification : UserControl
    {
        public ctrlNotification()
        {
            InitializeComponent();
        }
        public void LoadInfo(string Description)
        {
            lblDescription.Text = Description;
        }
    }
}
