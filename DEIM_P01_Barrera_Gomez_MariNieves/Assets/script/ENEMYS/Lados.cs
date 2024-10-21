using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lados : MonoBehaviour
{
    [SerializeField] private float vida;

    [SerializeField] GameObject moneda;

    [SerializeField] private float velocidad;

    [SerializeField] private Transform controladorSuelo;

    [SerializeField] private float distancia;

    private bool movimientoDerecha;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }


     public void TomarDanio(float danio)
    {

        vida -= danio;
        if (vida <= 0)
        {
            Muerte();
        }

    }

    private void Muerte()
    {
        Instantiate(moneda, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);  

        rb.velocity = new Vector2 (velocidad, rb.velocity.y);

        if (informacionSuelo == false )
        {
            Girar();
        }
    }

    private void Girar()
    {
        movimientoDerecha =! movimientoDerecha;

        transform.eulerAngles = new Vector3 (0,transform.eulerAngles.y + 180,0);

        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position+Vector3.down*distancia);
    }

   
}
