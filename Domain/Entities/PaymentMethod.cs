using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public string? PaymentMethodVia { get; set; }

    public string? PaymentMethodDescription { get; set; }

    public virtual ICollection<AccountMembership> AccountMemberships { get; set; } = new List<AccountMembership>();
}
