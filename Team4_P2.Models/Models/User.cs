﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Team4_P2.Models.Models
{
    public class User
    {
        public int UserId { get; set; }
        public Role Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Admin Admin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        
        
    }
}
