using System;
using System.Collections.Generic;

namespace ABCarriers.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
