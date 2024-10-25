using System.Collections;
using UnityEngine;

public class GuardianAtacar : MonoBehaviour
{
    [SerializeField] float tiempoDeAtaque = 1.5f; 
    private bool estaAtacando = false;
    private PatrullarDeRegreso_Guardian patrullarScript;

    void Start()
    {
        patrullarScript = GetComponent<PatrullarDeRegreso_Guardian>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador") && !estaAtacando)
        {
            StartCoroutine(AtacarJugador());
        }
    }

    private IEnumerator AtacarJugador()
    {
        estaAtacando = true;

        
        patrullarScript.DetenerMovimiento();
        Debug.Log("El guardián está atacando al jugador");
        yield return new WaitForSeconds(tiempoDeAtaque);

        patrullarScript.ReanudarMovimiento();
        estaAtacando = false;
      
    }
}
