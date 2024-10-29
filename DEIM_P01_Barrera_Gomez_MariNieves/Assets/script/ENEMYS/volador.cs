using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volador : MonoBehaviour
{

    [SerializeField] private float velocidad;

    [SerializeField] private Transform controladorSuelo;

    [SerializeField] private float distancia;

    [SerializeField] private LayerMask layerMaskMovimiento;

    private bool movimientoDerecha = true;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo;
        
        if (movimientoDerecha)
        {
            informacionSuelo= Physics2D.Raycast(controladorSuelo.position, Vector2.right, distancia,layerMaskMovimiento);

        }
        else
        {
            informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.left, distancia,layerMaskMovimiento);
        }


        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if (informacionSuelo == true)
        {
            Girar();
        }
    }

    private void Girar()
    {
        movimientoDerecha = !movimientoDerecha;

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;


        if (movimientoDerecha)
        {
            Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.right * distancia);
        }
        else
        {
            Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.left * distancia);
        }
       
    }



}
