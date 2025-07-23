using System.Collections.Generic;
using UnityEngine;

public class HandUI : Singleton<HandUI>
{
    [SerializeField] private GameObject buildButtonPrefab;
    [SerializeField] private Transform buttonParent;

    private List<BuildButton> buttons = new List<BuildButton>();

    private void Start()
    {
        RenderButtons();
        gameObject.SetActive(true);
    }

    public void RenderButtons()
    {
        ClearButtons();

        foreach (var build in HandManager.Instance.Hand)
        {
            var buttonObj = Instantiate(buildButtonPrefab, buttonParent);
            var button = buttonObj.GetComponent<BuildButton>();
            if (button == null)
            {
                Debug.LogError("BuildButton component missing on prefab!");
                continue;
            }

            button.Setup(build, () => OnBuildSelected(build));
            buttons.Add(button);
        }
    }

    private void ClearButtons()
    {
        foreach (var btn in buttons)
        {
            Destroy(btn.gameObject);
        }
        buttons.Clear();
    }

    public void OnBuildSelected(PlayerData selectedBuild)
    {
        if (Combat.Instance.IsInFight)
        {
            Combat.Instance.ChangeBuild(selectedBuild);
        }
    }

    public void UpdateBuilds()
    {
        RenderButtons();
    }
}
