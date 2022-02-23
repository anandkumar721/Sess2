using System;
using System.Collections.Generic;

#nullable disable

namespace Sess2.Models.Data
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public short Productid { get; set; }
        public string Productname { get; set; }
        public short? Supplierid { get; set; }
        public short? Categoryid { get; set; }
        public string Quantityperunit { get; set; }
        public float? Unitprice { get; set; }
        public short? Unitsinstock { get; set; }
        public short? Unitsonorder { get; set; }
        public short? Reorderlevel { get; set; }
        public int Discontinued { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
