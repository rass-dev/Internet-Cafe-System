namespace InternetCafe
{
    partial class formManagePC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formManagePC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete_Computer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit_Computer = new System.Windows.Forms.Button();
            this.pnLogout = new System.Windows.Forms.Panel();
            this.btnAddComputer = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.dataGridView_Manage_Computer = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnLogout.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Manage_Computer)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(484, 32);
            this.label3.TabIndex = 29;
            this.label3.Text = "Manage Computers";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnDelete_Computer);
            this.panel2.Location = new System.Drawing.Point(709, 532);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 50);
            this.panel2.TabIndex = 53;
            // 
            // btnDelete_Computer
            // 
            this.btnDelete_Computer.BackColor = System.Drawing.Color.Brown;
            this.btnDelete_Computer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete_Computer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete_Computer.ForeColor = System.Drawing.Color.White;
            this.btnDelete_Computer.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete_Computer.Image")));
            this.btnDelete_Computer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete_Computer.Location = new System.Drawing.Point(-20, -31);
            this.btnDelete_Computer.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete_Computer.Name = "btnDelete_Computer";
            this.btnDelete_Computer.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnDelete_Computer.Size = new System.Drawing.Size(223, 112);
            this.btnDelete_Computer.TabIndex = 2;
            this.btnDelete_Computer.Text = "         DELETE";
            this.btnDelete_Computer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete_Computer.UseVisualStyleBackColor = false;
            this.btnDelete_Computer.Click += new System.EventHandler(this.btnDelete_Computer_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnEdit_Computer);
            this.panel1.Location = new System.Drawing.Point(928, 532);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 50);
            this.panel1.TabIndex = 54;
            // 
            // btnEdit_Computer
            // 
            this.btnEdit_Computer.BackColor = System.Drawing.Color.SeaGreen;
            this.btnEdit_Computer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit_Computer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit_Computer.ForeColor = System.Drawing.Color.White;
            this.btnEdit_Computer.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit_Computer.Image")));
            this.btnEdit_Computer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit_Computer.Location = new System.Drawing.Point(-20, -31);
            this.btnEdit_Computer.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit_Computer.Name = "btnEdit_Computer";
            this.btnEdit_Computer.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnEdit_Computer.Size = new System.Drawing.Size(223, 112);
            this.btnEdit_Computer.TabIndex = 2;
            this.btnEdit_Computer.Text = "         EDIT";
            this.btnEdit_Computer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit_Computer.UseVisualStyleBackColor = false;
            this.btnEdit_Computer.Click += new System.EventHandler(this.btnEdit_Computer_Click);
            // 
            // pnLogout
            // 
            this.pnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnLogout.Controls.Add(this.btnAddComputer);
            this.pnLogout.Location = new System.Drawing.Point(87, 532);
            this.pnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.pnLogout.Name = "pnLogout";
            this.pnLogout.Size = new System.Drawing.Size(191, 50);
            this.pnLogout.TabIndex = 52;
            // 
            // btnAddComputer
            // 
            this.btnAddComputer.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddComputer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddComputer.ForeColor = System.Drawing.Color.White;
            this.btnAddComputer.Image = ((System.Drawing.Image)(resources.GetObject("btnAddComputer.Image")));
            this.btnAddComputer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddComputer.Location = new System.Drawing.Point(-20, -31);
            this.btnAddComputer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddComputer.Name = "btnAddComputer";
            this.btnAddComputer.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnAddComputer.Size = new System.Drawing.Size(223, 112);
            this.btnAddComputer.TabIndex = 2;
            this.btnAddComputer.Text = "         ADD PC";
            this.btnAddComputer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddComputer.UseVisualStyleBackColor = false;
            this.btnAddComputer.Click += new System.EventHandler(this.btnAddComputer_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnRestart);
            this.panel3.Location = new System.Drawing.Point(709, 601);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 50);
            this.panel3.TabIndex = 54;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Peru;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Image = ((System.Drawing.Image)(resources.GetObject("btnRestart.Image")));
            this.btnRestart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestart.Location = new System.Drawing.Point(-20, -31);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnRestart.Size = new System.Drawing.Size(223, 112);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "         RESTART";
            this.btnRestart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnShutdown);
            this.panel4.Location = new System.Drawing.Point(928, 601);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(191, 50);
            this.panel4.TabIndex = 55;
            // 
            // btnShutdown
            // 
            this.btnShutdown.BackColor = System.Drawing.Color.SteelBlue;
            this.btnShutdown.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnShutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShutdown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShutdown.ForeColor = System.Drawing.Color.White;
            this.btnShutdown.Image = ((System.Drawing.Image)(resources.GetObject("btnShutdown.Image")));
            this.btnShutdown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShutdown.Location = new System.Drawing.Point(-20, -31);
            this.btnShutdown.Margin = new System.Windows.Forms.Padding(4);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnShutdown.Size = new System.Drawing.Size(223, 112);
            this.btnShutdown.TabIndex = 2;
            this.btnShutdown.Text = "         SHUTDOWN";
            this.btnShutdown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShutdown.UseVisualStyleBackColor = false;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // dataGridView_Manage_Computer
            // 
            this.dataGridView_Manage_Computer.AllowUserToAddRows = false;
            this.dataGridView_Manage_Computer.AllowUserToDeleteRows = false;
            this.dataGridView_Manage_Computer.AllowUserToResizeColumns = false;
            this.dataGridView_Manage_Computer.AllowUserToResizeRows = false;
            this.dataGridView_Manage_Computer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Manage_Computer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Manage_Computer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.dataGridView_Manage_Computer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Manage_Computer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView_Manage_Computer.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Manage_Computer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Manage_Computer.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Manage_Computer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Manage_Computer.EnableHeadersVisualStyles = false;
            this.dataGridView_Manage_Computer.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView_Manage_Computer.Location = new System.Drawing.Point(35, 106);
            this.dataGridView_Manage_Computer.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Manage_Computer.Name = "dataGridView_Manage_Computer";
            this.dataGridView_Manage_Computer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_Manage_Computer.RowHeadersVisible = false;
            this.dataGridView_Manage_Computer.RowHeadersWidth = 51;
            this.dataGridView_Manage_Computer.RowTemplate.Height = 35;
            this.dataGridView_Manage_Computer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Manage_Computer.Size = new System.Drawing.Size(1084, 388);
            this.dataGridView_Manage_Computer.TabIndex = 56;
            this.dataGridView_Manage_Computer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Manage_Computer_CellContentClick);
            // 
            // formManagePC
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1148, 698);
            this.Controls.Add(this.dataGridView_Manage_Computer);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnLogout);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formManagePC";
            this.ShowIcon = false;
            this.Text = "fromSub1";
            this.Load += new System.EventHandler(this.formManagePC_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnLogout.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Manage_Computer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete_Computer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEdit_Computer;
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.Button btnAddComputer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnShutdown;
        public System.Windows.Forms.DataGridView dataGridView_Manage_Computer;
    }
}