using FluentValidation;

namespace DeliciousRestaurant.Application.Commands
{
    public interface IBaseCommandValidation<TCommand> : IValidator<TCommand> where TCommand : IBaseCommand
    {

    }
}
