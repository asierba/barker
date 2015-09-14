using Barker.App.Entities;

namespace Barker.External.Repositories
{
    public interface IUserRepository
    {
        User Get(string username);
        void Add(User user);
    }
}