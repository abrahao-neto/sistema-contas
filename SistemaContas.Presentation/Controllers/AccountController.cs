using Microsoft.AspNetCore.Mvc;
using SistemaContas.Data.Entities;
using SistemaContas.Data.Repositories;
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
            //Verificando se os campos do formulario (model) passaram nas regras de validação mapeadas na classe
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = new Usuario();
                    usuario.IdUsuario = Guid.NewGuid();
                    usuario.Nome = model.Nome;
                    usuario.Email = model.Email;
                    usuario.Senha = model.Senha;
                    usuario.DataHoraCriacao = DateTime.Now;

                    var usuarioRepository = new UsuarioRepository();
                    usuarioRepository.Inserir(usuario);

                    TempData["Mensagem"] = "Parabéns, sua conta de usuário foi criada com sucesso!";

                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Falha ao cadastrar usuário: " + e.Message;
                }
            }
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
