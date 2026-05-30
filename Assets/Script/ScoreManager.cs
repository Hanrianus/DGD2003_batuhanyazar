using UnityEngine;
using System.IO; 
using TMPro;    

public class ScoreManager : MonoBehaviour
{
    [Header("UI Elemanları")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int currentScore = 0;
    private int highScore = 0;
    private string saveFilePath;

    void Awake()
    {
        
        saveFilePath = Path.Combine(Application.persistentDataPath, "savedata.json");

        
        LoadHighScore();
    }

    void Start()
    {
        
        UpdateUI();
    }

    
    public void AddScore(int amount)
    {
        currentScore += amount;

        
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore(); 
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Puan: " + currentScore;

        if (highScoreText != null)
            highScoreText.text = "En Yüksek: " + highScore;
    }

   
    private void SaveHighScore()
    {
        GameData data = new GameData();
        data.highScore = highScore;

        
        string json = JsonUtility.ToJson(data, true);

        
        File.WriteAllText(saveFilePath, json);
        Debug.Log("JSON: Yeni en yüksek puan başarıyla diske kaydedildi: " + highScore);
    }

    
    private void LoadHighScore()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            highScore = data.highScore;
            Debug.Log("JSON: Eski en yüksek puan başarıyla yüklendi: " + highScore);
        }
        else
        {
            
            highScore = 0;
        }
    }
}


[System.Serializable]
public class GameData
{
    public int highScore;
}