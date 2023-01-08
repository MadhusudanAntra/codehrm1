using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Entities;
using Recruiting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Repositories
{
    public class JobRequirementRepository : BaseRepository<JobRequirement>, IJobRequirementRepository
    {
        RecruitingDbContext _dbContext;
        public JobRequirementRepository(RecruitingDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<JobRequirement>> GetJobRequirementsIncludingCategory(Expression<Func<JobRequirement, bool>> filter)
        {
            return await _dbContext.JobRequirements.Include("JobCategory").Where(filter).ToListAsync();
        }
    }
}
