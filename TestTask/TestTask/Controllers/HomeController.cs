using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}