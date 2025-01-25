using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



    public class Player : MonoBehaviour
    {
        
        public float speed = 1.0f; //Velocidad del movimiento
        public float rotationSpeed = 64.0f; // Esta variable es para rotar
        
        //Variable para saltar
        public float jump = 5.0f;

        private Rigidbody rb; //Referencia al Rigidbody
        private bool isGrounded = true; //Verifica si esta en el suelo
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            rb = GetComponent<Rigidbody>(); //Obtener el Rigidbody
        }
        // Update is called once per frame
        void Update()
        {
            //Movimiento
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
            // transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed, Space.World);

            //Rotacion hacia la direccion del movimiento
            if(movement != Vector3.zero){
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 *Time.deltaTime);
            }

            //Rotacion
            float rotationY = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * rotationSpeed, 0));

            //Salto
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        private void OnCollisionEnter(Collision collision){
            if(collision.gameObject.CompareTag("Ground")){
                isGrounded = true; //Detecta si esta tocando el suelo
            }
        }    }


