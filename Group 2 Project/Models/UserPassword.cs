using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_2_Project.Models
{
    class UserPassword
    {
        public int UserPasswordId { get; set; }
        public User User { get; set; }
        public string Site { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
