using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private Button button;

    public void Setup(PlayerData data, System.Action onClick)
    {
        label.text = data.PlayerName; // lub inna właściwość
        button.onClick.AddListener(() => onClick?.Invoke());
    }
}