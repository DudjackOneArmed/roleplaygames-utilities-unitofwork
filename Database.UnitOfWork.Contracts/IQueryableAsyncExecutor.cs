﻿using System.Linq.Expressions;

namespace Database.UnitOfWork.Contracts
{
    /// <summary>
    /// Manages async executing query logic
    /// </summary>
    public interface IQueryableAsyncExecutor
    {
        /// <summary>
        /// Defaule executer (if exists)
        /// </summary>
        public static IQueryableAsyncExecutor? Executor { get; set; }

        /// <summary>
        /// Determines whether all elements of a sequence satisfy a condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element for a condition.</param> the source sequence passes the test in the specified predicate, otherwise, false.</returns>
        Task<bool> AllAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Determines whether a sequence contains any elements asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains true if the source sequence contains any elements, otherwise, false.</returns>
        Task<bool> AnyAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param> true if any elements in the source sequence pass the test in the specified predicate, otherwise, false.</returns>
        Task<bool> AnyAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Converts an IQueryable to an IAsyncEnumerable
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The source IQueryable</param>
        /// <returns>The source as an IAsyncEnumerable</returns>
        IAsyncEnumerable<T> AsAsyncEnumerable<T>(IQueryable<T> query);

        /// <summary>
        /// Computes the average of a sequence of nullable decimal values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        Task<decimal?> AverageAsync(IQueryable<decimal?> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the average of a sequence of decimal values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        Task<decimal> AverageAsync(IQueryable<decimal> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the average of a sequence of nullable double values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        Task<double?> AverageAsync(IQueryable<double?> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the average of a sequence of double values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        Task<double> AverageAsync(IQueryable<double> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the average of a sequence of nullable float values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        Task<float?> AverageAsync(IQueryable<float?> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the average of a sequence of float values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        Task<float> AverageAsync(IQueryable<float> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the average of a sequence of nullable int values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        Task<double?> AverageAsync(IQueryable<int?> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the average of a sequence of int values asynchronously.
        /// of the sequence of values.</returns>
        Task<double> AverageAsync(IQueryable<int> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the average of a sequence of nullable long values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        Task<double?> AverageAsync(IQueryable<long?> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the average of a sequence of long values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the average of the sequence of values.</returns>
        Task<double> AverageAsync(IQueryable<long> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the number of elements in a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of elements in the input sequence.</returns>
        Task<int> CountAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the first element of a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first element in the query.</returns>
        /// <exception cref="InvalidOperationException">The source sequence is empty.</exception>
        Task<T> FirstAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the first element of a sequence that satisfies a specified condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element    /// <exception cref="InvalidOperationException">No element satisfies the condition in predicate.-or-The source sequence is empty.</exception>
        Task<T> FirstAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The queryreturns>
        Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the first element of a sequence that satisfies a specified condition, or a default value if no such element is found asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes the given action on each element in the source IQueryable
        /// </summary>
        /// <typeparam name="T">The type of the elements of source</typeparam>
        /// <param name="query">An IQueryable to enumerate</param>
        /// <param name="action">The action to execute for each element</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task ForEachAsync<T>(IQueryable<T> query, Action<T> action, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the last element of a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <paramexception>
        Task<T> LastAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="cancellationToken">A CancellationToken to.-or-The source sequence is empty.</exception>
        Task<T> LastAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns the last element of a sequence, or a default value if the sequence contains no elements asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the last element in the query, or a default value if the sequence is empty.</returns>

        Task<T?> LastOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition, or a default value if no such element is found asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function value if no such element is found.</returns>
        Task<T?> LastOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// Returns a long that represents the number of elements in a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of elements in the input sequence as a long.</returns>
        Task<long> LongCountAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a long that represents the number of elements in a sequence that satisfy a condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element for a condition.</     [inheritdoc/>
        Task<long> LongCountAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Projects each element of a sequence into a new form and returns the maximum resulting value asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
        /// <param name="query">The query to execute.</param> maximum value in the resulting sequence.</returns>
        Task<TResult> MaxAsync<T, TResult>(IQueryable<T> query, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the maximum value in a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the maximum value in the sequence.</returns>

        Task<T> MaxAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the minimum value in a sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the minimum value in the sequence.</returns>

        Task<T> MinAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the minimum value in a sequence asynchronously, projecting each element into a new form.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by the selector.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// </returns>Transform function to apply to each element.</returns>
        Task<TResult> MinAsync<T, TResult>(IQueryable<T> query, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the only element of a sequence asynchronously, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task
        Task<T> SingleAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition, or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of nullable decimal values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        Task<decimal?> SumAsync(IQueryable<decimal?> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of decimal values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        Task<decimal> SumAsync(IQueryable<decimal> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of nullable double values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        Task<double?> SumAsync(IQueryable<double?> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of double values asynchronously.
        /// </ the values in the sequence.</returns>
        Task<double> SumAsync(IQueryable<double> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of nullable float values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        Task<float?> SumAsync(IQueryable<float?> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of float values asynchronously.
        /// </summary>
        /// <param name="source">The source IQueryable to calculate the sum of.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        Task<float> SumAsync(IQueryable<float> source, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of nullable int values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        Task<int?> SumAsync(IQueryable<int?> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of int values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        Task<int> SumAsync(IQueryable<int> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of nullable long values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        Task<long?> SumAsync(IQueryable<long?> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of long values asynchronously.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the values in the sequence.</returns>
        Task<long> SumAsync(IQueryable<long> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element overload handles nullable decimal values.</remarks>
        Task<decimal?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, decimal?>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector
        /// <remarks>This overload handles decimal values.</remarks>
        Task<decimal> SumAsync<T>(IQueryable<T> query, Expression<Func<T, decimal>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <remarks>This overload handles nullable double values.</remarks>
        Task<double?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, double?>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the projected values in the sequence.</returns>
        /// <remarks>This overload handles double values.</remarks>
        Task<double> SumAsync<T>(IQueryable<T> query, Expression<Func<T, double>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the projected values in the sequence.</returns>
        /// <remarks>This overload handles nullable float values.</remarks>
        Task<float?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, float?>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="cancellationToken>A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the projected values in the sequence.</returns>
        /// <remarks>This overload handles float values.</remarks>
        Task<float> SumAsync<T>(IQueryable<T> query, Expression<Func<T, float>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <remarks>
        Task<int?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, int?>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function    /// <remarks>This overload handles int values.</remarks>
        Task<int> SumAsync<T>(IQueryable<T> query, Expression<Func<T, int>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <param name = "selector" > A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the sum of the projected values in the sequence.</returns>
        /// <remarks>This overload handles nullable long values.</remarks>
        Task<long?> SumAsync<T>(IQueryable<T> query, Expression<Func<T, long?>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Computes the sum of the sequence of long values that are obtained by invoking a transform function on each element of the input sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task
        Task<long> SumAsync<T>(IQueryable<T> query, Expression<Func<T, long>> selector, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an array from an IQueryable asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">An IQueryable to create an array from.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.  The task result contains an array that contains the elements from the input sequence.</returns>
        Task<T[]> ToArrayAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

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
        /// <exception cref="System.ArgumentException">An element with the same key already exists in the Dictionary{TKey,TValue}.</exception>
        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<T, TKey, TElement>(IQueryable<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, CancellationToken cancellationToken = default) where TKey : notnull;

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
        /// <exception cref="System.ArgumentException">An element with the same key already exists in the Dictionary{TKey,TValue}.</exception>
        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<T, TKey, TElement>(IQueryable<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default) where TKey : notnull;

        /// <summary>
        /// Creates a Dictionary{TKey,TValue} from an IQueryable asynchronously according to a specified key selector function.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>">An element with the same key already exists in the Dictionary{TKey,TValue}.</exception>
        Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(IQueryable<T> query, Func<T, TKey> keySelector, CancellationToken cancellationToken = default) where TKey : notnull;

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
        Task<List<T>> ToListAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition asynchronously, and throws an exception if more than one such element exists.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate"> the condition.</returns>
        /// <exception cref="System.InvalidOperationException">No element satisfies the condition in predicate.-or-More than one element satisfies the condition in predicate.</exception>
        Task<T> SingleAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the number of elements in a sequence that satisfy a condition asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>The task result contains the number of elements in the input sequence that satisfy the condition.</returns>
        Task<int> CountAsync<T>(IQueryable<T> query, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

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
        /// <exception cref="System.ArgumentException">An element with the same key already exists in the Dictionary{TKey,TValue}.</exception>
        Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(IQueryable<T> query, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default) where TKey : notnull;

        /// <summary>
        /// Asynchronously loads the related entities into the related entity collections of the entities in the source IQueryable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="query">The query containing the source IQueryable of entities to load related entities into.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        Task LoadAsync<TSource>(IQueryable<TSource> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the only element of a sequence, or a default value if the sequence is empty. This method throws an exception if more than one element satisfies the condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>Result contains the single element of the input sequence, or a default value if the sequence is empty.</returns>
        /// <exception cref="System.InvalidOperationException">The input sequence contains more than one element.</exception>
        Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken = default);
    }
}
