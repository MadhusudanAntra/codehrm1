using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Contracts.Services
{
    public interface ICandidateService
    {
    
        Task<int> AddCandidateAsync(CandidateCreateRequestModel model);
        Task<int> UpdateCandidateAsync(CandidateCreateRequestModel model);
        Task<int> DeleteCandidateAsync(int id);
        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);
        Task<List<Candidate>> GetAllCandidates();
    }
}
