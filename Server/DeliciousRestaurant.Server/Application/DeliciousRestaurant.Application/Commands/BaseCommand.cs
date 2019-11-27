using FluentValidation;
using FluentValidation.Results;

namespace DeliciousRestaurant.Application.Commands
{
    public abstract class BaseCommand : IBaseCommand
    {
        public BaseCommand(IValidator validator)
        {
            Validator = validator;
        }

        public ValidationResult ValidationResult { get; protected set; }
        public IValidator Validator { get; }

        public bool IsValid()
        {
            ValidationResult = Validator.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}