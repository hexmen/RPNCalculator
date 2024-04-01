using RPN.Application.Interfaces;
using RPN.Domain.Exceptions;
using RPN.Domain.Models;
using System.Collections.Concurrent;
using System.Text;

namespace RPN.Application.RpnStackLogics
{
    public class RpnStackLogics : IRpnStackLogics
    {
        ConcurrentDictionary<Guid, Stack<decimal>> StackDictionary = new ConcurrentDictionary<Guid, Stack<decimal>>();
        IOperationFactory _operationFactory;
        public RpnStackLogics(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public void ClearStack(Guid stackId)
        {
            StackDictionary[stackId].Clear();
        }

        public RPNStack CreateStack()
        {
            Guid stackId = Guid.NewGuid();
            StackDictionary.TryAdd(stackId, new Stack<decimal>());
            RPNStack stack = new RPNStack();
            stack.RpnStackId = stackId;
            return stack;
        }

        public RPNStack GetStack(Guid stackId)
        {
            return ConvertToStack(stackId,StackDictionary[stackId]);
        }

        public List<RPNStack> GetListStack()
        {
            var res = new List<RPNStack>();
            foreach (var item in StackDictionary)
            {
                res.Add(ConvertToStack(item.Key, item.Value));
            }

            return res;
        }

        public void RemoveStack(Guid stackId)
        {
            StackDictionary.TryRemove(stackId, out Stack<decimal> stack);
        }

        public RPNStack PushOperand(Guid stackId,Operand x)
        {
            StackDictionary[stackId].Push(x.Value);
            return GetStack(stackId);

        }
        public RPNStack PushOperator(Guid stackId,string operation)
        {
            IOperationStrategy operationStrategy = _operationFactory.Create(operation);

            ValidateOperation(stackId,operation, operationStrategy);
            StackDictionary[stackId].Push(operationStrategy.Calculate(StackDictionary[stackId].Pop(), StackDictionary[stackId].Pop()));
            return GetStack(stackId);
        }

        public List<Operation> GetSuportedOperations()
        {
            List<Operation> result = new List<Operation>();
            foreach(var item in _operationFactory.GetAllAvailableOperations())
            {
                result.Add(new Operation()
                {
                    Name = item
                });
            }

            return result;
        }
        private void ValidateOperation(Guid stackId,string operation, IOperationStrategy operationStrategy)
        {
            Guard.Against(() => StackDictionary[stackId].Count < operationStrategy.GetNumberOfNeededItemsToRun(), ValidationMessages.NeedAtLeast2Items);
            Guard.AgainstDivisionByZero(() => operation == "/" && StackDictionary[stackId].ElementAt(1) == 0, ValidationMessages.DivionByZero);
        }

        private RPNStack ConvertToStack(Guid stackId, Stack<decimal> rpnStack)
        {
            var stack = new RPNStack()
            {
                RpnStackId = stackId,
                StackItems = new List<decimal>()
            };

            foreach (var item in rpnStack)
            {
                stack.StackItems.Add(item);
            }

            return stack;
        }
    }
}
