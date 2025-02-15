﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class BlogPost
{
    public int BlogPostId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? ImageId { get; set; }

    public int? AuthorId { get; set; }

    public int? Period { get; set; }

    public string? Status { get; set; }

    public DateOnly? PublishedDay { get; set; }

    public virtual Account? Author { get; set; }

    public virtual ICollection<BlogBookmark> BlogBookmarks { get; set; } = new List<BlogBookmark>();

    public virtual ICollection<BlogLike> BlogLikes { get; set; } = new List<BlogLike>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
