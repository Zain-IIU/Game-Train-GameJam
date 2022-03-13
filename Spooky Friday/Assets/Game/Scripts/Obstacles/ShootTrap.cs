using DG.Tweening;
using UnityEngine;

public class ShootTrap : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float timeToShoot;

    [SerializeField] private Transform arrowPoint;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float arrowPower;
    
    private void Start()
    {
       InvokeRepeating(nameof(ShootArrow),1,timeToShoot);
    }

    private void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab,arrowPoint.position,Quaternion.identity);
        arrow.transform.DOMove(shootPoint.position, arrowPower).OnComplete(() =>
        {
            Destroy(arrow);
        });
    }
}
