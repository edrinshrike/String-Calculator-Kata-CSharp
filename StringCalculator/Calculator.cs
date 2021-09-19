using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Calculate(string numbers)
        {
            if(string.IsNullOrEmpty(numbers)) { return 0; }

            char operand = '+';

            List<char> possibleOperands = new List<char> { '+', '-', '*', '/' };

            if (possibleOperands.Contains(numbers.Last()))
            {
                operand = numbers.Last();
                numbers = numbers.Remove(numbers.Length - 2, 2);
            }

            var numArray = numbers.Split(',').Select(Int32.Parse).ToList();

            if (CheckForNegatives(numArray))
            {
                throw new InvalidOperationException("negatives not allowed");
            }

            int result = numArray[0];

            for(int i = 1; i < numArray.Count();  i++)
            {

                switch (operand)
                {
                    case '+':
                        result += numArray[i];
                        break;

                    case '-':
                        result -= numArray[i];
                        break;

                    case '*':
                        result *= numArray[i];
                        break;

                    case '/':
                        result /= numArray[i];
                        break;
                }
            }

            return result;
        }

        bool CheckForNegatives(List<int> numbers)
        {
            bool hasNegatives = false;

            foreach(int i in numbers)
            {
                if (i < 0)
                {
                    hasNegatives = true;
                }
            }

            return hasNegatives;
        }
    }
}
