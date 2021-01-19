using Microsoft.AspNetCore.Mvc;

namespace GameStoreApp.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}