using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
       readonly Product[] products = new Product[]
       {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
       };
        [Microsoft.AspNetCore.Mvc.HttpGet("ProductsDetails")]
        public  IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("ProductsItemDetails")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return (IHttpActionResult)NotFound();
            }
            
            return (IHttpActionResult)Ok(product);
        }
    }
}
