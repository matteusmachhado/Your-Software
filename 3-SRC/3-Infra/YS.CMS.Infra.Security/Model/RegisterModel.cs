using System.ComponentModel.DataAnnotations;

namespace YS.CMS.Infra.Security.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de senha")]
        [Compare("Password", ErrorMessage = "Confirmação de senha incorreta.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Persistir")]
        public bool? IsPersistent { get; set; }
    }
}
