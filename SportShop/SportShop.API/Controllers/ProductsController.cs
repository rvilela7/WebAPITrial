using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportShop.API.Models;

namespace SportShop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _ctx;

        public ProductsController(ShopContext ctx)
        {
            _ctx = ctx;

            //Initialize DB by checking that will be created
            _ctx.Database.EnsureCreated();
        }

        [HttpGet("/1")]
        public IEnumerable<Product> GetAllProducts1() { 
            return _ctx.Products.ToArray();
        }

        [HttpGet("/2")]
        public IActionResult GetAllProducts2() { 
            return Ok(_ctx.Products.ToArray());
        }

        //[HttpGet, Route("/products/{id}")]
        //OR attribute like above
        //[HttpGet("/products/{id}")]
        //OR We can provide DataTypes //Gives 404 instead of 400 when using string (no match in route)
        [HttpGet, Route("/products/{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var product = _ctx.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("/productsAsync/{id}")]
        public async Task<IActionResult> GetProduct2(int id)
        {
            var product = await _ctx.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}