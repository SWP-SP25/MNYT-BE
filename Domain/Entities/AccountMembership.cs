using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class AccountMembership
{
    public int MembershipId { get; set; }

    public int? AccountId { get; set; }

    public int? MembershipPlanId { get; set; }

    public DateOnly? AccountMembershipStartDate { get; set; }

    public DateOnly? AccountMembershipEndDate { get; set; }

    public decimal? AccountMembershipPaymentAmount { get; set; }

    public string? AccountMembershipPaymentStatus { get; set; }

    public int? PaymentMethodId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual MembershipPlan? MembershipPlan { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }
}
