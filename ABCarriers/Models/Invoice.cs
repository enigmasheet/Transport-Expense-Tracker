﻿using System;
using System.Collections.Generic;

namespace ABCarriers.Models;

public partial class Invoice
{
    public int id { get; set; }

    public DateOnly miti { get; set; }

    public string invoice_no { get; set; } = null!;

    public int? vendor_id { get; set; }

    public int? location_id { get; set; }

    public int? category_id { get; set; }

    public decimal quantity { get; set; }

    public decimal? rate { get; set; }

    public decimal? taxable_amount { get; set; }

    public decimal? vat_amount { get; set; }

    public decimal? total_amount { get; set; }

    public int? unit_id { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public int? created_by { get; set; }

    public int? updated_by { get; set; }

    public virtual Category? category { get; set; }

    public virtual Unit? unit { get; set; }

    public virtual Vendor? vendor { get; set; }
}
