using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : GameBehaviour
{
    public void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
