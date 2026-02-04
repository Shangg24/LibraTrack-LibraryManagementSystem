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
using System.IO;

namespace LibraTrack
{
    public partial class AddBooks : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");
        public AddBooks()
        {
            InitializeComponent();

            displayBooks();

            addBooks_published.Format = DateTimePickerFormat.Custom;
            addBooks_published.CustomFormat = "MM/dd/yyyy";

            dataGridViewAddBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAddBooks.MultiSelect = false;
            dataGridViewAddBooks.ReadOnly = true;
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayBooks();
        }

        private String imagePath;
        private void addBooks_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    addBooks_picture.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addBooks_addBtn_Click(object sender, EventArgs e)
        {
            if (addBooks_picture.Image == null
                || string.IsNullOrWhiteSpace(addBooks_bookTitle.Text)
                || string.IsNullOrWhiteSpace(addBooks_author.Text)
                || string.IsNullOrWhiteSpace(addBooks_status.Text))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();


                // ---------------------------------------------------------
                // 1. Generate new BookID (B-0001)
                // ---------------------------------------------------------
                string lastId = "B-0000";

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 id FROM Books ORDER BY id DESC", connect))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        lastId = result.ToString();
                }

                string numeric = lastId.Replace("B-", "");
                int num = 0;
                int.TryParse(numeric, out num);
                string newBookId = $"B-{(num + 1):0000}";


                // ---------------------------------------------------------
                // 2. Save Image
                // ---------------------------------------------------------
                DateTime today = DateTime.Today;

                string folderPath = @"C:\Users\Administrator\source\repos\LibraTrack\LibraTrack\Books_Directory";
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                // Prevent invalid filename characters
                string safeTitle = string.Join("_", addBooks_bookTitle.Text.Split(Path.GetInvalidFileNameChars()));

                string fileName = $"{safeTitle}_{today:yyyyMMdd}.jpg";
                string imagePath = Path.Combine(folderPath, fileName);

                // Save image
                File.Copy(addBooks_picture.ImageLocation, imagePath, true);


                // ---------------------------------------------------------
                // 3. Insert into BOOKS
                // ---------------------------------------------------------
                string insertBook = @"INSERT INTO Books (id, category, book_title, author, ISBN, shelf, published_date, status, image, Copies, available, date_insert) VALUES (@id, @category, @title, @author, @isbn, @shelf, @pub, @status, @image, @copies, @copies, @date)";

