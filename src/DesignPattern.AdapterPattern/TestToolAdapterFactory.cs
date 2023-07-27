
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DesignPattern.AdapterPattern
{
    public class TestToolAdapterFactory
    {
        public static ITestToolAdapter GetTestToolAdapterType(string application)
        {
            string className = $"DesignPattern.AdapterPattern.{application}Adapter";
            return Create(className);
        }

        private static ITestToolAdapter Create(string fullyQualifiedName)
        {
            try
            {
                Type classType = Type.GetType(fullyQualifiedName);
                if (classType != null && classType.IsClass && !classType.IsAbstract)
                {
                    return Activator.CreateInstance(classType) as ITestToolAdapter;
                }
                else
                {
                    throw new Exception("UNSUPPORTED_APPLICATION_TYPE");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
