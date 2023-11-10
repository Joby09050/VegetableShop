using System;
using System.Collections.Generic;

namespace GreenValley.Models;

public partial class CustomerDetail
{
    public int CustId { get; set; }

    public double? VgPrice { get; set; }

    public int? UserId { get; set; }

    public int? VegId { get; set; }

    public virtual Login? User { get; set; }

    public virtual VegetableDetail? Veg { get; set; }
}
