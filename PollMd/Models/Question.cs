using System;

namespace PollMd.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string UserId { get; set; }
    }
}
