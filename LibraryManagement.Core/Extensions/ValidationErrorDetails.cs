using FluentValidation.Results;

namespace LibraryManagement.Core.Extensions
{
    public class ValidationErrorDetails:ErrorDetails
    {
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
