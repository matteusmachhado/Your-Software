using FluentValidation;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Infra.Security.Validators
{
    public class CategoryValidactor : AbstractValidator<Category>
    {
        public CategoryValidactor()
        {
            RuleFor(c => c.Name).NotEmpty();
            // RuleFor(c => c.CreateUser).NotEmpty();
        }
    }
}
