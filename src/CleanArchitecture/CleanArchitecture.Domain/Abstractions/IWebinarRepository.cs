using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Abstractions
{
    public interface IWebinarRepository
    {
        Task<int> CreateWebinar(Webinar webinar);
    }
}
