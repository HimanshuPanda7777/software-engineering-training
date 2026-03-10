using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyDemoWebServices
{
    /// <summary>
    /// Summary description for LpuService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LpuService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Addme(int a, int b)
        {
            return a + b;
        }
        public Product[] ShowAllProducts()
        {
            //connection
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=MyDemoDB;Integrated Security=True");
            con.Open();
            //command
            SqlCommand cmd = new SqlCommand("select * from Product", con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            //reader
            SqlDataReader dr = cmd.ExecuteReader();
            //why execute reader? because we want to read the data from database and show it in our web service
            while (dr.Read())
            {

                Product p = new Product();
                p.ProdId = Convert.ToInt32(dr["ProdId"]);
                p.Name = dr["Name"].ToString();
                p.Price = Convert.ToInt32(dr["Price"]);
                p.Details = dr["Details"].ToString();
                p.Category = dr["Category"].ToString();
            }

        }

    }
}
