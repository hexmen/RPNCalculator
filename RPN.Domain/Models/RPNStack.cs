using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN.Domain.Models
{
    public class RPNStack
    {
        public Guid RpnStackId { get; set; }
        public List<decimal> StackItems { get; set; }
    }
}
