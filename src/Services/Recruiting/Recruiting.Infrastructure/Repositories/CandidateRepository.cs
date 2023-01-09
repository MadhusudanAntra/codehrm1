using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Entities;
using Recruiting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Repositories
{
    public class CandidateRepository :BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RecruitingDbContext context) : base(context)
        {
        }

        public async Task<Candidate> GetUserByEmail(string email)
        {
            return await _dbContext.Candidates.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
