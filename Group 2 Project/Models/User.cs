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
            UserData = new List<UserData>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual List<UserData> UserData { get; set; }
    }
}
