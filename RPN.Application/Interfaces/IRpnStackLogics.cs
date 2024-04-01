using RPN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN.Application.Interfaces
{
    public interface IRpnStackLogics
    {
        RPNStack CreateStack();
        void ClearStack(Guid stackId);
        RPNStack GetStack(Guid stackId);
        List<RPNStack> GetListStack();
        void RemoveStack(Guid stackId);
        RPNStack PushOperand(Guid stackId, Operand x);
        RPNStack PushOperator(Guid stackId, string operation);
        List<Operation> GetSuportedOperations();
    }
}
