using DG.Tweening;
using UnityEngine;

public  class FireObstacle : MonoBehaviour,IObstacle
{
    [SerializeField] private GameObject fire;

    public void DamagePlayer()
    {
        fire.transform.DOScaleY(0, 0.24f).SetEase(Ease.InOutSine).OnComplete(()=>
        {
            fire.SetActive(false);
        });
    }
}
