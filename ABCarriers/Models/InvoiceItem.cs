using System;
using System.Collections.Generic;

namespace ABCarriers.Models;

public partial class InvoiceItem
{
    public int Id { get; set; }

    public int? InvoiceId { get; set; }

    public int? CategoryId { get; set; }

    public int Quantity { get; set; }

    public decimal? Rate { get; set; }

    public decimal? TaxableAmount { get; set; }

    public decimal? VatAmount { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Invoice? Invoice { get; set; }
}
