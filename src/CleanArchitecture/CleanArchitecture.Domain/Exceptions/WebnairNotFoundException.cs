namespace CleanArchitecture.Domain.Exceptions
{
    public class WebnairNotFoundException: NotFoundException
    {
        public WebnairNotFoundException(Guid id) : base($"The webnair with identifier {id} was not found.")
        {
        }
    }
}
