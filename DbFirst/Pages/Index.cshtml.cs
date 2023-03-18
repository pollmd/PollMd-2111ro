using DbFirst.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DbFirst.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            SqlConnection conn = new SqlConnection("Server=ASPOSE\\SQLEXPRESS01;Database=Blog;Trusted_Connection=True;");
            string sqlSelect = "SELECT [id],[title],[text],[createdon],[author] FROM [Blog].[dbo].[Article]";
            var result = new List<Article>();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            var reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {

                    result.Add(new Article
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Text = reader.GetString(2),
                        Createdon = reader.GetDateTime(3)
                    });
                }

            }

            finally
            {
                reader.Close();
            }

            ViewData["Articles"] = result;

            conn.Close();

        }
    }
}