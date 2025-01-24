using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilidad del mouse
    public Transform playerBody; // Cuerpo del personaje para rotar en el eje Y

    private float xRotation = 0f; // Control de la rotación vertical

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro
    }

    void Update()
    {
        // Leer movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación vertical de la cámara
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar el ángulo de visión
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotación horizontal del personaje
        playerBody.Rotate(Vector3.up * mouseX);
    }

    if (Input.GetKeyDown(KeyCode.Escape))
{
    Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
    Cursor.visible = true; // Muestra el cursor
}

}
