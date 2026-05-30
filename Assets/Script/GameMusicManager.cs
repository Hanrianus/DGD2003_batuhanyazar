using UnityEngine;

public class GameMusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.7f);

            
            audioSource.volume = savedVolume;
        }
    }
}