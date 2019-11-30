using AutoMapper;
using DeliciousRestaurant.Application.Exceptions;
using DeliciousRestaurant.Application.Interfaces;
using FluentValidation.Results;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Commands
{
    public abstract class BaseCommandHandler<TCommand> : IRequestHandler<TCommand, bool> where TCommand : IBaseCommand
    {
        public BaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public abstract Task<bool> Handle(TCommand request, CancellationToken cancellationToken);

        protected void NotifyValidationErrors(IBaseCommand message)
        {
            var errors = message.ValidationResult.Errors;
            if (errors.Any())
                throw new MultipleValidationFailedException(message.ValidationResult.Errors);
        }

        protected void NotifyValidationErrors(string propertyName, string message, object sender)
        {
            throw new ValidationFailedException(new ValidationFailure(propertyName, message, sender));
        }
    }
}