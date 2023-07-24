using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.AbstractFactory.Abstracts;

namespace DesignPattern.AbstractFactory.ConcreteTypes
{
    public class AppleTestRunSuite : ITestRunSuite
    {
        public void Run()
        {
            Console.WriteLine($"Running Test Suite for {nameof(AppleTestRunSuite)}");
        }
    }
}
