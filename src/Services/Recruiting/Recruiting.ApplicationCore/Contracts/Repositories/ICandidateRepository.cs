using Recruiting.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Contracts.Repositories
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        Task<Candidate> GetUserByEmail(string email);
        Task<Candidate> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidate, bool>> where,
          params Expression<Func<Candidate, object>>[] includes);
    }
}
