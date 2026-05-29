using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    private InputAction move;
    private InputAction look;
    
    private Vector2 movement;
    private Vector2 looking;

    private Rigidbody rb;

    public float moveSpeed = 5.0f;
    public float lookSpeed = 5.0f;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        move = InputSystem.actions.FindAction("Move");
        look = InputSystem.actions.FindAction("Look");

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement = move.ReadValue<Vector2>();
        looking = look.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Walking();
        Looking();
    }

    private void Walking()
    {
        rb.MovePosition(rb.position + transform.forward * movement.y * moveSpeed * Time.deltaTime);
    }

    private void Looking()
    {
        if (movement.y != 0)
        {
            float rotationAmount = looking.x * lookSpeed * Time.deltaTime;
            Quaternion deltaRotation = Quaternion.Euler(0, rotationAmount, 0);
            rb.MoveRotation(rb.rotation *  deltaRotation);
        }
    }
}
