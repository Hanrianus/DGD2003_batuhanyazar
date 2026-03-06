using UnityEngine;

public class MoodController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("SadZone")) anim.SetFloat("Mood", 1);
        else if (other.CompareTag("HappyZone")) anim.SetFloat("Mood", 2);
        else if (other.CompareTag("DanceZone")) anim.SetFloat("Mood", 3);
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("SadZone") || other.CompareTag("HappyZone") || other.CompareTag("DanceZone"))
        {
            if (anim != null) anim.SetFloat("Mood", 0);
        }
    }
}