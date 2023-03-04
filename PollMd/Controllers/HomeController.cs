using Microsoft.AspNetCore.Mvc;
using PollMd.Data;
using PollMd.Models;
using System.Diagnostics;

namespace PollMd.Controllers
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

        public IActionResult Index()
        {
            var questions = _context.Question.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Titlul paginii Privacy";
            return View();
        }

        public IActionResult Exams()
        {
            return View(new List<Exam>());
        }

        public IActionResult Divide(int val1, int val2)
        {
            try
            {
                if(val2==0)
                    throw new MyException(val1, val2);

                TempData["CalcResult"] = val1 / val2;

            }
            catch (DivideByZeroException e)
            {
                TempData["CalcResult"] = "Împartirea la 0 nu este posibila";
            }
            catch (Exception e)
            {
                TempData["CalcResult"] = e.Message;
            }

            return Redirect("/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    class MyException : Exception
    {
        public MyException(int val1,int val2):base($"Impartirea {val1}/{val2} nu este posibila"){}
    }
}