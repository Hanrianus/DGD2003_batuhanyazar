using UnityEngine;

public class SimpleSlideDoor : MonoBehaviour
{
    [Header("Hareket Ayarlarý")]
    public Vector3 slideDirection = new Vector3(0, 4, 0); 
    public float speed = 5f;

    private Vector3 closedPos;
    private Vector3 targetPos;
    private bool opening = false;

    void Start()
    {
       
        closedPos = transform.localPosition;
        targetPos = closedPos;
    }

    void Update()
    {
        
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, speed * Time.deltaTime);
    }

    
    public void OpenDoor()
    {
        targetPos = closedPos + slideDirection;
        opening = true;
        Debug.Log("Özel Script: Kapý açýlma komutu alýndý");
    }
}