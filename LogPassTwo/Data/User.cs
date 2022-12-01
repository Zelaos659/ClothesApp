using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPass.Data
{
    internal class User
    {
        public int UserId { get; set; }
        
        public string? Phone { get; set; }

        // Шифрование через set;
        public string? Password { get; set; }

        public string? Access { get; set; }
    }
}
