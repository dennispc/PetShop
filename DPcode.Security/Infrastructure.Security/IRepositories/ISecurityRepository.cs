using DPcode.Security.Infrastructure.Security.Entities;

namespace Infrastructure.Security.Repositories.IRepositories
{
    public interface ISecurityRepository
    {
        User GetUser(string username, string hashedPassword);

        User AddUser(string username, string hashedPassword);

        bool DeleteUser(int id);

        User UpdateUser(User u);
    }
}