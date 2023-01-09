using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Contracts.Services
{
    public interface ISubmissionService
    {
        Task<int> AddSubmissionAsync(SubmissionRequestModel model);
        Task<int> UpdateSubmissionAsync(SubmissionRequestModel model);
        Task<int> DeleteSubmissionAsync(int id);
        Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissions();
        Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id);
    }
}
