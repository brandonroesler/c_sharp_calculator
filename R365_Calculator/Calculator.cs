using System;
using System.Collections.Generic;

namespace R365_Calculator
{
    public class Calculator
    {
        public int Add(string args)
        {
            string[] values = args.Split(",");
            int returnValue = 0;
            List<int> negatives = new List<int>();
            foreach (string el in values)
            {
                int number;
                bool result = int.TryParse(el, out number);
                if (number < 1001 && number > 0)
                {
                    returnValue = returnValue + number;
                }
                if (number < 0)
                {
                    negatives.Add(number);
                }
            }
            if (negatives.Count > 0)
            {
                string negativesString = String.Join(", ", negatives.ToArray());
                throw new ArgumentException(negativesString);
            }
            return returnValue;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
