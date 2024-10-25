using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumiJ : MonoBehaviour
{
    private bool recogido = false; // Controla si el Tumi ha sido recogido

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala") && !recogido)
        {
            recogido = true;
            GestorTumi.instancia.JugadorTieneTumi = true; // Marca que el jugador tiene el Tumi
            Debug.Log("Tumi recogido.");
            Destroy(gameObject); // Destruye el objeto Tumi en la escena
        }
    }
}