using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    public float jump = 5.0f; //Variable para saltar
    public Animator anim;
    public float x,y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb; //Variable de tipo Rigidbody
    private bool isGrounded; //Variable que detecta el suelo
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); //Obtener el RigidBody
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //Para rotar el personaje
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);

        //Para que se deplace
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        //Para animar
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        //Para saltar
        isGrounded = Physics.Raycast(transform.position, Vector3.down * 1.1f);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            // isGrounded = false;
        }
    }
    // private void OnCollisionEnter(Collision coliision){
    //     if(coliision.gameObject.CompareTag("Ground")){
    //         isGrounded = true;
    //     }
    // }
}
