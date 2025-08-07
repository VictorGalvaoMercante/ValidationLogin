using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ValidationLogin.Models;

namespace ValidationLogin.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

       
       
    }
}
