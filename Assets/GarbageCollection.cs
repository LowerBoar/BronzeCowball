using UnityEngine;

public class GarbageCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GC")) {
            Destroy(gameObject);
        }
    }
}
