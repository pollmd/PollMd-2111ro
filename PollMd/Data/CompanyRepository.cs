using PollMd.Models;
using Dapper;

namespace PollMd.Data
{
    public class CompanyRepository: ICompanyRepository
    {
        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<Exam> GetExams()
        {
            using(var connection = _context.CreateConnection())
            {
                return connection.Query<Exam>(@"SELECT [Id],[Name],[CreatedOn],
                                    [Active] FROM [db_a94da4_pollmd].[dbo].[Exam]");
            }
        }
    }

    public interface ICompanyRepository
    {
        public IEnumerable<Exam> GetExams();
    }
}
