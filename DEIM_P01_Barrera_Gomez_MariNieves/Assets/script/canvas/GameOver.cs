using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Gestor = GestionEscenas.SceneManager;


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
        Time.timeScale = 0f;
    }

    public void BotonStart()
    {
        Gestor.LoadScene("Level01");
    }

    public void BotonInicio()
    {
        Gestor.LoadScene("inicio");
    }


}
