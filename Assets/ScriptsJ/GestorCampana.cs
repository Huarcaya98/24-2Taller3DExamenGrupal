using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorCampana : MonoBehaviour
{
    [SerializeField] private Campana[] campanas;
    [SerializeField] private GameObject areaOculta; // El área que se desbloquea
    [SerializeField] private float tiempoLimite = 30f; // Tiempo límite para completar el puzzle

    private int campanasActivadas = 0;
    private bool puzzleCompletado = false;

    void Start()
    {
        foreach (Campana campana in campanas)
        {
            campana.SetGestorJuego(this);
        }
    }

    public void ActivarCampana(Campana campana)
    {
        if (!puzzleCompletado)
        {
            campanasActivadas++;

            if (campanasActivadas == 1) // Primera campana activada inicia el temporizador
            {
                StartCoroutine(Temporizador());
            }

            if (campanasActivadas >= campanas.Length)
            {
                DesbloquearAreaOculta();
            }
        }
    }

    private IEnumerator Temporizador()
    {
        yield return new WaitForSeconds(tiempoLimite);

        if (!puzzleCompletado) // Si no se ha completado en el tiempo, reiniciar
        {
            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        Debug.Log("Tiempo agotado. Reiniciando el puzzle.");
        campanasActivadas = 0;

        foreach (Campana campana in campanas)
        {
            campana.Resetear();
        }
    }

    private void DesbloquearAreaOculta()
    {
        Debug.Log("¡Puzzle completado! Desbloqueando área oculta.");
        puzzleCompletado = true;
        areaOculta.SetActive(false); // Abre el área oculta
    }
}
