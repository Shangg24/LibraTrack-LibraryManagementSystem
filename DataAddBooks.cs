using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Data;
using System.Data.SqlClient;


namespace LibraTrack
{
    internal class DataAddBooks
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;Trust Server Certificate=True");
        public int ID { get; set; }
        public string Category { get; set; }
        public string Book_Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Shelf { get; set; }
        public DateTime Published_Date { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }


        public List<DataAddBooks> addBooksData()
        {
            List<DataAddBooks> listData = new List<DataAddBooks>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT id, category, book_title, author, ISBN, shelf, published_date, image, status FROM books WHERE date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();


                        while (reader.Read())
                        {
                            DataAddBooks dab = new DataAddBooks();
                            dab.ID = (int)reader["id"];
                            dab.Book_Title = reader["book_title"].ToString();
                            dab.Author = reader["author"].ToString();
                            dab.Published_Date = Convert.ToDateTime(reader["published_date"]);
                            dab.Image = reader["image"].ToString();
                            dab.Status = reader["status"].ToString();

                            listData.Add(dab);
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting Database: " + ex);
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
