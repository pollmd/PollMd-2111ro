using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PollMd.Models;

namespace PollMd.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PollMd.Models.Question> Question { get; set; }
        public DbSet<PollMd.Models.Answer> Answer { get; set; }
        public DbSet<PollMd.Models.Exam> Exam { get; set; }
    }
}