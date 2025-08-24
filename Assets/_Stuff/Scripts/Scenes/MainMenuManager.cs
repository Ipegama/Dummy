using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject moreGamesPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject levelSelectPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject quitGamePanel;

    public void LoadGame(int index)
    {
        SelectedLevel.SelectedLevelIndex = index;
        SceneManager.LoadScene("Game",LoadSceneMode.Single);
    }
    
    public void OpenMoreGames()
    {
        moreGamesPanel.SetActive(true);
    }
    public void CloseMoreGames()
    {
        moreGamesPanel.SetActive(false);
    }
    public void OpenOptions()
    {
        levelSelectPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void OpenLevelSelect()
    {
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }
    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }
    public void OpenQuitGame()
    {
        quitGamePanel.SetActive(true);
    }
    public void CloseQuitGame()
    {
        quitGamePanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
