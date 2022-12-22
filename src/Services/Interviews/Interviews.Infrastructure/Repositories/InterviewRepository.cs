using System.Data;
using Interviews.ApplicationCore.Contracts.Repositories;
using Interviews.ApplicationCore.Entities;
using Interviews.Infrastructure.Data;
using Dapper;

namespace Interviews.Infrastructure.Repositories;

public class InterviewRepository : IInterviewRepository
{
    private readonly DbConnection _dbConnection;

    public InterviewRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<Interview> Create(Interview entity)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync("INSERT INTO Interview VALUES(@InterviewId, @InterviewerId, @InterviewTypeCode, @RecruiterId, @SubmissionId, @BeginTime, @EndTime)", entity);
        return entity;
    }

    public async Task<Interview> Update(Interview entity)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync(
            "UPDATE Interview SET InterviewerId = @InterviewerId, @InterviewTypeCode = InterviewTypeCode, @RecruiterId = RecruiterId, SubmissionId = @SubmissionId, BeginTime = @BeginTime, EndTime = @EndTime  WHERE InterviewId = @InterviewId", entity);
        return entity;
    }

    public async Task Delete(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync("DELETE FROM Interview WHERE InterviewId = @InterviewId", new { InterviewId = id });
    }

    public async Task<IEnumerable<Interview>> GetAll()
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return await conn.QueryAsync<Interview>("SELECT InterviewId, InterviewerId, InterviewTypeCode, RecruiterId, SubmissionId,BeginTime, EndTime  FROM Interview");
    }

    public async Task<Interview> GetById(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return await conn.QuerySingleOrDefaultAsync<Interview>("SELECT InterviewId, InterviewerId, InterviewTypeCode, RecruiterId, SubmissionId,BeginTime, EndTime FROM Interview WHERE InterviewerId = @InterviewId", new{InterviewId = id});
    }

    public async Task<IEnumerable<Interview>> GetInterviewByDate(DateTime date)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Interview>> GetInterviewByInterviewer(int interviewerId)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return await conn.QueryAsync<Interview>("SELECT InterviewId, InterviewerId, InterviewTypeCode, RecruiterId, SubmissionId,BeginTime, EndTime  FROM Interview WHERE InterviewerId = @InterviewerId", new {InterviewerId = interviewerId});
    }
}