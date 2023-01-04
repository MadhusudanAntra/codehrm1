using System.Data;
using Interviews.ApplicationCore.Contracts.Repositories;
using Interviews.ApplicationCore.Entities;
using Interviews.Infrastructure.Data;
using Dapper;

namespace Interviews.Infrastructure.Repositories;

public class InterviewTypeRepository : IInterviewTypeRepository
{
    private readonly DbConnection _dbConnection;

    public InterviewTypeRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<InterviewType> Create(InterviewType entity)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync("INSERT INTO InterviewType VALUES(@LookupCode, @InterviewTypeName)", entity);
        return entity;
    }

    public async Task<InterviewType> Update(InterviewType entity)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync(
            "UPDATE InterviewType SET InterviewTypeName = @InterviewTypeName WHERE LookupCode = @LookupCode", entity);
        return entity;
    }

    public async Task Delete(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        await conn.ExecuteAsync("DELETE FROM InterviewType WHERE LookupCode = @LookupCode", new { LookupCode = id });
    }

    public async Task<IEnumerable<InterviewType>> GetAll()
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return await conn.QueryAsync<InterviewType>("SELECT LookupCode, InterviewTypeName FROM InterviewType");
    }

    public async Task<InterviewType> GetById(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return await conn.QuerySingleOrDefaultAsync<InterviewType>("SELECT LookupCode, InterviewTypeName FROM InterviewType WHERE LookupCode = @LookupCode", new{LookupCode = id});
    }
}