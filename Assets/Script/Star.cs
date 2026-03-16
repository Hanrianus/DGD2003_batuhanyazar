using UnityEngine;
using UnityEngine.Events;

public class Star : MonoBehaviour
{
    public UnityEvent onCollected;

    void Collect()
    {
        onCollected?.Invoke();
        Destroy(gameObject);
    }
}