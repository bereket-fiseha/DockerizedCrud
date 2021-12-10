using DockerizedCrud.Data;
using DockerizedCrud.Data;
using DockerizedCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerizedCrud.Controllers
{
    public class AllProductController : Controller
    {
        private ProductDbContext _context;
        public AllProductController(ProductDbContext ctx)
        {
            _context = ctx;
        }
        [HttpGet]
        public IQueryable<Product> Products() { return _context.Products.AsQueryable<Product>(); }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public String getString()
        {
            return "hello";
        }
        [HttpPost]
        public async Task<StatusCodeResult> AddNewProductAsync(Product product){
try{
    Console.WriteLine(product);
            await _context.Products.AddAsync(product);
          await   _context.SaveChangesAsync();
return StatusCode(200);
}
catch{

    return BadRequest();
}
        }
    }
}
