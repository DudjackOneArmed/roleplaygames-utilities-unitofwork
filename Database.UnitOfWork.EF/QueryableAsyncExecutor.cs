using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Queryable.Async.Executors.EF
{
    /// <inheritdoc/>
    public class QueryableAsyncExecutor : Database.UnitOfWork.Contracts.IQueryableAsyncExecutor
    {
        /// <inheritdoc/>
        public Task<bool> AllAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.AllAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<bool> AnyAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.AnyAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<bool> AnyAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.AnyAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T> FirstAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.FirstAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T> FirstAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.FirstAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.FirstOrDefaultAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.FirstOrDefaultAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T> LastAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.LastAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T> LastAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.LastAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T?> LastOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.LastOrDefaultAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T?> LastOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.LastOrDefaultAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T> MaxAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.MaxAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<TResult> MaxAsync<T, TResult>(IQueryable<T> query, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default)
            => query.MaxAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<T> MinAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.MinAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<TResult> MinAsync<T, TResult>(IQueryable<T> query, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default)
            => query.MinAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<decimal?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, decimal?>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<decimal> SumAsync<T>(IQueryable<T> query, Expression<Func<T, decimal>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<double?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, double?>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<double> SumAsync<T>(IQueryable<T> query, Expression<Func<T, double>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<float?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, float?>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<float> SumAsync<T>(IQueryable<T> query, Expression<Func<T, float>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<int?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, int?>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<int> SumAsync<T>(IQueryable<T> query, Expression<Func<T, int>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<long?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, long?>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<long> SumAsync<T>(IQueryable<T> query, Expression<Func<T, long>> selector, CancellationToken cancellationToken = default)
            => query.SumAsync(selector, cancellationToken);

        /// <inheritdoc/>
        public Task<T> SingleAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.SingleAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T> SingleAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.SingleAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.SingleOrDefaultAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.SingleOrDefaultAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<T[]> ToArrayAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.ToArrayAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(IQueryable<T> query, Func<T, TKey> keySelector, CancellationToken cancellationToken = default) where TKey : notnull
            => query.ToDictionaryAsync(keySelector, cancellationToken);

        /// <inheritdoc/>
        public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<T, TKey, TElement>(IQueryable<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, CancellationToken cancellationToken = default) where TKey : notnull
            => query.ToDictionaryAsync(keySelector, elementSelector, cancellationToken);

        /// <inheritdoc/>
        public Task<List<T>> ToListAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.ToListAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<int> CountAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.CountAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<int> CountAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.CountAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<long> LongCountAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default)
            => query.LongCountAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<long> LongCountAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => query.LongCountAsync(predicate, cancellationToken);

        /// <inheritdoc/>
        public Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(IQueryable<T> query, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default) where TKey : notnull
            => query.ToDictionaryAsync(keySelector, comparer, cancellationToken);

        /// <inheritdoc/>
        public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<T, TKey, TElement>(IQueryable<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default) where TKey : notnull
            => query.ToDictionaryAsync(keySelector, elementSelector, comparer, cancellationToken);

        /// <inheritdoc/>
        public IAsyncEnumerable<T> AsAsyncEnumerable<T>(IQueryable<T> query)
            => query.AsAsyncEnumerable();

        /// <inheritdoc/>
        public Task ForEachAsync<T>(IQueryable<T> query, Action<T> action, CancellationToken cancellationToken = default)
            => query.ForEachAsync(action, cancellationToken);

        /// <inheritdoc/>
        public Task<float> SumAsync(IQueryable<float> source, CancellationToken cancellationToken = default)
            => source.SumAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<decimal> SumAsync(IQueryable<decimal> query, CancellationToken cancellationToken = default)
            => query.SumAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<decimal?> SumAsync(IQueryable<decimal?> query, CancellationToken cancellationToken = default)
            => query.SumAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<int> SumAsync(IQueryable<int> query, CancellationToken cancellationToken = default)
            => query.SumAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<int?> SumAsync(IQueryable<int?> query, CancellationToken cancellationToken = default)
            => query.SumAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<long> SumAsync(IQueryable<long> query, CancellationToken cancellationToken = default)
            => query.SumAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<long?> SumAsync(IQueryable<long?> query, CancellationToken cancellationToken = default)
            => query.SumAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<double> SumAsync(IQueryable<double> query, CancellationToken cancellationToken = default)
            => query.SumAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<double?> SumAsync(IQueryable<double?> query, CancellationToken cancellationToken = default)
            => query.SumAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<float?> SumAsync(IQueryable<float?> query, CancellationToken cancellationToken = default)
            => query.SumAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<decimal> AverageAsync(IQueryable<decimal> query, CancellationToken cancellationToken = default)
            => query.AverageAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<decimal?> AverageAsync(IQueryable<decimal?> query, CancellationToken cancellationToken = default)
            => query.AverageAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<double> AverageAsync(IQueryable<int> query, CancellationToken cancellationToken = default)
            => query.AverageAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<double?> AverageAsync(IQueryable<int?> query, CancellationToken cancellationToken = default)
            => query.AverageAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<double> AverageAsync(IQueryable<long> query, CancellationToken cancellationToken = default)
            => query.AverageAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<double?> AverageAsync(IQueryable<long?> query, CancellationToken cancellationToken = default)
            => query.AverageAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<double> AverageAsync(IQueryable<double> query, CancellationToken cancellationToken = default)
            => query.AverageAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<double?> AverageAsync(IQueryable<double?> query, CancellationToken cancellationToken = default)
            => query.AverageAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<float> AverageAsync(IQueryable<float> query, CancellationToken cancellationToken = default)
            => query.AverageAsync(cancellationToken);

        /// <inheritdoc/>
        public Task<float?> AverageAsync(IQueryable<float?> query, CancellationToken cancellationToken = default)
            => query.AverageAsync(cancellationToken);

        /// <inheritdoc/>
        public Task LoadAsync<TSource>(IQueryable<TSource> query, CancellationToken cancellationToken = default)
            => query.LoadAsync(cancellationToken);
    }
}
