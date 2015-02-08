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
                    UserData = new List<UserData>
                    {
                        new UserData
                        {
                            Type = "Address",
                            Information = "123 Main St."
                        },
                        new UserData
                        {
                            Type = "SSN",
                            Information = "123-45-6789"
                        },
                        new UserData
                        {
                            Type = "Amazon.com Password",
                            Information = "123456",
                            Comment = "UserName: amazonUser"
                        }
                    }
                },
                new User
                { 
                    UserName = "user2",
                    Password = "123456",
                    UserData = new List<UserData>
                    {
                        new UserData
                        {
                            Type = "Address",
                            Information = "879 Second Ave."
                        },
                        new UserData
                        {
                            Type = "SSN",
                            Information = "987-65-4321"
                        },
                        new UserData
                        {
                            Type = "Google Password",
                            Information = "123456",
                            Comment = "UserName: test@gmail.com"
                        }
                    }
                }
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}
