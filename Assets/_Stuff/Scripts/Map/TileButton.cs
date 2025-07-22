using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    public int x, y;
    public bool IsUnlocked { get; private set; }

    public EnemyData EnemyData { get; private set; }

    [SerializeField] private Button button;

    void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    public void Setup(int x, int y)
    {
        this.x = x;
        this.y = y;
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