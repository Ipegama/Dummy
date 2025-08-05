using System.Threading;
using UnityEngine;

namespace IpegamaGames
{
    public interface IWorldCameraController
    {
        void StopFollowTarget();
        void StartFollowTarget(Transform targetTransform);
        Awaitable DoLockOnTargetAnimation(Transform targetTransform, CancellationTokenSource cancellationTokenSource);
    }
}
