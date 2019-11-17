using FluentValidation.Results;
using MediatR;

namespace DeliciousRestaurant.Application.Commands
{
    public interface ICommand : IRequest<bool>
    {
        bool IsValid();

        ValidationResult ValidationResult { get; }
    }
}
