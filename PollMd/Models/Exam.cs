﻿namespace PollMd.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }
    }
}
