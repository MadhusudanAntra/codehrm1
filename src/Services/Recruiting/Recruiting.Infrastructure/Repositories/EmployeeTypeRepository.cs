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
    public class EmployeeTypeRepository : BaseRepository<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(RecruitingDbContext context) : base(context)
        {
        }
        public async Task<EmployeeType> GetEmployeeTypeByTypeName(string typeName)
        {
            return await _dbContext.EmployeeTypes.Where(x => x.TypeName == typeName.ToLower()).FirstOrDefaultAsync();
        }
    }
}
