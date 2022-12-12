using LogPass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LogPassTwo.Data
{
    internal class Product
    {
        public int ProductId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public BitmapSource sass { get { return WorkWithBD.ConvertByteToImage(Photo); } }
        public string ass { get { return $"{Price} ₽"; } }
    }
}
