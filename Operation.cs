using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class Operation
    {
        // Store result value for the specific operations
        private double sqrt { get; set; }
        private double sqr { get; set; }
        public Operation()
        {
            sqrt = 0;
            sqr = 0;
        }
        public double calculateSqrt(double num)
        {
            sqrt = Math.Sqrt(num);
            return sqrt;
        }
        public double calculateSqr(double num)
        {
            sqr = Math.Pow(num, 2);
            return sqr;
        }
    }
}
