using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string State { get; set; }

        //naviagational property
        public List<SubmissionStatus> SubmissionStatuses { get; set; }
    }
}
