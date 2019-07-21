using FluentValidation;
using YS.CMS.Common.Models.View;

namespace YS.CMS.Infra.Security.Validators
{
    public class CategoryValidactor : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidactor()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
