using Schola.Shared.Abstractions.Exceptions;

public class UserInvalidException : PublicException
    {

        public UserInvalidException() : base("User ID cannot be empty.")
        {
        }
    }
