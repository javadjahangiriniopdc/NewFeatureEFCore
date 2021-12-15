using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewFeatureEFCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewFeatureEFCore.Data;

namespace NewFeatureEFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var customers =await _context.Customers
                .Where(x => x.Name.Contains("a"))
                .OrderBy(o => o.Name)
                .ToListAsync();

            // var sqlStr = customers.ToQueryString();
            // Console.WriteLine(sqlStr);

            //var customerList = customers.ToListAsync();


            return View(customers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
