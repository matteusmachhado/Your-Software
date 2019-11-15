using System.ComponentModel.DataAnnotations;

namespace YS.CMS.Infra.Security.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Persistir")]
        public bool IsPersistent { get; set; }
    }
}
