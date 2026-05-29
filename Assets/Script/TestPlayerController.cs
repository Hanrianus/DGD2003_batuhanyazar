using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float moveSpeed = 6f;       
    public float rotationSpeed = 180f; 
    public float gravity = 9.81f;      

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveInput = 0f;
        float turnInput = 0f;

       
        if (Keyboard.current != null)
        {
            
            if (Keyboard.current.wKey.isPressed) moveInput += 1f;
            if (Keyboard.current.sKey.isPressed) moveInput -= 1f;

            
            if (Keyboard.current.aKey.isPressed) turnInput -= 1f;
            if (Keyboard.current.dKey.isPressed) turnInput += 1f;
        }

        
        transform.Rotate(Vector3.up * turnInput * rotationSpeed * Time.deltaTime);

        
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed;

       
        if (controller.isGrounded)
        {
            velocity.y = -2f; 
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime; 
        }

        
        Vector3 finalMove = moveDirection + velocity;

        if (controller != null)
        {
            controller.Move(finalMove * Time.deltaTime);
        }
    }
}