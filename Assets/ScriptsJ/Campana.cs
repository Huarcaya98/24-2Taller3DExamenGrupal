using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Campana : MonoBehaviour
{
    private GestorCampana gestorJuego;
    private bool activada = false;
    [SerializeField] private AudioSource fxSource;
    [SerializeField] private AudioClip clickSound;

    public void SetGestorJuego(GestorCampana gestor)
    {
        gestorJuego = gestor;
    }

    // Detecta el disparo de la bala
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala") && !activada)
        {
            fxSource.PlayOneShot(clickSound);
            activada = true;
            Debug.Log("Campana activada.");
            gestorJuego.ActivarCampana(this);
        }
    }

    private void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }

    public void Resetear()
    {
        activada = false;
        Debug.Log("Campana reseteada.");
    }
}
