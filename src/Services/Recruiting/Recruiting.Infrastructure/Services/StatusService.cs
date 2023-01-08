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
    public class StatusService : IStatusService
    {
        IStatusRepository statusRepository;
        public StatusService(IStatusRepository _status)
        {
            statusRepository = _status;
        }
        public async Task<int> AddStatusAsync(StatusRequestModel model)
        {
            var existingStatus = await statusRepository.GetAllAsync();
            if (existingStatus != null && existingStatus.First(x => x.ChangedOn == existingStatus.Max(x => x.ChangedOn)).State == model.State)
            {
                throw new Exception("Status is not changing");
            }
            Status status = new Status();
            if (model != null)
            {
                status.State = model.State;
                status.ChangedOn = DateTime.Now;
                status.StatusMessage = model.StatusMessage;
            }
            //returns number of rows affected, typically 1
            return await statusRepository.InsertAsync(status);
        }

        public async Task<int> DeleteStatusAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await statusRepository.DeleteAsync(id);
        }

        public async Task<List<Status>> GetAllStatus()
        {
            return (await statusRepository.GetAllAsync()).ToList();
        }

        public async Task<int> UpdateStatusAsync(StatusRequestModel model)
        {
            var existingStatus = await statusRepository.GetAllAsync();
            if (existingStatus != null && existingStatus.First(x => x.ChangedOn == existingStatus.Max(x => x.ChangedOn)).State == model.State)
            {
                throw new Exception("Status is not changing");
            }
            Status status = new Status();
            if (model != null)
            {
                status.State = model.State;
                status.ChangedOn = DateTime.Now;
                status.StatusMessage = model.StatusMessage;
                return await statusRepository.UpdateAsync(status);
            }
            
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}
