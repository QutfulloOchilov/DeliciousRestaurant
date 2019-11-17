using FluentValidation.Results;
using System;

namespace DeliciousRestaurant.Application.Commands
{
    public class Command : ICommand
    {
        public ValidationResult ValidationResult => throw new NotImplementedException();

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
