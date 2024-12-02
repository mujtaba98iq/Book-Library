namespace Simple_Library.Forms.Books.Controls
{
    partial class ctrlBookUserCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlBookUserCard));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.pbBookImage = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuther = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBorrowDate = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLateDays = new System.Windows.Forms.Label();
            this.btnReturnBook = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbBookImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBookImage
            // 
            this.pbBookImage.Image = global::Simple_Library.Properties.Resources.Elon_Musk;
            this.pbBookImage.Location = new System.Drawing.Point(-3, -2);
            this.pbBookImage.Name = "pbBookImage";
            this.pbBookImage.Size = new System.Drawing.Size(230, 342);
            this.pbBookImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBookImage.TabIndex = 1;
            this.pbBookImage.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblTitle.Location = new System.Drawing.Point(227, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(91, 24);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Rich Dadi";
            // 
            // lblAuther
            // 
            this.lblAuther.AutoSize = true;
            this.lblAuther.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblAuther.Location = new System.Drawing.Point(227, 74);
            this.lblAuther.Name = "lblAuther";
            this.lblAuther.Size = new System.Drawing.Size(167, 24);
            this.lblAuther.TabIndex = 4;
            this.lblAuther.Text = "Robert Levandosci";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(227, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Borrow Date :";
            // 
            // lblBorrowDate
            // 
            this.lblBorrowDate.AutoSize = true;
            this.lblBorrowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBorrowDate.Location = new System.Drawing.Point(356, 135);
            this.lblBorrowDate.Name = "lblBorrowDate";
            this.lblBorrowDate.Size = new System.Drawing.Size(106, 20);
            this.lblBorrowDate.TabIndex = 5;
            this.lblBorrowDate.Text = "Borrow Date :";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDueDate.Location = new System.Drawing.Point(356, 184);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(106, 20);
            this.lblDueDate.TabIndex = 6;
            this.lblDueDate.Text = "Borrow Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(227, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Due Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(227, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Late Days: ";
            // 
            // lblLateDays
            // 
            this.lblLateDays.AutoSize = true;
            this.lblLateDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLateDays.Location = new System.Drawing.Point(356, 232);
            this.lblLateDays.Name = "lblLateDays";
            this.lblLateDays.Size = new System.Drawing.Size(106, 20);
            this.lblLateDays.TabIndex = 6;
            this.lblLateDays.Text = "Borrow Date :";
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.AllowAnimations = true;
            this.btnReturnBook.AllowMouseEffects = true;
            this.btnReturnBook.AllowToggling = false;
            this.btnReturnBook.AnimationSpeed = 200;
            this.btnReturnBook.AutoGenerateColors = false;
            this.btnReturnBook.AutoRoundBorders = false;
            this.btnReturnBook.AutoSizeLeftIcon = true;
            this.btnReturnBook.AutoSizeRightIcon = true;
            this.btnReturnBook.BackColor = System.Drawing.Color.Transparent;
            this.btnReturnBook.BackColor1 = System.Drawing.Color.White;
            this.btnReturnBook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReturnBook.BackgroundImage")));
            this.btnReturnBook.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReturnBook.ButtonText = "Return Book";
            this.btnReturnBook.ButtonTextMarginLeft = 0;
            this.btnReturnBook.ColorContrastOnClick = 45;
            this.btnReturnBook.ColorContrastOnHover = 45;
            this.btnReturnBook.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnReturnBook.CustomizableEdges = borderEdges1;
            this.btnReturnBook.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReturnBook.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnReturnBook.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReturnBook.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnReturnBook.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnReturnBook.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnReturnBook.ForeColor = System.Drawing.Color.Gray;
            this.btnReturnBook.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnBook.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnReturnBook.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnReturnBook.IconMarginLeft = 11;
            this.btnReturnBook.IconPadding = 10;
            this.btnReturnBook.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturnBook.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnReturnBook.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnReturnBook.IconSize = 25;
            this.btnReturnBook.IdleBorderColor = System.Drawing.Color.White;
            this.btnReturnBook.IdleBorderRadius = 20;
            this.btnReturnBook.IdleBorderThickness = 1;
            this.btnReturnBook.IdleFillColor = System.Drawing.Color.White;
            this.btnReturnBook.IdleIconLeftImage = null;
            this.btnReturnBook.IdleIconRightImage = null;
            this.btnReturnBook.IndicateFocus = false;
            this.btnReturnBook.Location = new System.Drawing.Point(266, 278);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnReturnBook.OnDisabledState.BorderRadius = 20;
            this.btnReturnBook.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReturnBook.OnDisabledState.BorderThickness = 1;
            this.btnReturnBook.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReturnBook.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnReturnBook.OnDisabledState.IconLeftImage = null;
            this.btnReturnBook.OnDisabledState.IconRightImage = null;
            this.btnReturnBook.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnReturnBook.onHoverState.BorderRadius = 20;
            this.btnReturnBook.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReturnBook.onHoverState.BorderThickness = 1;
            this.btnReturnBook.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnReturnBook.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnReturnBook.onHoverState.IconLeftImage = null;
            this.btnReturnBook.onHoverState.IconRightImage = null;
            this.btnReturnBook.OnIdleState.BorderColor = System.Drawing.Color.White;
            this.btnReturnBook.OnIdleState.BorderRadius = 20;
            this.btnReturnBook.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReturnBook.OnIdleState.BorderThickness = 1;
            this.btnReturnBook.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnReturnBook.OnIdleState.ForeColor = System.Drawing.Color.Gray;
            this.btnReturnBook.OnIdleState.IconLeftImage = null;
            this.btnReturnBook.OnIdleState.IconRightImage = null;
            this.btnReturnBook.OnPressedState.BorderColor = System.Drawing.Color.White;
            this.btnReturnBook.OnPressedState.BorderRadius = 20;
            this.btnReturnBook.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReturnBook.OnPressedState.BorderThickness = 1;
            this.btnReturnBook.OnPressedState.FillColor = System.Drawing.Color.White;
            this.btnReturnBook.OnPressedState.ForeColor = System.Drawing.Color.Black;
            this.btnReturnBook.OnPressedState.IconLeftImage = null;
            this.btnReturnBook.OnPressedState.IconRightImage = null;
            this.btnReturnBook.Size = new System.Drawing.Size(150, 39);
            this.btnReturnBook.TabIndex = 8;
            this.btnReturnBook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReturnBook.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnReturnBook.TextMarginLeft = 0;
            this.btnReturnBook.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnReturnBook.UseDefaultRadiusAndThickness = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // ctrlBookUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.lblLateDays);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAuther);
            this.Controls.Add(this.pbBookImage);
            this.Name = "ctrlBookUserCard";
            this.Size = new System.Drawing.Size(446, 339);
            ((System.ComponentModel.ISupportInitialize)(this.pbBookImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBookImage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuther;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBorrowDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLateDays;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnReturnBook;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}
