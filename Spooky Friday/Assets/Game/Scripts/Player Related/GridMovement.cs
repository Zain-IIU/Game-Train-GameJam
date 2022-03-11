using System;
using DG.Tweening;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private float zMoveVal = 1f;


    [SerializeField] private float easeTime;
    [SerializeField] private Ease easeType;
    
    
    public void MoveGrid_Up()
    {
        if (Math.Abs(transform.eulerAngles.y - 90f) > 10f)
        {
            Debug.Log("Player Rotated");
            transform.DORotateQuaternion(Quaternion.Euler(0, 90, 0), easeTime).SetEase(easeType).OnComplete(() =>
            {
                transform.DOLocalMove(new Vector3(transform.localPosition.x + zMoveVal,0,0), easeTime*2).SetEase(easeType);
            });
        }
        else
        {
            transform.DOLocalMove(new Vector3(transform.localPosition.x + zMoveVal,0,0), easeTime*2).SetEase(easeType);
        }
        
    }
    public void MoveGrid_Down()
    {
        if (Math.Abs(transform.eulerAngles.y - 90f) < 10f)
        {
            Debug.Log("Player Rotated");
            transform.DORotateQuaternion(Quaternion.Euler(0, -90, 0), easeTime).SetEase(easeType).OnComplete(() =>
            {
                transform.DOLocalMove(new Vector3(transform.localPosition.x - zMoveVal,0,0), easeTime*2).SetEase(easeType);
            });
        }
        else
        {
            transform.DOLocalMove(new Vector3(transform.localPosition.x - zMoveVal,0,0), easeTime*2).SetEase(easeType);
        }
    }
    public void MoveGrid_Left()
    {
        if (Math.Abs(transform.eulerAngles.y - 0) > 10f)
        {
            Debug.Log("Player Rotated");
            transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), easeTime).SetEase(easeType).OnComplete(() =>
            {
                transform.DOLocalMove(new Vector3(0,0,transform.localPosition.z + zMoveVal), easeTime*2).SetEase(easeType);
            });
        }
        else
        {
            transform.DOLocalMove(new Vector3(0,0,transform.localPosition.z + zMoveVal), easeTime*2).SetEase(easeType);
        }
    }
    public void MoveGrid_Right()
    {
        if (Math.Abs(transform.eulerAngles.y - 0) < 10f)
        {
            Debug.Log("Player Rotated");
            transform.DORotateQuaternion(Quaternion.Euler(0, 180, 0), easeTime).SetEase(easeType).OnComplete(() =>
            {
                transform.DOLocalMove(new Vector3(0,0,transform.localPosition.z - zMoveVal), easeTime*2).SetEase(easeType);
            });
        }
        else
        {
            transform.DOLocalMove(new Vector3(0,0,transform.localPosition.z - zMoveVal), easeTime*2).SetEase(easeType);
        }
    }
    


}