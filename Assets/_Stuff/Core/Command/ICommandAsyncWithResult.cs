using System.Threading;
using UnityEngine;

namespace IpegamaGames
{
    public interface ICommandAsyncWithResult<TReturn> : IBaseCommand
    {
        Awaitable<TReturn> Execute(CancellationTokenSource cancellationTokenSource = null);
    }
}