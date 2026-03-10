using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyDemoWebServices
{
    /// <summary>
    /// Summary description for Product
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Product : System.Web.Services.WebService
    {

        [WebMethod]
       public class Product
        {
            public int ProdId { get; set; }
            public string Name { get; set; }
            public int? Price { get; set; }
            public string Details { get; set; }
            public string Category { get; set; }
        }
    }
}
