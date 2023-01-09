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
    public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(RecruitingDbContext context) : base(context)
        {
        }

        public async Task<Submission> GetSubmissionsByJobAndCandidateId(int jobReqId, int candidateId)
        {
            return await _dbContext.Submissions.Where(x => x.JobRequirementId == jobReqId && x.CandidateId == candidateId).FirstOrDefaultAsync();
        }
    }
}
