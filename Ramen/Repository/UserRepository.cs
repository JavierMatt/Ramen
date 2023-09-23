using Ramen.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Repository
{
    public class UserRepository
    {
        public static LocalDatabaseEntities db = new LocalDatabaseEntities();

        public static string registerUser(string name, string email, int roleId, string gender, string password)
        {
            User newUser = UserFactory.createUser(name, email, roleId, gender, password);

            db.Users.Add(newUser);
            db.SaveChanges();

            return "SUCCESS";
        }

        public static User getUser(int id, string username, string password)
        {
            return (from x in db.Users
                    where
                    (
                        (username == x.Username && password == x.Password) ||
                        id == x.Id                    )
                    select x
                    ).FirstOrDefault();
        }

        public static List<User> getUserByRole(int roleId)
        {
            return (from x in db.Users
                    where x.RoleId == roleId
                    select x
                    ).ToList();
        }

        public static string updateUser(string username, string email, string gender, string password, string newUsername, string newEmail, string newGender)
        {
            User update = (from x in db.Users
                           where
                           (
                            username == x.Username &&
                            email == x.Email &&
                            gender == x.Gender &&
                            password == x.Password
                           )
                           select x
                          ).FirstOrDefault();
            if(update != null)
            {
                update.Username = newUsername;
                update.Email = newEmail;
                update.Gender = newGender;
                db.SaveChanges();
                return "Update Success";
            }
            return "User not found";
            

        }

    }
}