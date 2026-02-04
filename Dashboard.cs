using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraTrack
{
    public partial class Dashboard : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");

        public void AddActivity(string message, bool newestOnTop = true)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => AddActivity(message, newestOnTop)));
                return;
            }

            try
            {
                Label lbl = new Label
                {
                    AutoSize = true,
                    Text = message,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    Margin = new Padding(6)
                };
                if (recentActivityPanel == null) return;

                recentActivityPanel.Controls.Add(lbl);

                if (newestOnTop)
                    recentActivityPanel.Controls.SetChildIndex(lbl, 0);
            }
            catch { }
        }


        public Dashboard()
        {
            InitializeComponent();
        }

        private Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            Graphics graphics = Graphics.FromImage(bmp);

            ColorMatrix matrix = new ColorMatrix();
            matrix.Matrix33 = opacity; // transparency level

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            graphics.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);

            graphics.Dispose();
            return bmp;
        }

        public void LoadActivityFromDatabase()
        {
            try
            {
                if (recentActivityPanel == null) return;

                using (SqlCommand cmd =
                    new SqlCommand("SELECT TOP 30 ActivityDate, ActivityDescription FROM ActivityLog ORDER BY ActivityDate DESC", connect))
                {
                    connect.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string date = Convert.ToDateTime(reader["ActivityDate"])
                                          .ToString("MM/dd/yyyy HH:mm");
                        string desc = reader["ActivityDescription"].ToString();

                        AddActivity($"{date} - {desc}", false); // <-- IMPORTANT FIX
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading activity: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }



        public void refreshData() //TO REFRESH THE # OF AVAILABLE, ISSUED AND RETURNED BOOKS REAL-TIME
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayAB();
            displayIB();
            displayRB();
        }
        private void displayAB()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string selectData = "SELECT COUNT(id) FROM books WHERE available > 0 AND date_delete IS NULL;";


                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();
                    int totalAvailable = Convert.ToInt32(result);

                    if (dashboard_AB != null)
                        dashboard_AB.Text = totalAvailable.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void displayIB()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string selectData = "SELECT COUNT(*) FROM issues WHERE status = 'Issued' AND date_delete IS NULL;";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    int tempIB = (int)cmd.ExecuteScalar();

                    if (dashboard_IB != null)
                    {
                        dashboard_IB.Text = tempIB.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }


        public void displayRB()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string selectData =
                    "SELECT COUNT(issue_id) FROM issues WHERE date_delete IS NULL;";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    int totalIssues = (int)cmd.ExecuteScalar();

                    if (dashboard_RB != null)
                    {
                        dashboard_RB.Text = totalIssues.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.ColumnCount == 0) return;

            int cardWidth = tableLayoutPanel1.GetColumnWidths()[0];
            tableLayoutPanel1.Height = cardWidth + 20; // + margin
        }


    }
}
