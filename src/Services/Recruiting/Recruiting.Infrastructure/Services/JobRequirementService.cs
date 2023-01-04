using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Services
{
    public class JobRequirementService : IJobRequirementService
    {
        IJobRequirementRepository jobRequirementRepository;
        public JobRequirementService(IJobRequirementRepository _jr)
        {
            jobRequirementRepository = _jr;
        }
        public async Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
        {
            var existingCandidate = await jobRequirementRepository.GetUserByEmail(model.Email);
            if (existingCandidate != null)
            {
                throw new Exception("Email is already used");
            }
            JobRequirement candidate = new JobRequirement();
            if (model != null)
            {
                candidate.FirstName = model.FirstName;
                candidate.MiddleName = model.MiddleName;
                candidate.LastName = model.LastName;
                candidate.Email = model.Email;
                candidate.ResumeURL = model.ResumeURL;
            }
            //returns number of rows affected, typically 1
            return await JobRequirementRepository.InsertAsync(candidate);
        }

        public async Task<int> DeleteJobRequirementAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await JobRequirementRepository.DeleteAsync(id);
        }

        public async Task<List<Candidate>> GetAllJobRequirements()
        {
            return (await JobRequirementRepository.GetAllAsync()).ToList();
        }

        public async Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            var existingCandidate = await JobRequirementRepository.GetUserByEmail(model.Email);
            if (existingCandidate == null)
            {
                throw new Exception("Candidate does not exist");
            }
            Candidate candidate = new Candidate();
            if (model != null)
            {
                candidate.CandidateId = model.CandidateId;
                candidate.FirstName = model.FirstName;
                candidate.MiddleName = model.MiddleName;
                candidate.LastName = model.LastName;
                candidate.Email = model.Email;
                candidate.ResumeURL = model.ResumeURL;
                return await candidateRepository.UpdateAsync(candidate);
            }
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}
