using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Models
{
    public class SubmissionStatusRequestModel
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int StatusId { get; set; }
        public DateTime ChangedOn { get; set; }
        public string StatusMessage { get; set; }
    }
}
