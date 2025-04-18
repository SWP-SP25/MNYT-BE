﻿namespace Domain.Entities;

public partial class BlogLike : BaseEntity
{
    public int? AccountId { get; set; }

    public int? PostId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual BlogPost? Post { get; set; }
}
