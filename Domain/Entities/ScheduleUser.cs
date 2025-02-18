using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class ScheduleUser
{
    public int ScheduleUserId { get; set; }

    public int? PregnancyId { get; set; }

    public string? ScheduleUserTitle { get; set; }

    public string? ScheduleUserStatus { get; set; }

    public string? ScheduleUserType { get; set; }

    public DateOnly? ScheduleUserDate { get; set; }

    public string? ScheduleUserNote { get; set; }

    public virtual Pregnancy? Pregnancy { get; set; }
}
