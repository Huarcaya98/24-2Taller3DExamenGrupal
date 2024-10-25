using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float velocidad = 5f; // Velocidad de movimiento del jugador
    private Rigidbody rb; // Referencia al Rigidbody del jugador

    void Start()
    {
        // Obtiene el componente Rigidbody al iniciar el script
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Captura la entrada de movimiento en los ejes horizontal y vertical
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcula el vector de movimiento en el plano XZ
        Vector3 movimiento = transform.right * movimientoHorizontal + transform.forward * movimientoVertical;
        movimiento *= velocidad;

        // Mueve al jugador aplicando una velocidad directamente al Rigidbody
        rb.velocity = new Vector3(movimiento.x, rb.velocity.y, movimiento.z); // Preserva la velocidad en Y (gravedad)
    }

}
