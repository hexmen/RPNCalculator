using System;

namespace RPN.Domain.Exceptions
{
    public class DivisionByZeroException : System.Exception
    {
        public DivisionByZeroException() { }

        public DivisionByZeroException(string message)
            : base(message) { }

        public DivisionByZeroException(string message, System.Exception inner)
            : base(message, inner) { }
    }
}
