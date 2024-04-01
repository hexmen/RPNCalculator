using RPN.Application;
using RPN.Application.Interfaces;
using RPN.Domain.Models;

namespace RPNCalculator.Services
{
    public class StackService : IStackService
    {

        IRpnStackLogics _rpnStackLogics;
        public StackService(IRpnStackLogics rpnStackLogics)
        {
            _rpnStackLogics = rpnStackLogics;
        }
        public void ClearStack(Guid stackId)
        {
            _rpnStackLogics.ClearStack(stackId);
        }

        public RPNStack CreateStack()
        {
            return _rpnStackLogics.CreateStack();
        }

        public RPNStack GetStack(Guid stackId)
        {
            return _rpnStackLogics.GetStack(stackId);
        }

        public List<RPNStack> GetListStack()
        {
            return _rpnStackLogics.GetListStack();
        }

        public void RemoveStack(Guid stackId)
        {
            _rpnStackLogics.RemoveStack(stackId);
        }
    }
}
