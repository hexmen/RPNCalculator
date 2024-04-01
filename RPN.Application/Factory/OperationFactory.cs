using Microsoft.Extensions.DependencyInjection;
using RPN.Application.Interfaces;
using RPN.Domain.Attributes;
using RPN.Domain.Exceptions;

namespace RPN.Application
{
    public class OperationFactory : IOperationFactory
    {
        //private static ArrayList _registeredImplementations;
        private IEnumerable<IOperationStrategy> _services;
        public OperationFactory(IEnumerable<IOperationStrategy> services)
        {
            _services = services;
        }

        public IOperationStrategy Create(string operationSymbol)
        {
            IOperationStrategy result = null ;
            foreach (var service in _services)
            {
                    object[] attrlist = service.GetType().GetCustomAttributes(true);

                    // loop thru all attributes for this class
                    foreach (object attr in attrlist)
                    {
                        if (attr is OperationSymbolAttribute)
                        {
                            if (((OperationSymbolAttribute)attr).TypeOfOperation.Equals(operationSymbol))
                            {
                                result = service;
                            }
                        }
                    }
            }

            Guard.Against(() => result == null, ValidationMessages.OperationNotFound);
            return result;
        }

        public List<string> GetAllAvailableOperations()
        {
            List<string> res = new List<string>();
            foreach (var service in _services)
            {
                object[] attrlist = service.GetType().GetCustomAttributes(true);

                // loop thru all attributes for this class
                foreach (object attr in attrlist)
                {
                    if (attr is OperationSymbolAttribute)
                    {
                        res.Add(((OperationSymbolAttribute)attr).TypeOfOperation);
                    }
                }
            }

            return res;
        }
    }
}
