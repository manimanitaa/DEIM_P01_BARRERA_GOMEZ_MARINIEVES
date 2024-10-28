using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLOQUES : MonoBehaviour
{

    public int vidas;


    private void Start()
    {
        vidas = 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            vidas -= 1;
            Destroy(collision.gameObject);
            if (vidas <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}

    

