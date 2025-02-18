using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class BlogBookmark
{
    public int BlogBookmarkId { get; set; }

    public int? AccountId { get; set; }

    public int? PostId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual BlogPost? Post { get; set; }
}
