namespace UserRegistration.CustomExceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException(string message) : base(message) { }
    }
}
