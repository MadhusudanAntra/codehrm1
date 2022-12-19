using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Entities
{
    public class JobRequirementCategory
    {
        public int Id { get; set; }
        public int JobRequirementId { get; set; }
        public string JobCategoryId { get; set; }
        public JobRequirement JobRequirement { get; set; }
        public JobCategory JobCategory { get; set; }
    }
}
