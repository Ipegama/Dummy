using UnityEngine;

namespace CoreDomain.GameDomain.GameStateDomain.GamePlayDomain.Scripts.Mvc.Balloon
{
    [CreateAssetMenu(fileName = "BalloonsConfiguration", menuName = "PracticAPI/Game/BalloonsConfiguration")]
    public class BalloonsConfiguration : ScriptableObject
    {
        public int PopScore = 5;
        public Color[] BalloonsColorPalette;
    }
}
