using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Özellikler")]
    public int scoreReward = 10;

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Collectible: Daireye bir nesne temas etti! Temas edenin adı: " + other.name);

        
        if (other.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Collectible: Temas eden nesnenin Oyuncu olduğu doğrulandı. İşlemler başlıyor...");

            
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(scoreReward);
            }
            else
            {
                Debug.LogError("Collectible HATA: Sahnede 'ScoreManager' bulunamadı! Hiyerarşide ScoreManager objesi var mı?");
            }

            
            AddressableSpawner spawner = FindObjectOfType<AddressableSpawner>();
            if (spawner != null)
            {
                spawner.SpawnNewCollectible();
            }
            else
            {
                Debug.LogError("Collectible HATA: Sahnede 'AddressableSpawner' bulunamadı! Hiyerarşide boş bir obje oluşturup içine AddressableSpawner kodunu attın mı?");
            }

           
            Destroy(gameObject);
        }
        else
        {
            
            Debug.LogWarning("Collectible: Daireye temas eden nesne Oyuncu değil. Kod durduruldu.");
        }
    }
}