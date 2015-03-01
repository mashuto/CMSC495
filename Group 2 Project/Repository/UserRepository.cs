/****************************************************************
 * UserRepository.cs
 * CMSC 495
 * 
 * Revisions:
 * 2/22/2015    Matthew Kocin:      Initial Creation
 * 3/01/2015    Matthew Kocin       when getting user, encrypt pass to check against db
*****************************************************************/

using Group_2_Project.DAL;
using Group_2_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_2_Project.Repository
{
    public class UserRepository
    {
        public DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        public bool CheckUserNameExists(string userName)
        {
            return context.Users.Any(x => x.UserName == userName);
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            var key = context.Users.FirstOrDefault(x => x.UserName == userName).Key;
            var encryptedPass = Crypto.Encrypt(key, password, (EncryptionAlgorithm)0);
            return context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == encryptedPass);
        }

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(x => x.UserId == id);
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void AddUserData(UserData userData)
        {
            context.UserData.Add(userData);
            context.SaveChanges();
        }

        public IQueryable<UserData> GetUserData(User user)
        {
            return context.UserData.Where(x => x.User == user);
        }
    }
}
