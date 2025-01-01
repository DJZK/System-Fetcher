namespace System_Fetcher.Interfaces
{
    partial class About
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
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            this.labelRepo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureLogo
            // 
            this.pictureLogo.Location = new System.Drawing.Point(27, 36);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(125, 125);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(174, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(251, 31);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "System Fetcher Tool";
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(180, 53);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(245, 18);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "<version>";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelCopyright.Location = new System.Drawing.Point(261, 181);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(72, 13);
            this.labelCopyright.TabIndex = 3;
            this.labelCopyright.Text = "©STRX 2024";
            // 
            // labelDesc
            // 
            this.labelDesc.Location = new System.Drawing.Point(177, 81);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(248, 63);
            this.labelDesc.TabIndex = 4;
            this.labelDesc.Text = "This program is designed for logging and fetching purposes only. No personal info" +
    "rmation is being collected by this application. You can find the repository of t" +
    "his program at the link below.\r\n";
            this.labelDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRepo
            // 
            this.labelRepo.AutoSize = true;
            this.labelRepo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRepo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRepo.ForeColor = System.Drawing.Color.Blue;
            this.labelRepo.Location = new System.Drawing.Point(255, 148);
            this.labelRepo.Name = "labelRepo";
            this.labelRepo.Size = new System.Drawing.Size(80, 13);
            this.labelRepo.TabIndex = 5;
            this.labelRepo.Text = "Repository Link";
            this.labelRepo.Click += new System.EventHandler(this.labelRepo_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 207);
            this.Controls.Add(this.labelRepo);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Label labelRepo;
    }
}