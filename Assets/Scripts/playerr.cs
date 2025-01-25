using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del personaje
    public Animator animator; // Animator para manejar las animaciones
    private Rigidbody rb; // Rigidbody del personaje

    private Vector3 moveDirection; // Dirección de movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Leer entradas del teclado
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular dirección de movimiento
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Actualizar animaciones
        animator.SetBool("isWalking", moveDirection.magnitude > 0);
    }

    void FixedUpdate()
    {
        // Mover al personaje usando Rigidbody
        if (moveDirection.magnitude > 0)
        {
            rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);

            // Rotar hacia la dirección del movimiento
            transform.forward = moveDirection;
        }
    }
}
