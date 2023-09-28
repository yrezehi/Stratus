using Microsoft.AspNetCore.Mvc;
using Static.Models;
using Static.Models.ViewModels;
using System.Diagnostics;

namespace Static.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}