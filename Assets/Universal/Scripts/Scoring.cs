using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : GameBehaviour
{
    float currentTime;
    float bestTime = 1000000;

    void Start()
    {
        if(PlayerPrefs.HasKey("Best Time"))
        {
            bestTime = PlayerPrefs.GetFloat("Best Time");
            _UI.UpdateBestTime(bestTime);
        }
        else
        {
            _UI.UpdateBestTime(bestTime, true);
        }

        _UI.UpdateCurrentTime(currentTime);
        _TIMER.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(_TIMER.IsTiming())
        {
            currentTime = _TIMER.GetTime();
            _UI.UpdateCurrentTime(currentTime);
        }

        if (Input.GetKeyDown(KeyCode.O))
            GameOver();

        if (Input.GetKeyDown(KeyCode.P))
            PlayerPrefs.DeleteKey("Best Time");
    }

    void GameOver()
    {
        _TIMER.StopTimer();
        currentTime = _TIMER.GetTime();

        if(currentTime < bestTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetFloat("Best Time", bestTime);
            _UI.UpdateBestTime(bestTime);
        }
    }
}
