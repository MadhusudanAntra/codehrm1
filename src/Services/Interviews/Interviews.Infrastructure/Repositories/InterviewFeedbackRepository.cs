using System.Data;
using Interviews.ApplicationCore.Contracts.Repositories;
using Interviews.ApplicationCore.Entities;
using Interviews.Infrastructure.Data;
using Dapper;

namespace Interviews.Infrastructure.Repositories;

public class InterviewFeedbackRepository : IInterviewFeedbackRepository
{
    private readonly DbConnection _dbConnection;

    public InterviewFeedbackRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<InterviewFeedback> Create(InterviewFeedback entity)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync(
            "INSERT INTO InterviewFeedback VALUES(@InterviewFeedbackId, @Rating, @Comment, @InterviewId)",
            entity);
        return entity;
    }

    public async Task<InterviewFeedback> Update(InterviewFeedback entity)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync(
            "UPDATE InterviewFeedback SET Rating = @Rating, Comment = @Comment" +
            "WHERE InterviewFeedbackId = @InterviewFeedbackId",
            entity);
        return entity;
    }

    public async Task Delete(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync(
            "DELETE FROM InterviewFeedback WHERE InterviewFeedbackId = @InterviewFeedbackId", 
            new { InterviewFeedbackId = id });
    }

    public async Task<IEnumerable<InterviewFeedback>> GetAll()
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return await conn.QueryAsync<InterviewFeedback>(
            "SELECT InterviewFeedbackId, Rating, Comment, InterviewId FROM InterviewFeedback");
    }

    public async Task<InterviewFeedback> GetById(int id)
    {
        using (var conn = _dbConnection.GetConnection())
        {
            //IDbConnection conn = _dbConnection.GetConnection();
            return await conn.QuerySingleOrDefaultAsync<InterviewFeedback>(
                "SELECT InterviewFeedbackId, Rating, Comment, InterviewId" +
                "FROM InterviewFeedback WHERE InterviewFeedbackId = @InterviewFeedbackId",
                new { InterviewFeedbackId = id });
        }
    }
}