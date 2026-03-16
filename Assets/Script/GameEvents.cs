using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public delegate void DeathDelegate();
    public delegate int ScoreDelegate(int points);

    public ScoreDelegate onScorePoints;
    public DeathDelegate OnPlayerDeath;

    public Action onHeal;
    public Action<float> onTakeDamage;
    

    private void OnEnable(){
        OnPlayerDeath += PlayerDied;
        OnPlayerDeath += UpdateUI;
        onTakeDamage += PlayerTookDamage;
        onScorePoints += AddScore;
    }
    
    private void OnDisable(){
        OnPlayerDeath -= PlayerDied;
        OnPlayerDeath -= UpdateUI;
        onTakeDamage -= PlayerTookDamage;
        onScorePoints -= AddScore;
    }

    private void PlayerDied(){
        Debug.Log("Player has died");
    }

    private void UpdateUI(){
        Debug.Log("UI Updated");
    }

    private void PlayerTookDamage(float damage){
        Debug.Log("Player took damage: " + damage);
    }

    private int AddScore(int points){
        Debug.Log("Score added: " + points);
        return points;
    }

    public void TriggerDeath(){
        OnPlayerDeath?.Invoke();
    }
}