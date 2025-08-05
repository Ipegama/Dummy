using UnityEngine;

namespace CoreDomain.GameDomain.Scripts.Services.Levels.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level", menuName = "PracticAPI/Game/Levels/Level")]
    public class LevelData : ScriptableObject
    {
        public int ScoreGoal = 100;
        public string TrackAddress;
    }
}