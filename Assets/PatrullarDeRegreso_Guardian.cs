using System.Collections;
using UnityEngine;

public class PatrullarDeRegreso_Guardian : MonoBehaviour
{
    [SerializeField] Transform puntoDeRetorno;
    [SerializeField] float rapidezDeRetorno;
    [SerializeField] bool estaFuera = false;
    private bool estaDetenido = false;

    void Update()
    {
        if (!estaDetenido)
        {
            RegresarAlPuestoOriginal();
        }
    }

    void RegresarAlPuestoOriginal()
    {
        if (estaFuera)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                puntoDeRetorno.position, rapidezDeRetorno * Time.deltaTime);
        }
    }

    public void DetenerMovimiento()
    {
        estaDetenido = true;
    }

    public void ReanudarMovimiento()
    {
        estaDetenido = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            estaFuera = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bala"))
        {
            StartCoroutine(DetenerPorTiempo(2f));
        }
    }

    private IEnumerator DetenerPorTiempo(float tiempo)
    {
        DetenerMovimiento();
        yield return new WaitForSeconds(tiempo);
        ReanudarMovimiento();
    }
}
