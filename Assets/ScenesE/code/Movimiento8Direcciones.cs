using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento8Direcciones : MonoBehaviour
{
    public float velocidadMovimiento = 5f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        
        float movimientoHorizontal = Input.GetAxis("Horizontal"); 
        float movimientoVertical = Input.GetAxis("Vertical");

        
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical).normalized;

        rb.MovePosition(transform.position + movimiento * velocidadMovimiento * Time.deltaTime);
    }

}
