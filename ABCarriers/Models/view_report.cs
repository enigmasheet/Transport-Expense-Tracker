using System;
using System.Collections.Generic;

namespace ABCarriers.Models;

public partial class view_report
{
    public DateOnly miti { get; set; }

    public string invoice_no { get; set; } = null!;

    public int? vendor_id { get; set; }

    public string vat_no { get; set; } = null!;

    public string name { get; set; } = null!;

    public int? location_id { get; set; }

    public string location_name { get; set; } = null!;

    public int? category_id { get; set; }

    public string category_name { get; set; } = null!;

    public decimal quantity { get; set; }

    public int? unit_id { get; set; }

    public string unit_name { get; set; } = null!;

    public decimal? rate { get; set; }

    public decimal? taxable_amount { get; set; }

    public decimal? vat_amount { get; set; }

    public decimal? total_amount { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}
