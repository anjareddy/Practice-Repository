using DesignPattern.AbstractFactory.Abstracts;

namespace DesignPattern.AbstractFactory
{
    public class OEMTestPackageFactory
    {
        public IOEMTestPackage GetOEMTestPackage(string oem)
        {
            return Create(oem);
        }

        private static IOEMTestPackage Create(string oem)
        {
            try
            {
                string className = $"DesignPattern.AbstractFactory.ConcreteFactories.{oem}TestPackageConcreteFactory";
                Type classType = Type.GetType(className);
                if (classType != null && classType.IsClass && !classType.IsAbstract)
                {
                    return Activator.CreateInstance(classType) as IOEMTestPackage;
                }
                else
                {
                    throw new Exception("UNSUPPORTED_OEM_TYPE");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
