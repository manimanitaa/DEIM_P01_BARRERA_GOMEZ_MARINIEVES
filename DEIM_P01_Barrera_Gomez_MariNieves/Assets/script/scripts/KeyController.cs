using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        print("frunciona");
        if (collision.gameObject.CompareTag("Player"))

        {
            Destroy(gameObject);
        }
    }

}
