namespace CleanArchitecture.Domain.Entities
{
    using Domain.Primitives;

    public class Webinar: Entity
    {
        public Webinar(Guid id, string name, string description, DateTime scheduledOn) : base(id)
        {
            Name = name;
            Description = description;
            ScheduledOn = scheduledOn;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime ScheduledOn { get; private set; }
    }
}
