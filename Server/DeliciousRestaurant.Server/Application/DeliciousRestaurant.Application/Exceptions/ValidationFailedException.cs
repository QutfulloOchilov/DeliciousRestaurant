using FluentValidation.Results;
using System;
using System.Runtime.Serialization;

namespace DeliciousRestaurant.Application.Exceptions
{
    public class ValidationFailedException : Exception
    {
        public ValidationFailure ValidationFailure { get; }

        public ValidationFailedException(ValidationFailure validationFailure) : base(validationFailure.ErrorMessage)
        {
            ValidationFailure = validationFailure;
        }

        public ValidationFailedException(ValidationFailure validationFailure, Exception innerException) : base(validationFailure.ErrorMessage, innerException)
        {
            ValidationFailure = validationFailure;
        }

        protected ValidationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}