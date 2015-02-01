using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_2_Project.Models
{
    class User
    {
        public User()
        {
            Passwords = new List<UserPassword>();
            Information = new List<UserInformation>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual List<UserPassword> Passwords { get; set; }
        public virtual List<UserInformation> Information { get; set; }
    }
}
