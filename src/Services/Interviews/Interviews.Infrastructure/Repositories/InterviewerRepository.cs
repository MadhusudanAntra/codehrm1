using System.Data;
using Interviews.ApplicationCore.Contracts.Repositories;
using Interviews.ApplicationCore.Entities;
using Interviews.Infrastructure.Data;
using Dapper;

namespace Interviews.Infrastructure.Repositories;

public class InterviewerRepository : IInterviewerRepository
{
    private readonly DbConnection _dbConnection;

    public InterviewerRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<Interviewer> Create(Interviewer entity)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync("INSERT INTO Interviewer VALUES(@InterviewerId, @FirstName, @LastName, @EmployeeId)", entity);
        return entity;
    }

    public async Task<Interviewer> Update(Interviewer entity)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync(
            "UPDATE Interviewer SET FirstName = @FirstName, LastName = @LastName WHERE InterviewerId = @InterviewerId", entity);
        return entity;
    }

    public async Task Delete(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync("DELETE FROM Interviewer WHERE InterviewerId = @InterviewerId", new { InterviewerId = id });
    }

    public async Task<IEnumerable<Interviewer>> GetAll()
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return await conn.QueryAsync<Interviewer>("SELECT InterviewerId, FirstName, LastName, EmployeeId FROM Interviewer");
    }

    public async Task<Interviewer> GetById(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return await conn.QuerySingleOrDefaultAsync<Interviewer>("SELECT InterviewerId, FirstName, LastName, EmployeeId FROM Interviewer WHERE InterviewerId = @InterviewerId", new{InterviewerId = id});
    }
}