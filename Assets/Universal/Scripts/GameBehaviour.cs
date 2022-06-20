using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameBehaviour : MonoBehaviour
{
    protected static Timer _TIMER { get { return Timer.INSTANCE; } }
    protected static UIManager _UI { get { return UIManager.INSTANCE; } }



    /// <summary>
    /// Gets a random colour from all possible colours with an alpha of 1
    /// </summary>
    /// <returns>A random colour</returns>
    public Color GetRandomColour()
    {
        return new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }

    /// <summary>
    /// Fades in a canvas group
    /// </summary>
    /// <param name="cvg">The canvas group to fade</param>
    /// <param name="tweenTime">optional time to tween - default is 1</param>
    public void FadeInCanvas(CanvasGroup cvg, float tweenTime = 1f)
    {
        cvg.DOFade(1, tweenTime);
        cvg.interactable = true;
        cvg.blocksRaycasts = true;
    }

    /// <summary>
    /// Fades out a canvas group
    /// </summary>
    /// <param name="cvg">The canvas group to fade</param>
    /// <param name="tweenTime">optional time to tween - default is 1</param>
    public void FadeOutCanvas(CanvasGroup cvg, float tweenTime = 1f)
    {
        cvg.DOFade(0, tweenTime).SetEase(Ease.InExpo);
        cvg.interactable = false;
        cvg.blocksRaycasts = false;
    }
}

public class GameBehaviour<T> : GameBehaviour where T : GameBehaviour
{
    private static T instance_;
    public static T INSTANCE
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = GameObject.FindObjectOfType<T>();
                if (instance_ == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    singleton.AddComponent<T>();
                }
            }
            return instance_;
        }
    }
    protected virtual void Awake()
    {
        if (instance_ == null)
        {
            instance_ = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
