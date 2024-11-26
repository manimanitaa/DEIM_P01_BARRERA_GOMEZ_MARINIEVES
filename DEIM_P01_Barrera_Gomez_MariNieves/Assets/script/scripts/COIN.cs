using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class COIN : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;

    [SerializeField] private SistemaPuntos sistemaPuntos;

    [SerializeField] private Rigidbody2D rb;

    public float fuerzaSalto = 1f;

    public float fuerzaIzquierda = -2f; 
    public float fuerzaDerecha = 2f;




    private void Start()
    {
        sistemaPuntos = GameObject.Find("SistemaPuntos").GetComponent<SistemaPuntos>();

        float impulsoX = Random.Range(fuerzaIzquierda, fuerzaDerecha);  
        float impulsoY = Random.Range(fuerzaSalto, fuerzaSalto + 1f); 

        // Aplicar la fuerza en la dirección deseada
        rb.AddForce(new Vector2(impulsoX, impulsoY), ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sistemaPuntos.SumarPuntos(cantidadPuntos);
            
            Destroy(gameObject);
        }
    }
}
