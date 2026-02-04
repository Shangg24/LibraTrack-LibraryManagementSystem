using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace LibraTrack
{
    public partial class IssueBooks : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");

        List<(string Id, string Title, string Author, int Copies, string ImagePath)> allBooks = new List<(string, string, string, int, string)>();
        private DataTable gradeSectionTable;
        private const int MAX_BOOKS = 5;
        string selectedBookId = null;
        private bool isSelectingBook = false;

        public IssueBooks()
        {
            InitializeComponent();

            // Setup grade & section combo box
            bookIssue_gradeSection.DropDownStyle = ComboBoxStyle.DropDown;
            bookIssue_gradeSection.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            bookIssue_gradeSection.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Setup Issue ID
            bookIssue_id.ReadOnly = true;
            bookIssue_id.Text = GenerateIssueID();

            // Setup DatePickers
            bookIssue_issueDate.Format = DateTimePickerFormat.Custom;
            bookIssue_issueDate.CustomFormat = "MM/dd/yyyy";
            bookIssue_returnDate.Format = DateTimePickerFormat.Custom;
            bookIssue_returnDate.CustomFormat = "MM/dd/yyyy";

            // Setup DataGridViews
            SetupBooksToBorrowGrid();
            dataGridViewIssueBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIssueBooks.MultiSelect = false;
            dataGridViewIssueBooks.ReadOnly = true;

            // Setup book search textbox events
            bookIssue_bookTitle.TextChanged += bookIssue_bookTitle_TextChanged;
            bookIssue_bookTitle.KeyDown += bookIssue_bookTitle_KeyDown;

            // Setup book suggestion listbox events
            bookIssue_bookTitleSearch.KeyDown += bookIssue_bookTitleSearch_KeyDown;

            LoadAllBooks();
            LoadGradeSections();
            DisplayBookIssueData();
            
        }



        #region --- Load Data ---

        private void LoadAllBooks()
        {
            allBooks.Clear();

            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT id, book_title, author, available, image FROM Books", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int available = 0;
                    int.TryParse(reader["available"]?.ToString(), out available);

                    allBooks.Add((
                        reader["id"].ToString(),
                        reader["book_title"].ToString(),
                        reader["author"].ToString(),
                        available,
                        reader["image"]?.ToString()
                    ));
                }
                reader.Close();
            }
        }



        private void LoadGradeSections()
        {
            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT grade_level + '_' + section AS DisplayText FROM GradeSections WHERE is_active = 1 ORDER BY grade_level, section";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                gradeSectionTable = new DataTable();
                da.Fill(gradeSectionTable);
                bookIssue_gradeSection.DataSource = gradeSectionTable;
                bookIssue_gradeSection.DisplayMember = "DisplayText";
                bookIssue_gradeSection.SelectedIndex = -1;
            }
        }


        public void DisplayBookIssueData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT 
                        id, 
                        issue_id AS [Issue ID],
                        full_name AS [Name],
                        ID_no AS [ID No],
                        grade_section AS [Gr. | Section],
                        email AS [Email],
                        contact AS [Contact],
                        issue_date AS [Issue],
                        return_date AS [Return]
                        FROM issues
                        WHERE status = 'Issued'
                        AND date_delete IS NULL
                        ORDER BY issue_date DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewIssueBooks.DataSource = dt;

                    if (dataGridViewIssueBooks.Columns.Contains("id"))
                        dataGridViewIssueBooks.Columns["id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying issued books:\n" + ex.Message);
            }
        }



        private void SetupBooksToBorrowGrid()
        {
            if (dataGridViewBooksToBorrow.Columns.Count == 0)
            {
                dataGridViewBooksToBorrow.Columns.Add("BookId", "Book ID");
                dataGridViewBooksToBorrow.Columns.Add("BookTitle", "Book Title");
                dataGridViewBooksToBorrow.Columns.Add("Author", "Author");
                dataGridViewBooksToBorrow.Columns["BookId"].Visible = false;
                dataGridViewBooksToBorrow.AllowUserToAddRows = false;
                dataGridViewBooksToBorrow.ReadOnly = true;
                dataGridViewBooksToBorrow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        #endregion

        #region --- Book Search & Suggestion ---



        private void bookIssue_search_TextChanged(object sender, EventArgs e)
        {
            SearchIssuedBooks(bookIssue_search.Text.Trim());

            string keyword = bookIssue_search.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                DisplayBookIssueData();
            }
            else
            {
                SearchIssuedBooks(keyword);
            }

            var dashboardControl = Application.OpenForms["MainForm"].Controls.Find("dashboard", true).FirstOrDefault() as Dashboard;

            if (dashboardControl != null && !string.IsNullOrEmpty(keyword))
            {
                dashboardControl.AddActivity($"Searched issued books for {keyword}");
            }
        }




        private void bookIssue_bookTitle_TextChanged(object sender, EventArgs e)
        {
            if (isSelectingBook) return;
            if (bookIssue_bookTitleSearch.Focused) return;

            string keyword = bookIssue_bookTitle.Text.Trim();
            bookIssue_bookTitleSearch.Items.Clear();

            if (string.IsNullOrEmpty(keyword))
            {
                bookIssue_bookTitleSearch.Visible = false;
                return;
            }

            foreach (var book in allBooks
                .Where(b => b.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                bookIssue_bookTitleSearch.Items.Add(book.Title);
            }

            // Move ListBox to Main Form so it is not clipped
            Form parentForm = this.FindForm();

            if (parentForm != null)
            {
                Point textboxLocation = bookIssue_bookTitle.PointToScreen(Point.Empty);
                Point formLocation = parentForm.PointToClient(textboxLocation);

                bookIssue_bookTitleSearch.Parent = parentForm;

                int itemHeight = bookIssue_bookTitleSearch.ItemHeight;
                int visibleItems = Math.Min(bookIssue_bookTitleSearch.Items.Count, 6);
                int calculatedHeight = itemHeight * visibleItems + 4;

                int spaceBelow = parentForm.ClientSize.Height -
                                 (formLocation.Y + bookIssue_bookTitle.Height);

                bookIssue_bookTitleSearch.Width = bookIssue_bookTitle.Width;
                bookIssue_bookTitleSearch.Height = calculatedHeight;

                if (spaceBelow >= calculatedHeight)
                {
                    // Show below textbox
                    bookIssue_bookTitleSearch.Left = formLocation.X;
                    bookIssue_bookTitleSearch.Top = formLocation.Y + bookIssue_bookTitle.Height + 2;
                }
                else
                {
                    // Show above textbox
                    bookIssue_bookTitleSearch.Left = formLocation.X;
                    bookIssue_bookTitleSearch.Top = formLocation.Y - calculatedHeight - 2;
                }

                bookIssue_bookTitleSearch.BringToFront();
                bookIssue_bookTitleSearch.Visible = true;
            }

        }





        private void bookIssue_bookTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (bookIssue_bookTitleSearch.Visible && e.KeyCode == Keys.Down)
            {
                bookIssue_bookTitleSearch.Focus();
                if (bookIssue_bookTitleSearch.SelectedIndex == -1)
                    bookIssue_bookTitleSearch.SelectedIndex = 0;
                e.Handled = true;
            }
        }



        private void bookIssue_bookTitleSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && bookIssue_bookTitleSearch.SelectedItem != null)
            {
                SelectBook(bookIssue_bookTitleSearch.SelectedItem.ToString());
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                bookIssue_bookTitleSearch.Visible = false;
                bookIssue_bookTitle.Focus();
            }
        }



        private void bookIssue_bookTitleSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (bookIssue_bookTitleSearch.SelectedItem != null)
            {
                SelectBook(bookIssue_bookTitleSearch.SelectedItem.ToString());
            }
        }



        private void SelectBook(string title)
        {
            var book = allBooks.FirstOrDefault(b =>
                b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(book.Id)) return;

            selectedBookId = book.Id;
            bookIssue_bookTitle.Text = book.Title;
            bookIssue_author.Text = book.Author;
            bookIssue_available.Text = book.Copies.ToString();

            if (!string.IsNullOrEmpty(book.ImagePath) && System.IO.File.Exists(book.ImagePath))
            {
                bookIssue_picture.Image = Image.FromFile(book.ImagePath);
            }
            else
            {
                bookIssue_picture.Image = null;
            }

            bookIssue_bookTitleSearch.Visible = false;
        }


        #endregion

        #region --- Issue Processing ---




        private string GenerateIssueID()
        {
            string newID = "I-0001";

            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();

                    string q = @"SELECT MAX(CAST(SUBSTRING(issue_id, 3, 10) AS INT)) FROM issues WHERE issue_id LIKE 'I-%'";

                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            int lastNum = Convert.ToInt32(result);
                            newID = $"I-{(lastNum + 1):0000}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Issue ID:\n" + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open) connect.Close();
            }

            return newID;
        }



        private void LogActivity(string message)
        {
            try
            {
                using (SqlConnection logConn = new SqlConnection(connect.ConnectionString))
                {
                    logConn.Open();
                    string logQuery = "INSERT INTO ActivityLog(ActivityDate, ActivityDescription) VALUES (@date, @desc)";
                    
                    using (SqlCommand logCmd = new SqlCommand(logQuery, logConn))
                    {
                        logCmd.Parameters.AddWithValue("@date", DateTime.Now);
                        logCmd.Parameters.AddWithValue("@desc", message);
                        logCmd.ExecuteNonQuery();
                    }
                }
                if (FindForm() is MainForm mainForm)
                {
                    mainForm.AddDashboardActivity(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging activity:\n" + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open) connect.Close();
            }
        }



        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            LoadAllBooks();
            DisplayBookIssueData();
        }



        private void clearFields()
        {
            bookIssue_id.Text = GenerateIssueID();
            bookIssue_name.Clear();
            bookIssue_idNo.Clear();
            bookIssue_gradeSection.SelectedIndex = -1;
            bookIssue_contact.Clear();
            bookIssue_email.Clear();
            bookIssue_bookTitle.Clear();
            bookIssue_author.Clear();
            bookIssue_picture.Image = null;
            bookIssue_available.Clear();
            bookIssue_issueDate.Value = DateTime.Today;
            bookIssue_returnDate.Value = DateTime.Today.AddDays(7);
        }



        public void SearchIssuedBooks(string keyword)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(connect.ConnectionString))
                {
                    string q = @"SELECT issue_id, full_name, contact, email, ID_no, grade_section, issue_date, return_date, date_insert FROM issues WHERE status = 'ISSUED' AND date_delete IS NULL AND (issue_id LIKE @keyword OR full_name LIKE @keyword OR ID_no LIKE @keyword) ORDER BY date_insert DESC";

                    using (SqlCommand cmd = new SqlCommand(q, Conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridViewIssueBooks.DataSource = dt;
                        if (dataGridViewIssueBooks.Columns.Contains("id"))
                            dataGridViewIssueBooks.Columns["id"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching issued books:\n" + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open) connect.Close();
            }
        }



        private void booksToBorrow_addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedBookId))
            {
                MessageBox.Show("Select a valid book.");
                return;
            }

            foreach (DataGridViewRow row in dataGridViewBooksToBorrow.Rows)
            {
                if (row.Cells["BookId"].Value.ToString() == selectedBookId)
                {
                    MessageBox.Show("Book already added.");
                    return;
                }
            }

            dataGridViewBooksToBorrow.Rows.Add(
                selectedBookId,
                bookIssue_bookTitle.Text,
                bookIssue_author.Text
            );

            // Reset only selection, NOT logic
            selectedBookId = null;
            bookIssue_bookTitle.Clear();
            bookIssue_author.Clear();
            bookIssue_available.Clear();
        }



        private void booksToBorrow_deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooksToBorrow.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to remove.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Remove selected book from the list?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dataGridViewBooksToBorrow.Rows.RemoveAt(
                    dataGridViewBooksToBorrow.SelectedRows[0].Index);
            }
        }



        private void dataGridViewBooksToBorrow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridViewBooksToBorrow.SelectedRows.Count > 0)
            {
                dataGridViewBooksToBorrow.Rows.RemoveAt(dataGridViewBooksToBorrow.SelectedRows[0].Index);
            }
        }



        private void bookIssue_issueBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bookIssue_name.Text) ||
                string.IsNullOrWhiteSpace(bookIssue_idNo.Text))
            {
                MessageBox.Show("Borrower info required.");
                return;
            }

            if (dataGridViewBooksToBorrow.Rows.Count == 0)
            {
                MessageBox.Show("Add at least one book.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connect.ConnectionString))
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        string issueId = bookIssue_id.Text;

                        // INSERT ISSUE
                        using (SqlCommand cmd = new SqlCommand(
                            @"INSERT INTO Issues (issue_id, issue_date, return_date, status, full_name, ID_no, grade_section, email, contact) VALUES (@id, @issueDate, @returnDate, 'Issued', @name, @idno, @gs, @email, @contact)",con, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", issueId);
                            cmd.Parameters.AddWithValue("@issueDate", bookIssue_issueDate.Value);
                            cmd.Parameters.AddWithValue("@returnDate", bookIssue_returnDate.Value);
                            cmd.Parameters.AddWithValue("@name", bookIssue_name.Text.Trim());
                            cmd.Parameters.AddWithValue("@idno", bookIssue_idNo.Text.Trim());
                            cmd.Parameters.AddWithValue("@gs", bookIssue_gradeSection.Text);
                            cmd.Parameters.AddWithValue("@email", bookIssue_email.Text.Trim());
                            cmd.Parameters.AddWithValue("@contact", bookIssue_contact.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        // INSERT BOOKS
                        foreach (DataGridViewRow row in dataGridViewBooksToBorrow.Rows)
                        {
                            string bookId = row.Cells["BookId"].Value.ToString();

                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO issue_books(issue_id, book_id) VALUES(@iid, @bid)",
                                con, tx))
                            {
                                cmd.Parameters.AddWithValue("@iid", issueId);
                                cmd.Parameters.AddWithValue("@bid", bookId);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand(
                                @"UPDATE Books SET available = available - 1,
                                status = CASE 
                                    WHEN available - 1 = 0 THEN 'Not Available' 
                                    ELSE 'Available' 
                                END
                                WHERE id = @id AND available > 0",
                                con, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", bookId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();

                        MessageBox.Show("Books issued successfully!");

                        dataGridViewBooksToBorrow.Rows.Clear();
                        bookIssue_id.Text = GenerateIssueID();
                        DisplayBookIssueData();
                        LoadAllBooks();
                        clearFields();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Issue failed:\n" + ex.Message);
                    }
                }
            }
        }


        private void bookIssue_clearBtn_Click(object sender, EventArgs e)
        {
            bookIssue_id.Text = GenerateIssueID();
            bookIssue_name.Clear();
            bookIssue_idNo.Clear();
            bookIssue_gradeSection.SelectedIndex = -1;
            bookIssue_contact.Clear();
            bookIssue_email.Clear();
            bookIssue_available.Clear();
            dataGridViewBooksToBorrow.Rows.Clear();
            bookIssue_issueDate.Value = DateTime.Today;
            bookIssue_returnDate.Value = DateTime.Today.AddDays(5);
        }

        #endregion

        #region --- DataGridView Click Events ---



        private void dataGridViewIssueBooks_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewIssueBooks.Rows[e.RowIndex];

            bookIssue_id.Text = row.Cells["Issue ID"].Value.ToString();
            bookIssue_name.Text = row.Cells["Name"].Value.ToString();
            bookIssue_idNo.Text = row.Cells["ID No"].Value.ToString();
            bookIssue_gradeSection.Text = row.Cells["Gr. | Section"].Value.ToString();
            bookIssue_email.Text = row.Cells["Email"].Value.ToString();
            bookIssue_contact.Text = row.Cells["Contact"].Value.ToString();

            bookIssue_issueDate.Value = Convert.ToDateTime(row.Cells["Issue"].Value);
            bookIssue_returnDate.Value = Convert.ToDateTime(row.Cells["Return"].Value);

            LoadIssuedBooks(bookIssue_id.Text);
        }



        private void LoadIssuedBooks(string issueId)
        {
            dataGridViewBooksToBorrow.Rows.Clear();
            using (SqlConnection con = new SqlConnection(connect.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT b.id,b.book_title,b.author 
                                                        FROM issue_books ib 
                                                        INNER JOIN Books b ON b.id = ib.book_id 
                                                        WHERE ib.issue_id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", issueId);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        dataGridViewBooksToBorrow.Rows.Add(rdr["id"], rdr["book_title"], rdr["author"]);
                }
            }
        }

        #endregion
    }
}
