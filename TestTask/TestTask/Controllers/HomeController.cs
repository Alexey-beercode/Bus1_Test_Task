using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILinkService _linkService;

        public HomeController(ILinkService linkService)
        {
            _linkService = linkService;
        }

        public async Task<IActionResult> Index()
        {
            var links = await _linkService.GetLinksAsync();
            return View("Index",links);
        }
    }
}