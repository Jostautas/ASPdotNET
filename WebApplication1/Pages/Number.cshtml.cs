using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Pages
{
    public class NumberModel : PageModel
    {
        private readonly ILogger<NumberModel> _logger;

        public NumberModel(ILogger<NumberModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        /*public int getNumber() {
            using(var con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-WebApplication1-53bc9b9d-9d6a-45d4-8429-2a2761773502;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM AspNetUsers";

                using (var cmd = new SqlCommand(query, con))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }*/
        
        /*public void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-WebApplication1-53bc9b9d-9d6a-45d4-8429-2a2761773502;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                using (SqlCommand cmdSQL = new SqlCommand("SELECT COUNT(*) FROM AspNetUsers", conn))
                {
                    conn.Open();
                    int? RowCount = (int?)cmdSQL.ExecuteScalar();
                    TextBox1.Text = RowCount.ToString();
                }
            }

        }*/
    }
}