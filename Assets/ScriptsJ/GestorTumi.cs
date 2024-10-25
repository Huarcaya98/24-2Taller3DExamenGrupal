using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorTumi : MonoBehaviour
{
    public static GestorTumi instancia;
    public bool JugadorTieneTumi { get; set; } // Indica si el jugador tiene el Tumi

    [SerializeField] private string escenaVictoriaConTumi;
    [SerializeField] private string escenaVictoriaSinTumi;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Mantiene el GameManager entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ComprobarVictoria()
    {
        if (JugadorTieneTumi)
        {
            Debug.Log("¡Victoria con Tumi!");
            SceneManager.LoadScene(escenaVictoriaConTumi);
        }
        else
        {
            Debug.Log("Victoria sin Tumi.");
            SceneManager.LoadScene(escenaVictoriaSinTumi);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bala"))
        {
            ComprobarVictoria();
        }
    }
}
