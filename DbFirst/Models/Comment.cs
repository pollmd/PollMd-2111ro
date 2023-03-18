using System;
using System.Collections.Generic;

namespace DbFirst.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? Articleid { get; set; }
        public string? Text { get; set; }
        public DateTime? Createdon { get; set; }
        public string? Author { get; set; }

        public virtual Article? Article { get; set; }
    }
}
