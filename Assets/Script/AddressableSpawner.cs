using UnityEngine;
using UnityEngine.AddressableAssets; // KRİTİK: Addressables paketinin komutlarını kullanabilmek için bu kütüphane şarttır!

public class AddressableSpawner : MonoBehaviour
{
    [Header("Addressables Ayarları")]
    [Tooltip("Prefab'e verdiğin Addressable ismiyle birebir aynı olmalı (büyük/küçük harf duyarlıdır)")]
    public string addressableKey = "CollectibleSphere";

    [Header("Spawn Sınırları (Harita Boyutu)")]
    [Tooltip("Dairelerin merkezden en fazla kaç metre uzakta doğabileceğini belirler")]
    public float spawnRange = 7f;

    // Yeni daireyi haritada rastgele bir konumda doğuran fonksiyon
    public void SpawnNewCollectible()
    {
        // 🔍 DEBUG: Konsola mesaj basarak bu fonksiyonun tetiklendiğini doğruluyoruz
        Debug.Log("AddressableSpawner: Yeni daire doğurma fonksiyonu tetiklendi! Addressables sistemi çağrılıyor...");

        // Belirttiğin sınırlara göre (-7 ile +7 arası gibi) rastgele X ve Z koordinatları seçiliyor
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);

        // Kürenin havada asılı kalmaması veya zemine gömülmemesi için Y yüksekliğini 0.5f yapıyoruz
        Vector3 spawnPosition = new Vector3(randomX, 0.5f, randomZ);

        // 🔥 HOCANIN ARADIĞI O ÖZEL SATIR: 
        // Objeyi klasik Instantiate ile değil, Addressables hafıza adresi üzerinden ASENKRON olarak sahneye doğuruyoruz.
        Addressables.InstantiateAsync(addressableKey, spawnPosition, Quaternion.identity);

        Debug.Log("AddressableSpawner: '" + addressableKey + "' isimli obje " + spawnPosition + " konumunda asenkron olarak doğruldu.");
    }
}