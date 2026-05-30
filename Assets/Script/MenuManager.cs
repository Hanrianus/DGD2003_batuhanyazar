using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Sahne Ýsimleri")]
    public string gameSceneName = "GameScene"; 
    public string testSceneName = "TestScene"; 

    [Header("UI Baðlantýlarý")]
    public GameObject settingsPanel;
    public Slider volumeSlider;

    void Start()
    {
        
        if (settingsPanel != null) settingsPanel.SetActive(false);

        
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenTestScene()
    {
        SceneManager.LoadScene(testSceneName);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SetVolume(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }
}