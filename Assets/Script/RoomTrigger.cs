using UnityEngine;

public class RoomTriggerZone : MonoBehaviour
{
    
    public SecuritySystem securitySystem;

    
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; 

            if (securitySystem != null)
            {
                
                securitySystem.StartSecurityAlarm();
                Debug.Log("Oyuncu odaya sýzdý! Alarm aktif!");
            }
            else
            {
                Debug.LogError("RoomTriggerZone: SecuritySystem scripti atanmadý!");
            }
        }
    }
}