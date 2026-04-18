using UnityEngine;
using Cinemachine;

public class TerminalController : MonoBehaviour
{
    [Header("Görsel Ayarlar")]
    public CinemachineVirtualCamera terminalCamera; 
    public GameObject hackGameUI; 

    [Header("Kapý Ayarý")]
    public DoorController targetDoor; 

    
    public void ActivateTerminal(GameObject player)
    {
        
        if (hackGameUI != null) hackGameUI.SetActive(true);

        
        if (terminalCamera != null)
        {
            terminalCamera.gameObject.SetActive(true);
            terminalCamera.Priority = 20;
        }

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            pm.isHacking = true;
        }
    }

    
    public void OnHackSuccess(GameObject player)
    {
        
        if (hackGameUI != null) hackGameUI.SetActive(false);

        
        if (terminalCamera != null)
        {
            terminalCamera.Priority = 0;
            terminalCamera.gameObject.SetActive(false);
        }

       
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            pm.isHacking = false;
        }

        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        
        if (targetDoor != null)
        {
            targetDoor.OpenDoor();
        }

        Debug.Log("Hack Baþarýlý! Kapý tetiklendi.");
    }
}