                using (SqlCommand cmd = new SqlCommand(insertBook, connect))
                {
                    cmd.Parameters.AddWithValue("@id", newBookId);
                    cmd.Parameters.AddWithValue("@category", addBooks_category.Text.Trim());
                    cmd.Parameters.AddWithValue("@title", addBooks_bookTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", addBooks_author.Text.Trim());
                    cmd.Parameters.AddWithValue("@isbn", addBooks_isbn.Text.Trim());
                    cmd.Parameters.AddWithValue("@shelf", addBooks_shelf.Text.Trim());
                    cmd.Parameters.AddWithValue("@pub", addBooks_published.Value);
                    cmd.Parameters.AddWithValue("@status", addBooks_status.Text.Trim());
                    cmd.Parameters.AddWithValue("@image", imagePath);
                    cmd.Parameters.AddWithValue("@copies", (int)numericUpDownCopies.Value);
                    cmd.Parameters.AddWithValue("@date", today);

                    cmd.ExecuteNonQuery();
                }


                string updateAvailable = "UPDATE Books SET available = Copies WHERE id = @id";
                using (SqlCommand cmd2 = new SqlCommand(updateAvailable, connect))
                {
                    cmd2.Parameters.AddWithValue("@id", newBookId);
                    cmd2.ExecuteNonQuery();
                }


                // Update status based on availability
                string updateStatus = @"UPDATE Books SET status = CASE WHEN available = 0 THEN 'Not Available' ELSE 'Available' END WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(updateStatus, connect))
                {
                    cmd.Parameters.AddWithValue("@id", newBookId);
                    cmd.ExecuteNonQuery();
                }



                // ---------------------------------------------------------
                // 4. Insert Book Copies
                // ---------------------------------------------------------
                // 4. Insert Book Copies
                int totalCopies = (int)numericUpDownCopies.Value;

                for (int i = 1; i <= totalCopies; i++)
                {
                    string numberOnly = newBookId.Replace("B-", "");
                    string copyID = $"BC-{numberOnly}-{i:00}";

                    string insertCopy = @"INSERT INTO BookCopies (CopyID, BookID, CopyNumber, Status)
                          VALUES (@cid, @bid, @num, 'Available')";

                    using (SqlCommand cmdCopy = new SqlCommand(insertCopy, connect))
                    {
                        cmdCopy.Parameters.AddWithValue("@cid", copyID);
                        cmdCopy.Parameters.AddWithValue("@bid", newBookId);
                        cmdCopy.Parameters.AddWithValue("@num", i);
                        cmdCopy.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Book Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                LogActivity($"Added book: {addBooks_bookTitle.Text} by {addBooks_author.Text}");

                clearFields();
                displayBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }


        public void clearFields()
        {
            addBooks_category.Text = "";
            addBooks_bookTitle.Text = "";
            addBooks_author.Text = "";
            addBooks_isbn.Text = "";
            addBooks_shelf.Text = "";
            addBooks_picture.Image = null;
            addBooks_published.Value = DateTime.Today;
            addBooks_status.SelectedIndex = -1;

            numericUpDownCopies.Value = numericUpDownCopies.Minimum;
        }
        public void displayBooks()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string query = "SELECT id, category, book_title, author, copies, ISBN, shelf, published_date, image, status FROM books WHERE date_delete IS NULL";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewAddBooks.DataSource = dt;

                if (dataGridViewAddBooks.Columns["Copies"] != null)
                    dataGridViewAddBooks.Columns["Copies"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying books: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }


        public void SearchAddBooks(string keyword)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string query = @"SELECT id, category, book_title, author, copies, ISBN, shelf, published_date, image, status FROM books WHERE date_delete IS NULL AND (category LIKE @keyword OR book_title LIKE @keyword OR author LIKE @keyword OR copies LIKE @keyword OR ISBN LIKE @keyword OR shelf LIKE @keyword OR published_date LIKE @keyword OR status LIKE @keyword)";


                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewAddBooks.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private string bookID = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewAddBooks.Rows[e.RowIndex];

                bookID = row.Cells["id"].Value?.ToString();

                addBooks_category.Text = row.Cells["category"].Value?.ToString();
                addBooks_bookTitle.Text = row.Cells["book_title"].Value?.ToString();
                addBooks_author.Text = row.Cells["author"].Value?.ToString();
                addBooks_isbn.Text = row.Cells["ISBN"].Value?.ToString();
                addBooks_shelf.Text = row.Cells["shelf"].Value?.ToString();
                addBooks_published.Value = Convert.ToDateTime(row.Cells["published_date"].Value);
                addBooks_status.Text = row.Cells["status"].Value?.ToString();


                string imagePath = row.Cells["image"].Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    using (var stream = new MemoryStream(File.ReadAllBytes(imagePath)))
                    {
                        addBooks_picture.Image = Image.FromStream(stream);
                    }

                    addBooks_picture.Tag = imagePath; // store the path safely
                }
                else
                {
                    addBooks_picture.Image = null;
                    addBooks_picture.Tag = null;
                }

                int copies = 0;

                if (int.TryParse(row.Cells["Copies"].Value?.ToString(), out copies))
                {
                    if (copies < numericUpDownCopies.Minimum)
                        copies = (int)numericUpDownCopies.Minimum;

                    if (copies > numericUpDownCopies.Maximum)
                        copies = (int)numericUpDownCopies.Maximum;

                    numericUpDownCopies.Value = copies;
                }
                else
                {
                    numericUpDownCopies.Value = numericUpDownCopies.Minimum;
                }


                addBooks_status.Text = row.Cells["status"].Value.ToString();
            }
        }


        private void dataGridViewAddBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewAddBooks.Columns[e.ColumnIndex].Name == "status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();

                    if (status == "Available")
                    {
                        e.CellStyle.BackColor = Color.MediumSpringGreen;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else if (status == "Not Available")
                    {
                        e.CellStyle.BackColor = Color.IndianRed;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }



        private void addBooks_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addBooks_updateBtn_Click(object sender, EventArgs e)
        {
            if (addBooks_picture.Image == null
                || string.IsNullOrWhiteSpace(addBooks_bookTitle.Text)
                || string.IsNullOrWhiteSpace(addBooks_author.Text)
                || string.IsNullOrWhiteSpace(addBooks_status.Text))
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    DialogResult check = MessageBox.Show("Are you sure you want to UPDATE book ID: " + bookID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (check == DialogResult.Yes)
                    {
                        try
                        {
                            connect.Open();
                            DateTime today = DateTime.Today;
                            string updateData = "UPDATE books SET category = @category, book_title = @bookTitle, author = @Author, copies = @copies, ISBN = @isbn, shelf = @shelf, published_date = @Published, image = @Image, date_update = @dateUpdate WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@category", addBooks_category.Text.Trim());
                                cmd.Parameters.AddWithValue("@bookTitle", addBooks_bookTitle.Text.Trim());
                                cmd.Parameters.AddWithValue("@Author", addBooks_author.Text.Trim());
                                cmd.Parameters.AddWithValue("@copies", (int)numericUpDownCopies.Value);
                                cmd.Parameters.AddWithValue("@isbn", addBooks_isbn.Text.Trim());
                                cmd.Parameters.AddWithValue("@shelf", addBooks_shelf.Text.Trim());
                                cmd.Parameters.AddWithValue("@Published", addBooks_published.Value);
                                cmd.Parameters.AddWithValue("@Image", addBooks_picture.Tag ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@dateUpdate", today);
                                cmd.Parameters.AddWithValue("@id", bookID);

                                cmd.ExecuteNonQuery(); 
                                displayBooks();
                                refreshData();

                                string logQuery = "INSERT INTO ActivityLog (ActivityDate, ActivityDescription) VALUES (@date, @desc)";

                                using (SqlConnection logConn = new SqlConnection(connect.ConnectionString))
                                {
                                    logConn.Open();
                                    using (SqlCommand logCmd = new SqlCommand(logQuery, logConn))
                                    {
                                        logCmd.Parameters.AddWithValue("@date", DateTime.Now);
                                        logCmd.Parameters.AddWithValue("@desc", "Updated new book: " + addBooks_bookTitle.Text);
                                        logCmd.ExecuteNonQuery();
                                    }
                                }

                                MessageBox.Show("Update successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LogActivity($"Updated book: {addBooks_bookTitle.Text} by {addBooks_author.Text}");


                                clearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cancelled.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void addBooks_deleteBtn_Click(object sender, EventArgs e)
        {
            if (addBooks_picture.Image == null
                || string.IsNullOrWhiteSpace(addBooks_bookTitle.Text)
                || string.IsNullOrWhiteSpace(addBooks_author.Text)
                || string.IsNullOrWhiteSpace(addBooks_status.Text))
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    DialogResult check = MessageBox.Show("Are you sure you want to DELETE book ID: " + bookID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (check == DialogResult.Yes)
                    {
                        try
                        {
                            connect.Open();
                            DateTime today = DateTime.Today;
                            string updateData = "UPDATE books SET date_delete = @dateDelete WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@dateDelete", today);
                                cmd.Parameters.AddWithValue("@id", bookID);

                                cmd.ExecuteNonQuery();
                                displayBooks();

                                string logQuery = "INSERT INTO ActivityLog (ActivityDate, ActivityDescription) VALUES (@date, @desc)";

                                using (SqlConnection logConn = new SqlConnection(connect.ConnectionString))
                                {
                                    logConn.Open();
                                    using (SqlCommand logCmd = new SqlCommand(logQuery, logConn))
                                    {
                                        logCmd.Parameters.AddWithValue("@date", DateTime.Now);
                                        logCmd.Parameters.AddWithValue("@desc", "Deleted new book: " + addBooks_bookTitle.Text);
                                        logCmd.ExecuteNonQuery();
                                    }
                                }

                                MessageBox.Show("Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LogActivity($"Deleted book: {addBooks_bookTitle.Text} by {addBooks_author.Text}");

                                clearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cancelled.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void addBooks_search_TextChanged(object sender, EventArgs e)
        {
            SearchAddBooks(addBooks_search.Text.Trim());

            string keyword = addBooks_search.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                displayBooks();
            }
            else
            {
                SearchAddBooks(keyword);
            }
            var dashboardControl = Application.OpenForms["MainForm"].Controls.Find("dashboard1", true).FirstOrDefault() as Dashboard;

            if (dashboardControl != null && !string.IsNullOrEmpty(keyword))
            {
                dashboardControl.AddActivity($"Searched issued books for: {keyword}");
            }

        }


        private string GenerateBookID()
        {
            string lastId = "B-0000";
            string query = "SELECT TOP 1 id FROM books ORDER BY id DESC";

            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        lastId = result.ToString();
                    }
                }
            }

            // Ensure the format is valid before parsing
            string numericPart = lastId.Replace("B-", "");

            if (!int.TryParse(numericPart, out int number))
            {
                number = 0; // fallback instead of crashing
            }

            number++;
            return $"B-{number:0000}";
        }


        private string GenerateCopyID(string bookId, int copyNumber)
        {
            string numeric = bookId.Replace("B-", "");   // extract 0001
            return $"BC-{numeric}-{copyNumber:00}";
        }



        private void InsertActivityLog(string activity)
        {
            using (SqlConnection logConn = new SqlConnection(connect.ConnectionString))
            {
                logConn.Open();
                string logQuery = "INSERT INTO ActivityLog (ActivityDate, ActivityDescription) VALUES (@date, @desc)";
                using (SqlCommand logCmd = new SqlCommand(logQuery, logConn))
                {
                    logCmd.Parameters.AddWithValue("@date", DateTime.Now);
                    logCmd.Parameters.AddWithValue("@desc", activity);
                    logCmd.ExecuteNonQuery();
                }
            }
        }


        private string GenerateNextCopyId(string bookId)
        {
            // Example: BC-B0001-01, BC-B0001-02 …
            string query = "SELECT TOP 1 CopyNumber FROM BookCopies WHERE book_id = @id ORDER BY CopyNumber DESC";
            int lastNum = 0;

            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@id", bookId);
                connect.Open();
                object result = cmd.ExecuteScalar();
                connect.Close();

                if (result != null)
                    lastNum = Convert.ToInt32(result);
            }

            int next = lastNum + 1;

            return $"{bookId}-{next:00}";
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

    }
}

 


