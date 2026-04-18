using UnityEngine;

public class MiniGameManagerUI : MonoBehaviour
{
    public Transform enemyContainer; 
    public TerminalController terminalController; 

    void Update()
    {
       
        if (enemyContainer != null && enemyContainer.childCount == 0)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            
            terminalController.OnHackSuccess(player);
            
            gameObject.SetActive(false);
        }
    }
}