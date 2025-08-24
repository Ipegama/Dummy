using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    [SerializeField] private GameObject fightGO;
    [SerializeField] private GameObject mapGO;

    void Start()
    {
        ShowMap();
    }

    public void ShowMap()
    {
        mapGO.SetActive(true);
        fightGO.SetActive(false);
    }

    public void ShowFight()
    {
        fightGO.SetActive(true);
        mapGO.SetActive(false);
    }
}
