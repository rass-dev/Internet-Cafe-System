namespace InternetCafe
{
    partial class formMembers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMembers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.pnLogout = new System.Windows.Forms.Panel();
            this.btnAddMembers = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete_M = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit_M = new System.Windows.Forms.Button();
            this.dataGridView_Members = new System.Windows.Forms.DataGridView();
            this.pnLogout.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Members)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 32);
            this.label3.TabIndex = 45;
            this.label3.Text = "Members";
            // 
            // pnLogout
            // 
            this.pnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnLogout.Controls.Add(this.btnAddMembers);
            this.pnLogout.Location = new System.Drawing.Point(50, 530);
            this.pnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.pnLogout.Name = "pnLogout";
            this.pnLogout.Size = new System.Drawing.Size(191, 50);
            this.pnLogout.TabIndex = 46;
            // 
            // btnAddMembers
            // 
            this.btnAddMembers.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMembers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMembers.ForeColor = System.Drawing.Color.White;
            this.btnAddMembers.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMembers.Image")));
            this.btnAddMembers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMembers.Location = new System.Drawing.Point(-20, -31);
            this.btnAddMembers.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddMembers.Name = "btnAddMembers";
            this.btnAddMembers.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnAddMembers.Size = new System.Drawing.Size(223, 112);
            this.btnAddMembers.TabIndex = 2;
            this.btnAddMembers.Text = "         ADD MEMBER";
            this.btnAddMembers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMembers.UseVisualStyleBackColor = false;
            this.btnAddMembers.Click += new System.EventHandler(this.btnAddMembers_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnDelete_M);
            this.panel2.Location = new System.Drawing.Point(692, 530);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 50);
            this.panel2.TabIndex = 51;
            // 
            // btnDelete_M
            // 
            this.btnDelete_M.BackColor = System.Drawing.Color.Brown;
            this.btnDelete_M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete_M.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete_M.ForeColor = System.Drawing.Color.White;
            this.btnDelete_M.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete_M.Image")));
            this.btnDelete_M.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete_M.Location = new System.Drawing.Point(-19, -32);
            this.btnDelete_M.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete_M.Name = "btnDelete_M";
            this.btnDelete_M.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnDelete_M.Size = new System.Drawing.Size(223, 112);
            this.btnDelete_M.TabIndex = 2;
            this.btnDelete_M.Text = "         DELETE";
            this.btnDelete_M.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete_M.UseVisualStyleBackColor = false;
            this.btnDelete_M.Click += new System.EventHandler(this.btnDelete_M_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnEdit_M);
            this.panel1.Location = new System.Drawing.Point(911, 530);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 50);
            this.panel1.TabIndex = 52;
            // 
            // btnEdit_M
            // 
            this.btnEdit_M.BackColor = System.Drawing.Color.SeaGreen;
            this.btnEdit_M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit_M.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit_M.ForeColor = System.Drawing.Color.White;
            this.btnEdit_M.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit_M.Image")));
            this.btnEdit_M.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit_M.Location = new System.Drawing.Point(-20, -32);
            this.btnEdit_M.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit_M.Name = "btnEdit_M";
            this.btnEdit_M.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnEdit_M.Size = new System.Drawing.Size(223, 112);
            this.btnEdit_M.TabIndex = 2;
            this.btnEdit_M.Text = "         EDIT";
            this.btnEdit_M.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit_M.UseVisualStyleBackColor = false;
            this.btnEdit_M.Click += new System.EventHandler(this.btnEdit_M_Click);
            // 
            // dataGridView_Members
            // 
            this.dataGridView_Members.AllowUserToAddRows = false;
            this.dataGridView_Members.AllowUserToDeleteRows = false;
            this.dataGridView_Members.AllowUserToResizeColumns = false;
            this.dataGridView_Members.AllowUserToResizeRows = false;
            this.dataGridView_Members.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Members.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Members.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240))))); // Light Blue Background
            this.dataGridView_Members.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Members.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView_Members.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))))); // Dark Blue Header Background
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))))); // Dark Blue Header Background
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Members.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Members.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(230))))); // Light Blue Selection Background
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Members.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Members.EnableHeadersVisualStyles = false;
            this.dataGridView_Members.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView_Members.Location = new System.Drawing.Point(50, 103);
            this.dataGridView_Members.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Members.Name = "dataGridView_Members";
            this.dataGridView_Members.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_Members.RowHeadersVisible = false;
            this.dataGridView_Members.RowHeadersWidth = 51;
            this.dataGridView_Members.RowTemplate.Height = 35;
            this.dataGridView_Members.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Members.Size = new System.Drawing.Size(1052, 388);
            this.dataGridView_Members.TabIndex = 53;
            this.dataGridView_Members.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Members_CellContentClick);
            // 
            // formMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1148, 698);
            this.Controls.Add(this.dataGridView_Members);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formMembers";
            this.Text = "formUsers";
            this.Load += new System.EventHandler(this.formMembers_Load);
            this.pnLogout.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Members)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.Button btnAddMembers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete_M;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEdit_M;
        public System.Windows.Forms.DataGridView dataGridView_Members;
    }
}