using System;
using System.Collections.Generic;

#nullable disable

namespace Sess2.Models.Data
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        public short Shipperid { get; set; }
        public string Companyname { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
