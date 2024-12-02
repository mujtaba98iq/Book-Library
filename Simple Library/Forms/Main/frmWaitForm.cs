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
    public partial class frmWaitForm : Form
    {
        public Action Artan { get; set; }
        public frmWaitForm(Action artan)
        {
            InitializeComponent();
            if (artan == null)
            {
                throw new ArgumentNullException();
            }
            Artan = artan;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Artan).ContinueWith(s => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
