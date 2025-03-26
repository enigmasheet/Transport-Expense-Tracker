using System;
using System.Collections.Generic;

namespace ABCarriers.Models;

public partial class Category
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public int? created_by { get; set; }

    public int? updated_by { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
