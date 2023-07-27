using DesignPattern.Common.Enums;

namespace DesignPattern.Common.Models
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public dynamic Configuration { get; set; }
        public dynamic PrerequisiteInfo { get; set; }
        public TestApplicationEnum TestApp { get; set; }

        public List<string> TestSteps { get; set; }
    }

    public enum TestApplicationEnum
    {
        CrystalDiskMark,
        ATTO,
        AS_SSD,
        IOMeter,
    }
}
