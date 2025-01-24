using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Personaje a seguir
    public Vector3 offset; // Distancia de la cámara al personaje

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset; // Seguir al personaje con un desplazamiento
        }
    }
}
