using System;
using System.Collections.Generic;

namespace PollMd2.Models
{
    public partial class Answer
    {
        //public Answer()
        //{
        //    Votes = new HashSet<Vote>();
        //}
        public int Id { get; set; }
        public string? Text { get; set; }
        public int QuestionId { get; set; }
        public bool? IsCorrect { get; set; }
        public int? Votes { get; set; }
        public virtual Question Question { get; set; } = null!;
        //public virtual ICollection<Vote> Votes { get; set; }
    }
}
