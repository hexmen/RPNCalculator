using RPN.Domain.Models;

namespace RPN.Application.Interfaces
{
    public interface IStackService
    {
        RPNStack GetStack(Guid stackId);
        RPNStack CreateStack();
        void RemoveStack(Guid stackId);

        void ClearStack(Guid stackId);
        List<RPNStack> GetListStack();
    }
}
