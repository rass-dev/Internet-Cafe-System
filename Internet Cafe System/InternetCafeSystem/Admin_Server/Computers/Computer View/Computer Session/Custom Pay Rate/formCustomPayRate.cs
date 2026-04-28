using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetCafe.Computers.Computer_View.Computer_Session.Custom_Pay_Rate
{
    public partial class formCustomPayRate : Form
    {
        private const string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";

        public formCustomPayRate()
        {
            InitializeComponent();
            LoadCustomPayRates();

            txtRatePerHour.KeyPress += txtRatePerHour_KeyPress;
            txtRatePerMinutes.KeyPress += txtRatePerMinutes_KeyPress;

            txtRatePerHour.TextChanged += txtRatePerHour_TextChanged;
            txtRatePerMinutes.TextChanged += txtRatePerMinutes_TextChanged;

            CkbHourRate.CheckedChanged += CkbHourRate_CheckedChanged;
            CkbMinutesRate.CheckedChanged += CkbMinutesRate_CheckedChanged;

            CkbMinutesRate.Checked = false;
            txtRatePerHour.Enabled = true;
            txtRatePerMinutes.Enabled = false;

            CkbHourRate.Checked = true;
        }


        private void LoadCustomPayRates()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, RateType, Rate FROM tbl_custom_pay_rates";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string rateType = reader.GetString(1);
                        decimal rate = reader.GetDecimal(2);

                        if (rateType == "Hour")
                        {
                            txtRatePerHour.Text = rate.ToString();
                        }
                        else if (rateType == "Minute")
                        {
                            txtRatePerMinutes.Text = rate.ToString();
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading custom pay rates: " + ex.Message);
            }
        }

        private bool UpdatePayRate(string rateType, string newRate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = $"UPDATE tbl_custom_pay_rates SET Rate = @Rate WHERE RateType = @RateType";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Rate", Convert.ToDecimal(newRate));
                    command.Parameters.AddWithValue("@RateType", rateType);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating {rateType} rate: " + ex.Message);
                return false;
            }
        }

        private void btnUpdatePayRate_Click(object sender, EventArgs e)
        {
            decimal newHourlyRate = Convert.ToDecimal(txtRatePerHour.Text);
            decimal newMinuteRate = Convert.ToDecimal(txtRatePerMinutes.Text);

            if (newHourlyRate == GetCurrentPayRate("Hour") && newMinuteRate == GetCurrentPayRate("Minute"))
            {
                MessageBox.Show("No changes in pay rate.");
                this.Close();
                return;
            }

            BalanceRates(ref newHourlyRate, ref newMinuteRate);

            bool hourlyUpdated = UpdatePayRate("Hour", newHourlyRate.ToString());
            bool minuteUpdated = UpdatePayRate("Minute", newMinuteRate.ToString());

            if (hourlyUpdated || minuteUpdated)
            {
                MessageBox.Show("Successfully updated pay rate.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update pay rate.");
            }
        }

        private void BalanceRates(ref decimal hourlyRate, ref decimal minuteRate)
        {
            if (hourlyRate != GetCurrentPayRate("Hour"))
            {
                minuteRate = hourlyRate / 60;
                txtRatePerMinutes.Text = minuteRate.ToString("0.00");
            }

            else if (minuteRate != GetCurrentPayRate("Minute"))
            {
                hourlyRate = minuteRate * 60;
                txtRatePerHour.Text = hourlyRate.ToString("0.00");
            }
        }



        private decimal GetCurrentPayRate(string rateType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Rate FROM tbl_custom_pay_rates WHERE RateType = @RateType";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RateType", rateType);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving {rateType} rate: " + ex.Message);
                return 0;
            }
        }

        private void txtRatePerHour_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRatePerMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void txtRatePerHour_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRatePerMinutes_TextChanged(object sender, EventArgs e)
        {

        }

        private void CkbHourRate_CheckedChanged(object sender, EventArgs e)
        {
            if (CkbHourRate.Checked)
            {
                CkbMinutesRate.Checked = false;            
                txtRatePerMinutes.Enabled = false; 
            }
            else
            {
                txtRatePerMinutes.Enabled = true;
            }
        }

        private void CkbMinutesRate_CheckedChanged(object sender, EventArgs e)
        {
            if (CkbMinutesRate.Checked)
            {
                CkbHourRate.Checked = false;
                txtRatePerHour.Enabled = false;
            }
            else
            {
                txtRatePerHour.Enabled = true;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formCustomPayRate_Load(object sender, EventArgs e)
        {

        }

      
    }
}
