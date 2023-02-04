namespace PollMd.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
