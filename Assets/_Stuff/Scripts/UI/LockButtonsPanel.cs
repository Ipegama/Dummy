using System.Collections;
using TMPro;
using UnityEngine;

public class LockButtonsPanel : Singleton<LockButtonsPanel>
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text panelText;
    public void LockButtons()
    {
        panel.SetActive(true);
        panelText.text = "Fight in progress";
    }
    public void UnlockButtons()
    {
        StartCoroutine(UnlockButtonsCR());
    }
    public IEnumerator UnlockButtonsCR()
    {
        panelText.text = "You won! \n Returning in 3";
        yield return new WaitForSeconds(1);
        panelText.text = "You won! \n Returning in 2";
        yield return new WaitForSeconds(1);
        panelText.text = "You won! \n Returning in 1";
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
        StateManager.Instance.ShowMap();
    }
}
