using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InternetCafe.Computers.Computer_View.Computer_Session.Custom_Pay_Rate
{
    public partial class formUpdatePaymentStatus : Form
    {
        private string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";

        public formUpdatePaymentStatus()
        {
            InitializeComponent();
        }

        private void formUpdatePaymentStatus_Load(object sender, EventArgs e)
        {
            PopulateComputerNumbers();

            cmbUpdatePaymentStatus.Items.Add("UNPAID");
            cmbUpdatePaymentStatus.Items.Add("PAID");

            txtTotalPayment.ReadOnly = true;
            txtClientName.ReadOnly = true;

            cmbComputerNumber.KeyPress += cmbComputerNumber_KeyPress;
            cmbUpdatePaymentStatus.KeyPress += cmbUpdatePaymentStatus_KeyPress;

            LoadTotalPaysData();
        }

        private void LoadTotalPaysData()
        {
            DataTable totalPaysTable = RetrieveTotalPays();
        }

        private DataTable RetrieveTotalPays()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ID_Pay, Computer_Number, Total_Pay, Payment_Date FROM tbl_total_pay";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving total pays: " + ex.Message);
            }
            return dataTable;
        }


        /* private void formUpdatePaymentStatus_Load(object sender, EventArgs e)
         {
                          PopulateComputerNumbers();

                          cmbUpdatePaymentStatus.Items.Add("UNPAID");
             cmbUpdatePaymentStatus.Items.Add("PAID");

                          txtTotalPayment.ReadOnly = true;
             txtClientName.ReadOnly = true;

                          cmbComputerNumber.KeyPress += cmbComputerNumber_KeyPress;
             cmbUpdatePaymentStatus.KeyPress += cmbUpdatePaymentStatus_KeyPress;
         }*/

        private void cmbComputerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            cmbUpdatePaymentStatus.SelectionLength = 0;
        }

        private void cmbUpdatePaymentStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            cmbUpdatePaymentStatus.SelectionLength = 0;

        }



        private void PopulateComputerNumbers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Computer_Number FROM tbl_session";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbComputerNumber.Items.Add(reader["Computer_Number"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmbComputerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string computerNumber = cmbComputerNumber.SelectedItem.ToString();
            GetClientInfo(computerNumber);
        }

        private void GetClientInfo(string computerNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT m.user_name, s.Total_Pay FROM tbl_session s INNER JOIN tbl_member m ON s.Member_ID = m.ID WHERE s.Computer_Number = @ComputerNumber";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtClientName.Text = reader["user_name"].ToString();
                        txtTotalPayment.Text = reader["Total_Pay"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmbUpdatePaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUpdatePaymentStatus.SelectedItem != null)
            {
                string selectedStatus = cmbUpdatePaymentStatus.SelectedItem.ToString();


                if (selectedStatus == "PAID")
                {
                    cmbUpdatePaymentStatus.ForeColor = Color.Green;
                }
                else if (selectedStatus == "UNPAID")
                {
                    cmbUpdatePaymentStatus.ForeColor = Color.Red;
                }
            }
        }


        /* private void btnUpadatePaymentStatus_Click(object sender, EventArgs e)
         {
                          if (cmbUpdatePaymentStatus.SelectedItem == null)
             {
                 MessageBox.Show("Please select a payment status.");
                 return;
             }

                          string newPaymentStatus = cmbUpdatePaymentStatus.SelectedItem.ToString();
             string computerNumber = cmbComputerNumber.SelectedItem.ToString();

             try
             {
                 using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                     connection.Open();

                                          string currentPaymentStatus = GetCurrentPaymentStatus(computerNumber, connection);

                                          string updateQuery = "UPDATE tbl_session SET Payment_Status = @PaymentStatus WHERE Computer_Number = @ComputerNumber";
                     SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                     updateCommand.Parameters.AddWithValue("@PaymentStatus", newPaymentStatus);
                     updateCommand.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                     int rowsAffected = updateCommand.ExecuteNonQuery();

                     if (rowsAffected > 0)
                     {
                                                  if (currentPaymentStatus == "UNPAID" && newPaymentStatus == "PAID")
                         {
                                                          StoreTotalPay(computerNumber, GetCurrentTotalPay(computerNumber, connection), connection);
                         }
                                                  else if (currentPaymentStatus == "PAID" && newPaymentStatus == "UNPAID")
                         {
                                                          RemoveTotalPay(computerNumber, connection);
                         }

                         MessageBox.Show("Payment status updated successfully.");

                                                  this.Close();
                     }
                     else
                     {
                         MessageBox.Show("No rows updated. Please check the computer number.");
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error: " + ex.Message);
             }
         }*/

        /*private void btnUpadatePaymentStatus_Click(object sender, EventArgs e)
        {
                        if (cmbUpdatePaymentStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment status.");
                return;
            }

                        string newPaymentStatus = cmbUpdatePaymentStatus.SelectedItem.ToString();
            string computerNumber = cmbComputerNumber.SelectedItem.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                                        string currentPaymentStatus = GetCurrentPaymentStatus(computerNumber, connection);

                                        if ((currentPaymentStatus == "UNPAID" && newPaymentStatus == "PAID") || currentPaymentStatus == "")
                    {
                                                StoreTotalPay(computerNumber, GetCurrentTotalPay(computerNumber, connection), connection);
                    }

                                        string updateQuery = "UPDATE tbl_session SET Payment_Status = @PaymentStatus WHERE Computer_Number = @ComputerNumber";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@PaymentStatus", newPaymentStatus);
                    updateCommand.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Payment status updated successfully.");

                                                this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No rows updated. Please check the computer number.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }*/

        private string GetCurrentPaymentStatus(string computerNumber, SqlConnection connection)
        {
            string currentPaymentStatus = "";
            string query = "SELECT Payment_Status FROM tbl_session WHERE Computer_Number = @ComputerNumber";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
            object result = command.ExecuteScalar();
            if (result != null)
            {
                currentPaymentStatus = result.ToString();
            }
            return currentPaymentStatus;
        }


        private void btnUpadatePaymentStatus_Click(object sender, EventArgs e)
        {
            if (cmbUpdatePaymentStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment status.");
                return;
            }

            string newPaymentStatus = cmbUpdatePaymentStatus.SelectedItem.ToString();
            string computerNumber = cmbComputerNumber.SelectedItem.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string currentPaymentStatus = GetCurrentPaymentStatus(computerNumber, connection);

                    if ((currentPaymentStatus == "UNPAID" && newPaymentStatus == "PAID") || currentPaymentStatus == "")
                    {
                        string memberID = GetMemberID(computerNumber, connection);

                        StoreTotalPay(computerNumber, GetCurrentTotalPay(computerNumber, connection), memberID, connection);
                    }

                    string updateQuery = "UPDATE tbl_session SET Payment_Status = @PaymentStatus WHERE Computer_Number = @ComputerNumber";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@PaymentStatus", newPaymentStatus);
                    updateCommand.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Payment status updated successfully.");

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No rows updated. Please check the computer number.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /*                        private string GetCurrentPaymentStatus(string computerNumber, SqlConnection connection)
                {
                    string currentPaymentStatus = "";
                    string query = "SELECT Payment_Status FROM tbl_session WHERE Computer_Number = @ComputerNumber";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        currentPaymentStatus = result.ToString();
                    }
                    return currentPaymentStatus;
                }*/

        private string GetMemberID(string computerNumber, SqlConnection connection)
        {
            string memberID = "";
            string query = "SELECT Member_ID FROM tbl_session WHERE Computer_Number = @ComputerNumber";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
            object result = command.ExecuteScalar();
            if (result != null)
            {
                memberID = result.ToString();
            }
            return memberID;

        }
        private string GetCurrentTotalPay(string computerNumber, SqlConnection connection)
        {
            string currentTotalPay = "";
            string query = "SELECT Total_Pay FROM tbl_session WHERE Computer_Number = @ComputerNumber";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
            object result = command.ExecuteScalar();
            if (result != null)
            {
                currentTotalPay = result.ToString();
            }
            return currentTotalPay;
        }

        /*          private void StoreTotalPay(string computerNumber, string totalPay, SqlConnection connection)
         {
             try
             {
                 string insertQuery = "INSERT INTO tbl_total_pay (Computer_Number, Total_Pay, Payment_Date) VALUES (@ComputerNumber, @TotalPay, @PaymentDate)";
                 SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                 insertCommand.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                 insertCommand.Parameters.AddWithValue("@TotalPay", totalPay);
                 insertCommand.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                 insertCommand.ExecuteNonQuery();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error storing total pay: " + ex.Message);
             }
         }*/

        private void StoreTotalPay(string computerNumber, string totalPay, string memberID, SqlConnection connection)
        {
            try
            {
                string insertQuery = "INSERT INTO tbl_total_pay (Computer_Number, Total_Pay, Payment_Date, Member_ID) VALUES (@ComputerNumber, @TotalPay, @PaymentDate, @MemberID)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                insertCommand.Parameters.AddWithValue("@TotalPay", totalPay);
                insertCommand.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                insertCommand.Parameters.AddWithValue("@MemberID", memberID);
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error storing total pay: " + ex.Message);
            }
        }

        private void RemoveTotalPay(string computerNumber, SqlConnection connection)
        {
            try
            {
                string deleteQuery = "DELETE FROM tbl_total_pay WHERE Computer_Number = @ComputerNumber";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                deleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing total pay: " + ex.Message);
            }
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
