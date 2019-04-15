using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Infra.Security.Validators.Core
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Text).NotEmpty();
        }
    }
}
