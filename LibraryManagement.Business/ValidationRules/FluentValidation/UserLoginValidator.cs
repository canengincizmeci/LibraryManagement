using FluentValidation;
using LibraryManagement.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.ValidationRules.FluentValidation
{
    public class UserLoginValidator : AbstractValidator<UserForLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(p => p.Email).MinimumLength(3).MaximumLength(200).NotNull().NotEmpty().NoSqlInjectionPatterns().NoHtmlTags().OnlySafeCharacters();

            RuleFor(p => p.Password).MinimumLength(2).MaximumLength(200).NotNull().NotEmpty().NoSqlInjectionPatterns().NoHtmlTags().OnlySafeCharacters();
        }
    }
}
