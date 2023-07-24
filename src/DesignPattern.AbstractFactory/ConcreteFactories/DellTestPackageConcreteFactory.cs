using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.AbstractFactory.Abstracts;
using DesignPattern.AbstractFactory.ConcreteTypes;

namespace DesignPattern.AbstractFactory.ConcreteFactories
{
    public class DellTestPackageConcreteFactory : IOEMTestPackage
    {
        public ITestRunSuite GetTestRunSuite()
        {
            return new DellTestRunSuite();
        }

        public IReportGenerator GetReportGenerator()
        {
            return new DellReportGenerator();
        }
    }
}
