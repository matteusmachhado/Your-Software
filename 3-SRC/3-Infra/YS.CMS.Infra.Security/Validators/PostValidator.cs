using FluentValidation;
using YS.CMS.Common.Models.View;

namespace YS.CMS.Infra.Security.Validators
{
    public class PostValidator : AbstractValidator<PostViewModel>
    {
        public PostValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Text).NotEmpty();
        }
    }
}
