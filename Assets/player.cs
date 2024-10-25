using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadCaminar = 5f;
    [SerializeField] private float velocidadCorrer = 10f;
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float escalaAgachar = 0.5f;
    [SerializeField] private Transform camaraJugador; // La cámara sigue la orientación del jugador

    private bool enSuelo = false; // Saber si el jugador está en el suelo
    private Rigidbody rb;
    private Vector3 escalaOriginal;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        escalaOriginal = transform.localScale; // Guardamos la escala original del jugador
    }

    void Update()
    {
        Movimiento();
        Saltar();
        Agachar();
    }

    // Movimiento del jugador (caminar/correr)
    void Movimiento()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector3 direccion = transform.forward * movimientoVertical + transform.right * movimientoHorizontal;
        Vector3 velocidad = Vector3.zero;

        // Correr al mantener presionada la tecla de correr (Shift)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidad = direccion * velocidadCorrer;
        }
        else
        {
            velocidad = direccion * velocidadCaminar;
        }

        // Mantener la velocidad en Y para que no afecte la gravedad
        velocidad.y = rb.velocity.y;
        rb.velocity = velocidad;
    }

    // Saltar
    void Saltar()
    {
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }
    }

    // Agacharse
    void Agachar()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.C))
        {
            // Reducir la escala para agacharse
            transform.localScale = new Vector3(escalaOriginal.x, escalaAgachar, escalaOriginal.z);
        }
        else
        {
            // Volver a la escala original
            transform.localScale = escalaOriginal;
        }
    }

    // Detectar si el jugador está en el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true; // Solo puede saltar si está en el suelo
        }
    }
    public bool EstaEnSuelo()
    {
        return enSuelo;
    }
}