using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LibraTrack
{
    internal class DataIssueBooks
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;Trust Server Certificate=True");

        public int ID { get; set; }
        public string IssueID { get; set; }
        public string Name { get; set; }
        public string IDNo { get; set; }
        public string GradeSection { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Copies { get; set; }
        public string DateIssue { get; set; }
        public string DateReturn { get; set; }
        public string Status { get; set; }

        public List<DataIssueBooks> IssueBooksData()
        {
            List<DataIssueBooks> listData = new List<DataIssueBooks>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=.\SQLEXPRESS;
AttachDbFilename=""C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LibraTrack.mdf"";
Integrated Security=True;"))
            {
                connect.Open();
                string query = @"SELECT * FROM issues WHERE status = 'Not Returned' AND date_delete IS NULL ORDER BY date_insert DESC";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DataIssueBooks dib = new DataIssueBooks();

                        dib.ID = (int)reader["id"];
                        dib.IssueID = reader["issue_id"].ToString();
                        dib.Name = reader["full_name"].ToString();
                        dib.IDNo = reader["id_no"].ToString();
                        dib.GradeSection = reader["grade_section"].ToString();
                        dib.Contact = reader["contact"].ToString();
                        dib.Email = reader["email"].ToString();
                        dib.BookTitle = reader["book_title"].ToString();
                        dib.Author = reader["author"].ToString();
                        dib.Copies = reader["copies"].ToString();
                        dib.DateIssue = reader["issue_date"].ToString();
                        dib.DateReturn = reader["return_date"].ToString();
                        dib.Status = reader["status"].ToString();

                        listData.Add(dib);
                    }
                }
            }
                
            return listData;
        }

        public List<DataIssueBooks> ReturnIssueBooksData()
        {
            List<DataIssueBooks> listData = new List<DataIssueBooks>();
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM issues WHERE status = 'Not Return' AND date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            DataIssueBooks dib = new DataIssueBooks();

                            dib.ID = (int)reader["id"];
                            dib.IssueID = reader["issue_id"].ToString();
                            dib.Name = reader["full_name"].ToString();
                            dib.Contact = reader["contact"].ToString();
                            dib.Email = reader["email"].ToString();
                            dib.BookTitle = reader["book_title"].ToString();
                            dib.Author = reader["author"].ToString();
                            dib.Copies = reader["copies"].ToString();
                            dib.DateIssue = reader["issue_date"].ToString();
                            dib.DateReturn = reader["return_date"].ToString();
                            dib.Status = reader["status"].ToString();

                            listData.Add(dib);
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;
        }
    }
}
