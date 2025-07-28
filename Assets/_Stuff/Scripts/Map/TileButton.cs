using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public bool IsUnlocked { get; private set; }

    public EnemyData EnemyData { get; private set; }

    [SerializeField] private Button button;
    [SerializeField] private Image tileVisual;
    void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    public void Setup(TileData data)
    {
        X = (int)data.position.x;
        Y = (int)data.position.y;
        UpdateState();

        SetEnemy(data.enemyData);

        tileVisual.gameObject.SetActive(false);     
    }

    private void SetEnemy(EnemyData enemyData)
    {
        if (enemyData == null)
        {
            EnemyData = null;
            tileVisual.sprite = null;
            return;
        }
        EnemyData = enemyData;
        tileVisual.sprite = EnemyData.Sprite;
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

    public void RemoveEnemy()
    {
        EnemyData = null;
        SetEnemy(null);
        tileVisual.gameObject.SetActive(false);
    }

    private void UpdateState()
    {
        button.interactable = IsUnlocked;
        GetComponent<Image>().color = IsUnlocked ? Color.white : Color.gray;
        if (EnemyData != null)
        {
            tileVisual.gameObject.SetActive(true);
        }
    }
}
