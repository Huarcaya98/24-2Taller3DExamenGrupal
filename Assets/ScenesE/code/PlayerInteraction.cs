using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
 
    public float interactionDistance = 3f;
    public string interactableTag = "Objetos"; 

    void Update()
    {
     
        GameObject[] interactableObjects = GameObject.FindGameObjectsWithTag(interactableTag);

        foreach (GameObject obj in interactableObjects)
        {
            
            if (Vector3.Distance(transform.position, obj.transform.position) <= interactionDistance)
            {
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact(obj); 
                }
            }
        }
    }

    void Interact(GameObject objectToInteract)
    {
        Debug.Log("Interacción con el objeto " + objectToInteract.name + ". El objeto ha sido destruido.");
        Destroy(objectToInteract);
    }
}

