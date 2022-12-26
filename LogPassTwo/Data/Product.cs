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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order = new HashSet<Order>();
        }
        public int ProductId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
        
        public int Count { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public BitmapSource ImgFromBD { get { return WorkWithBD.ConvertByteToImage(Photo); } }
        public string PriceString { get { return $"{Price} ₽"; } }
        public string CountString { get { return $"На складе: \t{Count}"; } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
