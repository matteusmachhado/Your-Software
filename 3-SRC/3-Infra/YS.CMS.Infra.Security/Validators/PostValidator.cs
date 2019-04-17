﻿using FluentValidation;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Infra.Security.Validators
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Text).NotEmpty();
            RuleFor(p => p.CreateUser).NotEmpty();
            RuleFor(p => p.Author).NotEmpty();
        }
    }
}
