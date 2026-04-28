using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InternetCafe
{
    public partial class Form1 : Form
    {

        // Declare a static timer object accessible from all forms
        public static Timer globalTimer = new Timer();

        formDashboard dashboard;
        formManagePC ManagePC;

        formAbout about;
      
        private formManagePC managePC;


        private formAdminLogin loginForm;

        public Form1()
        {
            InitializeGlobalTimer();

            managePC = new formManagePC();

            InitializeComponent();
            mdiProp();

            // Initialize an instance of formAdmin
            adminForm = new formAdmin();

            // Initialize an instance of formAdmin
            adminForm = new formAdmin();

            // Initialize the login form with adminForm instance
            this.loginForm = new formAdminLogin(); // Pass adminForm here

            // Subscribe to the login form's event to know when the user successfully logs in
            this.loginForm.LoginSuccess += LoginForm_LoginSuccess;

            // Show the login form
            this.loginForm.ShowDialog();

            // Hide the main form until login succeeds
            this.Visible = false;

            // Attach event handlers to the panel for drag functionality
            formPanel.MouseDown += FormPanel_MouseDown;
            formPanel.MouseMove += FormPanel_MouseMove;
            formPanel.MouseUp += FormPanel_MouseUp;

        }

        private bool isDragging = false;
        private Point lastCursor;
        private Point lastFormLocation;


        private void FormPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastFormLocation = this.Location;
        }

        private void FormPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = Cursor.Position.X - lastCursor.X;
                int deltaY = Cursor.Position.Y - lastCursor.Y;
                this.Location = new Point(lastFormLocation.X + deltaX, lastFormLocation.Y + deltaY);
            }
        }


        private void FormPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }



        private formAdmin adminForm;

        private void InitializeGlobalTimer()
        {
            // Initialize the global timer to update the date and time every second
            globalTimer.Interval = 1000;
            globalTimer.Tick += (s, args) => UpdateDateTime();
            // Start the timer only if it's not already running
            if (!globalTimer.Enabled)
            {
                globalTimer.Start();
            }
        }

        private void formPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }


        private void lblDate_Click(object sender, EventArgs e)
        {
            // Update the label's text with the current date and time
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }



        // Event handler for successful login
        private void LoginForm_LoginSuccess(object sender, EventArgs e)
        {
            // Close the formAdminLogin form after successful login
            loginForm.Close();

            // Show the main form after successful login
            this.Visible = true;

            // Trigger the form load event to start the timer
            Form1_Load(null, EventArgs.Empty);

            // Open the dashboard form
            OpenDashboardForm();
        }


        // Method to open the dashboard form
        private void OpenDashboardForm()
        {
            if (dashboard == null)
            {
                dashboard = new formDashboard();
                dashboard.FormClosed += dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill;
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
            }
        }


        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the timer to update the date and time every second
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, args) => UpdateDateTime();
            timer.Start();

            // Set the initial position of the date and time labels
            UpdateDateTimePosition();

            // Add lblTime and lblDate to the form controls only if they are not already added
            if (!this.Controls.Contains(lblTime))
                this.Controls.Add(lblTime);
            if (!this.Controls.Contains(lblDate))
                this.Controls.Add(lblDate);

            // Bring the labels to the front
            lblTime.BringToFront();
            lblDate.BringToFront();

            // Make sure labels are visible
            lblTime.Visible = true;
            lblDate.Visible = true;

            // Subscribe to the SizeChanged event
            this.SizeChanged += Form1_SizeChanged;

            // Set the back color of the labels to transparent using RGB values
            lblTime.BackColor = Color.FromArgb(27, 100, 155);
            lblDate.BackColor = Color.FromArgb(27, 100, 155);

            // Adjusting padding for the time label
            int timeLeftPadding = 0;
            int timeTopPadding = 20;
            int timeRightPadding = 90;
            int timeBottomPadding = 0;

            lblTime.Padding = new Padding(timeLeftPadding, timeTopPadding, timeRightPadding, timeBottomPadding);

            // Adjusting padding for the date label
            int dateLeftPadding = 0;
            int dateTopPadding = 30;
            int dateRightPadding = 90;
            int dateBottomPadding = 10;

            lblDate.Padding = new Padding(dateLeftPadding, dateTopPadding, dateRightPadding, dateBottomPadding);

            // Start the form maximized
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // Call UpdateDateTimePosition() whenever the form size changes
            UpdateDateTimePosition();
        }

        private void UpdateDateTimePosition()
        {
            // Calculate the position of the date and time labels relative to the client area of the form
            int xOffset = 10;
            int yOffset = 5;

            if (this.WindowState == FormWindowState.Maximized)
            {
                xOffset = 10;
                yOffset = 10; // Increase the yOffset to place them lower

            }
            lblTime.Location = new Point(xOffset, this.ClientSize.Height - lblTime.Height - lblTime.Height - yOffset);
            lblDate.Location = new Point(xOffset, this.ClientSize.Height - lblDate.Height - yOffset);

        }

        private void nightControlBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent = e as MouseEventArgs;
            if (mouseEvent != null)
            {
                int buttonWidth = 30;
                int buttonHeight = 30;
                int xMargin = 10;
                int yMargin = 10;

                Rectangle closeButtonBounds = new Rectangle(nightControlBox1.Width - buttonWidth - xMargin, yMargin, buttonWidth, buttonHeight);

                if (closeButtonBounds.Contains(mouseEvent.Location))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to close the application and go to the login page?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();

                        formAdminLogin loginForm = new formAdminLogin();
                        loginForm.LoginSuccess += LoginForm_LoginSuccess;
                        loginForm.ShowDialog();
                    }
                }

                // Update the position of the date and time labels when the maximize button is clicked
                UpdateDateTimePosition();
            }
        }



        private void WbTitle_Click(object sender, EventArgs e)
        {

        }

        bool sidebarExpand = true;

        private void btnHam_Click(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                // Sidebar is currently expanded, so close it
                sidebar.Width = 53;
                sidebarExpand = false;

                // Hide the time and date labels
                lblTime.Visible = false;
                lblDate.Visible = false;

                // Adjust other controls accordingly
                pnDashboard.Width = sidebar.Width;
                pnmenuContainer.Width = sidebar.Width;
                pnMembersContainer.Width = sidebar.Width;
                pnAdminContainer.Width = sidebar.Width;              
                pnLogout.Width = sidebar.Width;
            }
            else
            {
                // Sidebar is currently closed, so open it
                sidebar.Width = 250;
                sidebarExpand = true;

                // Show the time and date labels
                lblTime.Visible = true;
                lblDate.Visible = true;

                // Adjust other controls accordingly
                pnDashboard.Width = sidebar.Width;
                pnmenuContainer.Width = sidebar.Width;
                pnMembersContainer.Width = sidebar.Width;
                pnAdminContainer.Width = sidebar.Width;
                pnLogout.Width = sidebar.Width;
            }
        }


        // Dashboard ==================================================================================================================

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (dashboard == null)
            {
                dashboard = new formDashboard();
                dashboard.FormClosed += dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill;
                dashboard.Show();
            }
            else
            {
                dashboard = new formDashboard();
                dashboard.FormClosed += dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill;
                dashboard.Show();
            }
        }

        private void dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }

        private void pnDashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // Computers ==================================================================================================================

        bool ComputerExpand = false;


        private void ComputerTransition_Tick(object sender, EventArgs e)
        {
            // Check if the computer container is already expanded
            if (!ComputerExpand)
            {
                // If not expanded, expand it
                pnmenuContainer.Height += 10;
                if (pnmenuContainer.Height >= 210)
                {
                    ComputerTransition.Stop();
                    ComputerExpand = true;
                    // If other containers are expanded, collapse them
                    if (AdminExpand)
                    {
                        AdminTransition.Start();
                    }
                    if (MembersExpand)
                    {
                        MembersTransition.Start();
                    }
                }
            }
            else
            {
                // If expanded, collapse it
                pnmenuContainer.Height -= 10;
                if (pnmenuContainer.Height <= 53)
                {
                    ComputerTransition.Stop();
                    ComputerExpand = false;
                }
            }
        }


        private void ComputersContainer_Click(object sender, EventArgs e)
        {
            ComputerTransition.Start();

        }


        private void submenu2_Click(object sender, EventArgs e)
        {
            if (ManagePC == null)
            {
                ManagePC = new formManagePC();
                ManagePC.FormClosed += ManagePC_FormClosed;
                ManagePC.MdiParent = this;
                ManagePC.Dock = DockStyle.Fill;
                ManagePC.Show();

            }
            else
            {
                ManagePC.Activate();

            }

            // Trigger the btnAdd_Click event of formManagePC
            ManagePC.btnAddComputer_Click(sender, e);
        }

        private void submenu1_Click(object sender, EventArgs e)
        {
            if (ManagePC == null)
            {
                ManagePC = new formManagePC();
                ManagePC.FormClosed += ManagePC_FormClosed;
                ManagePC.MdiParent = this;
                ManagePC.Dock = DockStyle.Fill;
                ManagePC.Show();
            }
            else
            {
                ManagePC.Activate();



            }

        }

        private void ManagePC_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManagePC = null;
        }


        formComputer_Manage_Time formComputer_M_T;

        formMembers membersForm;
        formManagePC managePCForm;

        private void btnComputers_Click(object sender, EventArgs e)
        {

            if (formComputer_M_T == null)
            {
                // If not instantiated, create new instances of formMembers and formManagePC
                membersForm = new formMembers();
                managePCForm = new formManagePC();

                // Store the pause states of sessions before closing the form
                Dictionary<int, bool> pauseStates = GetPauseStates();

                // Pass references to formMembers, formManagePC, and pauseStates to formComputer_Manage_Time
                formComputer_M_T = new formComputer_Manage_Time(membersForm, managePCForm, pauseStates);

                // Handle the FormClosed event to clean up
                formComputer_M_T.FormClosed += formComputer_M_T_FormClosed;

                // Set the MDI parent and display the form
                formComputer_M_T.MdiParent = this;
                formComputer_M_T.Dock = DockStyle.Fill;
                formComputer_M_T.Show();
            }
            else
            {
                formComputer_M_T.Activate();
            }
                  
        }

        private void formComputer_M_T_FormClosed(object sender, FormClosedEventArgs e)
        {
            formComputer_M_T = null;
        }

        private Dictionary<int, bool> GetPauseStates()
        {
            Dictionary<int, bool> pauseStates = new Dictionary<int, bool>();
            if (formComputer_M_T != null && formComputer_M_T.dataGridView_New_Session != null)
            {
                foreach (DataGridViewRow row in formComputer_M_T.dataGridView_New_Session.Rows)
                {
                    int sessionId = Convert.ToInt32(row.Cells["Session_ID"].Value);
                    pauseStates[sessionId] = formComputer_M_T.timerPauseStates.ContainsKey(sessionId) && formComputer_M_T.timerPauseStates[sessionId];
                }
            }
            return pauseStates;
        }






        // Members ==================================================================================================================

        bool MembersExpand = false;

        private void MembersTransition_Tick(object sender, EventArgs e)
        {
            // Check if the members container is already expanded
            if (!MembersExpand)
            {
                // If not expanded, expand it
                pnMembersContainer.Height += 10;
                if (pnMembersContainer.Height >= 153)
                {
                    MembersTransition.Stop();
                    MembersExpand = true;
                    // If other containers are expanded, collapse them
                    if (AdminExpand)
                    {
                        AdminTransition.Start();
                    }
                    if (ComputerExpand)
                    {
                        ComputerTransition.Start();
                    }
                }
            }
            else
            {
                // If expanded, collapse it
                pnMembersContainer.Height -= 10;
                if (pnMembersContainer.Height <= 53)
                {
                    MembersTransition.Stop();
                    MembersExpand = false;
                }
            }
        }


        private void MembersContainer_Click(object sender, EventArgs e)
        {
            MembersTransition.Start();
        }


        private void pnMembersContainer_Paint(object sender, PaintEventArgs e)
        {

        }

      
        // ==================================================================================================================


        formMembers members;

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (members == null)
            {
                members = new formMembers();
                members.FormClosed += members_FormClosed;
                members.MdiParent = this;
                members.Dock = DockStyle.Fill;
                members.Show();
            }
            else
            {
                members.Activate();
            }
        }

        private void members_FormClosed(object sender, FormClosedEventArgs e)
        {
            members = null;

        }

        private void btnAddMembers_Click(object sender, EventArgs e)
        {
            if (members == null)
            {
                members = new formMembers();
                members.FormClosed += members_FormClosed;
                members.MdiParent = this;
                members.Dock = DockStyle.Fill;
                members.Show();
            }
            else
            {
                members = new formMembers();
                members.FormClosed += members_FormClosed;
                members.MdiParent = this;
                members.Dock = DockStyle.Fill;
                members.Show();
            }

            // Check if the user form instance exists
            if (members != null)
            {
                // Call the btnAddMembers_Click method of the formMembers instance
                members.btnAddMembers_Click(sender, e);
            }
        }



        // Admin ==================================================================================================================

        bool AdminExpand = false;

        private void AdminTransition_Tick(object sender, EventArgs e)
        {
            // Check if the admin container is already expanded
            if (!AdminExpand)
            {
                // If not expanded, expand it
                pnAdminContainer.Height += 10;
                if (pnAdminContainer.Height >= 153)
                {
                    AdminTransition.Stop();
                    AdminExpand = true;

                    // If other containers are expanded, collapse them
                    if (ComputerExpand)
                    {
                        ComputerTransition.Start();
                    }
                    if (MembersExpand)
                    {
                        MembersTransition.Start();
                    }
                }
            }
            else
            {
                // If expanded, collapse it
                pnAdminContainer.Height -= 10;
                if (pnAdminContainer.Height <= 53)
                {
                    AdminTransition.Stop();
                    AdminExpand = false;
                }
            }
        }



        private void AdminContainer_Click(object sender, EventArgs e)
        {
            AdminTransition.Start();
        }


        private void pnAdminContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        // ==================================================================================================================

        private formAdmin adminsForm; // Declare a formAdmins variable

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            if (adminsForm == null)
            {
                adminsForm = new formAdmin();
                adminsForm.FormClosed += AdminsForm_FormClosed;
                adminsForm.MdiParent = this;
                adminsForm.Dock = DockStyle.Fill;
                adminsForm.Show();
            }
            else
            {
                adminsForm = new formAdmin();
                adminsForm.FormClosed += AdminsForm_FormClosed;
                adminsForm.MdiParent = this;
                adminsForm.Dock = DockStyle.Fill;
                adminsForm.Show();
            }
        }

        private void AdminsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            adminsForm = null;
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            if (adminsForm == null)
            {
                adminsForm = new formAdmin();
                adminsForm.FormClosed += AdminsForm_FormClosed;
                adminsForm.MdiParent = this;
                adminsForm.Dock = DockStyle.Fill;
                adminsForm.Show();
            }
            else
            {
                adminsForm.Activate();
            }

            // Check if the admins form instance exists
            if (adminsForm != null)
            {
                // Call the btnAddAdmin_Click method of the formAdmins instance
                adminsForm.btnAddAdmin_Click(sender, e);
            }
        }

        // About ==================================================================================================================

        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (about == null)
            {
                about = new formAbout();
                about.FormClosed += about_FormClosed;
                about.MdiParent = this;
                about.Dock = DockStyle.Fill;
                about.Show();
            }
            else
            {
                about.Activate();
            }
        }

        private void about_FormClosed(object sender, FormClosedEventArgs e)
        {
            about = null;

        }

        // Logout ==================================================================================================================

        private void btnLogout_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Hide the current dashboard form
                this.Hide();

                // Show the login form
                formAdminLogin loginForm = new formAdminLogin();
                loginForm.LoginSuccess += LoginForm_LoginSuccess;
                loginForm.ShowDialog();
            }
        }

    }
}
