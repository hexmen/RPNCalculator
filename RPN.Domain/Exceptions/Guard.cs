
namespace RPN.Domain.Exceptions
{
    public static class Guard
    {
        public static void Against(this Func<bool> func, string message)
        {
            if (func())
            {
                throw new Exception(message);
            }
        }

        public static void AgainstDivisionByZero(this Func<bool> func, string message)
        {
            if (func())
            {
                throw new DivisionByZeroException(message);
            }
        }

        public static void AgainstOperationNotFound(this Func<bool> func, string message)
        {
            if (func())
            {
                throw new OperationNotFoundException(message);
            }
        }

        public static void AgainstStackNotFoundException(this Func<bool> func, string message)
        {
            if (func())
            {
                throw new StackNotFoundException(message);
            }
        }
        public static T GuardAgainstEmpty<T>(this T value, string message)
        {
            Guard.Against(() => IsEmpty(value), message);
            return value;
        }

        private static bool IsEmpty<T>(T value)
        {
            return value == null || value.Equals(default(T));
        }
    }
}
