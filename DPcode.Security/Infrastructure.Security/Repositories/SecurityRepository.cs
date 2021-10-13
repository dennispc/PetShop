using DPcode.Security.Infrastructure.Security.Entities;
using Infrastructure.Security.Repositories.IRepositories;

namespace Infrastructure.Security.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        public User AddUser(string username, string hashedPassword)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(string username, string hashedPassword)
        {
            throw new System.NotImplementedException();
        }

        public User UpdateUser(User u)
        {
            throw new System.NotImplementedException();
        }
    }
}