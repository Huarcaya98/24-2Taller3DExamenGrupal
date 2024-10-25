using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorAntorcha : MonoBehaviour
{
    [SerializeField] private GameObject puerta; // La puerta que se abrirá
    [SerializeField] private AntorchaNivel2[] antorchas; // Array de las antorchas
    [SerializeField] private string escenaDerrota = "Derrota"; // Nombre de la escena de derrota

    private int indiceAntorchaActual = 0; // Controla el índice de la antorcha actual

    void Start()
    {
        // Inicializamos todas las antorchas
        foreach (AntorchaNivel2 antorcha in antorchas)
        {
            antorcha.SetGestorJuego(this);
        }
    }

    // Este método se llamará cuando el jugador encienda una antorcha
    public void EncenderAntorcha(AntorchaNivel2 antorcha)
    {
        if (antorcha == antorchas[indiceAntorchaActual])
        {
            indiceAntorchaActual++; // Avanza al siguiente paso del puzzle
            if (indiceAntorchaActual >= antorchas.Length)
            {
                AbrirPuerta();
            }
        }
        else
        {
            EscenaDerrota();
        }
    }

    private void AbrirPuerta()
    {
        Debug.Log("¡Puzzle completado! Abriendo puerta.");
        puerta.SetActive(false); // Desactiva la puerta para abrirla
    }

    private void EscenaDerrota()
    {
        Debug.Log("Orden incorrecto. Fin del juego.");
        SceneManager.LoadScene(escenaDerrota); // Carga la escena de derrota
    }
}
