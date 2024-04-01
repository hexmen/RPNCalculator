using RPN.Application.Interfaces;
using RPN.Domain.Attributes;

namespace RPN.Application.Strategy
{
    [OperationSymbolAttribute("+")]
    public class AdditionStrategy : IOperationStrategy
    {
        public decimal Calculate(decimal x, decimal y)
        {
            return x + y;
        }

        public decimal GetNumberOfNeededItemsToRun()
        {
            return 2;
        }
    }
}
