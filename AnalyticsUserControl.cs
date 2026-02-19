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
    public partial class AnalyticsUserControl : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");

        public AnalyticsUserControl()
        {
            InitializeComponent();
        }

        private DataTable GetMostBorrowed()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();

                string query = @"
        SELECT b.book_title, COUNT(*) AS TotalBorrowed
        FROM issue_books i
        INNER JOIN books b ON i.book_id = b.id
        GROUP BY b.book_title
        ORDER BY TotalBorrowed DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
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
            // Load Most Borrowed
            dataGridViewMostBorrowed.DataSource = GetMostBorrowed();

            // Load Prediction
            DataTable dt = GetMonthlyBorrowData();

            DataTable predictionTable = new DataTable();
            predictionTable.Columns.Add("Book Title");
            predictionTable.Columns.Add("Predicted Borrow Next Month");

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
                    double prediction = lastThreeMonths.Average();
                    predictionTable.Rows.Add(book.Key, Math.Round(prediction, 0));
                }
            }

            dataGridViewPrediction.DataSource = predictionTable;
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
