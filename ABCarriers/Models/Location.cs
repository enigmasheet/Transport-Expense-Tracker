using System;
using System.Collections.Generic;

namespace ABCarriers.Models;

public partial class Location
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public int? created_by { get; set; }

    public int? updated_by { get; set; }

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
