using FluentValidation;

namespace DeliciousRestaurant.Application.Commands
{
    public interface IBaseValidation : IValidator
    {

    }

    public abstract class BaseCommandValidation<TCommand> : AbstractValidator<TCommand>,
        IBaseCommandValidation<TCommand>,
        IBaseValidation where TCommand : IBaseCommand

    {

    }
}
