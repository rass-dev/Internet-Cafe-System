namespace InternetCafe
{
    partial class formEditPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEditPC));
            this.pnLogout = new System.Windows.Forms.Panel();
            this.btnUpdatePC = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSystemWorking = new ReaLTaiizor.Controls.PoisonComboBox();
            this.cmbComputerNumber = new ReaLTaiizor.Controls.PoisonComboBox();
            this.txtLANIP = new System.Windows.Forms.TextBox();
            this.txtSubnetMask = new System.Windows.Forms.TextBox();
            this.pnLogout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLogout
            // 
            this.pnLogout.Controls.Add(this.btnUpdatePC);
            this.pnLogout.Location = new System.Drawing.Point(332, 487);
            this.pnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.pnLogout.Name = "pnLogout";
            this.pnLogout.Size = new System.Drawing.Size(191, 50);
            this.pnLogout.TabIndex = 53;
            // 
            // btnUpdatePC
            // 
            this.btnUpdatePC.BackColor = System.Drawing.Color.SeaGreen;
            this.btnUpdatePC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePC.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePC.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdatePC.Image")));
            this.btnUpdatePC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePC.Location = new System.Drawing.Point(-20, -31);
            this.btnUpdatePC.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdatePC.Name = "btnUpdatePC";
            this.btnUpdatePC.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnUpdatePC.Size = new System.Drawing.Size(223, 112);
            this.btnUpdatePC.TabIndex = 2;
            this.btnUpdatePC.Text = "         UPDATE";
            this.btnUpdatePC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePC.UseVisualStyleBackColor = false;
            this.btnUpdatePC.Click += new System.EventHandler(this.btnUpdatePC_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 292);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(331, 26);
            this.label6.TabIndex = 51;
            this.label6.Text = "LAN / IP Address";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(611, 156);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 242);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(203, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 32);
            this.label5.TabIndex = 50;
            this.label5.Text = "Details";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 32);
            this.label4.TabIndex = 49;
            this.label4.Text = "Computer";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 26);
            this.label2.TabIndex = 47;
            this.label2.Text = "Computer Number";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 32);
            this.label3.TabIndex = 45;
            this.label3.Text = "Computer Settings";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 26);
            this.label1.TabIndex = 54;
            this.label1.Text = "Status";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(327, 292);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(276, 26);
            this.label8.TabIndex = 58;
            this.label8.Text = "Subnet Mask";
            // 
            // cmbSystemWorking
            // 
            this.cmbSystemWorking.FormattingEnabled = true;
            this.cmbSystemWorking.ItemHeight = 24;
            this.cmbSystemWorking.Items.AddRange(new object[] {
            "Working",
            "Maintainance"});
            this.cmbSystemWorking.Location = new System.Drawing.Point(332, 236);
            this.cmbSystemWorking.Name = "cmbSystemWorking";
            this.cmbSystemWorking.Size = new System.Drawing.Size(220, 30);
            this.cmbSystemWorking.TabIndex = 131;
            this.cmbSystemWorking.UseSelectable = true;
            this.cmbSystemWorking.SelectedIndexChanged += new System.EventHandler(this.cmbSystemWorking_SelectedIndexChanged);
            // 
            // cmbComputerNumber
            // 
            this.cmbComputerNumber.FormattingEnabled = true;
            this.cmbComputerNumber.ItemHeight = 24;
            this.cmbComputerNumber.Location = new System.Drawing.Point(45, 236);
            this.cmbComputerNumber.Name = "cmbComputerNumber";
            this.cmbComputerNumber.Size = new System.Drawing.Size(220, 30);
            this.cmbComputerNumber.TabIndex = 132;
            this.cmbComputerNumber.UseSelectable = true;
            this.cmbComputerNumber.SelectedIndexChanged += new System.EventHandler(this.cmbComputerNumber_SelectedIndexChanged);
            // 
            // txtLANIP
            // 
            this.txtLANIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLANIP.Location = new System.Drawing.Point(31, 344);
            this.txtLANIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtLANIP.Name = "txtLANIP";
            this.txtLANIP.Size = new System.Drawing.Size(255, 30);
            this.txtLANIP.TabIndex = 133;
            this.txtLANIP.TextChanged += new System.EventHandler(this.txtLANIP_TextChanged);
            // 
            // txtSubnetMask
            // 
            this.txtSubnetMask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubnetMask.Location = new System.Drawing.Point(323, 344);
            this.txtSubnetMask.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubnetMask.Name = "txtSubnetMask";
            this.txtSubnetMask.Size = new System.Drawing.Size(255, 30);
            this.txtSubnetMask.TabIndex = 134;
            this.txtSubnetMask.TextChanged += new System.EventHandler(this.txtSubnetMask_TextChanged);
            // 
            // formEditPC
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(928, 650);
            this.Controls.Add(this.txtSubnetMask);
            this.Controls.Add(this.txtLANIP);
            this.Controls.Add(this.cmbComputerNumber);
            this.Controls.Add(this.cmbSystemWorking);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnLogout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formEditPC";
            this.Text = "formEditPC";
            this.Load += new System.EventHandler(this.formEditPC_Load);
            this.pnLogout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.Button btnUpdatePC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private ReaLTaiizor.Controls.PoisonComboBox cmbSystemWorking;
        private ReaLTaiizor.Controls.PoisonComboBox cmbComputerNumber;
        private System.Windows.Forms.TextBox txtLANIP;
        private System.Windows.Forms.TextBox txtSubnetMask;
    }
}