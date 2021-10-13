using DPcode.Security.Infrastructure.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Security
{
    public class SecurityContext : DbContext{

        
        public string DbPath { get; private set; }
        public SecurityContext(DbContextOptions<SecurityContext> opt) 
        : base(opt)
        {
            
        }

        public DbSet<User> users{get;set;}
    }
}
