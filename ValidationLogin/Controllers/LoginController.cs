using Microsoft.AspNetCore.Mvc;

namespace ValidationLogin.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext<LoginController> _context;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
