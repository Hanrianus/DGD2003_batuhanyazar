using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SecuritySystem : MonoBehaviour
{
    [Header("UI & Audio Settings")]
    public TextMeshProUGUI timerText;
    public GameObject sirenAudioObject; 
    public float timeLimit = 30f; 

    [Header("Light Settings")]
    public List<Light> schoolLights; 
    public float blinkSpeed = 0.5f;

    private float countdown;
    private bool isAlarmActive = false;
    private bool isLightsOn = true;

    void Start()
    {
        countdown = timeLimit;

       
        if (schoolLights == null || schoolLights.Count == 0)
        {
            schoolLights = new List<Light>(FindObjectsOfType<Light>());
        }
    }

   
    public void StartSecurityAlarm()
    {
        if (isAlarmActive) return; 

        isAlarmActive = true;

        
        if (timerText != null) timerText.gameObject.SetActive(true);

        
        if (sirenAudioObject != null)
        {
            sirenAudioObject.SetActive(true);

            
            AudioSource audio = sirenAudioObject.GetComponent<AudioSource>();
            if (audio != null)
            {
                audio.Play();
            }
        }

       
        foreach (Light l in schoolLights)
        {
            if (l.type == LightType.Point || l.type == LightType.Spot)
            {
                l.color = Color.red;
            }
        }
        StartCoroutine(BlinkLightsRoutine());
    }

    void Update()
    {
        if (!isAlarmActive) return;

        
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            DisplayTime(countdown);
        }
        else
        {
            
            RestartGame();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0) timeToDisplay = 0;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 100;
        timerText.text = string.Format("{0:00}:{1:00}", seconds, milliSeconds);
    }

    void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    IEnumerator BlinkLightsRoutine()
    {
        while (isAlarmActive)
        {
            isLightsOn = !isLightsOn;
            foreach (Light l in schoolLights)
            {
                if (l.type == LightType.Point || l.type == LightType.Spot)
                {
                    l.enabled = isLightsOn;
                }
            }
            yield return new WaitForSeconds(blinkSpeed);
        }
    }

    
    public void StopAlarmAndWin()
    {
        isAlarmActive = false;
        StopAllCoroutines(); 

        if (timerText != null) timerText.text = "GÖREV BAÞARILI!";

        
        if (sirenAudioObject != null)
        {
            AudioSource audio = sirenAudioObject.GetComponent<AudioSource>();
            if (audio != null)
            {
                audio.Stop(); 
            }
            sirenAudioObject.SetActive(false);
        }
    }
}