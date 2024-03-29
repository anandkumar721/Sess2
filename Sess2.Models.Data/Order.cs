﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Sess2.Models.Data
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public short Orderid { get; set; }
        public string Customerid { get; set; }
        public short? Employeeid { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; }
        public short? Shipvia { get; set; }
        public float? Freight { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
        public string Shipregion { get; set; }
        public string Shippostalcode { get; set; }
        public string Shipcountry { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Shipper ShipviaNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
