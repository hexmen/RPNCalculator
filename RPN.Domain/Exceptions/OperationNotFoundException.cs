namespace RPN.Domain.Exceptions
{
    public class OperationNotFoundException : Exception
    {
        public OperationNotFoundException() { }

        public OperationNotFoundException(string message)
            : base(message) { }

        public OperationNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
