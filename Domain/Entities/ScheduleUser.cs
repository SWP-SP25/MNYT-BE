﻿namespace Domain.Entities;

public partial class ScheduleUser : BaseEntity
{
    public string? Title { get; set; }

    public string? Status { get; set; }

    public string? Type { get; set; }

    public DateOnly? Date { get; set; }

    public string? Note { get; set; }

    public int? PregnancyId { get; set; }
    public virtual Pregnancy? Pregnancy { get; set; }
}
