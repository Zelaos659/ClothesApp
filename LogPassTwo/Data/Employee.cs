﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPass.Data
{
    internal class Employee
    {
        public int id { get; set; }
        
        public string? login { get; set; }

        // Шифрование через set;
        public string? password { get; set; }

        public string? role { get; set; }
    }
}