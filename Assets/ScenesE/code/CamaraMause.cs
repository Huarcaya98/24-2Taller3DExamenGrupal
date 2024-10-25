using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMause : MonoBehaviour
{
    public float sensibilidadHorizontal = 2f; // Sensibilidad del movimiento de la cámara izquierda/derecha
    public float sensibilidadVertical = 1f;   // Sensibilidad del movimiento de la cámara arriba/abajo
    public float limiteVertical = 30f;        // Límite del ángulo hacia arriba/abajo
    private float rotacionVertical = 0f;

    void Update()
    {
        // Obtener el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadHorizontal;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadVertical;

        // Rotar la cámara a la izquierda y derecha sin límites
        transform.Rotate(0, mouseX, 0);

        // Limitar el movimiento hacia arriba y abajo
        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -limiteVertical, limiteVertical);

        // Aplicar la rotación vertical con el límite establecido
        transform.localRotation = Quaternion.Euler(rotacionVertical, transform.localRotation.eulerAngles.y, 0);
    }
}
