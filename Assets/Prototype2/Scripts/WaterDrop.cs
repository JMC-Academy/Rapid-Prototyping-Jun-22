using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterDrop : MonoBehaviour
{
    public Transform moveToPos;
    Vector3 startPos;
    public float startSpeed = 1f;
    
    void Start()
    {
        startPos = transform.position;
        MoveDrop(startSpeed);
    }

    void MoveDrop(float _speed)
    {
        transform.DOMove(moveToPos.position, _speed).SetEase(Ease.Linear).OnComplete(()=>DropReached());
    }

    void DropReached()
    {
        GameEvents.ReportOnPointReached();
        transform.position = startPos;
        MoveDrop(startSpeed);
    }
}
