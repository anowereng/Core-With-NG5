using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Angular5WithCore.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System;

namespace Angular5WithCore.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IConfiguration Configuration;

        public ProductController(IConfiguration config)
        {
            this.Configuration = config;
        }
        [HttpGet("[action]")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Afraz", "Afreen", "ASHA", "KATHER", "Shanu" };
        }
        [HttpGet("[action]")]
        public IEnumerable<Product> Products()
        {

            //List<string> item = new List<string>();
            //item.Add("Mango");

            //Product model = new Product();
            //model.GetProduct();
            // IEnumerable<Product> list = null;
            //return list;
            //IEnumerable<string> list = null;
            List<Product> ProductList = new List<Product>();

            string constr = Configuration.GetConnectionString("MyConString");
            SqlConnection Connection = new SqlConnection(constr);
            Connection.Open();
          
            string Query = "SELECT * FROM tblStr_Product";
            SqlCommand Command = new SqlCommand(Query, Connection);
     
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Product aProduct = new Product();
                aProduct.ProductId = Convert.ToInt32(Reader["PrdId"].ToString());
                aProduct.ProductCode = Reader["PrdCode"].ToString();
                aProduct.ProductName = Reader["PrdName"].ToString();
                ProductList.Add(aProduct);
            }
            Connection.Close();
            Reader.Close();
           

            //List<Item> vTypeItem = new List<Item>()
            //{
            //    new Item { ItemId = 0, ItemCode = "P0001",ItemName="Demo" },
            //     new Item { ItemId = 1, ItemCode = "P0001",ItemName="Demo" },
            //      new Item { ItemId = 2, ItemCode = "P0001",ItemName="Demo" },
            //       new Item { ItemId = 3, ItemCode = "P0001",ItemName="Demo" },
            //        new Item { ItemId = 4, ItemCode = "P0001",ItemName="Demo" },
            //         new Item { ItemId = 5, ItemCode = "P0001",ItemName="Demo" }

            //};
            //IEnumerable<Item> list = (IEnumerable<Item>)vTypeItem;
            //list = item;
            return ProductList;
        }
    }
}
