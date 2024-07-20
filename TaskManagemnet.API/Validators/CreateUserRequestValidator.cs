using FluentValidation;
using Microsoft.AspNetCore.Mvc.Versioning;
using TaskManagement.DTO.Request.User;

namespace TaskManagemnet.API.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(q => q.Role).Must(BeValidCharacterForType).WithMessage("Role must be 'Employee/Manager/Admin'.");
            RuleFor(q => q.Email)
                .NotEmpty().WithMessage("Email should not be empty")
                .MaximumLength(254).WithMessage("Email should be 254 characters long")
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("Email is invalid kindly check it again");

        }
        private bool BeValidCharacterForType(string value)
        {
            return value == "Employee" || value == "Manager" || value == "Admin";
        }
    }
}
