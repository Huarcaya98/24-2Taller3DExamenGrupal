using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMause : MonoBehaviour
{
    public float sensibilidadHorizontal = 2f; 
    public float sensibilidadVertical = 1f;   
    public float limiteVertical = 30f;        
    private float rotacionVertical = 0f;

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadHorizontal;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadVertical;

        
        transform.Rotate(0, mouseX, 0);

        
        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -limiteVertical, limiteVertical);

        
        transform.localRotation = Quaternion.Euler(rotacionVertical, transform.localRotation.eulerAngles.y, 0);
    }
}
