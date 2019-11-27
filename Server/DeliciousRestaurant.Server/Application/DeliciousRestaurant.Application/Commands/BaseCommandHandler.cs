using DeliciousRestaurant.Application.Interfaces;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Commands
{
    public abstract class BaseCommandHandler<TCommand> : IRequestHandler<TCommand, bool> where TCommand : IBaseCommand
    {
        public BaseCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected void NotifyValidationErrors(IBaseCommand message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                //throw new NotImplementedException();
            }
        }

        protected void NotifyValidationErrors(string message, object sender)
        {
            var validationFlure = new ValidationFailure("", message, sender);
            //TODO: implement notify validation errors
            //foreach (var error in message.ValidationResult.Errors)
            //{
            //    //throw new NotImplementedException();
            //}
        }

        public IUnitOfWork UnitOfWork { get; }

        public abstract Task<bool> Handle(TCommand request, CancellationToken cancellationToken);
    }
}