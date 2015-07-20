using System.Data.Entity;

namespace Entity.Framework.Code.First.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=UserDBConnectionString")
        {

        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
