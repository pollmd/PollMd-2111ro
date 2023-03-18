using DbFirstMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DbFirstMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Comment c)
        {
            return View(c);
        }

        public IActionResult FormRedirect()
        {
            var c = new Comment { Id = 1, Text = "data from FormRedirect" };
            return RedirectToAction("Index", c);
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