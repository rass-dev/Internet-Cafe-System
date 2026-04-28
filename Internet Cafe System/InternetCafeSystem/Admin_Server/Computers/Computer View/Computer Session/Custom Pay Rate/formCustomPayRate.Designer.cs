namespace InternetCafe.Computers.Computer_View.Computer_Session.Custom_Pay_Rate
{
    partial class formCustomPayRate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCustomPayRate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pnLogout = new System.Windows.Forms.Panel();
            this.btnUpdatePayRate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CkbHourRate = new ReaLTaiizor.Controls.HopeCheckBox();
            this.CkbMinutesRate = new ReaLTaiizor.Controls.HopeCheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRatePerHour = new System.Windows.Forms.TextBox();
            this.txtRatePerMinutes = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pnLogout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Location = new System.Drawing.Point(281, 432);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 50);
            this.panel1.TabIndex = 105;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Crimson;
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(-20, -31);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnReturn.Size = new System.Drawing.Size(223, 112);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "         RETURN";
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pnLogout
            // 
            this.pnLogout.Controls.Add(this.btnUpdatePayRate);
            this.pnLogout.Location = new System.Drawing.Point(35, 432);
            this.pnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.pnLogout.Name = "pnLogout";
            this.pnLogout.Size = new System.Drawing.Size(191, 50);
            this.pnLogout.TabIndex = 104;
            // 
            // btnUpdatePayRate
            // 
            this.btnUpdatePayRate.BackColor = System.Drawing.Color.SeaGreen;
            this.btnUpdatePayRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePayRate.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePayRate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdatePayRate.Image")));
            this.btnUpdatePayRate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePayRate.Location = new System.Drawing.Point(-20, -31);
            this.btnUpdatePayRate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdatePayRate.Name = "btnUpdatePayRate";
            this.btnUpdatePayRate.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnUpdatePayRate.Size = new System.Drawing.Size(223, 112);
            this.btnUpdatePayRate.TabIndex = 2;
            this.btnUpdatePayRate.Text = "         UPDATE";
            this.btnUpdatePayRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePayRate.UseVisualStyleBackColor = false;
            this.btnUpdatePayRate.Click += new System.EventHandler(this.btnUpdatePayRate_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 32);
            this.label3.TabIndex = 99;
            this.label3.Text = "Custom Pay Rate";
            this.label3.UseMnemonic = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 176);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 32);
            this.label1.TabIndex = 112;
            this.label1.Text = "( Rate per hour to pay )";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 282);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 32);
            this.label2.TabIndex = 113;
            this.label2.Text = "( Rate per minute to pay )";
            // 
            // CkbHourRate
            // 
            this.CkbHourRate.AutoSize = true;
            this.CkbHourRate.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.CkbHourRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CkbHourRate.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.CkbHourRate.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.CkbHourRate.Enable = true;
            this.CkbHourRate.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.CkbHourRate.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.CkbHourRate.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.CkbHourRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CkbHourRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.CkbHourRate.Location = new System.Drawing.Point(32, 176);
            this.CkbHourRate.Margin = new System.Windows.Forms.Padding(4);
            this.CkbHourRate.Name = "CkbHourRate";
            this.CkbHourRate.Size = new System.Drawing.Size(93, 20);
            this.CkbHourRate.TabIndex = 118;
            this.CkbHourRate.Text = "Hours";
            this.CkbHourRate.UseVisualStyleBackColor = true;
            this.CkbHourRate.CheckedChanged += new System.EventHandler(this.CkbHourRate_CheckedChanged);
            // 
            // CkbMinutesRate
            // 
            this.CkbMinutesRate.AutoSize = true;
            this.CkbMinutesRate.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.CkbMinutesRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CkbMinutesRate.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.CkbMinutesRate.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.CkbMinutesRate.Enable = true;
            this.CkbMinutesRate.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.CkbMinutesRate.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.CkbMinutesRate.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.CkbMinutesRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CkbMinutesRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.CkbMinutesRate.Location = new System.Drawing.Point(31, 282);
            this.CkbMinutesRate.Margin = new System.Windows.Forms.Padding(4);
            this.CkbMinutesRate.Name = "CkbMinutesRate";
            this.CkbMinutesRate.Size = new System.Drawing.Size(114, 20);
            this.CkbMinutesRate.TabIndex = 119;
            this.CkbMinutesRate.Text = "Minutes";
            this.CkbMinutesRate.UseVisualStyleBackColor = true;
            this.CkbMinutesRate.CheckedChanged += new System.EventHandler(this.CkbMinutesRate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 32);
            this.label4.TabIndex = 101;
            this.label4.Text = "Update";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(117, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 32);
            this.label5.TabIndex = 102;
            this.label5.Text = "Pay Rate ";
            // 
            // txtRatePerHour
            // 
            this.txtRatePerHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRatePerHour.Location = new System.Drawing.Point(69, 222);
            this.txtRatePerHour.Margin = new System.Windows.Forms.Padding(4);
            this.txtRatePerHour.Name = "txtRatePerHour";
            this.txtRatePerHour.Size = new System.Drawing.Size(211, 30);
            this.txtRatePerHour.TabIndex = 120;
            this.txtRatePerHour.TextChanged += new System.EventHandler(this.txtRatePerHour_TextChanged);
            // 
            // txtRatePerMinutes
            // 
            this.txtRatePerMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRatePerMinutes.Location = new System.Drawing.Point(69, 327);
            this.txtRatePerMinutes.Margin = new System.Windows.Forms.Padding(4);
            this.txtRatePerMinutes.Name = "txtRatePerMinutes";
            this.txtRatePerMinutes.Size = new System.Drawing.Size(211, 30);
            this.txtRatePerMinutes.TabIndex = 121;
            this.txtRatePerMinutes.TextChanged += new System.EventHandler(this.txtRatePerMinutes_TextChanged);
            // 
            // formCustomPayRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(742, 528);
            this.Controls.Add(this.txtRatePerMinutes);
            this.Controls.Add(this.txtRatePerHour);
            this.Controls.Add(this.CkbMinutesRate);
            this.Controls.Add(this.CkbHourRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnLogout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formCustomPayRate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Pay Rate";
            this.Load += new System.EventHandler(this.formCustomPayRate_Load);
            this.panel1.ResumeLayout(false);
            this.pnLogout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.Button btnUpdatePayRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.HopeCheckBox CkbHourRate;
        private ReaLTaiizor.Controls.HopeCheckBox CkbMinutesRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRatePerHour;
        private System.Windows.Forms.TextBox txtRatePerMinutes;
    }
}