using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private PlayerControl playerActions;
    private Vector2 moveInput;
    private bool isSprinting;
    private Vector3 velocity;

    [Header("Movement Settings")]
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float gravity = -9.81f;

    [Header("Rotation References")]
    [Tooltip("Karakterin içindeki boþ 'Head' objesi")]
    public Transform headTransform;
    [Tooltip("Hiyerarþideki 'Main Camera' objesi")]
    public Transform cameraTransform;

    [Header("Interaction (Raycasting)")]
    public float interactDistance = 3f;
    public UnityEvent onInteract;

    [Header("Animation Settings")]
    public float speedDampTime = 0.1f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerActions = new PlayerControl();

        // Mouse kilitleme
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Input System Eventleri
        playerActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        playerActions.Player.Sprint.performed += ctx => isSprinting = true;
        playerActions.Player.Sprint.canceled += ctx => isSprinting = false;
    }

    private void OnEnable() => playerActions.Player.Enable();
    private void OnDisable() => playerActions.Player.Disable();

    private void Update()
    {
        HandleRotation();
        HandleMovement();
        ApplyGravity();
        HandleInteraction();
        UpdateAnimations();
    }

    private void HandleRotation()
    {
        if (cameraTransform == null) return;

        // Kritik Nokta: Karakterin gövdesi sadece kameranýn Y (saða-sola) açýsýna bakar.
        // Bu sayede yukarý bakarken karakter öne devrilmez, titreme yapmaz.
        float cameraYRotation = cameraTransform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, cameraYRotation, 0);
    }

    private void HandleMovement()
    {
        if (cameraTransform == null) return;

        // Hareket yönünü kameraya göre hesapla
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0; right.y = 0;
        forward.Normalize(); right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;

        if (moveDirection.magnitude >= 0.1f)
        {
            float speed = isSprinting ? runSpeed : walkSpeed;
            controller.Move(moveDirection * speed * Time.deltaTime);
        }
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleInteraction()
    {
        if (cameraTransform == null) return;

        // Raycasting: Kameranýn merkezinden ileriye ýþýn atar
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.CompareTag("Terminal"))
            {
                Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.green);
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    Debug.Log("Terminale etkileþim saðlandý!");
                    onInteract.Invoke();
                }
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);
            }
        }
    }

    private void UpdateAnimations()
    {
        float targetSpeed = moveInput.magnitude > 0.1f ? (isSprinting ? 1.0f : 0.5f) : 0f;
        animator.SetFloat("Speed", targetSpeed, speedDampTime, Time.deltaTime);
    }
}