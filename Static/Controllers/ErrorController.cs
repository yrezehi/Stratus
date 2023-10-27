using Microsoft.AspNetCore.Mvc;
using Static.Models.ViewModels;
using System.Diagnostics;

namespace Static.Controllers
{
    [Route("[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorController : Controller
    {
        public IActionResult Error() => 
            View(new ExceptionViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        public IActionResult Unauthroized() =>
            View(new ExceptionViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}