using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_Test_01.BLL.Exceptions;
using Demo_Test_01.BLL.Interfaces;

namespace Demo_Test_01.BLL.Services
{
    public class CalculatorService : ICalculatorService
    {
        private double FormatValue(double val)
        {
            if (double.IsInfinity(val))
            {
                throw new OutOfRangeCalculatorException();
            }

            return Math.Round(val, 5);
        }

        public double Add(double nb, params double[] nbs)
        {
            double result = nb;

            foreach(double n in nbs)
            {
                result += n;
            }

            return FormatValue(result);
        }

        public int Add(int nb, params int[] nbs)
        {
            double res = Add(nb, nbs.Select(n => (double)n).ToArray());

            if(res > int.MaxValue || res < int.MinValue)
            {
                throw new OutOfRangeCalculatorException();
            }

            return (int)res;
        }

        public double Sub(double nb1, double nb2)
        {
            double result = nb1 - nb2;
            return FormatValue(result);
        }


        public double Div(double nb1, double nb2)
        {
            if(nb2 == 0)
            {
                throw new DivByZeroCalculatorException();
            }

            double result = nb1 / nb2;
            return FormatValue(result);
        }

        public double Multi(double nb, params double[] nbs)
        {
            double result = nb;

            foreach (double n in nbs)
            {
                result *= n;
            }

            return FormatValue(result);
        }

    }
}
