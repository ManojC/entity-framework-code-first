using System;
using System.Data.Entity;
using System.Linq;
using Entity.Framework.Code.First.Model.Model;

namespace Entity.Framework.Code.First.Model
{
    public class CodeFirstDatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            AddUserTypes(context);
            AddUsers(context);
            AddUserPermissions(context);
            base.Seed(context);
        }

        private void AddUserTypes(DatabaseContext db)
        {
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("UserType{0}", i);
                db.UserTypes.Add(new UserType()
                {
                    Name = name
                });
            }
            db.SaveChanges();
        }

        private void AddUsers(DatabaseContext db)
        {
            var rnd = new Random();
            var userTypes = db.UserTypes.ToList();

            for (int i = 0; i < 51; i++)
            {
                var userType = userTypes[rnd.Next(userTypes.Count)];
                string fname = string.Format("First Name {0}", i);
                string lname = string.Format("First Name {0}", i);

                userType.Users.Add(new User()
                {
                    Fname = fname,
                    Lname = lname
                });
            }
            db.SaveChanges();
        }

        private void AddUserPermissions(DatabaseContext db)
        {
            for (int i = 0; i < 10; i++)
            {
                string type = string.Format("Type{0}", i);
                db.Permissions.Add(new Permission()
                {
                    Type = type
                });
            }
            db.SaveChanges();
        }
    }
}
