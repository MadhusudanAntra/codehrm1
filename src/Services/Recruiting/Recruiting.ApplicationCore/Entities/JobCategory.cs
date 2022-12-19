using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Entities
{
    public class JobCategory
    {
        /*
         public enum JobType
    {
        Employee = 1,
        Manager = 2
    }*/
        public int Id { get; set; }
        public string Name { get; set; }
        public List<JobRequirementCategory> JobRequirementCategories { get; set; }
    }
}
