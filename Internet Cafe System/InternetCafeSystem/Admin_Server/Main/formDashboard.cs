using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InternetCafe
{
    public partial class formDashboard : Form
    {
        public formDashboard()
        {
            InitializeComponent();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

                        int totalComputers = GetTotalComputerCountFromDatabase();

                        lblTotalComputers.Text = $"{totalComputers}";

                        int totalMembers = GetTotalMemberCountFromDatabase();

                        lblTotalMembers.Text = $"{totalMembers}";

                        int totalAdmins = GetTotalAdminCountFromDatabase();

                        lblTotalAdmins.Text = $"{totalAdmins}";

                        decimal totalRevenue = LoadTotalRevenue();

                        lblTotalProfits.Text = $"{totalRevenue}";
        }

        private int GetTotalAdminCountFromDatabase()
        {
            int totalAdmins = 0;

            try
            {
                string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_admin;Password=1234admin;";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                                        string query = "SELECT COUNT(*) FROM tbl_admin";
                    using (var command = new SqlCommand(query, connection))
                    {
                        totalAdmins = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting total admin count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalAdmins;
        }

        private decimal LoadTotalRevenue()
        {
            decimal totalRevenue = GetTotalRevenueFromDatabase();

                        lblTotalProfits.Text = $" {totalRevenue:C}";

            return totalRevenue;
        }


        private int GetTotalComputerCountFromDatabase()
        {
            int totalComputers = 0;

            try
            {
                string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_admin;Password=1234admin;";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM tbl_computer";
                    using (var command = new SqlCommand(query, connection))
                    {
                        totalComputers = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting total computer count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalComputers;
        }

        private int GetTotalMemberCountFromDatabase()
        {
            int totalMembers = 0;

            try
            {
                string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_admin;Password=1234admin;";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                                        string query = "SELECT COUNT(*) FROM tbl_member WHERE member_type = 'Member'";
                    using (var command = new SqlCommand(query, connection))
                    {
                        totalMembers = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting total member count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalMembers;
        }

        private void lblTotalProfits_Click(object sender, EventArgs e)
        {
                        decimal totalRevenue = GetTotalRevenueFromDatabase();

                        lblTotalProfits.Text = $"{totalRevenue}";
        }

        private decimal GetTotalRevenueFromDatabase()
        {
            decimal totalRevenue = 0;

            try
            {
                string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_admin;Password=1234admin;";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT SUM(Total_Pay) FROM tbl_total_pay";
                    using (var command = new SqlCommand(query, connection))
                    {
                                                object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalRevenue = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting total revenue: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalRevenue;
        }

        private void lblTotalAdmins_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalMembers_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

