using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Entity.Framework.Code.First.Model.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entity.Framework.Code.First.TestSuit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Read_Users_Top10()
        {
            List<User> first10Users = null;
            using (var db = new DatabaseContext())
            {
                first10Users = db.Users.OrderBy(user => user.Id).Take(10).ToList();
            }

            if (first10Users == null)
                Assert.Fail("no users found in database");

            first10Users.ForEach(user => Assert.IsNotNull(user.Fname));
        }

        [TestMethod]
        public void Update_UserType()
        {
            List<User> first10Users = null;
            List<User> updatedFirst10Users = null;
            UserType firstUserType = null;

            using (var db = new DatabaseContext())
            {
                firstUserType = db.UserTypes.First();

                if (firstUserType == null)
                    Assert.Fail("user types not found");

                first10Users = db.Users.OrderBy(user => user.Id).Take(10).ToList();

                first10Users.ForEach(user => user.UserTypeId = firstUserType.Id);
                db.SaveChanges();

                updatedFirst10Users = db.Users.OrderBy(user => user.Id).Take(10).ToList();
            }

            if (first10Users == null)
                Assert.Fail("no users found in database");

            updatedFirst10Users.ForEach(user => Assert.AreEqual(user.UserTypeId, firstUserType.Id));
        }

        [TestMethod]
        public void Insert_UserPermissions()
        {
            var rnd = new Random();

            List<User> first10Users = null;
            List<User> updatedFirst10Users = null;
            Permission permission = null;

            using (var db = new DatabaseContext())
            {
                var permissions = db.Permissions.ToList();

                first10Users = db.Users.OrderBy(user => user.Id).Take(10).ToList();

                foreach (var user in first10Users)
                {
                    user.Permissions = new Collection<Permission>();
                    user.Permissions.Add(permissions[rnd.Next(permissions.Count)]);
                }

                db.SaveChanges();

                updatedFirst10Users = db.Users.Include("Permissions").OrderBy(user => user.Id).Take(10).ToList();
            }

            updatedFirst10Users.ForEach(user => Assert.IsNotNull(user.Permissions));

            foreach (var user in updatedFirst10Users)
            {
                var oldUser = first10Users.FirstOrDefault(user1 => user1.Id == user.Id);
                if (oldUser == null)
                    Assert.Fail("can not get the user");
                Assert.AreEqual(user.Permissions.First().Type, oldUser.Permissions.First().Type);
            }
        }

        [TestMethod]
        public void Delete_Permissions()
        {
            List<Permission> updatedPermissions = null;
            using (var db = new DatabaseContext())
            {
                var users = db.Users.Include("Permissions").ToList();
                users.ForEach(user => user.Permissions = null);
                db.SaveChanges();

                var permissions = db.Permissions.ToList();
                db.Permissions.RemoveRange(permissions);
                db.SaveChanges();

                updatedPermissions = db.Permissions.ToList();
            }

            Assert.AreEqual(0, updatedPermissions.Count);
        }
    }
}
