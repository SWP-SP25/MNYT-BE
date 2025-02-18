using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class FetusRecord
{
    public int FetusRecordId { get; set; }

    public int FetusId { get; set; }

    public int? FetusRecordPeriod { get; set; }

    public int? FetusRecordInputPeriod { get; set; }

    public decimal? FetusRecordWeight { get; set; }

    public decimal? FetusRecordBpd { get; set; }

    public decimal? FetusRecordLength { get; set; }

    public decimal? FetusRecordHc { get; set; }

    public DateOnly? FetusRecordDate { get; set; }

    public virtual Fetus Fetus { get; set; } = null!;
}
