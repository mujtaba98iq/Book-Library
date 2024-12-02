using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Library.Forms.BorrowingRecords
{
    public partial class frmShowBorrowingRecordInfo : Form
    {
        public frmShowBorrowingRecordInfo(int BorrowRecordID)
        {
            InitializeComponent();
            ctrlBorrowingRecordInfoCard1.LoadInfo(BorrowRecordID);
        }
    }
}
