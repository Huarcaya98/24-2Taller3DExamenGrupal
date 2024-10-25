using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento8Direcciones : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento del personaje
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        // Obtener entrada de las teclas de movimiento (WASD o flechas)
        float movimientoHorizontal = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha
        float movimientoVertical = Input.GetAxis("Vertical"); // W/S o flechas arriba/abajo

        // Crear un vector de movimiento basado en la entrada del jugador
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical).normalized;

        // Mover al personaje usando el Rigidbody
        rb.MovePosition(transform.position + movimiento * velocidadMovimiento * Time.deltaTime);
    }

}
