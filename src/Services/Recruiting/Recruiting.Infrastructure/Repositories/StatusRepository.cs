using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(RecruitingDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Status>> GetStatusByState(string state)
        {
            var statuses = await _dbContext.Statuses.Where(s => s.State == state).Include(s => s.Submission).ToListAsync();
            return statuses;
        }

    }
}
