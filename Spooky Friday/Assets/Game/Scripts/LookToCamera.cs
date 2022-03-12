using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    public void FixedUpdate()
    {
        Camera camera = Camera.main;
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }
}
