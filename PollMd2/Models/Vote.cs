using System;
using System.Collections.Generic;

namespace PollMd2.Models
{
    public partial class Vote
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Answer? Answer { get; set; }
        public virtual Question? Question { get; set; }
    }
}
