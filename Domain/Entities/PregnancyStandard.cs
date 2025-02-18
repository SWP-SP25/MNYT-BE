using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class PregnancyStandard
{
    public int PregnancyStandardId { get; set; }

    public string? PregnancyType { get; set; }

    public string? PregnancyStandardType { get; set; }

    public int? PregnancyStandardPeriod { get; set; }

    public decimal? PregnancyStandardMinimum { get; set; }

    public decimal? PregnancyStandardMaximum { get; set; }

    public string? PregnancyStandardUnit { get; set; }
}
