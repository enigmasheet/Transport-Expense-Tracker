using System;
using System.Collections.Generic;

namespace ABCarriers.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public DateOnly Miti { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public int? VendorId { get; set; }

    public int? LocationId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual Location? Location { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
