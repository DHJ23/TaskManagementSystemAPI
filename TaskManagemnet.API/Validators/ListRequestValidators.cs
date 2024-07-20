using FluentValidation;
using TaskManagement.DTO;

namespace TaskManagemnet.API.Validators
{
    public class ListRequestValidators : AbstractValidator<ListRequest>
    {
        public ListRequestValidators()
        {
            RuleFor(x => x.Limit)
             .NotNull().WithMessage("Limit should not be empty")
             .GreaterThan(0).WithMessage("Limit parameter should be > 0");
            RuleFor(x => x.Offset)
             .NotNull().WithMessage("Offset should not be empty")
             .GreaterThanOrEqualTo(0).WithMessage("Offset parameter should be >= 0");
            RuleFor(x => x.SortOrder)
             .Must(q => (string.IsNullOrEmpty(q) || (!string.IsNullOrEmpty(q) && beValidSortOrder(q))))
             .WithMessage("SortOrder must be either 'asc' or 'desc'.");
        }
        private bool beValidSortOrder(string sortOrder)
        {
            return sortOrder.ToLower() == "asc" || sortOrder.ToLower() == "desc";
        }
        private bool beValidGuid(string guid)
        {
            return Guid.TryParse(guid, out _);
        }
    }
}
