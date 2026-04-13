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
using System.Windows.Forms.DataVisualization.Charting;

namespace LibraTrack
{
    public partial class AnalyticsUserControl : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");

        public AnalyticsUserControl()
        {
            InitializeComponent();
        }



        private void AnalyticsUserControl_Load(object sender, EventArgs e)
        {
            LoadSummary();
            LoadTopBooksChart();
        }


        private void LoadSummary()
        {
            try
            {
                connect.Open();

                lblTotalBooks.Text = "Total Books: " + new SqlCommand("SELECT COUNT(*) FROM books", connect).ExecuteScalar();
                lblBorrowed.Text = "Borrowed: " + new SqlCommand("SELECT COUNT(*) FROM issue_books WHERE status = 'Borrowed'", connect).ExecuteScalar();
                lblOverdue.Text = "Overdue: " + new SqlCommand(@"SELECT COUNT(*) FROM issues WHERE status = 'Issued' AND return_date < GETDATE()", connect).ExecuteScalar();
                lblUsers.Text = "Users: " + new SqlCommand("SELECT COUNT(*) FROM users", connect).ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }


        private void LoadTopBooksChart()
        {
            // Clear chart
            chartTopBooks.Series.Clear();
            chartTopBooks.Legends.Clear();
            chartTopBooks.Titles.Clear();

            var chartArea = chartTopBooks.ChartAreas[0];

            // Layout (clean + balanced)
            chartArea.Position = new ElementPosition(10, 5, 85, 90);
            chartArea.InnerPlotPosition = new ElementPosition(20, 5, 75, 85);

            // Background
            chartArea.BackColor = Color.White;

            // Axis titles
            chartArea.AxisX.Title = "Books";
            chartArea.AxisY.Title = "Number of Borrows";

            // Axis styling
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.Enabled = false;

            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            chartArea.AxisY.LabelStyle.Angle = 0;

            chartArea.AxisY.Interval = 1;
            chartArea.AxisX.Interval = 1;

            chartArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartArea.AxisY.IsLabelAutoFit = false;

            // ✅ DO NOT reverse anything (this was your problem)
            // chartArea.AxisY.IsReversed = false;
            // chartArea.AxisX.IsReversed = false;

            // Create series
            Series series = new Series("Top Books");
            series.ChartType = SeriesChartType.Bar;
            series.Color = Color.Maroon;
            series.IsValueShownAsLabel = true;
            series.IsXValueIndexed = true; // keeps order

            try
            {
                connect.Open();

                SqlCommand cmd = new SqlCommand(@"
            SELECT TOP 5 b.book_title, COUNT(*) AS total
            FROM issue_books i
            INNER JOIN books b ON i.book_id = b.id
            GROUP BY b.book_title
            ORDER BY total DESC", connect);

                SqlDataReader reader = cmd.ExecuteReader();

                List<(string title, int total)> data = new List<(string, int)>();

                while (reader.Read())
                {
                    string fullTitle = reader["book_title"].ToString();
                    int total = Convert.ToInt32(reader["total"]);

                    data.Add((fullTitle, total));
                }

                // ✅ Reverse the list so highest appears on top
                data.Reverse();

                foreach (var item in data)
                {
                    string displayTitle = item.title;

                    if (displayTitle.Length > 40)
                    {
                        displayTitle = displayTitle.Substring(0, 37) + "...";
                    }

                    displayTitle = WrapText(displayTitle, 20);

                    int pointIndex = series.Points.AddXY(displayTitle, item.total);

                    series.Points[pointIndex].ToolTip = item.title;
                }

                chartTopBooks.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }


        private string WrapText(string text, int maxLineLength)
        {
            var words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            int currentLength = 0;

            foreach (var word in words)
            {
                if (currentLength + word.Length > maxLineLength)
                {
                    sb.Append("\n");
                    currentLength = 0;
                }

                sb.Append(word + " ");
                currentLength += word.Length + 1;
            }

            return sb.ToString().Trim();
        }



        private DataTable GetMonthlyBorrowData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                b.book_title,
                YEAR(i.date_insert) AS Year,
                MONTH(i.date_insert) AS Month,
                COUNT(*) AS TotalBorrowed
            FROM issue_books i
            INNER JOIN books b ON i.book_id = b.id
            GROUP BY b.book_title, YEAR(i.date_insert), MONTH(i.date_insert)
            ORDER BY b.book_title, Year, Month";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }


        private void btnLoadPrediction_Click(object sender, EventArgs e)
        {
            // Load Prediction
            DataTable dt = GetMonthlyBorrowData();
            LoadSummary();
            LoadTopBooksChart();

            DataTable predictionTable = new DataTable();
            predictionTable.Columns.Add("Book Title");
            predictionTable.Columns.Add("Expected Borrowings");
            predictionTable.Columns.Add("Demand Level");
            predictionTable.Columns.Add("Prediction");

            var groupedBooks = dt.AsEnumerable()
                .GroupBy(r => r["book_title"].ToString());

            foreach (var book in groupedBooks)
            {
                var lastThreeMonths = book
                    .OrderByDescending(r =>
                        Convert.ToInt32(r["Year"]) * 100 +
                        Convert.ToInt32(r["Month"]))
                    .Take(3)
                    .Select(r => Convert.ToInt32(r["TotalBorrowed"]))
                    .ToList();

                if (lastThreeMonths.Count > 0)
                {
                    double avgPrediction = lastThreeMonths.Average();
                    int roundedPrediction = Convert.ToInt32(Math.Round(avgPrediction, 0));

                    string demandLevel;
                    string prediction;

                    // ✅ Demand Level
                    if (roundedPrediction >= 5)
                        demandLevel = "High Demand";
                    else if (roundedPrediction <= 1)
                        demandLevel = "Low Demand";
                    else
                        demandLevel = "Normal";

                    // ✅ Predictive Insight (THIS MATCHES YOUR TITLE)
                    if (lastThreeMonths.Count >= 2)
                    {
                        int current = lastThreeMonths[0];
                        int previous = lastThreeMonths[1];

                        if (current > previous)
                            prediction = "Likely to Increase";
                        else if (current < previous)
                            prediction = "Likely to Decrease";
                        else
                            prediction = "Stable";
                    }
                    else
                    {
                        prediction = "Insufficient Data";
                    }

                    predictionTable.Rows.Add(book.Key, roundedPrediction, demandLevel, prediction);
                }
            }

            dataGridViewPrediction.DataSource = predictionTable;

            foreach (DataGridViewRow row in dataGridViewPrediction.Rows)
            {
                if (row.Cells["Demand Level"].Value != null)
                {
                    string level = row.Cells["Demand Level"].Value.ToString();

                    if (level == "High Demand")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (level == "Low Demand")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }

                if (row.Cells["Prediction"].Value != null)
                {
                    string trendValue = row.Cells["Prediction"].Value.ToString();

                    if (trendValue == "Increasing")
                        row.Cells["Prediction"].Style.ForeColor = Color.Green;
                    else if (trendValue == "Decreasing")
                        row.Cells["Prediction"].Style.ForeColor = Color.Red;
                }
            }
        }


        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
        }
    }
}
