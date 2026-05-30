using UnityEngine;
using UnityEngine.SceneManagement; 

public class TestSceneManager : MonoBehaviour
{
    [Header("Sahne Ayarı")]
    [Tooltip("Ana menü sahnenizin tam adı (birebir aynı olmalı)")]
    public string mainMenuName = "MainMenu";

    
    public void ReturnToMainMenu()
    {
        
        SceneManager.LoadScene(mainMenuName);
    }
}