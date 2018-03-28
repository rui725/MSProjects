using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input= "";
            MyEventClass obj = new MyEventClass();
            obj.valueChanged += AddCurrentBalance;
            obj.maxReached += delegate (double cur, int max)
            {
                if(cur >= max)
                {
                    Console.WriteLine("You have reached the maximum limit " + max + 
                        " with your current balance at " + cur +" you can now withdraw money!");
                }
            };
            do
            {
                Console.WriteLine("How much is your deposit?");
                input = Console.ReadLine();
                if (Double.TryParse(input, out double result))
                {
                    obj.CurrentBalance = result;
                }
                else
                {
                    Console.WriteLine("Wrong Input Try again");
                }

            } while (!input.Equals("exit"));
        }

        public static void AddCurrentBalance(double n)
        {
            Console.WriteLine("The Current Balance is {0}", n);
        }
        
    }
}
