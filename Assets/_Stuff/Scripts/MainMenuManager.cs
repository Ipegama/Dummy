using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadSceneAsync("Game",LoadSceneMode.Additive);
    }

   
}
