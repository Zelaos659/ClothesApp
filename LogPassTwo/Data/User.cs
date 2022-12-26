using LogPassTwo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPass.Data
{
    internal class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }
        public int UserId { get; set; }
        
        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Access { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
