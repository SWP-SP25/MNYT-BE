﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Blog
{
    public class ReadCommentDTO
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string? AccountUserName { get; set; }
        public int? BlogPostId { get; set; }
        public int? ReplyId { get; set; }
        public string? Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
