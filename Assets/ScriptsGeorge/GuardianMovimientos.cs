using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianMovimientos : MonoBehaviour
{

    public Transform puntoA; // Referencia al punto A
    public Transform puntoB; // Referencia al punto B
    public Transform jugador; // Referencia al jugador
    public float velocidadPatrulla = 2f; // Velocidad del enemigo al patrullar
    public float velocidadPersecucion = 4f; // Velocidad del enemigo al perseguir
    public float rangoPersecucion = 5f; // Rango de detección para la persecución

    private Vector3 siguienteDestino; // Siguiente destino del enemigo
    private enum Estado { Dormido, Guardia, Persecucion }
    private Estado estadoActual = Estado.Guardia;

    void Start()
    {
        siguienteDestino = puntoA.position; // Comienza en el punto A
    }

    void Update()
    {
        switch (estadoActual)
        {
            case Estado.Dormido:
                // No hace nada, permanece quieto
                break;

            case Estado.Guardia:
                Patrullar();
                DetectarJugador();
                break;

            case Estado.Persecucion:
                PerseguirJugador();
                break;
        }
    }

    void Patrullar()
    {
        // Mueve el enemigo hacia el siguiente destino
        transform.position = Vector3.MoveTowards(transform.position, siguienteDestino, velocidadPatrulla * Time.deltaTime);

        // Cambia el destino cuando llega a A o B
        if (Vector3.Distance(transform.position, siguienteDestino) < 0.1f)
        {
            siguienteDestino = (siguienteDestino == puntoA.position) ? puntoB.position : puntoA.position;
        }
    }

    void DetectarJugador()
    {
        // Verifica si el jugador está dentro del rango de detección
        if (Vector3.Distance(transform.position, jugador.position) <= rangoPersecucion)
        {
            estadoActual = Estado.Persecucion; // Cambia al estado de persecución
        }
    }

    void PerseguirJugador()
    {
        // Mueve al enemigo hacia el jugador
        transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidadPersecucion * Time.deltaTime);

        // Comprueba si el jugador se aleja
        if (Vector3.Distance(transform.position, jugador.position) > rangoPersecucion)
        {
            estadoActual = Estado.Guardia; // Vuelve al estado de guardia
        }
    }

}
