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
            this.Activated += LoginForm_Activated;

            this.Load += LoginForm_Load;
        }


        private void LoginForm_Activated(object sender, EventArgs e)
        {
            login_username.Clear();
            login_password.Clear();
            login_username.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            login_username.Clear();
            login_password.Clear();
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
                    String selectData = @"SELECT id, role, status, IsFirstLogin, password FROM users WHERE username COLLATE SQL_Latin1_General_CP1_CS_AS = @username";

                    string hashedPassword = PasswordHelper.HashPassword(login_password.Text.Trim());

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                        //cmd.Parameters.AddWithValue("@password", hashedPassword);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count >= 1)
                        {
                            string storedPassword = table.Rows[0]["password"].ToString().Trim();
                            string inputPassword = PasswordHelper.HashPassword(login_password.Text.Trim());

                            if (storedPassword != inputPassword)
                            {
                                MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string role = table.Rows[0]["role"].ToString().Trim();
                            string status = table.Rows[0]["status"].ToString().Trim();

                            int userId = Convert.ToInt32(table.Rows[0]["id"]);
                            bool isFirstLogin = Convert.ToBoolean(table.Rows[0]["IsFirstLogin"]);

                            // ✅ Role check
                            if (!role.Equals("Admin", StringComparison.OrdinalIgnoreCase) &&
                                !role.Equals("IT", StringComparison.OrdinalIgnoreCase) &&
                                !role.Equals("IT Staff", StringComparison.OrdinalIgnoreCase) &&
                                !role.Equals("Librarian", StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Unknown role. Please contact IT support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // ✅ Only Librarians need approval
                            if (role.Equals("Librarian", StringComparison.OrdinalIgnoreCase) &&
                            !status.Trim().Equals("Approved", StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Your account has not been approved yet.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            MessageBox.Show("Login Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 🔥 FIRST LOGIN CHECK
                            if (isFirstLogin)
                            {
                                ChangePasswordForm cp = new ChangePasswordForm(userId);
                                cp.ShowDialog();

                                // After password change, force re-login
                                MessageBox.Show("Please login again using your new password.");
                                return;
                            }

                            // ✅ Normal redirect
                            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                                role.Equals("IT", StringComparison.OrdinalIgnoreCase) ||
                                role.Equals("IT Staff", StringComparison.OrdinalIgnoreCase))
                            {
                                AdminPanel aForm = new AdminPanel();
                                aForm.Show();
                            }
                            else if (role.Equals("Librarian", StringComparison.OrdinalIgnoreCase))
                            {
                                MainForm mForm = new MainForm();
                                mForm.Show();
                            }

                            this.Hide(); // hide login form
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            login_username.Clear();
                            login_password.Clear();

                            login_username.Focus();
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
