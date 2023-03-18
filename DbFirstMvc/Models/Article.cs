using System;
using System.Collections.Generic;

namespace DbFirstMvc.Models
{
    public partial class Article
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public DateTime? Createdon { get; set; }
        public string? Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
