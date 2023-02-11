using SistemaContas.Presentation.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace SistemaContas.Presentation.Models
{
    /// <summary>
    /// Modelo de dados para o formulário de criação de usuário
    /// </summary>
    public class AccountRegisterModel
    {
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{8,150}$", ErrorMessage = "Informe um nome válido de 8 a 150 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do usúario")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um enderco de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usúario.")]
        public string? Email { get; set; }

        [StrongPassword(ErrorMessage = "Por favor, informe uma senha forte de 8 a 20 caracteres com pelo menos 1 letra minúscula, 1 letra maiúscula, 1 número e 1 caractere especial.")]
        [Required(ErrorMessage = "Por favor, informe a senha do usúario.")]
        public string? Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem, por favor verifique.")]
        [Required(ErrorMessage = "Por favor, confirme a senha do usúario.")]
        public string? SenhaConfirmacao { get; set; }
    }
}
