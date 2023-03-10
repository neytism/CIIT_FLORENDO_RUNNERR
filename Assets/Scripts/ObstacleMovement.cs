using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{
    public bool isMoving = false;

    //for rotation
    public Vector3 Rotation;
    public float RotateDuration;
    public int RotateLoopCount;
    public LoopType RotateLoop;
    public Ease RotateEase = Ease.Linear;

    //for movement
    public Vector3 StartPos;
    public Vector3 EndPos;                                  
    public float LRDuration;
    public Ease LREase;


    // Start is called before the first frame update
    void Start()
    {

        transform.DOLocalRotate(Rotation, RotateDuration, RotateMode.LocalAxisAdd).SetLoops(RotateLoopCount,RotateLoop).SetEase(RotateEase);

        if (isMoving)
        {
            StartMovement();
        }
           
    }

    public void StartMovement()
    {
        transform.DOLocalMove(EndPos, LRDuration).OnComplete(() => RestartMovement()).SetEase(LREase);
    }

    public void RestartMovement()
    {
        transform.DOLocalMove(StartPos, LRDuration).OnComplete(() => StartMovement()).SetEase(LREase);
    }





    
}
