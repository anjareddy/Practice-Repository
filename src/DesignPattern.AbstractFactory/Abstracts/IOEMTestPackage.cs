using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory.Abstracts
{
    public interface IOEMTestPackage
    {
        ITestRunSuite GetTestRunSuite();

        IReportGenerator GetReportGenerator();
    }
}
