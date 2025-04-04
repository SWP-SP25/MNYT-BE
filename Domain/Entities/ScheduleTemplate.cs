﻿namespace Domain.Entities;

public partial class ScheduleTemplate : BaseEntity
{
    public int Period { get; set; }

    public string? Type { get; set; }

    public string Tag { get; set; }

    public string? Title { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ScheduleUser> ScheduleUser { get; set; } = new List<ScheduleUser>();
}
