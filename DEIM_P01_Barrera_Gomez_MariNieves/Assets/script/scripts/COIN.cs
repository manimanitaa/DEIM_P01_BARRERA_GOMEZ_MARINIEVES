using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class COIN : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;

    [SerializeField] private SistemaPuntos sistemaPuntos;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            sistemaPuntos.SumarPuntos(cantidadPuntos);
            
            Destroy(gameObject);
        }
    }
}
