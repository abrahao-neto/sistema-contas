using Microsoft.AspNetCore.Mvc;
using SistemaContas.Presentation.Models;

namespace SistemaContas.Presentation.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Método para abrir a página /Account/Login
        /// </summary>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Método para receber o SUBMIT POST do formulário
        /// </summary>
        [HttpPost]
        public IActionResult Login(AccountLoginModel model)
        {
            return View();
        }

        /// <summary>
        /// Método para abrir a página /Account/Register
        /// </summary>

        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Método para receber o SUBMIT POST do formulario
        /// </summary>
        [HttpPost]
        public IActionResult Register(AccountRegisterModel model)
        {
            return View();
        }


        /// <summary>
        /// Método para abrir a página /Account/PasswordRecover
        /// </summary>
        public IActionResult PasswordRecover()
        {
            return View();
        }

        /// <summary>
        /// Método para receber o SUBMIT POST do formulario
        /// </summary>
        [HttpPost]
        public IActionResult PasswordRecover(AccountPasswordRecoverModel model)
        {
            return View();
        }
    }
}
