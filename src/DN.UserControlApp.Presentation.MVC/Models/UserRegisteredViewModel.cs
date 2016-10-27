using System.ComponentModel.DataAnnotations;

namespace DN.UserControlApp.Presentation.MVC.Models
{
    public class UserRegisteredViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public string FirstName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(6, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}