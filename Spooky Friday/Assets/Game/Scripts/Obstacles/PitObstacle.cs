using DG.Tweening;
using UnityEngine;

public class PitObstacle : MonoBehaviour,IObstacle
{
    [SerializeField] private Transform spikes;
    [SerializeField] private Transform tile;
    
    public void DamagePlayer()
    {
        spikes.DOLocalMoveY(-2,0.5f).OnComplete(()=>
        {
            Debug.Log("Player Destroyed");
            tile.DOLocalMoveY(0, 0.25f);
        });
    }
}
