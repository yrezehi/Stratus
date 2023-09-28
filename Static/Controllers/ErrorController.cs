using Microsoft.AspNetCore.Mvc;
using Static.Models;
using Static.Models.ViewModels;
using System.Diagnostics;

namespace Static.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        public ErrorController() {  }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => 
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}