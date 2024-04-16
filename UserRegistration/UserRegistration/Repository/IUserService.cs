using UserRegistration.Model;

namespace UserRegistration.Repository
{
    public interface IUserService
    {
        Task<string> Register(User user);
    }
}
