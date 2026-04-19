using UnityEngine;

public class GameWin : MonoBehaviour
{
    public GameObject winPanel; // Hazýrladýðýn WinPanel'i buraya sürükle

    private void OnTriggerEnter(Collider other)
    {
        // Sadece oyuncu bu alana girerse çalýþ
        if (other.CompareTag("Player"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // Paneli aç
        if (winPanel != null) winPanel.SetActive(true);

        // Mouse'u serbest býrak
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Zamaný durdur (Oyunu dondurur)
        Time.timeScale = 0f;

        Debug.Log("Proje Baþarýyla Tamamlandý!");
    }
}