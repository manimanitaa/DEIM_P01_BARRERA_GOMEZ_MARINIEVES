using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;

    [SerializeField] public GameObject bala;

    [SerializeField] private float tiempoEntreDisparos;

    [SerializeField] private PlayerControl playerControl;

    private float tiempoSiguienteDisparo;

    
      private void Update()
    {
        if (Input.GetButtonDown("Fire1")&& Time.time >= tiempoSiguienteDisparo)
        {
            //Disparar


            if (playerControl.CantidadBalas > 0) Disparar();
            else
            {
                //NO TIENE BALAS
                playerControl.contadorBalas.color = Color.red;
                playerControl.contadorBalas.fontSize = 72;
            }
            




                tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
        playerControl.CantidadBalas -= 1;
    }
}
