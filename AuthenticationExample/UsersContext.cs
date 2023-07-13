using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationExample{
    public class UsersContext : IdentityUserContext<IdentityUser>{
        public UsersContext (DbContextOptions<UsersContext> options) : base(options){
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options){
            // It would be a good idea to move the connection string to user secrets
            options.UseNpgsql("User ID=devuser;Password=123456789;Server=localhost;Port=5432;Database=AuthenticationExampleDb; Integrated Security=true;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
        }
    }
}