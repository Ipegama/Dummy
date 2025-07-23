using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public bool IsUnlocked { get; private set; }

    public EnemyData EnemyData { get; private set; }

    [SerializeField] private Button button;

    void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    public void Setup(TileData data)
    {
        X = (int)data.position.x;
        Y = (int)data.position.y;
        EnemyData = data.enemyData;
        UpdateState();
    }

    private void OnClick()
    {
        if (!IsUnlocked) return;
        MapManager.Instance.OnTileClicked(this);
    }

    public void Unlock()
    {
        IsUnlocked = true;
        UpdateState();
    }

    private void UpdateState()
    {
        button.interactable = IsUnlocked;
        GetComponent<Image>().color = IsUnlocked ? Color.white : Color.gray;
    }
}
