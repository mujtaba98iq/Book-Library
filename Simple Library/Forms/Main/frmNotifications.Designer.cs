namespace Simple_Library.Forms.Main
{
    partial class frmNotifications
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotifications));
            this.pnlBorderPnlNotifications = new System.Windows.Forms.Panel();
            this.btnDeleteAllNotifications = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlNotifications = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCloseNotifications = new System.Windows.Forms.PictureBox();
            this.pnlBorderPnlNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseNotifications)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBorderPnlNotifications
            // 
            this.pnlBorderPnlNotifications.Controls.Add(this.btnDeleteAllNotifications);
            this.pnlBorderPnlNotifications.Controls.Add(this.label1);
            this.pnlBorderPnlNotifications.Controls.Add(this.btnCloseNotifications);
            this.pnlBorderPnlNotifications.Controls.Add(this.pnlNotifications);
            this.pnlBorderPnlNotifications.Location = new System.Drawing.Point(1, 3);
            this.pnlBorderPnlNotifications.Name = "pnlBorderPnlNotifications";
            this.pnlBorderPnlNotifications.Size = new System.Drawing.Size(327, 473);
            this.pnlBorderPnlNotifications.TabIndex = 4;
            // 
            // btnDeleteAllNotifications
            // 
            this.btnDeleteAllNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(234)))));
            this.btnDeleteAllNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDeleteAllNotifications.Location = new System.Drawing.Point(216, 5);
            this.btnDeleteAllNotifications.Name = "btnDeleteAllNotifications";
            this.btnDeleteAllNotifications.Size = new System.Drawing.Size(84, 35);
            this.btnDeleteAllNotifications.TabIndex = 35;
            this.btnDeleteAllNotifications.Text = "Clear";
            this.btnDeleteAllNotifications.UseVisualStyleBackColor = false;
            this.btnDeleteAllNotifications.Click += new System.EventHandler(this.btnDeleteAllNotifications_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(234)))));
            this.label1.Location = new System.Drawing.Point(26, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Notifications";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnlNotifications
            // 
            this.pnlNotifications.AutoScroll = true;
            this.pnlNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(234)))));
            this.pnlNotifications.Location = new System.Drawing.Point(-4, 44);
            this.pnlNotifications.Name = "pnlNotifications";
            this.pnlNotifications.Size = new System.Drawing.Size(331, 429);
            this.pnlNotifications.TabIndex = 0;
            // 
            // btnCloseNotifications
            // 
            this.btnCloseNotifications.BackColor = System.Drawing.Color.White;
            this.btnCloseNotifications.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseNotifications.Image")));
            this.btnCloseNotifications.Location = new System.Drawing.Point(0, 0);
            this.btnCloseNotifications.Name = "btnCloseNotifications";
            this.btnCloseNotifications.Size = new System.Drawing.Size(20, 19);
            this.btnCloseNotifications.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCloseNotifications.TabIndex = 33;
            this.btnCloseNotifications.TabStop = false;
            this.btnCloseNotifications.Tag = "2";
            this.btnCloseNotifications.Click += new System.EventHandler(this.btnCloseNotifications_Click);
            // 
            // frmNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 473);
            this.Controls.Add(this.pnlBorderPnlNotifications);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotifications";
            this.Text = "frmNotifications";
            this.Load += new System.EventHandler(this.frmNotifications_Load);
            this.pnlBorderPnlNotifications.ResumeLayout(false);
            this.pnlBorderPnlNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseNotifications)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBorderPnlNotifications;
        private System.Windows.Forms.PictureBox btnCloseNotifications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteAllNotifications;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.FlowLayoutPanel pnlNotifications;
    }
}