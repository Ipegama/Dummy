using System.Threading;
using UnityEngine;

namespace IpegamaGames
{
    public interface ICommandAsync : IBaseCommand
    {
        Awaitable Execute(CancellationTokenSource cancellationTokenSource);
    }
}