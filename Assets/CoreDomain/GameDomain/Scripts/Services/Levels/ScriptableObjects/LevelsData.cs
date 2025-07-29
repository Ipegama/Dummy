using UnityEngine;

namespace CoreDomain.GameDomain.Scripts.Services.Levels.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Levels", menuName = "PracticAPI/Game/Levels/Levels")]
    public class LevelsData : ScriptableObject
    {
        public LevelData[] LevelsByOrder;
    }
}
