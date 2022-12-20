using Interviews.ApplicationCore.Entities;

namespace Interviews.ApplicationCore.Contracts.Repositories;

public interface IInterviewRepository : IAsyncRepository<Interview>
{
    Task<IEnumerable<Interview>> GetInterviewByDate(DateTime date);
    Task<IEnumerable<Interview>> GetInterviewByInterviewer(int interviewerId);
}