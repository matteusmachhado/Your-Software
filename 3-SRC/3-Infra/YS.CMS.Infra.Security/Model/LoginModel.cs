using System.ComponentModel.DataAnnotations;

namespace YS.CMS.Infra.Security.Model
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Persistir login.")]
        public bool? IsPersistent { get; set; }

        [Required]
        [Display(Name = "Bloqueio por falha.")]
        public bool? LockoutOnFailure { get; set; }
    }
}
