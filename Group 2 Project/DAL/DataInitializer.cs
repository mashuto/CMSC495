using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Group_2_Project.Models;

namespace Group_2_Project.DAL
{
    class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var users = new List<User>
            {
                new User
                { 
                    UserName = "user1",
                    Password = "123456",
                    Passwords = new List<UserPassword>
                    { 
                        new UserPassword
                        { 
                            Site = "amazon",
                            UserName = "user1amazon",
                            Password = "654321"
                        },
                        new UserPassword
                        {
                            Site = "yahoo",
                            UserName = "user1yahoo",
                            Password = "abc"
                        }
                    },
                    Information = new List<UserInformation>
                    {
                        new UserInformation
                        {
                            Type = "Address",
                            Information = "123 Main St."
                        },
                        new UserInformation
                        {
                            Type = "SSN",
                            Information = "123-45-6789"
                        }
                    }
                },
                new User
                { 
                    UserName = "user2",
                    Password = "123456",
                    Passwords = new List<UserPassword>
                    { 
                        new UserPassword
                        { 
                            Site = "google",
                            UserName = "user2google",
                            Password = "test"
                        },
                        new UserPassword
                        {
                            Site = "facebook",
                            UserName = "user2facebook",
                            Password = "newtest"
                        }
                    },
                    Information = new List<UserInformation>
                    {
                        new UserInformation
                        {
                            Type = "Address",
                            Information = "879 Second Ave."
                        },
                        new UserInformation
                        {
                            Type = "SSN",
                            Information = "987-65-4321"
                        }
                    }
                }
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}
