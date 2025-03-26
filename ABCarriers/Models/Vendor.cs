using System;
using System.Collections.Generic;

namespace ABCarriers.Models;

public partial class Vendor
{
    public int Id { get; set; }

    public string VatNo { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? LocationId { get; set; }

    public string? Contact { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Location? Location { get; set; }
}
