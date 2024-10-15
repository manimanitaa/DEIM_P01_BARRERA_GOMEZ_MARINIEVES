using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;

    [SerializeField] public GameObject bala;

    [SerializeField] private float tiempoEntreDisparos;

    private float tiempoSiguienteDisparo;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")&& Time.time >= tiempoSiguienteDisparo)
        {
            //Disparar

            Disparar();
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
