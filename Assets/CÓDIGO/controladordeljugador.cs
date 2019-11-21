using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladordeljugador : MonoBehaviour
{
    //Almacena componente Rigibody del personaje Jugador.//
    Rigidbody rb;
    public float velocidad;
    int contador;
    int numItems_1;
    int numItems_2;
    int numitems_3;



    public Text marcador ;
    public Text Findejuego ;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        marcador.text = "Puntos" + contador;
        Findejuego.gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);        rb.AddForce(movimiento);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Suma1")
        {
            Destroy(other.gameObject);
            contador = contador + 1;
            numItems_1 = numItems_1 + 1;
        }

        else if (other.tag == "Suma2")
        {
            Destroy(other.gameObject);
            contador = contador + 2;
            numItems_2 = numItems_2 + 1;
        }
        else if (other.tag == "Resta1")
        {
            Destroy(other.gameObject);
            contador = contador - 1;
        }

        ActualizarMarcador();

        if (numItems_1 >= 6 && numItems_2 >= 4 )
    
        {
            Findejuego.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
   
    public void ActualizarMarcador()
    {
        marcador.text = "Puntos " + " " + contador;
    }
}

