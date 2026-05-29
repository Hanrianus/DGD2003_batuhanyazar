using UnityEngine;
using UnityEngine.AddressableAssets; 

public class AddressableSpawner : MonoBehaviour
{
    [Header("Addressables Ayarları")]
    [Tooltip("Prefab'e verdiğin Addressable ismiyle birebir aynı olmalı (büyük/küçük harf duyarlıdır)")]
    public string addressableKey = "CollectibleSphere";

    [Header("Mesafe Ayarları (Merkez Odaklı)")]
    [Tooltip("Yeni daire merkez koordinatın en az kaç metre uzağında doğsun?")]
    public float minSpawnDistance = 1f;

    [Tooltip("Yeni daire merkez koordinatın en fazla kaç metre uzağında doğsun?")]
    public float maxSpawnDistance = 6f;

    [Header("Sabit Merkez Koordinat Ayarı")]
    [Tooltip("Dairelerin etrafında rastgele dağılacağı ana merkez nokta")]
    
    public Vector3 centerPoint = new Vector3(31.6045494f, 35.6699982f, -101.419998f);

    
    public void SpawnNewCollectible()
    {
        
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

        
        float targetX = centerPoint.x + (randomDirection.x * randomDistance);
        float targetZ = centerPoint.z + (randomDirection.y * randomDistance);

        
        Vector3 spawnPosition = new Vector3(targetX, centerPoint.y, targetZ);

        
        Addressables.InstantiateAsync(addressableKey, spawnPosition, Quaternion.identity);

        Debug.Log("AddressableSpawner: Yeni daire sabit merkezin etrafında, Y: " + centerPoint.y + " yüksekliğinde doğuruldu! Konum: " + spawnPosition);
    }
}