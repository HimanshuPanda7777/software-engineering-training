using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    public class Calculator
    {
        public int Addme(int num1, int num2)
            {
            return num1 + num2;
        }
        public int Subtractme(int num1, int num2) => num1 - num2;
        public int Productme(int num1, int num2) => num1 * num2;
        public float Divme(int num1, int num2)
        {
            float numRes;
            if (num2 > 0)
            {
                numRes = num1 / num2;
            }
            else
            {
                               throw new DivideByZeroException("You Cant divide by zero");

            }
            return numRes;
        }
    }
}
