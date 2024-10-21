using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float speed;

    [SerializeField] private float FuerzaSalto;

    [SerializeField] private Animator animator;

    [Tooltip("Referencia al sprite renderer del personaje")] 
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] public GameObject[]hearts;

    [Tooltip("tiwmpo máximoq ue el jugador puede mantener pulsado la tecla desalto")]
    [SerializeField] private float maxJumpTime;

    [Tooltip("fuerza caida del eprsonaje")]
    private float fallForce;

    public int vidas;

    private float jumptime;

    private bool jumping;

    public event EventHandler MuerteJugador;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("se ejecuta Stat");
    }

    // Update is called once per frame
   
    void Update()
    {
        if (Input.GetKey(KeyCode.D))    //comprueba que esta pulsando la tecla "D"
        {
            rb.AddForce(Vector2.right * speed);   // añade fuerza hacia la drch

            spriteRenderer.flipX = true;     // gira al personaje cuando cambia de dirección
        }
        else if (Input.GetKey(KeyCode.A))    // comprueba que estas tocando la tecla "A"
        {
            rb.AddForce(Vector2.left * speed);    // añade fuerza hacia la izq

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            // el personaje inicia el salto
            jumping = true;

            jumptime = 0;

            Debug.Log("inicio del salto");

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

        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector2.down * fallForce);
        }


        if ( vidas < 1)
        {
            hearts[0].gameObject.SetActive(false);
        }

        if (vidas < 2)
        {
            hearts[1].gameObject.SetActive(false);
        }

        if (vidas < 3)
        {
            hearts[2].gameObject.SetActive(false);
        }

        MuerteJugador? . Invoke (this, EventArgs.Empty);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("enemy"))

            vidas -= 1;

        if (vidas == 0)
        {
            vidas = 3;

            hearts[0].gameObject.SetActive(true);
            hearts[1].gameObject.SetActive(true);
            hearts[2].gameObject.SetActive(true);
        }

    }

}
