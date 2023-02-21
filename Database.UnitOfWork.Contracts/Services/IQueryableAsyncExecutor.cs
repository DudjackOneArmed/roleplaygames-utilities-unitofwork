using System.Linq.Expressions;

namespace Database.UnitOfWork.Contracts.Services
{
    /// <summary>
    /// Manages async executing query logic
    /// </summary>
    public interface IQueryableAsyncExecutor
    {
        /// <summary>
        /// Finds first query element asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>First query element</returns>
        Task<T> FirstAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds first query element asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="predicate">Predicate to select elemets</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>First query element</returns>
        Task<T> FirstAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds first query element asynchronously or returns default value
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>First query element or default value</returns>
        Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds first query element asynchronously or returns default value
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="predicate">Predicate to select elemets</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>First query element or default value</returns>
        Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds last query element asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Last query element</returns>
        Task<T> LastAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds last query element asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="predicate">Predicate to select elemets</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Last query element</returns>
        Task<T> LastAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds last query element asynchronously or returns default value
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Last query element or default value</returns>
        Task<T?> LastOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds last query element asynchronously or returns default value
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="predicate">Predicate to select elemets</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Last query element or default value</returns>
        Task<T?> LastOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds max query element asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Max element</returns>
        Task<T> MaxAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds max query element selector result asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Max element selector result</returns>
        Task<TResult> MaxAsync<T, TResult>(IQueryable<T> query, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds max query element selector result asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Min element</returns>
        Task<T> MinAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds min query element selector result asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Min element selector result</returns>
        Task<TResult> MinAsync<T, TResult>(IQueryable<T> query, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds query elements selector results sum asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Elements selector results sum</returns>
        Task<decimal?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, decimal?>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds query elements selector results sum asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Elements selector results sum</returns>
        Task<decimal> SumAsync<T>(IQueryable<T> query, Expression<Func<T, decimal>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds query elements selector results sum asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Elements selector results sum</returns>
        Task<double?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, double?>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds query elements selector results sum asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Elements selector results sum</returns>
        Task<double> SumAsync<T>(IQueryable<T> query, Expression<Func<T, double>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds query elements selector results sum asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Elements selector results sum</returns>
        Task<float?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, float?>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds query elements selector results sum asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Elements selector results sum</returns>
        Task<float> SumAsync<T>(IQueryable<T> query, Expression<Func<T, float>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds query elements selector results sum asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Elements selector results sum</returns>
        Task<int?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, int?>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds query elements selector results sum asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Elements selector results sum</returns>
        Task<int> SumAsync<T>(IQueryable<T> query, Expression<Func<T, int>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds query elements selector results sum asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Elements selector results sum</returns>
        Task<long?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, long?>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds query elements selector results sum asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="selector"></param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Elements selector results sum</returns>
        Task<long> SumAsync<T>(IQueryable<T> query, Expression<Func<T, long>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds single query element asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Single query element</returns>
        Task<T> SingleAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds single query element selector result asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="predicate">Predicate to select elemets</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Single query element selector result</returns>
        Task<T> SingleAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds single query element or returns default value asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Single query element or default value</returns>
        Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds single query element or returns default value of selector asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="predicate">Predicate to select elemets</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Single query element or default value</returns>
        Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Load query result to array asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Array</returns>
        Task<T[]> ToArrayAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Load query result to dictionary asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="query">Query</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Dictionary</returns>
        Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(IQueryable<T> query, Func<T, TKey> keySelector, CancellationToken cancellationToken = default) where TKey : notnull;

        /// <summary>
        /// Load query result to dictionary asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TElement">Element type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="elementSelector">Element selector</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>Dictionary</returns>
        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<T, TKey, TElement>(IQueryable<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, CancellationToken cancellationToken = default) where TKey : notnull;

        /// <summary>
        /// Load query result to list asynchronously
        /// </summary>
        /// <typeparam name="T">Query elements type</typeparam>
        /// <param name="query">Query</param>
        /// <param name="cancellationToken">Action cancellation token</param>
        /// <returns>List</returns>
        Task<List<T>> ToListAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);
    }
}
