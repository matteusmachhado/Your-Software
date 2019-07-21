using System.ComponentModel.DataAnnotations;

namespace YS.CMS.Infra.Security.Model
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de senha")]
        [Compare("Password", ErrorMessage = "Senha e confirmação são diferentes.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Persistir login.")]
        public bool? IsPersistent { get; set; }
    }
}
