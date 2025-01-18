using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Player : MonoBehaviour
    {
        //Creo una variable que le da la velocidad inicial al objeto
        public float speed = 1.0f;
        public float rotationSpeed = 64.0f; // Esta variable es para rotar
        
        //Variable para saltar
        public float jump = 5.0f;

        private Rigidbody rb;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            rb = GetComponent<Rigidbody>();
        }
        // Update is called once per frame
        void Update()
        {
            //Movimiento
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);

            //Rotacion
            float rotationY = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * rotationSpeed, 0));

            //Salto
            if(Input.GetKeyDown(KeyCode.Space)){
                rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            }
        }
    }


