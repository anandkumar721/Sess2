﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Sess2.Models.Data
{
    public partial class Customercustomerdemo
    {
        public string Customerid { get; set; }
        public string Customertypeid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Customerdemographic Customertype { get; set; }
    }
}
