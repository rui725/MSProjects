using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegadeChallenges
{
    class Program
    {
        public delegate string MyInput();
        public delegate double MyResult(int z, double p);
        static void Main(string[] args)
        {
            MyInput input = askMeZone;
            MyResult res = Answer;
            while(Int32.TryParse(input().ToString(), out int zone))
            {
              
                    input = askMeItemPrice;
                    if(Double.TryParse(input().ToString(), out double price) && zone > 0 && zone <5)
                    {
                        if(zone == 2 || zone == 4)
                        {
                            Console.WriteLine(res(zone, price) + res(--zone,price));
                        }
                        else
                        {
                            Console.WriteLine(res(zone, price));
                        }
                        input = askMeZone;
                    }
            }
        }
        static string askMeZone()
        {
            Console.WriteLine("What is the destination zone[1-4]?");
            return Console.ReadLine();
        }
        static string askMeItemPrice()
        {
            Console.WriteLine("What is the Item Price?");
            return Console.ReadLine();
        }
        static double Answer(int zone, double price)
        {
            double []Zone = { .25, .12, .08, .04 };

            return Zone[zone-1]*price;
        }
    }
}
