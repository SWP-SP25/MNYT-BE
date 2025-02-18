﻿using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class Account
{
    public int AccountId { get; set; }

    public string AccountUserName { get; set; } = null!;

    public string AccountFullName { get; set; } = null!;

    public string AccountEmail { get; set; } = null!;

    public string AccountPassword { get; set; } = null!;

    public string? AccountPhoneNumber { get; set; }

    public string? AccountRole { get; set; }

    public string? AccountStatus { get; set; }

    public bool? AccountIsExternal { get; set; }

    public string? AccountExternalProvider { get; set; }

    public virtual ICollection<AccountMembership> AccountMemberships { get; set; } = new List<AccountMembership>();

    public virtual ICollection<BlogBookmark> BlogBookmarks { get; set; } = new List<BlogBookmark>();

    public virtual ICollection<BlogLike> BlogLikes { get; set; } = new List<BlogLike>();

    public virtual ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Pregnancy> Pregnancies { get; set; } = new List<Pregnancy>();
}
