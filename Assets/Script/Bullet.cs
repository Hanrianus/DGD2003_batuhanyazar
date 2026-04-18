using UnityEngine;

public class BulletUI : MonoBehaviour
{
    public float speed = 800f;
    public float destroyY = 500f;

    void Update()
    {
        
        transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);

        
        if (transform.localPosition.y > destroyY)
        {
            Destroy(gameObject);
        }

        CheckCollision();
    }

    void CheckCollision()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            
            if (Vector3.Distance(transform.localPosition, enemy.transform.localPosition) < 50f)
            {
                Destroy(enemy);
                Destroy(gameObject);
                break;
            }
        }
    }
}