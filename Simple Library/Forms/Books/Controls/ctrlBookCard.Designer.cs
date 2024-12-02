namespace Simple_Library.Forms.Books.Controls
{
    partial class ctrlBookCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIsAvailabel = new System.Windows.Forms.Label();
            this.Rate = new Bunifu.UI.WinForms.BunifuRating();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuther = new System.Windows.Forms.Label();
            this.cmsManageBook = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmBookDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBorrow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pbBookImage = new System.Windows.Forms.PictureBox();
            this.cmsManageReservations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmReserveBook = new System.Windows.Forms.ToolStripMenuItem();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.cmsManageBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookImage)).BeginInit();
            this.cmsManageReservations.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(0, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Auther:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(0, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblIsAvailabel
            // 
            this.lblIsAvailabel.AutoSize = true;
            this.lblIsAvailabel.BackColor = System.Drawing.Color.Red;
            this.lblIsAvailabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblIsAvailabel.Location = new System.Drawing.Point(0, 0);
            this.lblIsAvailabel.Name = "lblIsAvailabel";
            this.lblIsAvailabel.Size = new System.Drawing.Size(92, 20);
            this.lblIsAvailabel.TabIndex = 1;
            this.lblIsAvailabel.Text = "Not Avilabel";
            // 
            // Rate
            // 
            this.Rate.BackColor = System.Drawing.Color.Transparent;
            this.Rate.DisabledEmptyFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.Rate.DisabledRatedFillColor = System.Drawing.Color.DarkGray;
            this.Rate.EmptyBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.Rate.EmptyFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.Rate.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.Rate.HoverFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.Rate.InnerRadius = 2F;
            this.Rate.Location = new System.Drawing.Point(31, 342);
            this.Rate.Name = "Rate";
            this.Rate.OuterRadius = 10F;
            this.Rate.RatedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.Rate.RatedFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.Rate.ReadOnly = true;
            this.Rate.RightClickToClear = true;
            this.Rate.Size = new System.Drawing.Size(121, 22);
            this.Rate.TabIndex = 2;
            this.Rate.Text = "bunifuRating1";
            this.Rate.Value = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTitle.Location = new System.Drawing.Point(40, 296);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(61, 15);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Rich Dadi";
            // 
            // lblAuther
            // 
            this.lblAuther.AutoSize = true;
            this.lblAuther.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAuther.Location = new System.Drawing.Point(51, 321);
            this.lblAuther.Name = "lblAuther";
            this.lblAuther.Size = new System.Drawing.Size(109, 15);
            this.lblAuther.TabIndex = 1;
            this.lblAuther.Text = "Robert Levandosci";
            // 
            // cmsManageBook
            // 
            this.cmsManageBook.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBookDetails,
            this.tsmBorrow,
            this.tsmEdit,
            this.tsmDelete});
            this.cmsManageBook.Name = "contextMenuStrip1";
            this.cmsManageBook.Size = new System.Drawing.Size(181, 114);
            this.cmsManageBook.Opening += new System.ComponentModel.CancelEventHandler(this.cmsManageBook_Opening);
            // 
            // tsmBookDetails
            // 
            this.tsmBookDetails.Name = "tsmBookDetails";
            this.tsmBookDetails.Size = new System.Drawing.Size(180, 22);
            this.tsmBookDetails.Text = "Show Book Details";
            this.tsmBookDetails.Click += new System.EventHandler(this.tsBookDetails_Click);
            // 
            // tsmBorrow
            // 
            this.tsmBorrow.Name = "tsmBorrow";
            this.tsmBorrow.Size = new System.Drawing.Size(180, 22);
            this.tsmBorrow.Text = "Borrow";
            this.tsmBorrow.Click += new System.EventHandler(this.tsmBorrow_Click);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(180, 22);
            this.tsmEdit.Text = "Edit";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(180, 22);
            this.tsmDelete.Text = "Delete";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // pbBookImage
            // 
            this.pbBookImage.Image = global::Simple_Library.Properties.Resources.Book_Question;
            this.pbBookImage.Location = new System.Drawing.Point(-1, 0);
            this.pbBookImage.Name = "pbBookImage";
            this.pbBookImage.Size = new System.Drawing.Size(192, 289);
            this.pbBookImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBookImage.TabIndex = 0;
            this.pbBookImage.TabStop = false;
            // 
            // cmsManageReservations
            // 
            this.cmsManageReservations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmReserveBook});
            this.cmsManageReservations.Name = "contextMenuStrip1";
            this.cmsManageReservations.Size = new System.Drawing.Size(169, 26);
            // 
            // tsmReserveBook
            // 
            this.tsmReserveBook.Name = "tsmReserveBook";
            this.tsmReserveBook.Size = new System.Drawing.Size(168, 22);
            this.tsmReserveBook.Text = "Reserve This Book";
            this.tsmReserveBook.Click += new System.EventHandler(this.tsmReserveBook_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // ctrlBookCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(234)))));
            this.ContextMenuStrip = this.cmsManageBook;
            this.Controls.Add(this.Rate);
            this.Controls.Add(this.lblIsAvailabel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAuther);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbBookImage);
            this.Name = "ctrlBookCard";
            this.Size = new System.Drawing.Size(191, 367);
            this.cmsManageBook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBookImage)).EndInit();
            this.cmsManageReservations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBookImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIsAvailabel;
        private Bunifu.UI.WinForms.BunifuRating Rate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuther;
        private System.Windows.Forms.ContextMenuStrip cmsManageBook;
        private System.Windows.Forms.ToolStripMenuItem tsmBookDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmBorrow;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ContextMenuStrip cmsManageReservations;
        private System.Windows.Forms.ToolStripMenuItem tsmReserveBook;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}
