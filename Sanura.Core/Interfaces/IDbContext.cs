using System.Data;
using static Dapper.SqlMapper;

namespace Sanura.Core.Interfaces
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection
        {
            get;
        }

        Task<T> ExecuteScalarAsync<T>(string query, CommandType commandType = CommandType.StoredProcedure, object? parameters = null);

        Task<T> QuerySingleAsync<T>(string query, CommandType commandType = CommandType.StoredProcedure, object? parameters = null);

        Task<T> QuerySingleOrDefaultAsync<T>(string query, object parameters = null);

        Task<int> ExecuteAsync(string query, CommandType commandType = CommandType.StoredProcedure, object? parameters = null);

        Task<IEnumerable<T>> QueryAsync<T>(string query, CommandType commandType = CommandType.StoredProcedure, object? parameters = null);

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string query, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, object parameters = null);

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, Fourth, TReturn>(string query, Func<TFirst, TSecond, TThird, Fourth, TReturn> map, string splitOn, object parameters = null);

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, string splitOn, object parameters = null);

        IEnumerable<T> Query<T>(string query, object parameters = null);

        GridReader QueryMultiple(string query, object parameters = null);
    }
}
