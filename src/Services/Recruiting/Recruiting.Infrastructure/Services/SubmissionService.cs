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
    public class SubmissionService : ISubmissionService
    {
        ISubmissionRepository submissionRepository;
        public SubmissionService(ISubmissionRepository _Submissions)
        {
            submissionRepository = _Submissions;
        }
        public async Task<int> AddSubmissionAsync(SubmissionRequestModel model)
        {
            var existingSubmission = await submissionRepository.GetUserByEmail(model.Email);
            if (existingSubmission != null)
            {
                throw new Exception("Email is already used");
            }
            Submission submission = new Submission();
            if (model != null)
            {
                submission.FirstName = model.FirstName;
                submission.MiddleName = model.MiddleName;
                submission.LastName = model.LastName;
                submission.Email = model.Email;
                submission.ResumeURL = model.ResumeURL;
            }
            //returns number of rows affected, typically 1
            return await submissionRepository.InsertAsync(submission);
        }

        public async Task<int> DeleteSubmissionAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await submissionRepository.DeleteAsync(id);
        }

        public async Task<List<Submission>> GetAllSubmissions()
        {
            return (await submissionRepository.GetAllAsync()).ToList();
        }

        public async Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            var existingSubmission = await submissionRepository.GetUserByEmail(model.Email);
            if (existingSubmission == null)
            {
                throw new Exception("Submission does not exist");
            }
            Submission submission = new Submission();
            if (model != null)
            {
                submission.SubmissionId = model.SubmissionId;
                submission.FirstName = model.FirstName;
                submission.MiddleName = model.MiddleName;
                submission.LastName = model.LastName;
                submission.Email = model.Email;
                submission.ResumeURL = model.ResumeURL;
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
