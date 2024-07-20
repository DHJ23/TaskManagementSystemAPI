using TaskManagement.DTO;
using FluentValidation.Results;
namespace TaskManagemnet.API.Extension
{
    public static class ValidationFailedResponseMapper
    {
        public static List<Error> MapToValidationError(ValidationResult validateResult)
        {
            return validateResult.Errors.Select(x => new Error(
                x.ErrorMessage,
                x.PropertyName))
        .ToList();
        }
    }
}
