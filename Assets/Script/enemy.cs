using UnityEngine;

public class EnemyHorizontalMove : MonoBehaviour
{
    [Header("Hareket Ayarlarý")]
    [Tooltip("Düþmanýn saða-sola gitme hýzý")]
    public float speed = 2f;

    [Tooltip("UI objeleri için mesafe genelde büyüktür (Örn: 50, 100, 200 piksel). Dýþarý taþýyorsa bu deðeri küçültün.")]
    public float moveDistance = 100f;

    
    private Vector3 startLocalPos;

    void Start()
    {
        
        startLocalPos = transform.localPosition;
    }

    void Update()
    {
        
        float newX = startLocalPos.x + Mathf.Sin(Time.time * speed) * moveDistance;

        
        transform.localPosition = new Vector3(newX, startLocalPos.y, startLocalPos.z);
    }
}