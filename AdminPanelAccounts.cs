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

namespace LibraTrack
{
    public partial class AdminPanelAccounts : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");

        private bool isLoaded = false;
        private int selectedUserId = -1;


        private void AdminPanelAccounts_Load(object sender, EventArgs e)
        {
            if (isLoaded) return;
            isLoaded = true;

            LoadAccounts();

            // LoadAccounts();
            MessageBox.Show("Accounts Loaded");

        }


        public AdminPanelAccounts()
        {
            InitializeComponent();

            // Connect events
            dataGridViewUsers.CellClick += dataGridViewUsers_CellClick;
            dataGridViewUsers.CellFormatting += dataGridViewUsers_CellFormatting;
            adminPanelAccount_btnApprove.Click += btnApprove_Click;
            adminPanelAccount_btnReject.Click += btnReject_Click;
            adminPanelAccount_btnDelete.Click += btnDelete_Click;
            adminPanelAccount_txtSearch.TextChanged += txtSearch_TextChanged;
            adminPanel_txtDateRegister.Format = DateTimePickerFormat.Custom;
            adminPanel_txtDateRegister.CustomFormat = "MM/dd/yyyy";

        }


        public void refreshData()
        {
            LoadAccounts(); // or whatever method loads the grid
        }



        // ✅ Load all users into the DataGridView
        private void LoadAccounts()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT id, id_number AS [ID Number], email AS [Email], username AS [Username], password AS [Password], role AS [Role], status AS [status], FORMAT(date_register, 'MM/dd/yyyy') AS [Date Registered] FROM users";


                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridViewUsers.DataSource = dt;
                    dataGridViewUsers.Columns["id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading accounts: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // ✅ Search users into the DataGridView

        private void SearchAccounts(string keyword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();

                    string query = @"SELECT id, email, username, password, role, status, FORMAT(date_register, 'MM/dd/yyyy') AS date_register FROM users WHERE (id LIKE @keyword OR email LIKE @keyword OR username LIKE @keyword OR password LIKE @keyword OR role LIKE @keyword OR status LIKE @keyword OR FORMAT(date_register, 'MM/dd/yyyy') LIKE @keyword)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dataGridViewUsers.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching accounts: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(adminPanelAccount_txtSearch.Text))
            {
                LoadAccounts(); // if empty, load all
            }
            else
            {
                SearchAccounts(adminPanelAccount_txtSearch.Text.Trim()); // live search
            }
        }


        // ✅ Highlight color based on status
        private void dataGridViewUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();

                    if (status == "Approved")
                    {
                        e.CellStyle.BackColor = Color.MediumSpringGreen;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else if (status == "Pending")
                    {
                        e.CellStyle.BackColor = Color.Khaki; // yellow
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else if (status == "Rejected")
                    {
                        e.CellStyle.BackColor = Color.IndianRed; // red
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }


        // ✅ Approve account
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();
                string query = "UPDATE users SET status='Approved' WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedUserId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Account approved successfully!");
            LoadAccounts();

        }


        // ✅ Reject account
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();
                string query = "UPDATE users SET status='Rejected' WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedUserId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Account rejected successfully!");
            LoadAccounts();

        }


        // ✅ Delete account
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this account?",
                "Confirm Delete",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM users WHERE id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedUserId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Account deleted successfully!");
                LoadAccounts();
            }

        }


        // ✅ Delete method (corrected connection handling)
        private void DeleteAccount(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM users WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Account deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting account: " + ex.Message);
            }
        }


        // ✅ Update status in DB (fixed connection logic)
        private void UpdateStatus(int id, string newStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE users SET status = @status WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("User status updated to " + newStatus, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating account: " + ex.Message);
            }
        }



        // ✅ Show details when clicking a row
        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUsers.Rows[e.RowIndex];

                // 🔑 INTERNAL DB ID (HIDDEN)
                selectedUserId = Convert.ToInt32(row.Cells["id"].Value);

                // 👤 USER ID NUMBER (VISIBLE)
                adminPanelAccount_txtID.Text = row.Cells["ID Number"].Value?.ToString() ?? "";

                adminPanelAccount_txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                adminPanelAccount_txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
                adminPanelAccount_txtPassword.Text = row.Cells["Password"].Value?.ToString() ?? "";
                adminPanelAccount_txtRole.Text = row.Cells["Role"].Value?.ToString() ?? "";
                adminPanelAccount_txtStatus.Text = row.Cells["Status"].Value?.ToString() ?? "";
                adminPanel_txtDateRegister.Text = row.Cells["Date Registered"].Value?.ToString() ?? "";
            }
        }

    }
}

