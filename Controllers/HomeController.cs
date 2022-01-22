using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DockerizedCrud.Models;
using DockerizedCrud.Data;
using Microsoft.Extensions.Configuration;


namespace DockerizedCrud.Controllers {
public class HomeController : Controller {
private readonly  ProductDbContext dbcontext;
private string message;
public HomeController(ProductDbContext _dbcontext, IConfiguration config) {
dbcontext = _dbcontext;
message = config["MESSAGE"] ?? "Essential Docker";
}
        [HttpGet]
        public String getString() {
            return "hello this i s";
        }
public IActionResult Index() {
ViewBag.Message = message;
return View(dbcontext.Products);
}
}
}