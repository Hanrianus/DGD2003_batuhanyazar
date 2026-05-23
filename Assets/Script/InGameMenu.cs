using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [Header("Menu UI")]
    public GameObject mainPanel;     
    public GameObject settingsPanel; 
    public Slider volumeSlider;      

    void Start()
    {
        
        Time.timeScale = 0f;

        
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);

       
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 0.2f);
        AudioListener.volume = savedVolume;

        
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;

        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Debug.Log("Oyundan Çýkýldý!");
        Application.Quit();
    }

    
    public void OpenSettings()
    {
        mainPanel.SetActive(false); 
        settingsPanel.SetActive(true); 
    }

    
    public void CloseSettings()
    {
        settingsPanel.SetActive(false); 
        mainPanel.SetActive(true); 
    }

    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; 
        PlayerPrefs.SetFloat("GameVolume", volume); 
    }
}