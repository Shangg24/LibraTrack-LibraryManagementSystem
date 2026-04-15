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
    public partial class BookRequests : UserControl
    {
        SqlConnection connect = new SqlConnection(
    @"Data Source=acer-extenza\SQLEXPRESS;
      Initial Catalog=LibraTrack;
      Integrated Security=True;
      TrustServerCertificate=True");

        public BookRequests()
        {
            InitializeComponent();
            dataGridViewRequests.CellFormatting += dataGridViewRequests_CellFormatting;

            dataGridViewRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRequests.MultiSelect = false;
            dataGridViewRequests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(128, 0, 0);
            dataGridViewRequests.DefaultCellStyle.SelectionForeColor = Color.White;

        }

        public void LoadRequests(string keyword = "")
        {
            if (connect.State != ConnectionState.Open)
                connect.Open();

            string query = @"
        SELECT r.request_id,
               r.ID_no,
               r.book_id,
               b.book_title,
               r.request_date,
               r.status
        FROM book_requests r
        JOIN books b ON r.book_id = b.id
        WHERE 
            (@keyword = '' OR 
             r.ID_no LIKE @keyword OR 
             r.request_id LIKE @keyword OR 
             b.book_title LIKE @keyword)
        ORDER BY
            CASE
                WHEN r.status = 'Pending' THEN 1
                WHEN r.status = 'Reserved' THEN 2
                WHEN r.status = 'Rejected' THEN 3
            END,
            r.request_date DESC";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
            adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            DataTable table = new DataTable();
            adapter.Fill(table);

            // Add formatted column
            table.Columns.Add("Request No.", typeof(string));

            foreach (DataRow row in table.Rows)
            {
                int id = Convert.ToInt32(row["request_id"]);
                row["Request No."] = "REQ-" + id.ToString("D4");
            }

            dataGridViewRequests.DataSource = table;

            // Hide original ID column
            dataGridViewRequests.Columns["request_id"].Visible = false;

            connect.Close();
        }



        private void BookRequests_Load(object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            LoadRequests();
            request_searchBtn.Clear();
        }

        private void approve_btn_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request.");
                return;
            }

            int requestId = Convert.ToInt32(
                dataGridViewRequests.SelectedRows[0].Cells["request_id"].Value);

            if (connect.State != ConnectionState.Open)
                connect.Open();

            string updateQuery = @"
            UPDATE book_requests
            SET status = 'Reserved'
            WHERE request_id = @id";

            SqlCommand cmd = new SqlCommand(updateQuery, connect);
            cmd.Parameters.AddWithValue("@id", requestId);
            cmd.ExecuteNonQuery();

            string bookTitle = dataGridViewRequests.SelectedRows[0].Cells["book_title"].Value.ToString();
            string studentId = dataGridViewRequests.SelectedRows[0].Cells["ID_no"].Value.ToString();

            LogActivity($"Approved book request '{bookTitle}' for Student ID {studentId}");

            connect.Close();

            MessageBox.Show("Request Approved.");
            LoadRequests();
        }


        private void reject_btn_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request.");
                return;
            }

            int requestId = Convert.ToInt32(
                dataGridViewRequests.SelectedRows[0].Cells["request_id"].Value);

            if (connect.State != ConnectionState.Open)
                connect.Open();

            string updateQuery = @"
        UPDATE book_requests
        SET status = 'Rejected'
        WHERE request_id = @id";

            SqlCommand cmd = new SqlCommand(updateQuery, connect);
            cmd.Parameters.AddWithValue("@id", requestId);
            cmd.ExecuteNonQuery();

            string bookTitle = dataGridViewRequests.SelectedRows[0].Cells["book_title"].Value.ToString();
            string studentId = dataGridViewRequests.SelectedRows[0].Cells["ID_no"].Value.ToString();

            LogActivity($"Rejected book request '{bookTitle}' for Student ID {studentId}");

            connect.Close();

            MessageBox.Show("Request Rejected.");
            LoadRequests();
        }


        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            LoadRequests();
        }


        private void LogActivity(string message)
        {
            try
            {
                // Save to ActivityLog table
                using (SqlConnection logConn = new SqlConnection(connect.ConnectionString))
                {
                    logConn.Open();

                    string logQuery = "INSERT INTO ActivityLog (ActivityDate, ActivityDescription) VALUES (@date, @desc)";

                    using (SqlCommand cmd = new SqlCommand(logQuery, logConn))
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@desc", message);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Update dashboard in real-time
                if (FindForm() is MainForm main)
                {
                    main.AddDashboardActivity(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging activity: " + ex.Message);
            }
        }


        private void dataGridViewRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewRequests.Columns[e.ColumnIndex].Name == "status")
            {
                string status = e.Value?.ToString();

                if (status == "Pending")
                    e.CellStyle.BackColor = Color.Khaki;

                else if (status == "Reserved")
                    e.CellStyle.BackColor = Color.PeachPuff;

                else if (status == "Rejected")
                    e.CellStyle.BackColor = Color.LightCoral;

                else if (status == "Completed")
                    e.CellStyle.BackColor = Color.LightGreen;
            }
        }

        private void request_searchBtn_TextChanged(object sender, EventArgs e)
        {
            LoadRequests(request_searchBtn.Text.Trim());
        }
    }
}

