using System.Threading;
using UnityEngine;

namespace IpegamaGames
{
    public interface ISceneInitiator
    {
        SceneType SceneType { get; }
        Awaitable LoadEntryPoint(IInitiatorEnterData enterDataObject, CancellationTokenSource cancellationTokenSource);
        Awaitable StartEntryPoint(IInitiatorEnterData enterDataObject, CancellationTokenSource cancellationTokenSource);
        Awaitable InitExitPoint(CancellationTokenSource cancellationTokenSource);
    }
}
