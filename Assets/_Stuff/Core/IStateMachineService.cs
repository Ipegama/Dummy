using System.Threading;
using UnityEngine;

namespace IpegamaGames
{
    public interface IStateMachineService
    {
        IGameState CurrentState();
        Awaitable EnterInitialGameState(IGameState initialState, CancellationTokenSource cancellationTokenSource);
        void SwitchState(IGameState newState);
    }
}
