using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Hareket Ayarlarý")]
    public float speed = 6f;
    public float gravity = 9.81f; 

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) moveDirection.z += 1f;
            if (Keyboard.current.sKey.isPressed) moveDirection.z -= 1f;
            if (Keyboard.current.aKey.isPressed) moveDirection.x -= 1f;
            if (Keyboard.current.dKey.isPressed) moveDirection.x += 1f;
        }

        moveDirection = moveDirection.normalized;

        
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 720f * Time.deltaTime);
        }

        
        if (controller.isGrounded)
        {
            velocity.y = -2f; 
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime; 
        }

        
        Vector3 finalMove = (moveDirection * speed) + velocity;

        
        if (controller != null)
        {
            controller.Move(finalMove * Time.deltaTime);
        }
    }
}