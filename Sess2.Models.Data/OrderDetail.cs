using System;
using System.Collections.Generic;

#nullable disable

namespace Sess2.Models.Data
{
    public partial class OrderDetail
    {
        public short Orderid { get; set; }
        public short Productid { get; set; }
        public float Unitprice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
