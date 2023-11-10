using System;
using System.Collections.Generic;

namespace GreenValley.Models;

public partial class Login
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public virtual ICollection<CustomerDetail> CustomerDetails { get; set; } = new List<CustomerDetail>();

    public virtual ICollection<VegetableDetail> VegetableDetails { get; set; } = new List<VegetableDetail>();
}
