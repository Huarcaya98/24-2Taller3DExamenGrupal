using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntorchaNivel2 : MonoBehaviour
{
    private GestorAntorcha gestorJuego;
    private bool encendida = false;

    public void SetGestorJuego(GestorAntorcha gestor)
    {
        gestorJuego = gestor;
    }

    // Método para interactuar con la antorcha y encenderla
    public void Encender()
    {
        if (!encendida)
        {
            encendida = true;
            Debug.Log("Antorcha encendida.");
            gestorJuego.EncenderAntorcha(this); // Informa al gestor que la antorcha ha sido encendida
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) // Por ejemplo, el jugador presiona 'E' para encender
        {
            Encender();
        }
    }
}
