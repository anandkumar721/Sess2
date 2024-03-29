﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Sess2.Models.Data
{
    public partial class Employee
    {
        public Employee()
        {
            Employeeterritories = new HashSet<Employeeterritory>();
            InverseReportstoNavigation = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        public short Employeeid { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Title { get; set; }
        public string Titleofcourtesy { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? Hiredate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public string Homephone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public short? Reportsto { get; set; }
        public string Photopath { get; set; }

        public virtual Employee ReportstoNavigation { get; set; }
        public virtual ICollection<Employeeterritory> Employeeterritories { get; set; }
        public virtual ICollection<Employee> InverseReportstoNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
