using UnityEngine;
using System.IO;
using TMPro;

[System.Serializable]
public class GameData
{
    public int currentScore = 0;
    public int highScore = 0;
}

public class ScoreManager : MonoBehaviour
{
    [Header("UI Elemanları")]
    public TextMeshProUGUI scoreText;

    [Header("Kayıt Verisi")]
    public GameData data = new GameData();

    private string savePath;

    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "savedata.json");

        
        LoadGameData();
    }

    void Start()
    {
        
        data.currentScore = 0;

       
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        data.currentScore += points;

        if (data.currentScore > data.highScore)
        {
            data.highScore = data.currentScore;
        }

        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puan: " + data.currentScore + " | En Yüksek: " + data.highScore;
        }
    }

   
    public void SaveGameData()
    {
        string jsonText = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, jsonText);
        Debug.Log("Oyun Verileri JSON Olarak Kaydedildi!");
    }

    
    public void LoadGameData()
    {
        if (File.Exists(savePath))
        {
            string jsonText = File.ReadAllText(savePath);
            data = JsonUtility.FromJson<GameData>(jsonText);
            Debug.Log("Eski JSON Kaydı Başarıyla Yüklendi!");
        }
        else
        {
            data = new GameData();
        }
    }

    void OnApplicationQuit()
    {
        SaveGameData();
    }
}