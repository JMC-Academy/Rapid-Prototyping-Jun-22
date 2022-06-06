using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playtesting : GameBehaviour
{
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangePlayerColour();
    }

    void ChangePlayerColour()
    {
        rend.material.color = GetRandomColour();
    }
}
