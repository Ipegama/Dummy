﻿using System.Threading;
using UnityEngine;

namespace IpegamaGames
{
    public interface ILevelsDataService
    {
        int MaxLevelNumberReached { get; }
        Awaitable LoadLevelsData(CancellationTokenSource cancellationTokenSource);
        int GetLevelsAmount();
        LevelData GetLevelData(int levelNumber);
        LevelData[] GetAllLevelsData();
        void SetLastSavedLevel(int levelNumber);
    }
}
