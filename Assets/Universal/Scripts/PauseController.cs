using UnityEngine;

public class PauseController : GameBehaviour
{
    public GameObject pausePanel;
    bool paused;

    void Start()
    {
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        paused = !paused;
        pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }
}