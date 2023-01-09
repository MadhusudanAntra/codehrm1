using Recruiting.ApplicationCore.Contracts.Repositories;
using Recruiting.ApplicationCore.Contracts.Services;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Exceptions;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Helpers;
using Recruiting.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Services
{
    public class SubmissionService : ISubmissionService
    {
        ISubmissionRepository submissionRepository;
        ICandidateRepository candidateRepository;
        public SubmissionService(ISubmissionRepository _Submissions, ICandidateRepository candidateRepository)
        {
            submissionRepository = _Submissions;
            this.candidateRepository = candidateRepository;
        }

        //Check if the candidate's submission is linked with jR to see if candidate has already submitted a submission to that same jR
        public async Task<int> AddSubmissionAsync(SubmissionRequestModel model)
        {
            var candidateJRSubs = await candidateRepository.FirstOrDefaultWithIncludesAsync(x => x.Id == model.CandidateId, x=> x.Submissions);
            var exists = candidateJRSubs.Submissions.FirstOrDefault(s => s.JobRequirementId == model.JobRequirementId);

            if (exists != null)
            {
                throw new Exception("Submission already made");
            }
            Submission submission = new Submission();
            if (model != null)
            {
                submission.JobRequirementId = model.JobRequirementId;
                submission.CandidateId = model.CandidateId;
                submission.SubmittedOn = model.SubmittedOn;
                submission.ConfirmedOn = model.ConfirmedOn;
                submission.RejectedOn = model.RejectedOn;
            }
            //returns number of rows affected, typically 1
            return await submissionRepository.InsertAsync(submission);
        }

        public async Task<int> DeleteSubmissionAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await submissionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissions()
        {
            var submissions = await submissionRepository.GetAllAsync();
            var response = submissions.Select(x => x.ToSubmissionResponseModel());
            return response;
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
        {
            var sub = await submissionRepository.GetByIdAsync(id);
            if (sub != null)
            {
                var response = sub.ToSubmissionResponseModel();
                return response;
            }
            else
            {
                throw new NotFoundException("EmployeeType", id);
            }
        }

        public async Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            var existingSubmission = await submissionRepository.GetByIdAsync(model.Id);
            if (existingSubmission == null)
            {
                throw new Exception("Submission does not exist");
            }
            Submission submission = new Submission();
            if (model != null)
            {
                submission.Id = model.Id;
                submission.JobRequirementId = model.JobRequirementId;
                submission.CandidateId = model.CandidateId;
                submission.SubmittedOn = model.SubmittedOn;
                submission.ConfirmedOn = model.ConfirmedOn;
                submission.RejectedOn = model.RejectedOn;
                return await submissionRepository.UpdateAsync(submission);
            }
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}
