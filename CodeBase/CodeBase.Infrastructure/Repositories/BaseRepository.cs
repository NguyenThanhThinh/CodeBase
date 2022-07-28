using System.Data;
using System.Data.SqlClient;
using CodeBase.Core.Models;
using CodeBase.Core.Repositories.Interfaces;
using Dapper;

namespace CodeBase.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
{
    #region Contructor

    public BaseRepository()
    {
        SqlConnectionString = "";
        SqlTableName = typeof(TEntity).Name;
        SqlEntityName = SqlTableName;
    }

    #endregion

    #region Properties

    protected string SqlConnectionString;

    protected SqlConnection? Conn;

    protected string SqlTableName;

    protected string SqlEntityName;

    #endregion

    #region Methods

    public async Task<bool> CheckExist(Guid id)
    {
        var entity = await GetById(id);
        return entity != null;
    }

    public async Task<int> Delete(Guid id)
    {
        await using (Conn = new SqlConnection(SqlConnectionString))
        {
            var sql = $"DELETE FROM {SqlTableName} WHERE {SqlEntityName}Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            return await Conn.ExecuteAsync(sql, parameters);
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        await using (Conn = new SqlConnection(SqlConnectionString))
        {
            var sql = $"SELECT * FROM {SqlTableName}";

            var entityList = await Conn.QueryAsync<TEntity>(sql);

            return entityList.ToList();
        }
    }

    public virtual async Task<TEntity> GetById(Guid id)
    {
        await using (Conn = new SqlConnection(SqlConnectionString))
        {
            var sql = $"SELECT * FROM {SqlTableName} WHERE {SqlEntityName}Id=@id";

            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            return await Conn.QueryFirstOrDefaultAsync<TEntity>(sql, parameters);
        }
    }

    public async Task<Paging> GetPaging(int pageIndex, int size, string keyword)
    {
        await using (Conn = new SqlConnection(SqlConnectionString))
        {
            var sqlProcedure = $"Proc_Filter{SqlTableName}";

            var parameters = new DynamicParameters();
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@Size", size);
            parameters.Add("@Keyword", keyword);
            parameters.Add("@TotalRecords", direction: ParameterDirection.Output);
            parameters.Add("@RecordStart", direction: ParameterDirection.Output);
            parameters.Add("@RecordEnd", direction: ParameterDirection.Output);

            var list = await Conn.QueryAsync<TEntity>(sqlProcedure, parameters,
                                                      commandType: CommandType.StoredProcedure);
            var totalRecords = parameters.Get<int>("@TotalRecords");
            var recordStart = parameters.Get<int>("@RecordStart");
            var recordEnd = parameters.Get<int>("@RecordEnd");

            return new Paging(list.ToList(), totalRecords, recordStart, recordEnd);
        }
    }

    public async Task<int> Insert(TEntity entity)
    {
        await using (Conn = new SqlConnection(SqlConnectionString))
        {
            var sql = $"Proc_Insert{SqlTableName}";

            var res = await Conn.ExecuteAsync(sql, entity, commandType: CommandType.StoredProcedure);

            return res;
        }
    }


    public async Task<int> Update(TEntity entity)
    {
        await using (Conn = new SqlConnection(SqlConnectionString))
        {
            var sql = $"Proc_Update{SqlTableName}";
            var res = await Conn.ExecuteAsync(sql, entity, commandType: CommandType.StoredProcedure);
            return res;
        }
    }

    #endregion
}