using UnityEngine;

public class SpectatorCamera : MonoBehaviour
{
    public float moveSpeed = 10f;    // Velocidad de movimiento
    public float lookSpeed = 2f;     // Sensibilidad del ratón
    public float sprintMultiplier = 2f; // Multiplicador de velocidad al hacer sprint
    public bool invertY = false;     // Invertir el eje Y

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        // Movimiento con teclas WASD
        float moveX = Input.GetAxis("Horizontal");  // A/D o Flechas Izquierda/Derecha
        float moveZ = Input.GetAxis("Vertical");    // W/S o Flechas Adelante/Atrás

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Sprint con Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            move *= sprintMultiplier;
        }

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // Rotación de la cámara con el ratón
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * (invertY ? 1 : -1);

        rotationX += mouseX;
        rotationY += mouseY;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);  // Limita la rotación vertical

        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}
