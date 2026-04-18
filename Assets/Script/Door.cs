using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Kapý Ayarlarý")]
    public Vector3 openOffset = new Vector3(0, 4, 0); 
    public float openSpeed = 2f;

    private bool isOpen = false;
    private Vector3 closedPosition;
    private Vector3 targetPosition;

    void Start()
    {
        closedPosition = transform.position;
        targetPosition = closedPosition;
    }

    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * openSpeed);
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            targetPosition = closedPosition + openOffset;
            isOpen = true;
            Debug.Log("Kapý açýlýyor...");
        }
    }
}