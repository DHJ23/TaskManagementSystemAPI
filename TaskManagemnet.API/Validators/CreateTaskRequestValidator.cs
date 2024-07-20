using FluentValidation;
using TaskManagement.DTO.Request.Task;

namespace TaskManagemnet.API.Validators
{
    public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskRequestValidator()
        {
            RuleFor(q => q.Status).Must(BeValidCharacterForType).WithMessage("Status must be 'Open/Pending/In Progress/Completed'.");

        }
        private bool BeValidCharacterForType(string value)
        {
            return value == "Open" || value == "Pending" || value == "In Progress" || value == "Completed";
        }
    }
}
