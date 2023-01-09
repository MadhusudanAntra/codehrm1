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
    public class JobCategoryRepository : BaseRepository<JobCategory>, IJobCategoryRepository
    {
        public JobCategoryRepository(RecruitingDbContext context) : base(context)
        {
        }
    }
}
