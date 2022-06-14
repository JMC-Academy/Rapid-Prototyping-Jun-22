using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFader : GameBehaviour
{
    public CanvasGroup background;
    
    void Start()
    {
        background.alpha = 1;
        FadeOutCanvas(background);
    }
}
