using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            AudioManager.instance.Play("break");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
