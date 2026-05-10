using Schola.Shared.Abstractions.Exceptions;

namespace Schola.Domain.Exceptions;

    public class SampleInvalidException : PublicException
    {

        public SampleInvalidException() : base("Sample ID cannot be empty.")
        {
        }
    }
