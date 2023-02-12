using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaContas.Presentation.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        /// <summary>
        /// Método para abrir a página /Dashboard/Index
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
