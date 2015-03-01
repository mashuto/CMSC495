/****************************************************************
 * User.cs
 * CMSC 495
 * 
 * Revisions:
 * 2/22/2015    Matthew Kocin:      Initial Creation
 * 3/01/2015    Matthew Kocin       Updated fields for encryption
*****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_2_Project.Models
{
    public class User
    {
        public User()
        {
            UserData = new List<UserData>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }

        public virtual List<UserData> UserData { get; set; }
    }
}
