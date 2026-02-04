using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraTrack
{
    public partial class AdminPanelGradeSection : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");

        private int selectedGradeSectionId = -1;

        public AdminPanelGradeSection()
        {
            InitializeComponent();
            LoadDepartments();

            dataGridViewGradeSection.CellClick += dataGridViewGradeSection_CellClick;
        }


        public void refreshData()
        {
            LoadGradeSections(); // or whatever method loads the grid
        }

        private void LoadDepartments()
        {
            gradeSection_department.Items.Clear();
            gradeSection_department.Items.Add("Elementary");
            gradeSection_department.Items.Add("Junior High School");
            gradeSection_department.Items.Add("Senior High School");
            gradeSection_department.Items.Add("College");

            gradeSection_department.SelectedIndex = 0;
        }


        private void LoadGradeSections()
        {
            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();
                string query = "SELECT id, department, grade_level, section FROM GradeSections WHERE is_active = 1 ORDER BY grade_level, section";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewGradeSection.DataSource = dt;

                dataGridViewGradeSection.Columns["id"].Visible = false;
            }
        }


        private void gradeSection_addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gradeSection_gradeLevel.Text) ||
                string.IsNullOrWhiteSpace(gradeSection_section.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO GradeSections 
                         (department, grade_level, section)
                         VALUES (@dept, @grade, @section)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dept", gradeSection_department.Text);
                        cmd.Parameters.AddWithValue("@grade", gradeSection_gradeLevel.Text.Trim());
                        cmd.Parameters.AddWithValue("@section", gradeSection_section.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Grade & Section added.");
                LoadGradeSections();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void dataGridViewGradeSection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewGradeSection.Rows[e.RowIndex];

                selectedGradeSectionId = Convert.ToInt32(row.Cells[0].Value);

                gradeSection_department.Text = row.Cells["department"].Value.ToString();
                gradeSection_gradeLevel.Text = row.Cells["grade_level"].Value.ToString();
                gradeSection_section.Text = row.Cells["section"].Value.ToString();
            }
        }


        private void gradeSection_updateBtn_Click(object sender, EventArgs e)
        {
            if (selectedGradeSectionId == -1)
            {
                MessageBox.Show("Please select a grade section to update.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();

                string query = @"UPDATE GradeSections 
                         SET department=@dept, grade_level=@grade, section=@section
                         WHERE id=@id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dept", gradeSection_department.Text);
                    cmd.Parameters.AddWithValue("@grade", gradeSection_gradeLevel.Text);
                    cmd.Parameters.AddWithValue("@section", gradeSection_section.Text);
                    cmd.Parameters.AddWithValue("@id", selectedGradeSectionId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Updated successfully.");
            LoadGradeSections();
            ClearFields();
        }


        private void gradeSection_deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedGradeSectionId == -1)
            {
                MessageBox.Show("Please select a grade section to delete.");
                return;
            }

            DialogResult res = MessageBox.Show("Delete this record?", "Confirm", MessageBoxButtons.YesNo);
            if (res != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM GradeSections WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", selectedGradeSectionId);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadGradeSections();
            ClearFields();
        }


        private void ClearFields()
        {
            selectedGradeSectionId = -1;
            gradeSection_gradeLevel.Clear();
            gradeSection_section.Clear();
            gradeSection_department.SelectedIndex = 0;
        }
    }
}
