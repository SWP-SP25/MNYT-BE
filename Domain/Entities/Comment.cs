using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? AccountId { get; set; }

    public int? BlogPostId { get; set; }

    public int? ReplyId { get; set; }

    public string? CommentStatus { get; set; }

    public string? CommentContent { get; set; }

    public virtual Account? Account { get; set; }

    public virtual BlogPost? BlogPost { get; set; }
}
