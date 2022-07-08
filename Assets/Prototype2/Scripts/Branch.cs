using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Branch : GameBehaviour
{
    public GameObject leaf;
    Renderer rend;
    Renderer leafRend;
    bool over = false;
    AudioSource audioSource;
    

    private void Start()
    {
        rend = GetComponent<Renderer>();
        leafRend = leaf.GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseEnter()
    {
        rend.material.color = Color.green;
        over = true;
    }

    private void OnMouseExit()
    {
        rend.material.color = Color.white;
        over = false;
    }

    void OnPointReached()
    {
        if(over)
        {
            audioSource.Play();
            leaf.transform.DOScale(Vector3.one * 1.2f, 0.2f).OnComplete(() => leaf.transform.DOScale(Vector3.one, 0.1f));
            leafRend.material.DOColor(Color.blue, 0.05f).OnComplete(() => leafRend.material.DOColor(Color.white, 0.5f));
        }
    }

    private void OnEnable()
    {
        GameEvents.OnPointReached += OnPointReached;
    }

    private void OnDisable()
    {
        GameEvents.OnPointReached -= OnPointReached;
    }
}
