using UnityEngine;
using Cinemachine;
using UnityEngine.Events; 

public class TerminalController : MonoBehaviour
{
    [Header("Görsel Ayarlar")]
    public CinemachineVirtualCamera terminalCamera;
    public GameObject hackGameUI;

    [Header("VFX Ayarlarý")]
    public GameObject successVFXPrefab;
    public Transform vfxSpawnPoint;

    [Header("Script Haberleþmesi (Unity Event)")]
   
    public UnityEvent onHackSuccessEvent;

    
    public void ActivateTerminal(GameObject player)
    {
        if (hackGameUI != null) hackGameUI.SetActive(true);

        if (terminalCamera != null)
        {
            terminalCamera.gameObject.SetActive(true);
            terminalCamera.Priority = 100;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        if (pm != null) pm.isHacking = true;
    }

   
    public void OnHackSuccess(GameObject player)
    {
        
        if (successVFXPrefab != null)
        {
            Vector3 spawnPos = vfxSpawnPoint != null ? vfxSpawnPoint.position : transform.position;
            GameObject effect = Instantiate(successVFXPrefab, spawnPos, Quaternion.identity);

            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null) ps.Play();

            Destroy(effect, 4f);
        }

        
        if (hackGameUI != null) hackGameUI.SetActive(false);

        if (terminalCamera != null)
        {
            terminalCamera.Priority = 0;
            terminalCamera.gameObject.SetActive(false);
        }

       
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        if (pm != null) pm.isHacking = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

       
        if (onHackSuccessEvent != null)
        {
            onHackSuccessEvent.Invoke();
        }

        Debug.Log("Hack Baþarýlý! Unity Event tetiklendi.");
    }
}