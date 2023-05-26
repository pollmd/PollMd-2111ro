using System;
using System.Collections.Generic;

namespace PollMd2.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
