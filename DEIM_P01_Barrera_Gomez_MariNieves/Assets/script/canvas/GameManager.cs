using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Gestor = GestionEscenas.SceneManager;

public class GameManager : MonoBehaviour
{
    private string sceneToLoad;
    public bool enPausa;
    public GameObject panelPausa;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PanelPausa();

       
    }

    public void BotonContinuar()
    {
        Time.timeScale = 1.0f;
        panelPausa.SetActive(false);
    }

    public void BotonSalir()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void PanelPausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enPausa == false)
            {
                panelPausa.SetActive(true);
                enPausa = true;
            }
            else
            {
                panelPausa.SetActive(false);
                enPausa = false;
            }
        }
    }

    public void BotonStart()
    {
        Gestor.LoadScene("Level01");
    }
}
