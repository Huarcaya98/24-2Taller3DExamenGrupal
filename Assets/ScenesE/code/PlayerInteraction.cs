using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
 
    public float interactionDistance = 3f; // Distancia para interactuar
    public string interactableTag = "Objetos"; // Tag de los objetos con los que se puede interactuar

    void Update()
    {
        // Buscar todos los objetos con el tag "Objetos"
        GameObject[] interactableObjects = GameObject.FindGameObjectsWithTag(interactableTag);

        foreach (GameObject obj in interactableObjects)
        {
            // Verifica la distancia entre el Player y cada objeto interactuable
            if (Vector3.Distance(transform.position, obj.transform.position) <= interactionDistance)
            {
                // Si la tecla E es presionada
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact(obj); // Pasa el objeto con el que se interactúa
                }
            }
        }
    }

    void Interact(GameObject objectToInteract)
    {
        // Destruye el objeto con el que estás interactuando
        Debug.Log("Interacción con el objeto " + objectToInteract.name + ". El objeto ha sido destruido.");
        Destroy(objectToInteract); // Destruye el objeto
    }
}

