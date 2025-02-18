using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class MembershipPlan
{
    public int MembershipPlanId { get; set; }

    public string MembershipPlanName { get; set; } = null!;

    public string? MembershipPlanDescription { get; set; }

    public decimal MembershipPlanPrice { get; set; }

    public virtual ICollection<AccountMembership> AccountMemberships { get; set; } = new List<AccountMembership>();
}
