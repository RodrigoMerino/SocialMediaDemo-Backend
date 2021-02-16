using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .Length(0, 500 );

            RuleFor(x => x.Date)
                .LessThan(DateTime.Now);
        }
    }
}
