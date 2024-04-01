using RPN.Domain.Models;

namespace RPN.Application.Interfaces
{
    public interface IOperationService
    {
        RPNStack AddOperation(Guid stackId, string operation);
        RPNStack AddOperand(Guid stackId, Operand operand);
        List<Operation> GetSuportedOperations();
    }
}
