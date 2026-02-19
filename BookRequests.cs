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

        }

        public void LoadRequests()
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
        ORDER BY
            CASE
                WHEN r.status = 'Pending' THEN 1
                WHEN r.status = 'Reserved' THEN 2
                WHEN r.status = 'Rejected' THEN 3
        END,
        r.request_date DESC";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
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
        SET status = 'Approved'
        WHERE request_id = @id";

            SqlCommand cmd = new SqlCommand(updateQuery, connect);
            cmd.Parameters.AddWithValue("@id", requestId);
            cmd.ExecuteNonQuery();

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
        }

        private void dataGridViewRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewRequests.Columns[e.ColumnIndex].Name == "status")
            {
                string status = e.Value?.ToString();

                if (status == "Pending")
                    e.CellStyle.BackColor = Color.Khaki;

                else if (status == "Reserved")
                    e.CellStyle.BackColor = Color.LightBlue;

                else if (status == "Rejected")
                    e.CellStyle.BackColor = Color.LightCoral;

                else if (status == "Borrowed")
                    e.CellStyle.BackColor = Color.LightGreen;
            }
        }
    }
}

