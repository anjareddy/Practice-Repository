namespace DesignPattern.CQRS
{
    public interface ICommand
    {
        Guid Id { get; }
        Guid CreatedBy { get; set; }
        DateTimeOffset CreatedOn { get; set; }
        Guid UpdatedBy { get; set; }
        DateTimeOffset UpdatedOn { get; set; }
    }
}