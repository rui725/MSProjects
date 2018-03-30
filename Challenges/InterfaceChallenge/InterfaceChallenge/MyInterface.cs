using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InterfaceChallenge
{
    interface IRandomizable
    {
        double GetRandomNum(double n);
    }
    class MyInterface : IRandomizable
    {
        
        public double GetRandomNum(double n)
        {
            Random r = new Random();
            n = r.NextDouble() * (n - 0);
            return n;
        }

    }
}
