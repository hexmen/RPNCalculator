namespace RPN.Application.Interfaces
{
    public interface IOperationFactory
    {
        IOperationStrategy Create(string algorithmType);
        List<string> GetAllAvailableOperations();
    }
}