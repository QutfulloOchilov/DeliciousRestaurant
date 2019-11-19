using FluentValidation;

namespace DeliciousRestaurant.Application.Commands
{
    public abstract class BaseCommandValidation<TCommand> : AbstractValidator<TCommand>, IBaseCommandValidation<TCommand> where TCommand : IBaseCommand
    {

    }
}
