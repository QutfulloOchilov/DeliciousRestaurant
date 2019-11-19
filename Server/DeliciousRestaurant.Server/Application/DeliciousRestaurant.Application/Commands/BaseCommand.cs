using FluentValidation.Results;
using System;

namespace DeliciousRestaurant.Application.Commands
{
    public class BaseCommand : IBaseCommand
    {
        public ValidationResult ValidationResult => throw new NotImplementedException();

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
