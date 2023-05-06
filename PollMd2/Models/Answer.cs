using System;
using System.Collections.Generic;

namespace PollMd2.Models
{
    public partial class Answer
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int QuestionId { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
