using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoCapsula : MonoBehaviour
{
    public GameObject proyectilPrefab; // Prefab del proyectil
    public Transform puntoDeDisparo;   // Punto desde donde se disparar� el proyectil
    public float velocidadDisparo = 20f;

    void Update()
    {
        // Dispara cuando se presiona la tecla "Espacio"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Crear el proyectil en la posici�n del punto de disparo
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);

        // Asignar velocidad al proyectil en la direcci�n en que apunta la c�psula
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = puntoDeDisparo.forward * velocidadDisparo;
        }
    }
}
