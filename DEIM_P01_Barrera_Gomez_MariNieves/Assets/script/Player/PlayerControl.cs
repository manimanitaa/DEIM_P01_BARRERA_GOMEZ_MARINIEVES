using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System;
using Unity.VisualScripting;

public class PlayerControl : MonoBehaviour
{
    [Tooltip("Referencia a los datos de configuracion del personaje")]
    [SerializeField] private PlayerConfigData playerConfigData;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float FuerzaSalto;

    [SerializeField] private Animator animator;

    [Tooltip("Referencia al sprite renderer del personaje")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] public GameObject[] hearts;

    [Tooltip("tiempo máximo que el jugador puede mantener pulsado la tecla desalto")]
    [SerializeField] private float maxJumpTime;

    [SerializeField] private float distancia;
    [SerializeField] private Transform controladorSueloIzquierdo;
    [SerializeField] private Transform controladorSueloDerecho;
    [SerializeField] private LayerMask layerMaskSalto;

    [SerializeField] public TMPro.TextMeshProUGUI contadorBalas;

    public int CantidadBalas = 0;

    [Tooltip("fuerza caida del eprsonaje")]
    private float fallForce;

    public int vidas;

    private float jumptime;

    private bool jumping;

    public int saltosMaximos;
    private int saltosRestantes;

    public event EventHandler MuerteJugador;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("se ejecuta Stat");

        saltosRestantes = saltosMaximos;

        playerConfigData.MovementSpeed = 3;

        animator.runtimeAnimatorController = playerConfigData.animatorController;
    }


    private void FixedUpdate()
    {
        //vuelve el contador a su estilo normal
        contadorBalas.color = Color.Lerp(contadorBalas.color, Color.white, .1f);
        contadorBalas.fontSize = Mathf.Lerp(contadorBalas.fontSize, 72, .1f);

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.D))    //comprueba que esta pulsando la tecla "D"
        {
            rb.AddForce(Vector2.right * playerConfigData.MovementSpeed);   // añade fuerza hacia la drch

            spriteRenderer.flipX = true;     // gira al personaje cuando cambia de dirección
        }
        else if (Input.GetKey(KeyCode.A))    // comprueba que estas tocando la tecla "A"
        {
            rb.AddForce(Vector2.left * playerConfigData.MovementSpeed);    // añade fuerza hacia la izq

            spriteRenderer.flipX = false;     // gira al personaje cuando cambia de dirección
        }
        else
        {
            //print("funciona");
            //rigidbody.velocity.Set(0 , rigidbody.velocity.y);

            rb.velocity = new Vector2(0, rb.velocity.y);

            //rigidbody.velocity= Vector2.zero;
        }

        // EMPIEZA EL CODIGO DE SALTO
        if(Input.GetKeyDown(KeyCode.W)&& EstaEnAire()&& saltosRestantes > 0)
        {
            jumping = true;

            jumptime = 0;

            saltosRestantes = 0;

            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {           
            RaycastHit2D informacionSueloIzquierdo = Physics2D.Raycast(controladorSueloIzquierdo.position, Vector2.down, distancia, layerMaskSalto);
            RaycastHit2D informacionSueloDerecho = Physics2D.Raycast(controladorSueloDerecho.position, Vector2.down, distancia, layerMaskSalto);
            if ((informacionSueloIzquierdo == true)||(informacionSueloDerecho == true))
            {
                jumping = true;

                jumptime = 0;

                saltosRestantes = 1;

                Debug.Log("inicio del salto");
            }
        }

        if ((Input.GetKeyUp(KeyCode.W)) || (jumptime >= maxJumpTime))
        {

            // el personaje finaliza el salto
            jumping = false;
            Debug.Log("fin de salto");

        }

        if (jumping)
        {
            //rb.AddForce(Vector2.up * FuerzaSalto);

            rb.velocity = (Vector2.up * FuerzaSalto);

            jumptime += Time.deltaTime;
        }

        // TERMINA EL SALTO


        animator.SetBool("walking", rb.velocity.x != 0);

        if (rb.velocity.y < 0)    // el jugador esta cayendo
        {
            rb.AddForce(Vector2.down * fallForce);

            RaycastHit2D informacionSueloIzquierdo = Physics2D.Raycast(controladorSueloIzquierdo.position, Vector2.down, distancia, layerMaskSalto);
            RaycastHit2D informacionSueloDerecho = Physics2D.Raycast(controladorSueloDerecho.position, Vector2.down, distancia, layerMaskSalto);
            if ((informacionSueloIzquierdo == true)|| (informacionSueloDerecho == true))
            {
                saltosRestantes = 1;
            }
        }


        if (vidas == 0)
        {
            hearts[0].gameObject.SetActive(false);
            hearts[1].gameObject.SetActive(false);
            hearts[2].gameObject.SetActive(false);
        }

        if (vidas == 1)
        {
            hearts[0].gameObject.SetActive(true);
            hearts[1].gameObject.SetActive(false);
            hearts[2].gameObject.SetActive(false);
        }
        if (vidas == 2)
        {
            hearts[0].gameObject.SetActive(true);
            hearts[1].gameObject.SetActive(true);
            hearts[2].gameObject.SetActive(false);
        }
        if (vidas == 3)
        {
            hearts[0].gameObject.SetActive(true);
            hearts[1].gameObject.SetActive(true);
            hearts[2].gameObject.SetActive(true);
        }

        //MUESTRA LA CANTIDAD DE BALAS QUE TIENE EL JUGADOR 
        contadorBalas.text = CantidadBalas.ToString();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSueloIzquierdo.transform.position, controladorSueloIzquierdo.transform.position + Vector3.down * distancia);
        Gizmos.DrawLine(controladorSueloDerecho.transform.position, controladorSueloDerecho.transform.position + Vector3.down * distancia);
    }



    private bool EstaEnAire()
    {
        RaycastHit2D informacionSueloIzquierdo = Physics2D.Raycast(controladorSueloIzquierdo.position, Vector2.down, distancia, layerMaskSalto);
        RaycastHit2D informacionSueloDerecho = Physics2D.Raycast(controladorSueloDerecho.position, Vector2.down, distancia, layerMaskSalto);

        return (informacionSueloIzquierdo.collider == null)&&(informacionSueloDerecho.collider == null);
        
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            vidas -= 1;
        }

        if (collision.gameObject.CompareTag("curacion"))
        {
            //print("funciona");

            vidas += 1;
        }

        if (vidas == 0)
        {
            MuerteJugador.Invoke(this, EventArgs.Empty);
        }

        if (collision.gameObject.CompareTag("+Bala"))
        {
            Destroy(collision.gameObject);
            CantidadBalas += 8;

            contadorBalas.color = Color.green;
            contadorBalas.fontSize = 100;
        }

        if (collision.gameObject.CompareTag("CABEZA"))
        {
            Destroy(collision.transform.parent.gameObject);  // usando el transform accedo al enemigo en general
        }
    }

    

    
}
