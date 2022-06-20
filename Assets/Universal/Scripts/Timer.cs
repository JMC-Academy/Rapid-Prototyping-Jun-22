using UnityEngine;

public class Timer : GameBehaviour<Timer>
{
    public enum TimerDirection {CountUp, CountDown}
    public TimerDirection timerDirection;
    public float startTime = 0;
    float currentTime;
    bool isTiming = false;

    void Update()
    {
        if (isTiming)
        {
            if(timerDirection == TimerDirection.CountUp)
                currentTime += Time.deltaTime;
            else
                currentTime -= Time.deltaTime;
        }  
    }

    /// <summary>
    /// Starts the timer from zero and increments in real time seconds
    /// </summary>
    public void StartTimer()
    {
        isTiming = true;
        currentTime = startTime;
    }

    /// <summary>
    /// Will resume the timer from the previously paused time
    /// </summary>
    public void ResumeTimer()
    {
        isTiming = true;
    }

    /// <summary>
    /// Will pause the timer, with the intention to resume
    /// </summary>
    public void PauseTimer()
    {
        isTiming = false;
    }

    /// <summary>
    /// Stops the timer from timing
    /// </summary>
    public void StopTimer()
    {
        isTiming = false;
    }

    /// <summary>
    /// Increments our timer by a set amount
    /// </summary>
    /// <param name="_increment">The amount to increment by</param>
    public void IncrementTimer(float _increment)
    {
            currentTime += _increment;
    }

    /// <summary>
    /// Decrements our timer by a set amount
    /// </summary>
    /// <param name="_decrement">The amount to decrement by</param>
    public void DecrementTimer(float _decrement)
    {
        currentTime -= _decrement;
    }

    /// <summary>
    /// Gets the current time of the timer
    /// </summary>
    /// <returns>The current time of the timer</returns>
    public float GetTime()
    {
        return currentTime;
    }

    /// <summary>
    /// Are we timing or not?
    /// </summary>
    /// <returns>True if we are timing</returns>
    public bool IsTiming()
    {
        return isTiming;
    }

    /// <summary>
    /// Checks whether our time has expired or not
    /// </summary>
    /// <returns>True if timer is less than zero</returns>
    public bool TimeExpired()
    {
        return currentTime < 0f;
    }
}