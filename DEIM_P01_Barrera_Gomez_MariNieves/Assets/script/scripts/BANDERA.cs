using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;



public class BANDERA : MonoBehaviour
{

    [SerializeField] private GameObject panel_win;


    private void Start()
    {
        panel_win.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            panel_win.SetActive(true);
        }

    }
}
