using UnityEngine;
using UnityEngine.AI;

public class GuardianRegresarPuesto : MonoBehaviour
{
    
    private NavMeshAgent guardianAgente;
    [SerializeField] Transform puntoDeRetorno;
    [SerializeField] bool estaFuera = false;

    [SerializeField] float tiempoParaRotar = 2f; // Tiempo total en segundos para llegar a 0 grados.
    private float velocidadRotacion;
    private Quaternion rotacionFinal;
    private bool estaRegresando = false;

    void Start()
    {
        guardianAgente = GetComponent<NavMeshAgent>();
        rotacionFinal = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        if (estaFuera)
        {
            Regresar();
        }

        // Verifica si ha llegado al punto de retorno y, si es así, inicia la rotación.
        if (estaRegresando && !guardianAgente.pathPending && guardianAgente.remainingDistance <= guardianAgente.stoppingDistance)
        {
            RotarHaciaCeroGrados();
        }
    }

    public void Regresar()
    {
        guardianAgente.SetDestination(puntoDeRetorno.position);
        estaRegresando = true;
    }

    private void RotarHaciaCeroGrados()
    {
        
        velocidadRotacion = 90f / tiempoParaRotar; 

        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionFinal, velocidadRotacion * Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, rotacionFinal) < 0.1f)
        {
            estaFuera = false;
            estaRegresando = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            estaFuera = true;
        }
    }
}
