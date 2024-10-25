using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausaUI; 
    private bool juegoPausado = false;

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        menuPausaUI.SetActive(false); 
        Time.timeScale = 1f; 
        juegoPausado = false;
    }

    void Pausar()
    {
        menuPausaUI.SetActive(true); 
        Time.timeScale = 0f; 
        juegoPausado = true;
    }

    public void CargarMenuPrincipal()
    {
        Time.timeScale = 1f; 
        //SceneManager.LoadScene("MenuPrincipal");
    }

    public void AbrirMenuOpciones()
    {
        //SceneManager.LoadScene("MenuDeOpciones");

    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); 
    }
}
