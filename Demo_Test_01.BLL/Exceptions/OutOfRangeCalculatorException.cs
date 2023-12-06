using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Test_01.BLL.Exceptions
{
    public class OutOfRangeCalculatorException : Exception
    {
        public OutOfRangeCalculatorException(): base() { }
        public OutOfRangeCalculatorException(string message): base(message) { }
    }
}
