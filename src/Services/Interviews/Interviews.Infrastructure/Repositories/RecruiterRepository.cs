using System.Data;
using Interviews.ApplicationCore.Contracts.Repositories;
using Interviews.ApplicationCore.Entities;
using Dapper;
using Interviews.Infrastructure.Data;

namespace Interviews.Infrastructure.Repositories;

public class RecruiterRepository : IRecruiterRepository
{
    private readonly DbConnection _dbConnection;

    public RecruiterRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<Recruiter> Create(Recruiter entity)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync("INSERT INTO Recruiter VALUES(@RecruiterId, @FirstName, @LastName, @EmployeeId)", entity);
        return entity;
    }

    //is EmployeeId able to be updated?
    public async Task<Recruiter> Update(Recruiter entity)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync(
            "UPDATE Recruiter SET FirstName = @FirstName, LastName = @LastName WHERE RecruiterId = @RecruiterId", entity);
        return entity;
    }

    public async Task Delete(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync("DELETE FROM Recruiter WHERE RecruiterId = @RecruiterId", new { RecruiterId = id });
    }

    public async Task<IEnumerable<Recruiter>> GetAll()
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return await conn.QueryAsync<Recruiter>("SELECT RecruiterId, FirstName, LastName, EmployeeId FROM Recruiter");
    }

    public async Task<Recruiter> GetById(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return await conn.QuerySingleOrDefaultAsync<Recruiter>("SELECT RecruiterId, FirstName, LastName, EmployeeId FROM Recruiter WHERE RecruiterId = @RecruiterId", new{RecruiterId = id});
    }
}