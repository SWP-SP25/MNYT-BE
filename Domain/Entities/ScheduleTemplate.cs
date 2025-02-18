using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class ScheduleTemplate
{
    public int ScheduleTemplateId { get; set; }

    public int ScheduleTemplatePeriod { get; set; }

    public string? ScheduleTemplateType { get; set; }

    public string? ScheduleTemplateTitle { get; set; }

    public string? ScheduleTemplateDescription { get; set; }
}
