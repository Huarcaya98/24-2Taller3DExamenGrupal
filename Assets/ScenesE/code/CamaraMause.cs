using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMause : MonoBehaviour
{
    public float sensibilidadHorizontal = 2f; // Sensibilidad del movimiento de la c�mara izquierda/derecha
    public float sensibilidadVertical = 1f;   // Sensibilidad del movimiento de la c�mara arriba/abajo
    public float limiteVertical = 30f;        // L�mite del �ngulo hacia arriba/abajo
    private float rotacionVertical = 0f;

    void Update()
    {
        // Obtener el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadHorizontal;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadVertical;

        // Rotar la c�mara a la izquierda y derecha sin l�mites
        transform.Rotate(0, mouseX, 0);

        // Limitar el movimiento hacia arriba y abajo
        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -limiteVertical, limiteVertical);

        // Aplicar la rotaci�n vertical con el l�mite establecido
        transform.localRotation = Quaternion.Euler(rotacionVertical, transform.localRotation.eulerAngles.y, 0);
    }
}
