using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;

    [SerializeField] private float speed;

    [SerializeField] private float FuerzaSalto;

    [SerializeField] private Animator animator;

    [Tooltip("Referencia al sprite renderer del personaje")] 
    [SerializeField] private SpriteRenderer spriteRenderer;

    public int vidas;
    [SerializeField] public GameObject[]hearts;

    [Tooltip("fuerza caida del eprsonaje")] private float fallForce;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("se ejecuta Stat");

    }

    // Update is called once per frame
   
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector2.right * speed);

            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(Vector2.left * speed);

            spriteRenderer.flipX = false;
        }
        else 
        {
            print("funciona");
            //rigidbody.velocity.Set(0 , rigidbody.velocity.y);

            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);

            //rigidbody.velocity= Vector2.zero;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.AddForce(Vector2.up * FuerzaSalto);
        }

        animator.SetBool("walking", rigidbody.velocity.x != 0);

        if (rigidbody.velocity.y < 0)
        {
            rigidbody.AddForce(Vector2.down * fallForce);
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
