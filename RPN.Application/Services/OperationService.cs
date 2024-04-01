using RPN.Application.Interfaces;
using RPN.Domain.Models;

namespace RPN.Application
{
    public class OperationService : IOperationService
    {
        private readonly IRpnStackLogics _rpnStackLogics;
        public OperationService(IRpnStackLogics rpnStackLogics) 
        {
            _rpnStackLogics = rpnStackLogics;
        }
        public RPNStack AddOperand(Guid stackId, Operand operand)
        {
            return _rpnStackLogics.PushOperand(stackId, operand);
        }

        public RPNStack AddOperation(Guid stackId, string operation)
        {
            return _rpnStackLogics.PushOperator(stackId, operation);
        }

        public List<Operation> GetSuportedOperations()
        {
            return _rpnStackLogics.GetSuportedOperations();
        }
    }
}
