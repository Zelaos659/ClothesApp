using LogPass.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPassTwo.Data
{
    internal class Order
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public string? Status { get; set; }

        public string? TrackNumber { get; set; }

        public virtual Product? Product { get; set; }

        public virtual User? User { get; set; }
    }
}
