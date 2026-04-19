using UnityEngine;

public class GameWin : MonoBehaviour
{
    public GameObject winPanel; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        
        if (winPanel != null) winPanel.SetActive(true);

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        
        Time.timeScale = 0f;

        Debug.Log("Proje Baþarýyla Tamamlandý!");
    }
}