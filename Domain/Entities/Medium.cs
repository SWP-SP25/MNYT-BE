﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Medium : BaseEntity
{
    public string? Type { get; set; }

    public string? Url { get; set; }
}
