using FluentValidation;
using LibraryManagement.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.ValidationRules.FluentValidation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {


            RuleFor(p => p.Author).MinimumLength(3).MaximumLength(200).NotEmpty().NotNull().StartsWithUpperCase().NoSqlInjectionPatterns().NoHtmlTags().OnlySafeCharacters();

            RuleFor(p => p.Title).MinimumLength(3).MaximumLength(200).NotEmpty().NotNull().StartsWithUpperCase().NoHtmlTags().NoSqlInjectionPatterns().OnlySafeCharacters();
        }

    }
}
