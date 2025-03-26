using System;
using System.Collections.Generic;

namespace ABCarriers.Models;

public partial class Vendor
{
    public int id { get; set; }

    public string vat_no { get; set; } = null!;

    public string name { get; set; } = null!;

    public int? location_id { get; set; }

    public string? contact { get; set; }

    public string? email { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public int? created_by { get; set; }

    public int? updated_by { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Location? location { get; set; }
}
