using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player; 
    public float rotationSpeed = 5f; 

    void Update()
    {
        if (player != null)
        {
            
            Vector3 direction = player.position - transform.position;

            
            direction.y = 0;

            
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}