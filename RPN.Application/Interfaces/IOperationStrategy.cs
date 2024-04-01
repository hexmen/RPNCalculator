namespace RPN.Application.Interfaces
{
    public interface IOperationStrategy
    {
        decimal GetNumberOfNeededItemsToRun();

        decimal Calculate(decimal x, decimal y);
    }
}
