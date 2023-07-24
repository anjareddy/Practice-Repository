using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.AbstractFactory.Abstracts;
using DesignPattern.AbstractFactory.ConcreteTypes;

namespace DesignPattern.AbstractFactory.ConcreteFactories
{
    public class AppleTestPackageConcreteFactory: IOEMTestPackage
    {
        public ITestRunSuite GetTestRunSuite()
        {
            return new AppleTestRunSuite();
        }

        public IReportGenerator GetReportGenerator()
        {
            return new AppleReportGenerator();
        }
    }
}
