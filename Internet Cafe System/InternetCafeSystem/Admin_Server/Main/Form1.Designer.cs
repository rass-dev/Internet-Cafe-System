namespace InternetCafe
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.formPanel = new System.Windows.Forms.Panel();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.WbTitle = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnDashboard = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnmenuContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ComputersContainer = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnComputers = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.submenu1 = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.ComputerContainer = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.submenu2 = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pnMembersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MembersContainer = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnManagePC = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAddMembers = new System.Windows.Forms.Button();
            this.pnAdminContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.AdminContainer = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnManageAdmin = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnAddAdmin = new System.Windows.Forms.Button();
            this.pnLogout = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.ComputerTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.MembersTransition = new System.Windows.Forms.Timer(this.components);
            this.AdminTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.pnDashboard.SuspendLayout();
            this.pnmenuContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.pnMembersContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnAdminContainer.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel7.SuspendLayout();
            this.pnLogout.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.White;
            this.formPanel.Controls.Add(this.nightControlBox1);
            this.formPanel.Controls.Add(this.btnHam);
            this.formPanel.Controls.Add(this.WbTitle);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formPanel.Location = new System.Drawing.Point(0, 0);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(1100, 39);
            this.formPanel.TabIndex = 0;
            this.formPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.formPanel_Paint);
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = true;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(961, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 1;
            this.nightControlBox1.Click += new System.EventHandler(this.nightControlBox1_Click);
            // 
            // btnHam
            // 
            this.btnHam.Image = ((System.Drawing.Image)(resources.GetObject("btnHam.Image")));
            this.btnHam.Location = new System.Drawing.Point(5, 4);
            this.btnHam.Name = "btnHam";
            this.btnHam.Size = new System.Drawing.Size(41, 31);
            this.btnHam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnHam.TabIndex = 1;
            this.btnHam.TabStop = false;
            this.btnHam.Click += new System.EventHandler(this.btnHam_Click);
            // 
            // WbTitle
            // 
            this.WbTitle.AutoSize = true;
            this.WbTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WbTitle.Location = new System.Drawing.Point(67, 9);
            this.WbTitle.Name = "WbTitle";
            this.WbTitle.Size = new System.Drawing.Size(171, 23);
            this.WbTitle.TabIndex = 2;
            this.WbTitle.Text = "Internet Cafe System";
            this.WbTitle.Click += new System.EventHandler(this.WbTitle_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(3, 325);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(128, 42);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "00:00:00";
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(3, 367);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(117, 30);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "00/00/0000";
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // pnDashboard
            // 
            this.pnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(170)))));
            this.pnDashboard.Controls.Add(this.btnDashboard);
            this.pnDashboard.Location = new System.Drawing.Point(0, 33);
            this.pnDashboard.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pnDashboard.Name = "pnDashboard";
            this.pnDashboard.Size = new System.Drawing.Size(252, 53);
            this.pnDashboard.TabIndex = 2;
            this.pnDashboard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnDashboard_Paint);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(-22, -20);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(278, 91);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "              Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnmenuContainer
            // 
            this.pnmenuContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(155)))));
            this.pnmenuContainer.Controls.Add(this.panel2);
            this.pnmenuContainer.Controls.Add(this.panel10);
            this.pnmenuContainer.Controls.Add(this.panel8);
            this.pnmenuContainer.Controls.Add(this.panel5);
            this.pnmenuContainer.Location = new System.Drawing.Point(0, 92);
            this.pnmenuContainer.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pnmenuContainer.Name = "pnmenuContainer";
            this.pnmenuContainer.Size = new System.Drawing.Size(252, 53);
            this.pnmenuContainer.TabIndex = 8;
            this.pnmenuContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ComputersContainer);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 53);
            this.panel2.TabIndex = 5;
            // 
            // ComputersContainer
            // 
            this.ComputersContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.ComputersContainer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComputersContainer.ForeColor = System.Drawing.Color.White;
            this.ComputersContainer.Image = ((System.Drawing.Image)(resources.GetObject("ComputersContainer.Image")));
            this.ComputersContainer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComputersContainer.Location = new System.Drawing.Point(-19, -17);
            this.ComputersContainer.Margin = new System.Windows.Forms.Padding(0);
            this.ComputersContainer.Name = "ComputersContainer";
            this.ComputersContainer.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.ComputersContainer.Size = new System.Drawing.Size(278, 91);
            this.ComputersContainer.TabIndex = 2;
            this.ComputersContainer.Text = "              Computer";
            this.ComputersContainer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComputersContainer.UseVisualStyleBackColor = false;
            this.ComputersContainer.Click += new System.EventHandler(this.ComputersContainer_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnComputers);
            this.panel10.Location = new System.Drawing.Point(0, 53);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(258, 53);
            this.panel10.TabIndex = 4;
            // 
            // btnComputers
            // 
            this.btnComputers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.btnComputers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComputers.ForeColor = System.Drawing.Color.White;
            this.btnComputers.Image = ((System.Drawing.Image)(resources.GetObject("btnComputers.Image")));
            this.btnComputers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComputers.Location = new System.Drawing.Point(-16, -18);
            this.btnComputers.Margin = new System.Windows.Forms.Padding(0);
            this.btnComputers.Name = "btnComputers";
            this.btnComputers.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnComputers.Size = new System.Drawing.Size(278, 91);
            this.btnComputers.TabIndex = 2;
            this.btnComputers.Text = "             New Computer Session";
            this.btnComputers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComputers.UseVisualStyleBackColor = false;
            this.btnComputers.Click += new System.EventHandler(this.btnComputers_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.submenu1);
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Location = new System.Drawing.Point(0, 106);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(258, 53);
            this.panel8.TabIndex = 4;
            // 
            // submenu1
            // 
            this.submenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.submenu1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submenu1.ForeColor = System.Drawing.Color.White;
            this.submenu1.Image = ((System.Drawing.Image)(resources.GetObject("submenu1.Image")));
            this.submenu1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenu1.Location = new System.Drawing.Point(-14, -22);
            this.submenu1.Margin = new System.Windows.Forms.Padding(0);
            this.submenu1.Name = "submenu1";
            this.submenu1.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.submenu1.Size = new System.Drawing.Size(278, 91);
            this.submenu1.TabIndex = 2;
            this.submenu1.Text = "             Manage Computers";
            this.submenu1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenu1.UseVisualStyleBackColor = false;
            this.submenu1.Click += new System.EventHandler(this.submenu1_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.ComputerContainer);
            this.panel11.Location = new System.Drawing.Point(0, 53);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(248, 53);
            this.panel11.TabIndex = 4;
            // 
            // ComputerContainer
            // 
            this.ComputerContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(190)))));
            this.ComputerContainer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComputerContainer.ForeColor = System.Drawing.Color.White;
            this.ComputerContainer.Image = ((System.Drawing.Image)(resources.GetObject("ComputerContainer.Image")));
            this.ComputerContainer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComputerContainer.Location = new System.Drawing.Point(0, 145);
            this.ComputerContainer.Margin = new System.Windows.Forms.Padding(0);
            this.ComputerContainer.Name = "ComputerContainer";
            this.ComputerContainer.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.ComputerContainer.Size = new System.Drawing.Size(278, 91);
            this.ComputerContainer.TabIndex = 2;
            this.ComputerContainer.Text = "              Computer";
            this.ComputerContainer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComputerContainer.UseVisualStyleBackColor = false;
            this.ComputerContainer.Click += new System.EventHandler(this.ComputersContainer_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.submenu2);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Location = new System.Drawing.Point(0, 159);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(258, 53);
            this.panel5.TabIndex = 5;
            // 
            // submenu2
            // 
            this.submenu2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.submenu2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submenu2.ForeColor = System.Drawing.Color.White;
            this.submenu2.Image = ((System.Drawing.Image)(resources.GetObject("submenu2.Image")));
            this.submenu2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenu2.Location = new System.Drawing.Point(-13, -21);
            this.submenu2.Name = "submenu2";
            this.submenu2.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.submenu2.Size = new System.Drawing.Size(278, 91);
            this.submenu2.TabIndex = 2;
            this.submenu2.Text = "             Add Computer";
            this.submenu2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submenu2.UseVisualStyleBackColor = false;
            this.submenu2.Click += new System.EventHandler(this.submenu2_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.button2);
            this.panel9.Location = new System.Drawing.Point(0, 53);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(248, 53);
            this.panel9.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(190)))));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 145);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(278, 91);
            this.button2.TabIndex = 2;
            this.button2.Text = "              Computer";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // pnMembersContainer
            // 
            this.pnMembersContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(155)))));
            this.pnMembersContainer.Controls.Add(this.panel1);
            this.pnMembersContainer.Controls.Add(this.panel3);
            this.pnMembersContainer.Controls.Add(this.panel4);
            this.pnMembersContainer.Location = new System.Drawing.Point(0, 151);
            this.pnMembersContainer.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pnMembersContainer.Name = "pnMembersContainer";
            this.pnMembersContainer.Size = new System.Drawing.Size(252, 53);
            this.pnMembersContainer.TabIndex = 9;
            this.pnMembersContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnMembersContainer_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MembersContainer);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 53);
            this.panel1.TabIndex = 4;
            // 
            // MembersContainer
            // 
            this.MembersContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.MembersContainer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembersContainer.ForeColor = System.Drawing.Color.White;
            this.MembersContainer.Image = ((System.Drawing.Image)(resources.GetObject("MembersContainer.Image")));
            this.MembersContainer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MembersContainer.Location = new System.Drawing.Point(-22, -19);
            this.MembersContainer.Margin = new System.Windows.Forms.Padding(0);
            this.MembersContainer.Name = "MembersContainer";
            this.MembersContainer.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.MembersContainer.Size = new System.Drawing.Size(278, 91);
            this.MembersContainer.TabIndex = 2;
            this.MembersContainer.Text = "              Members";
            this.MembersContainer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MembersContainer.UseVisualStyleBackColor = false;
            this.MembersContainer.Click += new System.EventHandler(this.MembersContainer_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnManagePC);
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(258, 53);
            this.panel3.TabIndex = 5;
            // 
            // btnManagePC
            // 
            this.btnManagePC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.btnManagePC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagePC.ForeColor = System.Drawing.Color.White;
            this.btnManagePC.Image = ((System.Drawing.Image)(resources.GetObject("btnManagePC.Image")));
            this.btnManagePC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagePC.Location = new System.Drawing.Point(-18, -18);
            this.btnManagePC.Name = "btnManagePC";
            this.btnManagePC.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnManagePC.Size = new System.Drawing.Size(278, 91);
            this.btnManagePC.TabIndex = 2;
            this.btnManagePC.Text = "             Manage Members";
            this.btnManagePC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagePC.UseVisualStyleBackColor = false;
            this.btnManagePC.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAddMembers);
            this.panel4.Location = new System.Drawing.Point(0, 106);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(258, 53);
            this.panel4.TabIndex = 4;
            // 
            // btnAddMembers
            // 
            this.btnAddMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.btnAddMembers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMembers.ForeColor = System.Drawing.Color.White;
            this.btnAddMembers.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMembers.Image")));
            this.btnAddMembers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMembers.Location = new System.Drawing.Point(-13, -31);
            this.btnAddMembers.Name = "btnAddMembers";
            this.btnAddMembers.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAddMembers.Size = new System.Drawing.Size(278, 91);
            this.btnAddMembers.TabIndex = 2;
            this.btnAddMembers.Text = "            Add Members";
            this.btnAddMembers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMembers.UseVisualStyleBackColor = false;
            this.btnAddMembers.Click += new System.EventHandler(this.btnAddMembers_Click);
            // 
            // pnAdminContainer
            // 
            this.pnAdminContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(155)))));
            this.pnAdminContainer.Controls.Add(this.panel6);
            this.pnAdminContainer.Controls.Add(this.panel12);
            this.pnAdminContainer.Controls.Add(this.panel7);
            this.pnAdminContainer.Location = new System.Drawing.Point(0, 210);
            this.pnAdminContainer.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pnAdminContainer.Name = "pnAdminContainer";
            this.pnAdminContainer.Size = new System.Drawing.Size(252, 53);
            this.pnAdminContainer.TabIndex = 10;
            this.pnAdminContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnAdminContainer_Paint);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.AdminContainer);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(251, 53);
            this.panel6.TabIndex = 4;
            // 
            // AdminContainer
            // 
            this.AdminContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.AdminContainer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminContainer.ForeColor = System.Drawing.Color.White;
            this.AdminContainer.Image = ((System.Drawing.Image)(resources.GetObject("AdminContainer.Image")));
            this.AdminContainer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AdminContainer.Location = new System.Drawing.Point(-21, -19);
            this.AdminContainer.Margin = new System.Windows.Forms.Padding(0);
            this.AdminContainer.Name = "AdminContainer";
            this.AdminContainer.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.AdminContainer.Size = new System.Drawing.Size(278, 91);
            this.AdminContainer.TabIndex = 2;
            this.AdminContainer.Text = "              Admin";
            this.AdminContainer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AdminContainer.UseVisualStyleBackColor = false;
            this.AdminContainer.Click += new System.EventHandler(this.AdminContainer_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnManageAdmin);
            this.panel12.Location = new System.Drawing.Point(0, 53);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(258, 53);
            this.panel12.TabIndex = 4;
            // 
            // btnManageAdmin
            // 
            this.btnManageAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.btnManageAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageAdmin.ForeColor = System.Drawing.Color.White;
            this.btnManageAdmin.Image = ((System.Drawing.Image)(resources.GetObject("btnManageAdmin.Image")));
            this.btnManageAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageAdmin.Location = new System.Drawing.Point(-29, -20);
            this.btnManageAdmin.Name = "btnManageAdmin";
            this.btnManageAdmin.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnManageAdmin.Size = new System.Drawing.Size(301, 91);
            this.btnManageAdmin.TabIndex = 2;
            this.btnManageAdmin.Text = "                 Manage Admins";
            this.btnManageAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageAdmin.UseVisualStyleBackColor = false;
            this.btnManageAdmin.Click += new System.EventHandler(this.btnAdmins_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnAddAdmin);
            this.panel7.Location = new System.Drawing.Point(0, 106);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(258, 53);
            this.panel7.TabIndex = 5;
            // 
            // btnAddAdmin
            // 
            this.btnAddAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(121)))), ((int)(((byte)(180)))));
            this.btnAddAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAddAdmin.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAdmin.Image")));
            this.btnAddAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAdmin.Location = new System.Drawing.Point(-17, -22);
            this.btnAddAdmin.Name = "btnAddAdmin";
            this.btnAddAdmin.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAddAdmin.Size = new System.Drawing.Size(278, 91);
            this.btnAddAdmin.TabIndex = 2;
            this.btnAddAdmin.Text = "             Add Admin";
            this.btnAddAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAdmin.UseVisualStyleBackColor = false;
            this.btnAddAdmin.Click += new System.EventHandler(this.btnAddAdmin_Click);
            // 
            // pnLogout
            // 
            this.pnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(170)))));
            this.pnLogout.Controls.Add(this.btnLogout);
            this.pnLogout.Location = new System.Drawing.Point(0, 269);
            this.pnLogout.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pnLogout.Name = "pnLogout";
            this.pnLogout.Size = new System.Drawing.Size(252, 53);
            this.pnLogout.TabIndex = 7;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(-19, -19);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(278, 91);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "             Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // ComputerTransition
            // 
            this.ComputerTransition.Interval = 5;
            this.ComputerTransition.Tick += new System.EventHandler(this.ComputerTransition_Tick);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 1;
            // 
            // MembersTransition
            // 
            this.MembersTransition.Interval = 5;
            this.MembersTransition.Tick += new System.EventHandler(this.MembersTransition_Tick);
            // 
            // AdminTransition
            // 
            this.AdminTransition.Interval = 5;
            this.AdminTransition.Tick += new System.EventHandler(this.AdminTransition_Tick);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.sidebar.Controls.Add(this.pnDashboard);
            this.sidebar.Controls.Add(this.pnmenuContainer);
            this.sidebar.Controls.Add(this.pnMembersContainer);
            this.sidebar.Controls.Add(this.pnAdminContainer);
            this.sidebar.Controls.Add(this.pnLogout);
            this.sidebar.Controls.Add(this.lblTime);
            this.sidebar.Controls.Add(this.lblDate);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebar.Location = new System.Drawing.Point(0, 39);
            this.sidebar.Name = "sidebar";
            this.sidebar.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.sidebar.Size = new System.Drawing.Size(250, 578);
            this.sidebar.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1100, 617);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.formPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Internet Cafe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.pnDashboard.ResumeLayout(false);
            this.pnmenuContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.pnMembersContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnAdminContainer.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.pnLogout.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.PictureBox btnHam;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private System.Windows.Forms.Label WbTitle;
        private System.Windows.Forms.Panel pnDashboard;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnManagePC;
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button ComputerContainer;
        private System.Windows.Forms.Timer ComputerTransition;
        private System.Windows.Forms.FlowLayoutPanel pnmenuContainer;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button submenu1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button submenu2;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnComputers;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.FlowLayoutPanel pnMembersContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MembersContainer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddMembers;
        private System.Windows.Forms.Timer MembersTransition;
        private System.Windows.Forms.FlowLayoutPanel pnAdminContainer;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button AdminContainer;
        private System.Windows.Forms.Button btnManageAdmin;
        private System.Windows.Forms.Button btnAddAdmin;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Timer AdminTransition;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ComputersContainer;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
    }
}

