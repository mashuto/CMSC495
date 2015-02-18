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
    }
}
