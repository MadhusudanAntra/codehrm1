﻿using Recruiting.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Contracts.Repositories
{
    public interface ISubmissionRepository : IRepository<Submission>
    {
        public Task<Submission> GetSubmissionsByJobAndCandidateId(int jobReqId, int candidateId);
    }
}
