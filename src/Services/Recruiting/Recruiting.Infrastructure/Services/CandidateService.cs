using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Services
{
    public class CandidateService : ICandidateService
    {
        ICandidateRepository candidateRepository;
        public CandidateService(ICandidateRepository _candidates)
        {
            candidateRepository = _candidates;
        }
        public async Task<int> AddCandidateAsync(CandidateCreateRequestModel model)
        {
            var existingCandidate = await candidateRepository.GetUserByEmail(model.Email);
            if(existingCandidate != null)
            {
                throw new Exception("Email is already used");
            }
            Candidate candidate = new Candidate();
            if (model != null)
            {
                candidate.FirstName = model.FirstName;
                candidate.MiddleName = model.MiddleName;
                candidate.LastName = model.LastName;
                candidate.Email = model.Email;
                candidate.ResumeURL = model.ResumeURL;
            }
            //returns number of rows affected, typically 1
            return await candidateRepository.InsertAsync(candidate);
        }

        public async Task<int> DeleteCandidateAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await candidateRepository.DeleteAsync(id);
        }

        public async Task<List<Candidate>> GetAllCandidates()
        {
            return (await candidateRepository.GetAllAsync()).ToList();
        }

        public async Task<int> UpdateCandidateAsync(CandidateCreateRequestModel model)
        {
            var existingCandidate = await candidateRepository.GetUserByEmail(model.Email);
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
