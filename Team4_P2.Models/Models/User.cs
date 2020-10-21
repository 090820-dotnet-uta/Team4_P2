using System;
using System.Collections.Generic;
using System.Text;

namespace Team4_P2.Models.Models
{
    public class User
    {
        public int UserId { get; set; }
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Char Gender { get; set; }
        
    }
}
