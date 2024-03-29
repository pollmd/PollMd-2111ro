﻿using System;
using System.Collections.Generic;

namespace PollMd2.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string UserId { get; set; } = null!;
        public int? ExamId { get; set; }
        public int Type { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
