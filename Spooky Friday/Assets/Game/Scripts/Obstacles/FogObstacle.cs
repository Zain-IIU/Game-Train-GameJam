using UnityEngine;

public  class FogObstacle : MonoBehaviour,IObstacle
{

    [SerializeField] private ParticleSystem fog;

    public void DamagePlayer()
    {
        var emissionModule = fog.emission;
        emissionModule.rateOverTime = 0;
    }
}