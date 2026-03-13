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
using System.Configuration;

namespace LibraTrack
{
    public partial class StudentPortalAccounts : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");
        public StudentPortalAccounts()
        {
            InitializeComponent();

            spa_userName.ReadOnly = true;
            dataGridViewStudentsPortal.RowPrePaint += dataGridViewStudentsPortal_RowPrePaint;
            spa_password.ReadOnly = true;
        }

        private void stp_create_btn_Click(object sender, EventArgs e)
        {
            if (spa_studentID.Text == "" ||
        spa_fullName.Text == "" ||
        spa_email.Text == "" ||
        spa_contact.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();

                // 1️⃣ Check duplicate Student ID
                string checkQuery = "SELECT COUNT(*) FROM Students WHERE ID_no = @id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@id", spa_studentID.Text);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Student ID already exists.");
                    return;
                }

                // 2️⃣ Insert student
                string insertQuery = @"INSERT INTO Students 
        (ID_no, username, full_name, email, contact, passwordHash, IsFirstLogin, IsActive)
        VALUES
        (@id, @username, @name, @email, @contact, @pass, 1, 1)";

                SqlCommand cmd = new SqlCommand(insertQuery, conn);

                cmd.Parameters.AddWithValue("@id", spa_studentID.Text);
                cmd.Parameters.AddWithValue("@username", spa_studentID.Text); // SAME AS ID
                cmd.Parameters.AddWithValue("@name", spa_fullName.Text);
                cmd.Parameters.AddWithValue("@email", spa_email.Text);
                cmd.Parameters.AddWithValue("@contact", spa_contact.Text);
                cmd.Parameters.AddWithValue("@pass", spa_studentID.Text); // we improve this next

                cmd.ExecuteNonQuery();

                MessageBox.Show("Student account created successfully!\n\n" + "Username: " + spa_studentID.Text + "\n" + "Temporary Password: " + spa_studentID.Text + "\n\n" + "The student must change the password on first login.", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStudents();
                ClearFields();
            }
        }

        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                string query = @"SELECT ID_no, full_name, email,contact,IsActive FROM Students";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewStudentsPortal.DataSource = dt;

                foreach (DataGridViewRow row in dataGridViewStudentsPortal.Rows)
                {
                    if (row.Cells["IsActive"].Value != null)
                    {
                        bool isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);
                        
                        if (isActive)
                        {
                            row.DefaultCellStyle.BackColor = Color.Honeydew;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.MistyRose;
                        }
                    }
                }
            }
        }

        public void refreshData()
        {
            LoadStudents(); // or whatever method loads the grid
        }


        private void spa_clear_btn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void spa_studentID_TextChanged(object sender, EventArgs e)
        {
            spa_userName.Text = spa_studentID.Text;
        }

        private void ClearFields()
        {
            spa_studentID.Text = "";
            spa_fullName.Text = "";
            spa_email.Text = "";
            spa_contact.Text = "";
            spa_userName.Text = "";
            spa_password.Text = "";
        }

        private void dataGridViewStudentsPortal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewStudentsPortal.Rows[e.RowIndex];

                spa_studentID.Text = row.Cells["ID_no"].Value.ToString();
                spa_fullName.Text = row.Cells["full_name"].Value.ToString();
                spa_email.Text = row.Cells["email"].Value.ToString();
                spa_contact.Text = row.Cells["contact"].Value.ToString();
                spa_userName.Text = row.Cells["ID_no"].Value.ToString(); // username is same as ID
            }
        }


        private void dataGridViewStudentsPortal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridViewStudentsPortal.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    dataGridViewStudentsPortal.ClearSelection();
                    dataGridViewStudentsPortal.Rows[hit.RowIndex].Selected = true;
                    dataGridViewStudentsPortal.CurrentCell = dataGridViewStudentsPortal.Rows[hit.RowIndex].Cells[0];
                }
            }
        }


        private void spa_update_btn_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();

            string query = @"UPDATE Students SET full_name = @name, email = @email, contact = @contact WHERE ID_no = @id";

            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@id", spa_studentID.Text.Trim());
                cmd.Parameters.AddWithValue("@name", spa_fullName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", spa_email.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", spa_contact.Text.Trim());
                cmd.Parameters.AddWithValue("@username", spa_userName.Text.Trim());

                cmd.ExecuteNonQuery();
            }

            connect.Close();

            MessageBox.Show("Student updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadStudents();
            ClearFields();
        }

        private void spa_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = spa_search.Text.Trim();

            if (connect.State == ConnectionState.Closed)
                connect.Open();

            string query = @"SELECT ID_no, full_name, email, contact, username
                     FROM Students
                     WHERE ID_no LIKE @k
                        OR full_name LIKE @k
                        OR email LIKE @k
                        OR username LIKE @k";

            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@k", "%" + keyword + "%");

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                dataGridViewStudentsPortal.DataSource = dt;
            }

            connect.Close();
        }

        private void dataGridViewStudentsPortal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewStudentsPortal.Rows[e.RowIndex];

                spa_studentID.Text = row.Cells["ID_no"].Value.ToString();
                spa_fullName.Text = row.Cells["full_name"].Value.ToString();
                spa_email.Text = row.Cells["email"].Value.ToString();
                spa_contact.Text = row.Cells["contact"].Value.ToString();
                spa_userName.Text = row.Cells["ID_no"].Value.ToString(); // username is same as ID
                spa_password.Text = row.Cells["ID_no"].Value.ToString();
            }
        }


        private void dataGridViewStudentsPortal_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dataGridViewStudentsPortal.Rows[e.RowIndex].Cells["IsActive"].Value != null)
            {
                bool isActive = Convert.ToBoolean(
                    dataGridViewStudentsPortal.Rows[e.RowIndex].Cells["IsActive"].Value
                );

                if (isActive)
                {
                    // ACTIVE → Light Green
                    dataGridViewStudentsPortal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    // INACTIVE → Light Red
                    dataGridViewStudentsPortal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudentsPortal.SelectedRows.Count == 0)
                return;

            string studentID = dataGridViewStudentsPortal.SelectedRows[0].Cells["ID_no"].Value.ToString();

            if (connect.State == ConnectionState.Closed)
                connect.Open();

            string query = @"UPDATE Students 
                     SET passwordHash = @pass, IsFirstLogin = 1 
                     WHERE ID_no = @id";

            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@id", studentID);
                cmd.Parameters.AddWithValue("@pass", studentID);
                cmd.ExecuteNonQuery();
            }

            connect.Close();

            MessageBox.Show("Password reset successfully.\nDefault password is the Student ID.");
        }

        private void deactivateAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudentsPortal.SelectedRows.Count == 0)
                return;

            string studentID = dataGridViewStudentsPortal.SelectedRows[0].Cells["ID_no"].Value.ToString();

            if (connect.State == ConnectionState.Closed)
                connect.Open();

            string query = "UPDATE Students SET IsActive = 0 WHERE ID_no = @id";

            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@id", studentID);
                cmd.ExecuteNonQuery();
            }

            connect.Close();

            MessageBox.Show("Student account deactivated.");

            LoadStudents();
        }
    }
}
