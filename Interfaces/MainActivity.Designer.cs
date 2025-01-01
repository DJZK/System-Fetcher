namespace System_Fetcher.Functions
{
    partial class MainActivity
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textPSU = new System.Windows.Forms.TextBox();
            this.textCPU = new System.Windows.Forms.TextBox();
            this.textChassy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textAT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textOwner = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonView = new System.Windows.Forms.Button();
            this.labelVerison = new System.Windows.Forms.Label();
            this.ticker = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manual Inputs:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "PSU:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CPU Cooler:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chassis (and Fans):";
            // 
            // textPSU
            // 
            this.textPSU.Location = new System.Drawing.Point(117, 45);
            this.textPSU.Name = "textPSU";
            this.textPSU.Size = new System.Drawing.Size(157, 20);
            this.textPSU.TabIndex = 4;
            // 
            // textCPU
            // 
            this.textCPU.Location = new System.Drawing.Point(117, 71);
            this.textCPU.Name = "textCPU";
            this.textCPU.Size = new System.Drawing.Size(157, 20);
            this.textCPU.TabIndex = 5;
            // 
            // textChassy
            // 
            this.textChassy.Location = new System.Drawing.Point(117, 97);
            this.textChassy.Name = "textChassy";
            this.textChassy.Size = new System.Drawing.Size(157, 20);
            this.textChassy.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(32, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Actions Taken:";
            // 
            // textAT
            // 
            this.textAT.Location = new System.Drawing.Point(117, 132);
            this.textAT.Multiline = true;
            this.textAT.Name = "textAT";
            this.textAT.Size = new System.Drawing.Size(157, 45);
            this.textAT.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(70, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Owner:";
            // 
            // textOwner
            // 
            this.textOwner.Location = new System.Drawing.Point(117, 190);
            this.textOwner.Name = "textOwner";
            this.textOwner.Size = new System.Drawing.Size(157, 20);
            this.textOwner.TabIndex = 11;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(159, 236);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonView
            // 
            this.buttonView.Location = new System.Drawing.Point(49, 236);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(75, 23);
            this.buttonView.TabIndex = 13;
            this.buttonView.Text = "View";
            this.buttonView.UseVisualStyleBackColor = true;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // labelVerison
            // 
            this.labelVerison.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelVerison.Location = new System.Drawing.Point(147, 279);
            this.labelVerison.Name = "labelVerison";
            this.labelVerison.Size = new System.Drawing.Size(127, 20);
            this.labelVerison.TabIndex = 14;
            this.labelVerison.Text = "<version>";
            this.labelVerison.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ticker
            // 
            this.ticker.Interval = 1000;
            this.ticker.Tick += new System.EventHandler(this.ticker_Tick);
            // 
            // labelTime
            // 
            this.labelTime.Location = new System.Drawing.Point(12, 279);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(129, 23);
            this.labelTime.TabIndex = 15;
            this.labelTime.Text = "<time>";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainActivity
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 308);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelVerison);
            this.Controls.Add(this.buttonView);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textOwner);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textAT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textChassy);
            this.Controls.Add(this.textCPU);
            this.Controls.Add(this.textPSU);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hardware Fetcher";
            this.Load += new System.EventHandler(this.MainActivity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPSU;
        private System.Windows.Forms.TextBox textCPU;
        private System.Windows.Forms.TextBox textChassy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textAT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textOwner;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.Label labelVerison;
        private System.Windows.Forms.Timer ticker;
        private System.Windows.Forms.Label labelTime;
    }
}