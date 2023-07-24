﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.AbstractFactory.Abstracts;

namespace DesignPattern.AbstractFactory.ConcreteTypes
{
    public class DellReportGenerator : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine($"Generating Report for {nameof(DellReportGenerator)}");
        }
    }
}