using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaChallenges
{
    public delegate void MyEventHandler(double v);
    public delegate void MyEventMaxHandler(double v, int n);
    class MyEventClass
    {
        private double theBalance = 0;
        private const int MAX = 500;
        public event MyEventHandler valueChanged;
        public event MyEventMaxHandler maxReached;
        public double CurrentBalance
        {
            set
            {
                this.theBalance += value;
                this.valueChanged(theBalance);
                this.maxReached(theBalance, MAX);
            }
        }

    }
}
