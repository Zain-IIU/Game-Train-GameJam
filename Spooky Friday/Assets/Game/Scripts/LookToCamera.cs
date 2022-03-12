using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    public void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
