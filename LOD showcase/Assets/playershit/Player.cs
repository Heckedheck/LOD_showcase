using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private Vector2 Movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnMove(InputValue value)
    {
        // Read value from control. The type depends on what type of controls.
        // the action is bound to.
        Movement = value.Get<Vector2>();
        rb.AddForce(Movement);
    }
}
