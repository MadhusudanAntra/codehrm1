using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Exceptions;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Helpers;
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
        public async Task<int> AddCandidateAsync(CandidateRequestModel model)
        {
            // Get User By Email uses FirstorDefault which allows Null as return. 
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

        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidates()
        {
            var candidates = await candidateRepository.GetAllAsync();
            var response = candidates.Select(x => x.ToCandidateResponseModel());
            return response;
        }

        public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
        {
            var candidate = await candidateRepository.GetByIdAsync(id);
            if (candidate != null)
            {
                var response = candidate.ToCandidateResponseModel();
                return response;
            }
            else
            {
                throw new NotFoundException("Candidate", id);
            }
        }

        public async Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            var existingCandidate = await candidateRepository.GetByIdAsync(model.Id);
            if (existingCandidate == null)
            {
                throw new Exception("Candidate does not exist");
            }
            Candidate candidate = new Candidate();
            if (model != null)
            {
                candidate.Id = model.Id;
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
