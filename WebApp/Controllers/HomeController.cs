using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;
        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            Reviews reviews = new Reviews()
            {
                Antrenors = _context.Antrenors.ToList(),
                Ratings = _context.Rating.ToList(),
                Clients = _context.Clients.ToList()
            };
            return View(reviews);
        }

        [HttpPost]
        [Route("rating/addreview")]
        public IActionResult AddReview([Bind(Prefix = "Rating")]Rating rating)
        {
            try
            {
                _context.Rating.Add(new Rating(int.Parse(Request.Form["antrenori"]), 
                    int.Parse(Request.Form["clienti"]), int.Parse(Request.Form["nota"])));
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error");
            }
            return View();
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
