using System;
using System.Linq;
using Entity.Framework.Code.First.Model;
using Entity.Framework.Code.First.Model.Model;

namespace Entity.Framework.Code.First
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DatabaseContext())
            {
                AddUserTypes(db);
                AddUsers(db);
                AddUserPermissions(db);
            }
        }
        
        private static void AddUserTypes(DatabaseContext db)
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

        private static void AddUsers(DatabaseContext db)
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

        private static void AddUserPermissions(DatabaseContext db)
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
