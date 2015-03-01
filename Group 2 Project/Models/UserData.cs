/****************************************************************
 * UserData.cs
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
    public class UserData
    {
        public int UserDataId { get; set; }
        public User User { get; set; }
        public string Type { get; set; }
        public string Information { get; set; }
        public string Comment { get; set; }
        public string Key { get; set; }
        public int Encryption { get; set;
        }
    }
}
