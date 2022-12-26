﻿using LogPassTwo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPass.Data
{
    internal class User
    {
        public int UserId { get; set; }

        public string SecondName { get; set; }

        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        
        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Access { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}
