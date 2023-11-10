using System;
using System.Collections.Generic;

namespace GreenValley.Models;

public partial class VegetableDetail
{
    public int VegId { get; set; }

    public string? VegName { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<CustomerDetail> CustomerDetails { get; set; } = new List<CustomerDetail>();

    public virtual Login? User { get; set; }
}
