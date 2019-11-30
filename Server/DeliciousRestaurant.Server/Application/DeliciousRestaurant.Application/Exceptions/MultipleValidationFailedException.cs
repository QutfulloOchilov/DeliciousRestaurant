using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DeliciousRestaurant.Application.Exceptions
{
    public class MultipleValidationFailedException : Exception
    {
        public IList<ValidationFailure> ValidationFailures { get; }

        public MultipleValidationFailedException(IList<ValidationFailure> validationFailures)
            : base(string.Join("\r\n", validationFailures.Select(v => v.ToString())))
        {
            ValidationFailures = validationFailures;
        }

        public MultipleValidationFailedException(IList<ValidationFailure> validationFailures, Exception innerException)
            : base(string.Join("\r\n", validationFailures.Select(v => v.ToString())), innerException)
        {
            ValidationFailures = validationFailures;
        }

        protected MultipleValidationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
