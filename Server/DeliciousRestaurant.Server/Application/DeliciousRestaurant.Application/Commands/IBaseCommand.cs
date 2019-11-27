using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DeliciousRestaurant.Application.Commands
{
    public interface IBaseCommand : IRequest<bool>
    {
        bool IsValid();

        ValidationResult ValidationResult { get; }

        IValidator Validator { get; }
    }
}
