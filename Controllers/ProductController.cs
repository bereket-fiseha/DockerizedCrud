using DockerizedCrud.Data;
using DockerizedCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DockerizedCrud.Controllers
{
    public class ProductController : Controller
    {
        private ProductDbContext _context;
        public ProductController(ProductDbContext ctx)
        {
            _context = ctx;
        }
        [HttpGet]
        public IQueryable<Product> Products() { return _context.Products.AsQueryable<Product>(); }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Products);
        }

        [HttpPost]
        public async Task<StatusCodeResult> AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    return StatusCode(400);
                }
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<StatusCodeResult> EditProduct(Product oldProduct)
        {
            try
            {
              if(oldProduct.ProductID==0)
                      return BadRequest();
                var product = await _context.Products.FindAsync(oldProduct.ProductID);
                if (product == null)
                {
                    return NotFound();
                }
                
              var prod=new Product
              {
              ProductID=oldProduct.ProductID ,
              Name=oldProduct.Name,
              Category=oldProduct.Category,
              Price=oldProduct.Price
  };
                _context.Products.Attach(prod);
                _context.Entry(prod).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch(Exception ex)
            {

Console.WriteLine(ex);
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<StatusCodeResult> DeleteProduct(int productId)
        {
            try
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                {
                    return NotFound();
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}


