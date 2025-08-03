using System.Threading;
using UnityEngine;

namespace IpegamaGames
{
    public interface ISceneLoaderService
    {
        void InitEntryPoint();
        Awaitable<bool> TryLoadScene<TEnterData>(SceneType sceneType, TEnterData enterData, CancellationTokenSource cancellationTokenSource) where TEnterData : class, IInitiatorEnterData;
        Awaitable StartScene<TEnterData>(SceneType sceneType, TEnterData enterData, CancellationTokenSource cancellationTokenSource) where TEnterData : class, IInitiatorEnterData;
        Awaitable<bool> TryUnloadScene(SceneType sceneType, CancellationTokenSource cancellationTokenSource);
    }
}