using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorCampana : MonoBehaviour
{
    [SerializeField] private Campana[] campanas;
    [SerializeField] private GameObject areaOculta; // El área que se desbloquea
    [SerializeField] private float tiempoLimite = 30f; // Tiempo límite para completar el puzzle
    
    [SerializeField] TextMeshProUGUI timerText;
    private float timer;
    private bool eventActive = false;

    private int campanasActivadas = 0;
    private bool puzzleCompletado = false;

    [SerializeField] private string escenaDerrota;

    void Awake()
    {
        timerText.gameObject.SetActive(false);

        foreach (Campana campana in campanas)
        {
            campana.SetGestorJuego(this);
        }
    }

    private void Update()
    {
        if (eventActive)
        {
            timer -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (timer <= tiempoLimite / 2 && timer > 10)
            {
                timerText.color = Color.yellow;
            }

            else if (timer <= 10 && timer > 0)
            {
                timerText.color = Color.red;
            }

            else if (timer <= 0)
            {
                timerText.gameObject.SetActive(false);
                SceneManager.LoadScene(escenaDerrota);
            }
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
        eventActive = true;
        timer = tiempoLimite;
        timerText.gameObject.SetActive(true);
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
        eventActive = false;
        timerText.gameObject.SetActive(false);
        Debug.Log("¡Puzzle completado! Desbloqueando área oculta.");
        puzzleCompletado = true;
        areaOculta.SetActive(false); // Abre el área oculta
    }
}
