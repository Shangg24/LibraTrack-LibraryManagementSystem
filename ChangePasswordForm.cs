using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraTrack
{
    
    public partial class ChangePasswordForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");

        private int userId;
        public ChangePasswordForm(int id)
        {
            InitializeComponent();
            userId = id;

            resetPass_newPass.UseSystemPasswordChar = false;
            resetPass_confirmPass.UseSystemPasswordChar = false;
        }

        private void resetPass_submitBtn_Click(object sender, EventArgs e)
        {
            if (resetPass_newPass.Text != resetPass_confirmPass.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();

                string query = @"UPDATE users 
                         SET password=@pass, IsFirstLogin=0
                         WHERE id=@id";

                string hashedPassword = PasswordHelper.HashPassword(resetPass_newPass.Text);

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pass", hashedPassword);
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Password changed successfully!");

            this.Close();
        }

        private void resetPass_showPassNew_CheckedChanged(object sender, EventArgs e)
        {
            if (resetPass_showPassNew.Checked)
            {
                resetPass_newPass.PasswordChar = '\0';
                resetPass_confirmPass.PasswordChar = '\0';
            }
            else
            {
                resetPass_newPass.PasswordChar = '●'; // or '*'
                resetPass_confirmPass.PasswordChar = '●';
            }
        }

        private void resetPass_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
