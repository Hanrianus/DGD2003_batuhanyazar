using UnityEngine;
using UnityEngine.AI; 

public class NavMeshEnemyAI : MonoBehaviour
{
    [Header("Yapay Zeka Hedefi")]
    public Transform playerTransform; 

    private NavMeshAgent agent; 

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
        if (playerTransform != null && agent != null)
        {
            
            agent.SetDestination(playerTransform.position);
        }
    }
}