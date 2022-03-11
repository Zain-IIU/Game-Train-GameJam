using DG.Tweening;
using UnityEngine;

public partial class FireObstacle : MonoBehaviour,IObstacle
{
    [SerializeField] private ObstacleType type;

    [SerializeField] private GameObject fire;

    public void DamagePlayer()
    {
        fire.transform.DOScaleY(0, 0.24f).SetEase(Ease.InOutSine).OnComplete(()=>
        {
            fire.SetActive(false);
        });
    }
}
