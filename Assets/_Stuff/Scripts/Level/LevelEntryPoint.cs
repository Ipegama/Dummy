using System.Collections.Generic;
using UnityEngine;

public class LevelEntryPoint : MonoBehaviour
{
    [SerializeField] private List<LevelData> levels;
    private void Start()
    {
        int mappedIndex = SelectedLevel.SelectedLevelIndex - 1;
        MapManager.Instance.GenerateMap(levels[mappedIndex].MapData);
        HandManager.Instance.Setup(levels[mappedIndex].Hand);
        QuestManager.Instance.SetBounty(levels[mappedIndex].Bounty);
    }
}
