using System.Data.Entity;

namespace Entity.Framework.Code.First.Model.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=UserDBConnectionString")
        {
            Database.SetInitializer(new CodeFirstDatabaseInitializer());
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
