using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LogicaBarraVida : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image imagenBarraVida;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       vidaActual = vidaMax; 
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        if(vidaActual <= 0){
            
            gameObject.SetActive(false);
            
        }
    }
    public void RevisarVida(){
        imagenBarraVida.fillAmount = vidaActual / vidaMax;
    }
}
