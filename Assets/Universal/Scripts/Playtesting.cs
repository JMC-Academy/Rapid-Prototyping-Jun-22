using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum MoveDirection {Up, Down, Left, Right}
public class Playtesting : GameBehaviour
{
    Renderer rend;
    public float moveDistance = 2f;
    public float moveSpeed = 1f;
    public Ease moveEase;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangePlayerColour();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            MovePlayer(MoveDirection.Up);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            MovePlayer(MoveDirection.Down);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MovePlayer(MoveDirection.Left);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MovePlayer(MoveDirection.Right);
    }

    void MovePlayer(MoveDirection _direction)
    {
        switch(_direction)
        {
            case MoveDirection.Up:
                transform.DOMoveZ(transform.position.z + moveDistance, moveSpeed).SetEase(moveEase).OnComplete(()=>
                CameraShake());
                break;
            case MoveDirection.Down:
                transform.DOMoveZ(transform.position.z - moveDistance, moveSpeed).SetEase(moveEase).OnComplete(() =>
                CameraShake());
                break;
            case MoveDirection.Left:
                transform.DOMoveX(transform.position.x - moveDistance, moveSpeed).SetEase(moveEase).OnComplete(() =>
                CameraShake());
                break;
            case MoveDirection.Right:
                transform.DOMoveX(transform.position.x + moveDistance, moveSpeed).SetEase(moveEase).OnComplete(() =>
                CameraShake());
                break;
        }
        //ChangePlayerScale();
        ChangePlayerColour();
    }

    void ChangePlayerScale()
    {
        transform.DOScale(Vector3.one * 2, moveSpeed / 2).OnComplete(()=>
        transform.DOScale(Vector3.one, moveSpeed / 2));
    }

    void ChangePlayerColour()
    {
        rend.material.DOColor(GetRandomColour(), 1f);
    }

    void CameraShake()
    {
        Camera.main.DOShakePosition(moveSpeed, 0.4f);
    }
}
