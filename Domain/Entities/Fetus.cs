using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class Fetus
{
    public int FetusId { get; set; }

    public int PregnancyId { get; set; }

    public string? FetusName { get; set; }

    public string? FetusGender { get; set; }

    public virtual ICollection<FetusRecord> FetusRecords { get; set; } = new List<FetusRecord>();

    public virtual Pregnancy Pregnancy { get; set; } = null!;
}
