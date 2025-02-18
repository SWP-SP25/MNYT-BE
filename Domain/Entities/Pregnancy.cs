using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class Pregnancy
{
    public int PregnancyId { get; set; }

    public int? AccountId { get; set; }

    public string? PregnancyType { get; set; }

    public string? PregnancyStatus { get; set; }

    public DateOnly? PregnancyStartDate { get; set; }

    public DateOnly? PregnancyEndDate { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Fetus> Fetus { get; set; } = new List<Fetus>();

    public virtual ICollection<ScheduleUser> ScheduleUsers { get; set; } = new List<ScheduleUser>();
}
