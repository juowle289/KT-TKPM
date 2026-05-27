using CommandService.Models;

namespace CommandService.Service
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
    }
}
