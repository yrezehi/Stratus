﻿using Microsoft.AspNetCore.Mvc;

namespace Static.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() =>
            View();
        
    }
}