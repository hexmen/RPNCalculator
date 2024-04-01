using RPN.Application.Interfaces;
using RPN.Domain.Attributes;

namespace RPN.Application.Strategy
{
    [OperationSymbol("/")]
    public class DivisionStrategy : IOperationStrategy
    {
        public decimal Calculate(decimal x, decimal y)
        {
            return x / y;
        }

        public decimal GetNumberOfNeededItemsToRun()
        {
            return 2;
        }
    }
}
