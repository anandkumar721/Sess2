using System;
using System.Collections.Generic;

#nullable disable

namespace Sess2.Models.Data
{
    public partial class Customerdemographic
    {
        public Customerdemographic()
        {
            Customercustomerdemos = new HashSet<Customercustomerdemo>();
        }

        public string Customertypeid { get; set; }
        public string Customerdesc { get; set; }

        public virtual ICollection<Customercustomerdemo> Customercustomerdemos { get; set; }
    }
}
