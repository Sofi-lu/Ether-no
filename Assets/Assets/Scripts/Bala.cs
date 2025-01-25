using UnityEngine;

public class Bala : MonoBehaviour
{
    public float daño = 2.0f; // Daño que la bala inflige

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la bala impacta con un objeto que tiene el componente LogicaBarraVida
        LogicaBarraVida barraVida = collision.gameObject.GetComponent<LogicaBarraVida>();
        if (barraVida != null && collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Haciendo daño a enemigo");
            // Reduce la vida del objeto impactado
            barraVida.vidaActual -= daño;
        }

        // Destruye la bala tras el impacto
        Destroy(gameObject);
    }
}
