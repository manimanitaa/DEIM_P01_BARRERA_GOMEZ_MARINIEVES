using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambio_camara : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera camara;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            camara.Priority = 30;

        }
    }
}
