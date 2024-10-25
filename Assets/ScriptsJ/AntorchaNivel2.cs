using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AntorchaNivel2 : MonoBehaviour
{
    private GestorAntorcha gestorJuego;
    private bool encendida = false;
    [SerializeField] private AudioSource fxSource;
    [SerializeField] private AudioClip clickSound;

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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala") && Input.GetKeyDown(KeyCode.E)) // Por ejemplo, el jugador presiona 'E' para encender
        {
            fxSource.PlayOneShot(clickSound);
            Encender();
        }
    }

    private void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }
}
