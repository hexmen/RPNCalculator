namespace RPN.Domain.Models
{
    public class Operand
    {
        public decimal Value { get; }

        public Operand(decimal value)
        {
            Value = value;
        }
    }
}