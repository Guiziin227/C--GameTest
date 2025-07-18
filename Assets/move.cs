using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;

    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the GameObject.");
        }
    }

    private void Start()
    {
        Debug.Log("Move script initialized with speed: " + speed);
    }

    // 1. Este método será chamado pelo componente PlayerInput
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        // 2. A movimentação agora usa o valor lido pelo OnMove
        // O Input System já lida com a normalização para teclados e valores analógicos para controles
        rb.linearVelocity = moveInput * speed;
    }
}