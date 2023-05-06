using System;
using System.Collections.Generic;

namespace PollMd2.Models
{
    public partial class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }
    }
}
