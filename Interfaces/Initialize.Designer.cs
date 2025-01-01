namespace System_Fetcher.Functions
{
    partial class Initialize
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
            this.labelHandler = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.textOrg = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHandler
            // 
            this.labelHandler.AutoSize = true;
            this.labelHandler.Location = new System.Drawing.Point(12, 24);
            this.labelHandler.Name = "labelHandler";
            this.labelHandler.Size = new System.Drawing.Size(63, 13);
            this.labelHandler.TabIndex = 0;
            this.labelHandler.Text = "Technician:";
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Location = new System.Drawing.Point(21, 50);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(54, 13);
            this.labelCompany.TabIndex = 1;
            this.labelCompany.Text = "Company:";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(81, 21);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(160, 20);
            this.textName.TabIndex = 2;
            // 
            // textOrg
            // 
            this.textOrg.Location = new System.Drawing.Point(81, 47);
            this.textOrg.Name = "textOrg";
            this.textOrg.Size = new System.Drawing.Size(160, 20);
            this.textOrg.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(166, 80);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Initialize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 121);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textOrg);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelCompany);
            this.Controls.Add(this.labelHandler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Initialize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initialize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHandler;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textOrg;
        private System.Windows.Forms.Button buttonSave;
    }
}