using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaContas.Data.Entities;
using SistemaContas.Data.Repositories;
using SistemaContas.Presentation.Models;
using System.Security.Claims;

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
            //Verificando se os campos do formulario (model) passaram nas regras de validação mapeadas na classe
            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioRepository = new UsuarioRepository();
                    var usuario = usuarioRepository.ObterPorEmailESenha(model.Email, model.Senha);

                    //Verificando se o usuário foi encontrado
                    if (usuario != null)
                    {
                        //armazenar os dados do usuário autenticado
                        var usuarioModel = new UsuarioModel();
                        usuarioModel.IdUsuario = usuario.IdUsuario;
                        usuarioModel.Nome = usuario.Nome;
                        usuarioModel.Email = usuario.Email;
                        usuarioModel.DataHoraAcesso = DateTime.Now;

                        //criando a identificação do usuário autenticado para ser gravada no Cookie de autenticação
                        var identity = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(usuarioModel)) //identificação do usuário!
                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                        //gravar a identificação no Cookie de autenticação
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);  

                        //Redirecionando para a página /Dashboard/Index
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Acesso negado. Usuário não encontardo.";
                    }
                }
                catch (Exception e)
                {

                    TempData["Mensagem"] = "Falha ao autenticar usuário: " + e.Message;
                }
            }

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
                    var usuarioRepository = new UsuarioRepository();
                    if (usuarioRepository.ObterPorEmail(model.Email) != null) 
                    {
                        TempData["ErroEmail"] = "O email informado já está cadastrado no sistema, tente outro.";
                    }
                    else
                    {
                        var usuario = new Usuario();
                        usuario.IdUsuario = Guid.NewGuid();
                        usuario.Nome = model.Nome;
                        usuario.Email = model.Email;
                        usuario.Senha = model.Senha;
                        usuario.DataHoraCriacao = DateTime.Now;

                        usuarioRepository.Inserir(usuario);

                        TempData["Mensagem"] = "Parabéns, sua conta de usuário foi criada com sucesso!";
                        ModelState.Clear(); //Limpar os campos do formulário
                    }
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

        /// <summary>
        /// Método para processar a requisiçãao de logout de usuário /Account/Logout
        /// </summary>
        public IActionResult Logout()
        {
            //apagar o cookie de autenticação do AspNet MVC
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //redirecionar o usuário de volta para a página /Account/Login
            return RedirectToAction("Login", "Account");
        }
    }
}
