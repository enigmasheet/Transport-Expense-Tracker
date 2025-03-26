using System;
using System.Collections.Generic;

namespace ABCarriers.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
