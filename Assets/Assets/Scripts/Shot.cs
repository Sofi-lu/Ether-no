using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;

    public RectTransform crosshair; // La mira en el Canvas (RawImage)

    public float shotForce = 1500; //Fuerza con que dispara
    public float shotRate = 0.5f;

    private float shotRateTime = 0;


    public Transform weapon;        // Transform del arma
    public Camera mainCamera;       // Cámara principal para calcular el movimiento
     public float weaponRotationSpeed = 5f; // Velocidad de rotación del arma


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            if(Time.time > shotRateTime){
               
                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 2);
            }
        }
         MoveCrosshair();
        RotateWeapon();
    }
    void MoveCrosshair(){
         // Obtener la posición del mouse en pantalla
        Vector3 mousePosition = Input.mousePosition;

        // Convertir la posición del mouse al espacio del Canvas
        crosshair.position = mousePosition;
    }
    void RotateWeapon()
    {
        // Obtiene la posición del mouse en el mundo desde la cámara
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Calcula la dirección desde el arma hacia el punto del mouse
            Vector3 direction = hit.point - weapon.position;
            

            // Rota el arma hacia la dirección del mouse
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            weapon.rotation = Quaternion.Lerp(weapon.rotation, targetRotation, Time.deltaTime * weaponRotationSpeed);
        }
    }
}
