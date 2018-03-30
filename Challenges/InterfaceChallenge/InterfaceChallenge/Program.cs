using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            MyInterface m = new MyInterface();
            
            string input = "";
            do
            {
                Console.WriteLine("Enter a number for the upper bound: ");
                input = Console.ReadLine();
                if(Double.TryParse(input, out double result))
                {
                    Console.WriteLine("Random Number is: " + m.GetRandomNum(result));
                }

            } while (!input.Equals("exit"));
        }
    }
}
