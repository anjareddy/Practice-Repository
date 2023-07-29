using DesignPattern.Common.Enums;

namespace DesignPattern.Common.Models
{
    public class TestSuite
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public dynamic Configuration { get; set; }
        public dynamic PrerequisiteInfo { get; set; }

        public List<Test> Tests { get; set; }
    }
}
