using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Application.Queries
{
    public abstract class BaseQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IBaseQueryHandler<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
        public Task<TResult> MapAsync<TSource, TResult>(IMapper mapper, Task<TSource> task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            var tcs = new TaskCompletionSource<TResult>();

            task
                .ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);

            task
                .ContinueWith
                (
                    t =>
                    {
                        tcs.TrySetResult(mapper.Map<TSource, TResult>(t.Result));
                    },
                    TaskContinuationOptions.OnlyOnRanToCompletion
                );

            task
                .ContinueWith
                (
                    t => tcs.TrySetException(t.Exception),
                    TaskContinuationOptions.OnlyOnFaulted
                );

            return tcs.Task;
        }
    }
}
