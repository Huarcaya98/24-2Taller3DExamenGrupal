using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campana : MonoBehaviour
{
    private GestorCampana gestorJuego;
    private bool activada = false;

    public void SetGestorJuego(GestorCampana gestor)
    {
        gestorJuego = gestor;
    }

    // Detecta el disparo de la bala
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala") && !activada)
        {
            activada = true;
            Debug.Log("Campana activada.");
            gestorJuego.ActivarCampana(this);
        }
    }

    public void Resetear()
    {
        activada = false;
        Debug.Log("Campana reseteada.");
    }
}
