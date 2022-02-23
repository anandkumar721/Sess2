using System;
using System.Collections.Generic;

#nullable disable

namespace Sess2.Models.Data
{
    public partial class Employeeterritory
    {
        public short Employeeid { get; set; }
        public string Territoryid { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
