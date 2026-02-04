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

namespace LibraTrack
{
    public partial class ReturnBooks : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");
        public ReturnBooks()
        {
            InitializeComponent();
            returnBooks_bookIssue.Format = DateTimePickerFormat.Custom;
            returnBooks_bookIssue.CustomFormat = "MM/dd/yyyy";

            DisplayIssuedBooksData();

            dataGridViewReturnBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReturnBooks.MultiSelect = false;
            dataGridViewReturnBooks.ReadOnly = true;

            dataGridViewBorrowedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBorrowedBooks.MultiSelect = true;
            dataGridViewBorrowedBooks.ReadOnly = true;
        }

        public void refreshData() //TO REFRESH THE ISSUED BOOKS LIST
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            DisplayIssuedBooksData();
        }

        private void LogActivity(string message)
        {
            try
            {
                // 1. Insert into ActivityLog table
                using (SqlConnection logConn = new SqlConnection(connect.ConnectionString))
                {
                    logConn.Open();
                    string logQuery = "INSERT INTO ActivityLog (ActivityDate, ActivityDescription) VALUES (@date, @desc)";
                    using (SqlCommand logCmd = new SqlCommand(logQuery, logConn))
                    {
                        logCmd.Parameters.AddWithValue("@date", DateTime.Now);
                        logCmd.Parameters.AddWithValue("@desc", message);
                        logCmd.ExecuteNonQuery();
                    }
                }

                // 2. Update the dashboard's recent activity panel in real-time
                if (FindForm() is MainForm main)
                {
                    main.AddDashboardActivity(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging activity: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void returnBooks_returnBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewBorrowedBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select at least one book to return.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string issueId = returnBooks_issueID.Text.Trim();

            if (string.IsNullOrEmpty(issueId))
            {
                MessageBox.Show("Select a transaction first.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                using (SqlTransaction tx = connect.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridViewBorrowedBooks.SelectedRows)
                        {
                            if (row.Cells["Status"].Value.ToString() == "Returned")
                                continue; // skip already returned books

                            int issueBookId = Convert.ToInt32(row.Cells["IssueBookID"].Value);
                            string bookId = row.Cells["BookID"].Value.ToString();

                            // 1️⃣ Mark as Returned
                            string q1 = "UPDATE issue_books SET status = 'Returned' WHERE id = @id";
                            using (SqlCommand cmd1 = new SqlCommand(q1, connect, tx))
                            {
                                cmd1.Parameters.AddWithValue("@id", issueBookId);
                                cmd1.ExecuteNonQuery();
                            }

                            // 2️⃣ Increase available count
                            string q2 = "UPDATE books SET available = available + 1 WHERE id = @bookId";
                            using (SqlCommand cmd2 = new SqlCommand(q2, connect, tx))
                            {
                                cmd2.Parameters.AddWithValue("@bookId", bookId);
                                cmd2.ExecuteNonQuery();
                            }

                            // 3️⃣ Update book status
                            string q3 = @"UPDATE books
                                  SET status = CASE 
                                                WHEN available = 0 THEN 'Not Available'
                                                ELSE 'Available'
                                               END
                                  WHERE id = @bookId";
                            using (SqlCommand cmd3 = new SqlCommand(q3, connect, tx))
                            {
                                cmd3.Parameters.AddWithValue("@bookId", bookId);
                                cmd3.ExecuteNonQuery();
                            }
                        }

                        // 4️⃣ Check remaining borrowed books
                        string checkQuery = @"SELECT COUNT(*)
                                      FROM issue_books
                                      WHERE issue_id = @iid AND status = 'Borrowed'";

                        int remaining;

                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, connect, tx))
                        {
                            checkCmd.Parameters.AddWithValue("@iid", issueId);
                            remaining = (int)checkCmd.ExecuteScalar();
                        }

                        if (remaining == 0)
                        {
                            string updateIssue = @"UPDATE issues
                                           SET status = 'Returned',
                                               return_date = @rdate
                                           WHERE issue_id = @iid";

                            using (SqlCommand cmd4 = new SqlCommand(updateIssue, connect, tx))
                            {
                                cmd4.Parameters.AddWithValue("@iid", issueId);
                                cmd4.Parameters.AddWithValue("@rdate", DateTime.Now);
                                cmd4.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();

                        if (FindForm() is MainForm mainForm)
                        {
                            mainForm.RefreshIssueBooks();
                        }
                       

                        MessageBox.Show("Selected book(s) returned successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadBorrowedBooks(issueId);
                        DisplayIssuedBooksData();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Return failed: " + ex.Message);
                    }
                }
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }




        public void DisplayIssuedBooksData()
        {
            try
            {
                if (connect.State == ConnectionState.Closed) connect.Open();

                string query = @"
            SELECT issue_id AS IssueID,
                   full_name AS Name,
                   contact AS Contact,
                   email AS Email,
                   ID_no AS StudentID,
                   grade_section AS GradeSection,
                   issue_date AS IssueDate,
                   return_date AS ReturnDate,
                   status AS Status   
            FROM issues
            WHERE date_delete IS NULL
            ORDER BY date_insert DESC";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridViewReturnBooks.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading return records: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open) connect.Close();
            }
        }



        private void LoadBorrowedBooks(string issueId)
        {
            using (SqlConnection con = new SqlConnection(connect.ConnectionString))
            {
                con.Open();

                string query = @"
                SELECT 
                    ib.id AS IssueBookID,
                    b.id AS BookID,
                    b.book_title AS BookTitle,
                    b.author AS Author,
                    ib.status AS Status
                FROM issue_books ib
                INNER JOIN books b ON b.id = ib.book_id
                WHERE ib.issue_id = @issueId
                ORDER BY ib.date_insert ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@issueId", issueId);

                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dataGridViewBorrowedBooks.DataSource = dt;

                    // Hide internal IDs (important but not visible to user)
                    dataGridViewBorrowedBooks.Columns["IssueBookID"].Visible = false;
                    dataGridViewBorrowedBooks.Columns["BookID"].Visible = false;
                }
            }
        }




        public void SearchReturnedBooks(string keyword)
        {
            try
            {
                if (connect.State == ConnectionState.Closed) connect.Open();

                string query = @"
            SELECT issue_id AS IssueID,
                   full_name AS Name,
                   contact AS Contact,
                   email AS Email,
                   ID_no AS StudentID,
                   grade_section AS GradeSection,
                   issue_date AS IssueDate,
                   return_date AS ReturnDate
            FROM issues
            WHERE date_delete IS NULL
              AND (issue_id LIKE @k OR
                    full_name LIKE @k OR
                    contact LIKE @k OR
                    email LIKE @k OR
                    ID_no LIKE @k OR
                    grade_section LIKE @k)
            ORDER BY date_insert DESC;";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@k", "%" + keyword + "%");

                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    dataGridViewReturnBooks.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching return records: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open) connect.Close();
            }
        }



        private void dataGridViewReturnBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewReturnBooks.Rows[e.RowIndex];
                string issueId = row.Cells["IssueID"].Value.ToString();

                returnBooks_issueID.Text = issueId;
                returnBooks_name.Text = row.Cells["Name"].Value.ToString();
                returnBooks_contact.Text = row.Cells["Contact"].Value.ToString();
                returnBooks_email.Text = row.Cells["Email"].Value.ToString();

                if (DateTime.TryParse(row.Cells["IssueDate"].Value.ToString(), out DateTime issued))
                    returnBooks_bookIssue.Value = issued;
                else
                    returnBooks_bookIssue.Value = DateTime.Now;

                // ✅ Load the books for this issue
                LoadBorrowedBooks(issueId);
            }
        }



        private void dataGridViewReturnBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewReturnBooks.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();

                    if (status == "Returned")
                    {
                        e.CellStyle.BackColor = Color.MediumSpringGreen;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else if (status == "Not Return")
                    {
                        e.CellStyle.BackColor = Color.Khaki; // yellow
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }



        public void clearFields() //TO CLEAR THE CONTENT ON THE FORM
        {
            returnBooks_issueID.Text = "";
            returnBooks_name.Text = "";
            returnBooks_contact.Text = "";
            returnBooks_email.Text = "";
            //returnBooks_bookTitle.Text = "";
            //returnBooks_author.Text = "";
        }
        private void returnBooks_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void bookReturn_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = bookReturn_search.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
                DisplayIssuedBooksData();
            else
                SearchReturnedBooks(keyword);
        }

        private void dataGridViewBorrowedBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewBorrowedBooks.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();

                    if (status == "Returned")
                    {
                        dataGridViewBorrowedBooks.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Honeydew;
                    }
                }
            }
        }
    }
}
