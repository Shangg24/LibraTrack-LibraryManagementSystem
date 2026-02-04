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
    public partial class LoginForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = loginBtn;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            RegisterForm rForm = new RegisterForm();
            rForm.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0': '*';
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    // username + password, role + status
                    String selectData = "SELECT role, status FROM users WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", login_password.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count >= 1)
                        {
                            string role = table.Rows[0]["role"].ToString().Trim();
                            string status = table.Rows[0]["status"].ToString().Trim();

                            // ✅ Role check
                            if (!role.Equals("Admin", StringComparison.OrdinalIgnoreCase) &&
                                !role.Equals("IT", StringComparison.OrdinalIgnoreCase) &&
                                !role.Equals("Librarian", StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Unknown role. Please contact IT support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // ✅ Only Librarians need approval
                            if (role.Equals("Librarian", StringComparison.OrdinalIgnoreCase) &&
                                !status.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Your account has not been approved yet.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            MessageBox.Show("Login Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // ✅ Redirect based on role
                            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                                role.Equals("IT", StringComparison.OrdinalIgnoreCase))
                            {
                                AdminPanel aForm = new AdminPanel();
                                aForm.Show();
                            }
                            else if (role.Equals("Librarian", StringComparison.OrdinalIgnoreCase))
                            {
                                MainForm mForm = new MainForm(); // Dashboard
                                mForm.Show();
                            }

                            this.Hide(); // hide login form
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting Database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }


    }
}
