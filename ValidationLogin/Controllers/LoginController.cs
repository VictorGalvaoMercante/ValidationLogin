using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ValidationLogin.data;
using ValidationLogin.Models;

namespace ValidationLogin.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<Usuario> _passwordHasher;

        public LoginController(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Usuario>();
        }

        // Exibe a tela de login
        public IActionResult Index()
        {
            return View();
        }

        // Recebe o POST do login
        [HttpPost]
        public IActionResult Index(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ModelState.AddModelError("", "Preencha email e senha.");
                return View();
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.SenhaHash, senha);
                if (resultado == PasswordVerificationResult.Success)
                {
 
                    return RedirectToAction("Index", "Trilhas");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login não encontrado");

            }

            return View();
        }

        // Exibe a tela de registro
        public IActionResult Register()
        {
            return View();
        }

        // Recebe o POST do registro
        [HttpPost]
        public IActionResult Register(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            if (usuario.Senha != usuario.ConfirmacaoSenha)
            {
                ModelState.AddModelError("", "A senha e a confirmação não conferem.");
                return View(usuario);
            }

            if (_context.Usuarios.Any(u => u.Email == usuario.Email))
            {
                ModelState.AddModelError("", "Email já cadastrado.");
                return View(usuario);
            }

            usuario.SenhaHash = _passwordHasher.HashPassword(usuario, usuario.Senha);


            _context.Add(usuario);
            _context.SaveChanges();
            Console.WriteLine("Usuário salvo no banco com sucesso.");

            // Após registro, redireciona para login
            Console.WriteLine("Redirecionando para login...");
            return RedirectToAction("Index", "Login");



        }
    }
}
