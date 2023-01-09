﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Entities
{
    public class Submission
    {
        public int Id { get; set; }
        public int JobRequirementId { get; set; }
        public int CandidateId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public DateTime ConfirmedOn { get; set; }
        public DateTime RejectedOn { get; set; }
        public List<SubmissionStatus> SubmissionStatus { get; set; }
        public JobRequirement JobRequirement { get; set; }
        public Candidate Candidate { get; set; }
    }
}
