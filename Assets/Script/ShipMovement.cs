using UnityEngine;
using UnityEngine.InputSystem;

public class ShipControllerUI : MonoBehaviour
{
    public float speed = 500f;
    public GameObject bulletPrefab;
    public Transform bulletParent;

    
    public float screenLimitX = 500f;

    private PlayerMovement playerScript;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) playerScript = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerScript == null || !playerScript.isHacking) return;

        float moveInput = 0;
        if (Keyboard.current.aKey.isPressed) moveInput = -1;
        if (Keyboard.current.dKey.isPressed) moveInput = 1;

        
        transform.localPosition += new Vector3(moveInput * speed * Time.deltaTime, 0, 0);

        
        Vector3 pos = transform.localPosition;

        if (pos.x > screenLimitX) 
        {
            pos.x = -screenLimitX; 
        }
        else if (pos.x < -screenLimitX) 
        {
            pos.x = screenLimitX; 
        }

        transform.localPosition = pos;

        if (Keyboard.current.spaceKey.wasPressedThisFrame) Shoot();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletParent);
        bullet.transform.position = transform.position;
        
        bullet.transform.localRotation = Quaternion.identity;
    }
}