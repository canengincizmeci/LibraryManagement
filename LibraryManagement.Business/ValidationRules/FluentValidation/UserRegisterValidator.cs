using FluentValidation;
using LibraryManagement.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.ValidationRules.FluentValidation
{
    public class UserRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(p => p.FirstName).MinimumLength(2).MaximumLength(100).NotNull().NotEmpty().NoSqlInjectionPatterns().NoHtmlTags().OnlySafeCharacters();

            RuleFor(p => p.Email).MinimumLength(3).MaximumLength(200).NotNull().NotEmpty().NoSqlInjectionPatterns().NoHtmlTags().OnlySafeCharacters();

            RuleFor(p => p.FirstName).MinimumLength(3).MaximumLength(200).NotNull().NotEmpty().NoSqlInjectionPatterns().NoHtmlTags().OnlySafeCharacters();

            RuleFor(p => p.LastName).MinimumLength(2).MaximumLength(200).NotEmpty().NotNull().NoSqlInjectionPatterns().NoHtmlTags().OnlySafeCharacters();

        }
    }
}
