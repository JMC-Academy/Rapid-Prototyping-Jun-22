using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action<int, int, int, int> OnAudioTick = null;
    public static event Action OnPointReached = null;

    public static void ReportAudioTick(int bar, int beat, int quarter, int step)
    {
        OnAudioTick?.Invoke(bar, beat, quarter, step);
    }

    public static void ReportOnPointReached()
    {
        Debug.Log("Point Reached");
        OnPointReached?.Invoke();
    }
}
