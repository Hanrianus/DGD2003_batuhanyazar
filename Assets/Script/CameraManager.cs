using UnityEngine;
using Cinemachine; 

public class CameraManager : MonoBehaviour
{
    
    public CinemachineVirtualCamera introCam;
    public CinemachineVirtualCamera fpsCam;

    void Start()
    {
        introCam.Priority = 20;
        fpsCam.Priority = 10;

        Invoke("SwitchToFPS", 2.0f);
    }

    void SwitchToFPS()
    {
        fpsCam.Priority = 30;
    }
}