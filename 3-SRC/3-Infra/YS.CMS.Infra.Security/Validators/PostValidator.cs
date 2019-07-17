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
            RuleFor(p => p.CreateUser).NotEmpty();
            RuleFor(p => p.Author).NotEmpty();
            RuleFor(p => p.Categories).Custom((categories, context) =>
            {
                if (categories == null || categories.Count == 0)
                {
                    context.AddFailure(context.DisplayName, "Informe à(s) categorias do post.");
                }
            });
        }
    }
}
