using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace CalculatorFramework.Elements
{
    public class Wait
    {
        public void WaitFor(int timeoutMs)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (!(timer.ElapsedMilliseconds > timeoutMs))
            {
                Thread.Sleep(1000);
            }
        }

        public void WaitFor(int timeoutMs, Func<bool> condition)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while((timer.ElapsedMilliseconds <= timeoutMs) && !condition())
            {
                Thread.Sleep(1000);
            }
        }
    }
}
