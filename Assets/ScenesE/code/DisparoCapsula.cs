using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoCapsula : MonoBehaviour
{
    public GameObject proyectilPrefab; 
    public Transform puntoDeDisparo;   
    public float velocidadDisparo = 20f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);

        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = puntoDeDisparo.forward * velocidadDisparo;
        }
    }
}
