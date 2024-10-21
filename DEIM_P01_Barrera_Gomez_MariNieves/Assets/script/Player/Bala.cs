using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;

    [SerializeField] private float danio;


    private void Update()
    {
      transform.Translate(Vector2.down * velocidad * Time.deltaTime, Space.World);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("SI"+other.name);
        if (other.CompareTag("enemy"))
        {
            print("FUNCIONA");

            other.GetComponent<enemigo>().TomarDanio(danio);
            Destroy(gameObject);
        }
    }
}
