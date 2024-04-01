namespace RPN.Domain.Exceptions
{
    public class StackNotFoundException : System.Exception
    {
        public StackNotFoundException() { }

        public StackNotFoundException(string message)
            : base(message) { }

        public StackNotFoundException(string message, System.Exception inner)
            : base(message, inner) { }
    }
}
