using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento
    public LayerMask groundMask;      // Capa del suelo
    public Transform groundCheck;     // Objeto que detecta si estamos en el suelo
    public float groundDistance = 0.4f; // Distancia para chequear el suelo

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Inicializar el Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Comprobar si está tocando el suelo (opcional si no necesitas la verificación)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Obtener entrada para movimiento en el eje X y Z
        float x = Input.GetAxis("Horizontal");  // Teclas A/D o Flechas Izquierda/Derecha
        float z = Input.GetAxis("Vertical");    // Teclas W/S o Flechas Adelante/Atrás

        // Crear un vector de movimiento
        Vector3 move = new Vector3(x, 0, z).normalized * moveSpeed;

        // Aplicar movimiento al Rigidbody
        rb.MovePosition(rb.position + move * Time.deltaTime);
    }
}
