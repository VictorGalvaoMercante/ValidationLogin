using Microsoft.AspNetCore.Mvc;
using ValidationLogin.data;
using ValidationLogin.Models;
using System.Linq;

namespace ValidationLogin.Controllers
{
    public class TrilhasPublicasController : Controller
    {
        private readonly AppDbContext _context;

        public TrilhasPublicasController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string busca = null)
        {
            var trilhas = _context.Trilha.AsQueryable();

            if (!string.IsNullOrEmpty(busca))
            {
                busca = busca.ToLower();
                trilhas = trilhas.Where(t =>
                    t.Nome.ToLower().Contains(busca) ||
                    t.Localizacao.ToLower().Contains(busca));
            }

            var listaTrilhas = trilhas.OrderBy(t => t.Nome).ToList();

            return View(listaTrilhas);
        }

        public IActionResult Detalhes(int id)
        {
            var trilha = _context.Trilha.FirstOrDefault(t => t.TrilhaId == id);
            if (trilha == null)
                return NotFound();

            return View(trilha);
        }
        public IActionResult Reservar(int id)
        {
            var trilha = _context.Trilha.FirstOrDefault(t => t.TrilhaId == id);
            if (trilha == null)
                return NotFound();

            // Se você estiver usando autenticação com sessão ou Identity, pode buscar o usuário logado
            var usuarioLogado = HttpContext.Session.GetString("UsuarioNome"); // Exemplo se armazenar na sessão
            var emailLogado = HttpContext.Session.GetString("UsuarioEmail");

            ViewBag.NomeUsuario = usuarioLogado;
            ViewBag.EmailUsuario = emailLogado;

            return View(trilha);
        }

    }
}
