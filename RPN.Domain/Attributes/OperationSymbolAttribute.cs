namespace RPN.Domain.Attributes
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class OperationSymbolAttribute : Attribute
    {
        private string _operationType;


        public OperationSymbolAttribute(string operationType)
        {
            this._operationType = operationType;
        }

        public string TypeOfOperation
        {
            get { return _operationType; }
        }
    }
}
