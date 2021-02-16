using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
    }
}