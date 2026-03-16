using UnityEngine;
using UnityEngine.Events;

public class UniversalTrigger : MonoBehaviour
{
    public string targetTag;

    public UnityEvent<Collider> onTriggerEnter;
    public UnityEvent<Collider> onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            onTriggerEnter?.Invoke(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            onTriggerExit?.Invoke(other);
        }
    }
}