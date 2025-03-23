using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Database.UnitOfWork.Contracts.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Determines whether all elements of a sequence satisfy a condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element for a condition.</param> the source sequence passes the test in the specified predicate, otherwise, false.</returns>
        public static Task<bool> AllAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.All(predicate)) : IQueryableAsyncExecutor.Executor.AllAsync(query, predicate, cancellationToken);

        /// <summary>
        /// Determines whether a sequence contains any elements asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains true if the source sequence contains any elements, otherwise, false.</returns>
        public static Task<bool> AnyAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Any()) : IQueryableAsyncExecutor.Executor.AnyAsync(query, cancellationToken);

        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param> true if any elements in the source sequence pass the test in the specified predicate, otherwise, false.</returns>
        public static Task<bool> AnyAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Any(predicate)) : IQueryableAsyncExecutor.Executor.AnyAsync(query, predicate, cancellationToken);

        /// <summary>
        /// Converts an IQueryable to an IAsyncEnumerable
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The source IQueryable</param>
        /// <returns>The source as an IAsyncEnumerable</returns>
        public static IAsyncEnumerable<T> AsAsyncEnumerable<T>(this IQueryable<T> query)
            => IQueryableAsyncExecutor.Executor is null ? query.ToAsyncEnumerable() : IQueryableAsyncExecutor.Executor.AsAsyncEnumerable(query);

        /// <summary>
        /// Converts an IEnumerable to an IAsyncEnumerable.  This conversion is synchronous; the resulting IAsyncEnumerable will enumerate the IEnumerable on the calling thread when consumed.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the IEnumerable.</typeparam>
        /// <param name="source">The IEnumerable to convert.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while yielding control to the caller.</param>
        /// <returns>An IAsyncEnumerable that is the asynchronous representation of the IEnumerable.</returns>
        public static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(this IQueryable<T> source, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            foreach (var item in source)
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return item;
            }
        }

        /// <summary>
        /// Computes the average of a sequence of nullable decimal values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        public static Task<decimal?> AverageAsync(this IQueryable<decimal?> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Average()) : IQueryableAsyncExecutor.Executor.AverageAsync(query, cancellationToken);

        /// <summary>
        /// Computes the average of a sequence of decimal values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        public static Task<decimal> AverageAsync(this IQueryable<decimal> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Average()) : IQueryableAsyncExecutor.Executor.AverageAsync(query, cancellationToken);

        /// <summary>
        /// Computes the average of a sequence of nullable double values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        public static Task<double?> AverageAsync(this IQueryable<double?> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Average()) : IQueryableAsyncExecutor.Executor.AverageAsync(query, cancellationToken);

        /// <summary>
        /// Computes the average of a sequence of double values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        public static Task<double> AverageAsync(this IQueryable<double> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Average()) : IQueryableAsyncExecutor.Executor.AverageAsync(query, cancellationToken);

        /// <summary>
        /// Computes the average of a sequence of nullable float values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        public static Task<float?> AverageAsync(this IQueryable<float?> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Average()) : IQueryableAsyncExecutor.Executor.AverageAsync(query, cancellationToken);

        /// <summary>
        /// Computes the average of a sequence of float values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        public static Task<float> AverageAsync(this IQueryable<float> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Average()) : IQueryableAsyncExecutor.Executor.AverageAsync(query, cancellationToken);

        /// <summary>
        /// Computes the average of a sequence of nullable int values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        public static Task<double?> AverageAsync(this IQueryable<int?> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Average()) : IQueryableAsyncExecutor.Executor.AverageAsync(query, cancellationToken);

        /// <summary>
        /// Computes the average of a sequence of int values asynchronously.
        /// of the sequence of values.</returns>
        public static Task<double> AverageAsync(this IQueryable<int> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Average()) : IQueryableAsyncExecutor.Executor.AverageAsync(query, cancellationToken);

        /// <summary>
        /// Computes the average of a sequence of nullable long values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        public static Task<double?> AverageAsync(this IQueryable<long?> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Average()) : IQueryableAsyncExecutor.Executor.AverageAsync(query, cancellationToken);

        /// <summary>
        /// Computes the average of a sequence of long values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        public static Task<double> AverageAsync(this IQueryable<long> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Average()) : IQueryableAsyncExecutor.Executor.AverageAsync(query, cancellationToken);

        /// <summary>
        /// Returns the number of elements in a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of elements in the input sequence.</returns>
        public static Task<int> CountAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Count()) : IQueryableAsyncExecutor.Executor.CountAsync(query, cancellationToken);

        /// <summary>
        /// Returns the first element of a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first element in the query.</returns>
        /// <exception cref="InvalidOperationException">The source sequence is empty.</exception>
        public static Task<T> FirstAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.First()) : IQueryableAsyncExecutor.Executor.FirstAsync(query, cancellationToken);

        /// <summary>
        /// Returns the first element of a sequence that satisfies a specified condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element
        /// <exception cref="InvalidOperationException">No element satisfies the condition in predicate.-or-The source sequence is empty.</exception>
        public static Task<T> FirstAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.First(predicate)) : IQueryableAsyncExecutor.Executor.FirstAsync(query, predicate, cancellationToken);

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The queryreturns>
        public static Task<T?> FirstOrDefaultAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.FirstOrDefault()) : IQueryableAsyncExecutor.Executor.FirstOrDefaultAsync(query, cancellationToken);

        /// <summary>
        /// Returns the first element of a sequence that satisfies a specified condition, or a default value if no such element is found asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        public static Task<T?> FirstOrDefaultAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.FirstOrDefault(predicate)) : IQueryableAsyncExecutor.Executor.FirstOrDefaultAsync(query, predicate, cancellationToken);

        /// <summary>
        /// Executes the given action on each element in the source IQueryable
        /// </summary>
        /// <typeparam name="T">The type of the elements of source</typeparam>
        /// <param name="query">An IQueryable to enumerate</param>
        /// <param name="action">The action to execute for each element</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static Task ForEachAsync<T>(this IQueryable<T> query, Action<T> action, CancellationToken cancellationToken = default)
        {
            if (IQueryableAsyncExecutor.Executor is null)
            {
                foreach (var item in query)
                    action(item);

                return Task.CompletedTask;
            }

            return IQueryableAsyncExecutor.Executor.ForEachAsync(query, action, cancellationToken);
        }

        /// <summary>
        /// Returns the last element of a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        public static Task<T> LastAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Last()) : IQueryableAsyncExecutor.Executor.LastAsync(query, cancellationToken);

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="cancellationToken">A CancellationToken to.-or-The source sequence is empty.</exception>
        public static Task<T> LastAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Last(predicate)) : IQueryableAsyncExecutor.Executor.LastAsync(query, predicate, cancellationToken);

        /// <summary>
        /// Returns the last element of a sequence, or a default value if the sequence contains no elements asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the last element in the query, or a default value if the sequence is empty.</returns>
        public static Task<T?> LastOrDefaultAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.LastOrDefault()) : IQueryableAsyncExecutor.Executor.LastOrDefaultAsync(query, cancellationToken);

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition, or a default value if no such element is found asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function value if no such element is found.</returns>
        public static Task<T?> LastOrDefaultAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.LastOrDefault(predicate)) : IQueryableAsyncExecutor.Executor.LastOrDefaultAsync(query, predicate, cancellationToken);

        /// Returns a long that represents the number of elements in a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of elements in the input sequence as a long.</returns>
        public static Task<long> LongCountAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.LongCount()) : IQueryableAsyncExecutor.Executor.LongCountAsync(query, cancellationToken);

        /// <summary>
        /// Returns a long that represents the number of elements in a sequence that satisfy a condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element for a condition.</     [inheritdoc/>
        public static Task<long> LongCountAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.LongCount(predicate)) : IQueryableAsyncExecutor.Executor.LongCountAsync(query, predicate, cancellationToken);

        /// <summary>
        /// Projects each element of a sequence into a new form and returns the maximum resulting value asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
        /// <param name="query">The query to execute.</param> maximum value in the resulting sequence.</returns>
        public static Task<TResult> MaxAsync<T, TResult>(this IQueryable<T> query, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Max(selector)) : IQueryableAsyncExecutor.Executor.MaxAsync(query, selector, cancellationToken);

        /// <summary>
        /// Returns the maximum value in a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the maximum value in the sequence.</returns>
        public static Task<T> MaxAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Max()) : IQueryableAsyncExecutor.Executor.MaxAsync(query, cancellationToken);

        /// <summary>
        /// Returns the minimum value in a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the minimum value in the sequence.</returns>
        public static Task<T> MinAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Min()) : IQueryableAsyncExecutor.Executor.MinAsync(query, cancellationToken);

        /// <summary>
        /// Returns the minimum value in a sequence asynchronously, projecting each element into a new form.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by the selector.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// </returns>Transform function to apply to each element.</returns>
        public static Task<TResult> MinAsync<T, TResult>(this IQueryable<T> query, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Min(selector)) : IQueryableAsyncExecutor.Executor.MinAsync(query, selector, cancellationToken);

        /// <summary>
        /// Returns the only element of a sequence asynchronously, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task
        public static Task<T> SingleAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Single()) : IQueryableAsyncExecutor.Executor.SingleAsync(query, cancellationToken);

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition, or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        public static Task<T?> SingleOrDefaultAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.SingleOrDefault(predicate)) : IQueryableAsyncExecutor.Executor.SingleOrDefaultAsync(query, predicate, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of nullable decimal values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        public static Task<decimal?> SumAsync(this IQueryable<decimal?> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum()) : IQueryableAsyncExecutor.Executor.SumAsync(query, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of decimal values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        public static Task<decimal> SumAsync(this IQueryable<decimal> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum()) : IQueryableAsyncExecutor.Executor.SumAsync(query, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of nullable double values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        public static Task<double?> SumAsync(this IQueryable<double?> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum()) : IQueryableAsyncExecutor.Executor.SumAsync(query, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of double values asynchronously.
        /// </ the values in the sequence.</returns>
        public static Task<double> SumAsync(this IQueryable<double> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum()) : IQueryableAsyncExecutor.Executor.SumAsync(query, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of nullable float values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        public static Task<float?> SumAsync(this IQueryable<float?> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum()) : IQueryableAsyncExecutor.Executor.SumAsync(query, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of float values asynchronously.
        /// </summary>
        /// <param name="source">The source IQueryable to calculate the sum of.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        public static Task<float> SumAsync(this IQueryable<float> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum()) : IQueryableAsyncExecutor.Executor.SumAsync(query, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of nullable int values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        public static Task<int?> SumAsync(this IQueryable<int?> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum()) : IQueryableAsyncExecutor.Executor.SumAsync(query, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of int values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        public static Task<int> SumAsync(this IQueryable<int> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum()) : IQueryableAsyncExecutor.Executor.SumAsync(query, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of nullable long values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        public static Task<long?> SumAsync(this IQueryable<long?> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum()) : IQueryableAsyncExecutor.Executor.SumAsync(query, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of long values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        public static Task<long> SumAsync(this IQueryable<long> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum()) : IQueryableAsyncExecutor.Executor.SumAsync(query, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element overload handles nullable decimal values.</remarks>
        public static Task<decimal?> SumAsync<T>(this IQueryable<T> query, Expression<Func<T, decimal?>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum(selector)) : IQueryableAsyncExecutor.Executor.SumAsync(query, selector, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector
        /// <remarks>This overload handles decimal values.</remarks>
        public static Task<decimal> SumAsync<T>(this IQueryable<T> query, Expression<Func<T, decimal>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum(selector)) : IQueryableAsyncExecutor.Executor.SumAsync(query, selector, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <remarks>This overload handles nullable double values.</remarks>
        public static Task<double?> SumAsync<T>(this IQueryable<T> query, Expression<Func<T, double?>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum(selector)) : IQueryableAsyncExecutor.Executor.SumAsync(query, selector, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the projected values in the sequence.</returns>
        /// <remarks>This overload handles double values.</remarks>
        public static Task<double> SumAsync<T>(this IQueryable<T> query, Expression<Func<T, double>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum(selector)) : IQueryableAsyncExecutor.Executor.SumAsync(query, selector, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the projected values in the sequence.</returns>
        /// <remarks>This overload handles nullable float values.</remarks>
        public static Task<float?> SumAsync<T>(this IQueryable<T> query, Expression<Func<T, float?>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum(selector)) : IQueryableAsyncExecutor.Executor.SumAsync(query, selector, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the projected values in the sequence.</returns>
        /// <remarks>This overload handles float values.</remarks>
        public static Task<float> SumAsync<T>(this IQueryable<T> query, Expression<Func<T, float>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum(selector)) : IQueryableAsyncExecutor.Executor.SumAsync(query, selector, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <remarks>This overload handles nullable int values.</remarks>
        public static Task<int?> SumAsync<T>(this IQueryable<T> query, Expression<Func<T, int?>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum(selector)) : IQueryableAsyncExecutor.Executor.SumAsync(query, selector, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function
        /// <remarks>This overload handles int values.</remarks>
        public static Task<int> SumAsync<T>(this IQueryable<T> query, Expression<Func<T, int>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum(selector)) : IQueryableAsyncExecutor.Executor.SumAsync(query, selector, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <param name = "selector" > A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the projected values in the sequence.</returns>
        /// <remarks>This overload handles nullable long values.</remarks>
        public static Task<long?> SumAsync<T>(this IQueryable<T> query, Expression<Func<T, long?>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum(selector)) : IQueryableAsyncExecutor.Executor.SumAsync(query, selector, cancellationToken);

        /// <summary>
        /// Computes the sum of the sequence of long values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task
        public static Task<long> SumAsync<T>(this IQueryable<T> query, Expression<Func<T, long>> selector, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Sum(selector)) : IQueryableAsyncExecutor.Executor.SumAsync(query, selector, cancellationToken);

        /// <summary>
        /// Creates an array from an IQueryable asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">An IQueryable to create an array from.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.  The task result contains an array that contains the elements from the input sequence.</returns>
        public static Task<T[]> ToArrayAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.ToArray()) : IQueryableAsyncExecutor.Executor.ToArrayAsync(query, cancellationToken);

        /// <summary>
        /// Creates a Dictionary{TKey,TValue} from an IQueryable asynchronously according to a specified key selector function and an element selector function.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
        /// <param name="query">An IQueryable to create a Dictionary{TKey,TValue} from.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for is null.</exception>
        /// <exception cref="ArgumentException">An element with the same key already exists in the Dictionary{TKey,TValue}.</exception>
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<T, TKey, TElement>(this IQueryable<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, CancellationToken cancellationToken = default) where TKey : notnull
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.ToDictionary(keySelector, elementSelector)) : IQueryableAsyncExecutor.Executor.ToDictionaryAsync(query, keySelector, elementSelector, cancellationToken);

        /// <summary>
        /// Creates a Dictionary{TKey,TValue} from an IQueryable asynchronously according to a specified key selector function, a comparer, and an element selector function.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <typeparam name="TElement">The type of the value returned by elementSelector.</typeparam>
        /// <param name="query">An IQueryable to create a Dictionary{TKey,TValue} from.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
        /// <param name="comparer">An IEqualityComparer{TKey} to compare keys.</param>
        /// <param name="cancellationToken">.ArgumentNullException">keySelector or elementSelector is null.</exception>
        /// <exception cref="ArgumentException">An element with the same key already exists in the Dictionary{TKey,TValue}.</exception>
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<T, TKey, TElement>(this IQueryable<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default) where TKey : notnull
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.ToDictionary(keySelector, elementSelector, comparer)) : IQueryableAsyncExecutor.Executor.ToDictionaryAsync(query, keySelector, elementSelector, comparer, cancellationToken);

        /// <summary>
        /// Creates a Dictionary{TKey,TValue} from an IQueryable asynchronously according to a specified key selector function.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>">An element with the same key already exists in the Dictionary{TKey,TValue}.</exception>
        public static Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(this IQueryable<T> query, Func<T, TKey> keySelector, CancellationToken cancellationToken = default) where TKey : notnull
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.ToDictionary(keySelector)) : IQueryableAsyncExecutor.Executor.ToDictionaryAsync(query, keySelector, cancellationToken);

        /// <summary>
        /// Creates a Dictionary{TKey,TValue} from an IQueryable asynchronously according to a specified key selector function and key comparer.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="query">An IQueryable to create a Dictionary{TKey,TValue} from.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="comparer">An IEqualityComparer{TKey} to compare keys.</param>
        /// <param name="cancellationToken>The type of the elements in the query.</typeparam>
        /// <param name="query">An IQueryable to create a List{T} from.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.  The task result contains a List{T} that contains the elements from the input sequence.</returns>
        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.ToList()) : IQueryableAsyncExecutor.Executor.ToListAsync(query, cancellationToken);

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition asynchronously, and throws an exception if more than one such element exists.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate"> the condition.</returns>
        /// <exception cref="InvalidOperationException">No element satisfies the condition in predicate.-or-More than one element satisfies the condition in predicate.</exception>
        public static Task<T> SingleAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Single(predicate)) : IQueryableAsyncExecutor.Executor.SingleAsync(query, predicate, cancellationToken);

        /// <summary>
        /// Returns the number of elements in a sequence that satisfy a condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>The task result contains the number of elements in the input sequence that satisfy the condition.</returns>
        public static Task<int> CountAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.Count(predicate)) : IQueryableAsyncExecutor.Executor.CountAsync(query, predicate, cancellationToken);

        /// <summary>
        /// Creates a Dictionary{TKey,TValue} from an IQueryable asynchronously according to a specified key selector function and key comparer.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="query">An IQueryable to create a Dictionary{TKey,TValue} from.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="comparer">An IEqualityComparer{TKey} to compare keys.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <exception cref="ArgumentNullException">keySelector or comparer is null.</exception>
        /// <exception cref="ArgumentException">An element with the same key already exists in the Dictionary{TKey,TValue}.</exception>
        public static Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(this IQueryable<T> query, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default) where TKey : notnull
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.ToDictionary(keySelector, comparer)) : IQueryableAsyncExecutor.Executor.ToDictionaryAsync(query, keySelector, comparer, cancellationToken);

        /// <summary>
        /// Asynchronously loads the related entities into the related entity collections of the entities in the source IQueryable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="query">The query containing the source IQueryable of entities to load related entities into.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        public static Task LoadAsync<TSource>(this IQueryable<TSource> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.CompletedTask : IQueryableAsyncExecutor.Executor.LoadAsync(query, cancellationToken);

        /// <summary>
        /// Returns the only element of a sequence, or a default value if the sequence is empty. This method throws an exception if more than one element satisfies the condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>Result contains the single element of the input sequence, or a default value if the sequence is empty.</returns>
        /// <exception cref="InvalidOperationException">The input sequence contains more than one element.</exception>
        public static Task<T?> SingleOrDefaultAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
            => IQueryableAsyncExecutor.Executor is null ? Task.FromResult(query.SingleOrDefault()) : IQueryableAsyncExecutor.Executor.SingleOrDefaultAsync(query, cancellationToken);
    }
}
