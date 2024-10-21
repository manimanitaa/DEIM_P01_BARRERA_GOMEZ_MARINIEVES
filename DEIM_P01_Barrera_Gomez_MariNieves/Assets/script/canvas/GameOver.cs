using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class GameOver : MonoBehaviour
{

    [SerializeField] private GameObject menuGameOver;

    private PlayerControl playerControl;

    private void Start()
    {
         playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        playerControl.MuerteJugador += ActivarMenu;

       menuGameOver.SetActive(false);

    }


    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }

    public void BotonStart()
    {
        SceneManager.LoadScene("Level01");
    }

    public void BotonSalir()
    {
        SceneManager.LoadScene("Inicio");
    }

    
}
